-- VoC Common Database Queries

-- 1. Insert a New User
INSERT INTO users (name, surname, role, email, password_hash)
VALUES ('John', 'Doe', 'admin', 'john@example.com', 'hashed_password_here')
ON CONFLICT (email) DO NOTHING;

-- 2. Insert a New Brand
INSERT INTO brands (name)
VALUES ('Burger King')
RETURNING id;

-- 3. Logic: Save Brand Feeder request if not already requested today
-- Note: Logic is handled in the app/job as requested.
-- This query returns the feeder record if it exists for today.
SELECT id
FROM brand_feeder
WHERE brand_id = 'YOUR_BRAND_UUID'
  AND created_at::DATE = CURRENT_DATE
LIMIT 1;

-- 4. Scraper Job: Find pending Yemeksepeti tasks for today
SELECT bf.id, bf.lat, bf.long, b.name as brand_name, bf.competition_brand_ids
FROM brand_feeder bf
JOIN brands b ON bf.brand_id = b.id
WHERE bf.yemeksepeti_status = FALSE
  AND bf.yemeksepeti_retry_count < 3
  AND bf.created_at::DATE = CURRENT_DATE;

-- 5. Mark Yemeksepeti scrape as successful
UPDATE brand_feeder
SET yemeksepeti_status = TRUE,
    updated_at = CURRENT_TIMESTAMP
WHERE id = 'YOUR_FEEDER_UUID';

-- 6. Increment Retry Count on Failure
UPDATE brand_feeder
SET yemeksepeti_retry_count = yemeksepeti_retry_count + 1,
    updated_at = CURRENT_TIMESTAMP
WHERE id = 'YOUR_FEEDER_UUID';

-- 7. Get all channels status for a specific feeder request
SELECT 
    yemeksepeti_status, 
    trendyol_status, 
    getir_status, 
    migros_status
FROM brand_feeder
WHERE id = 'YOUR_FEEDER_UUID';

-- 8. Save Yemeksepeti Listing Result
INSERT INTO ys_listing (brand_feeder_id, vendor_code, name, rating_value, is_open, raw_data)
VALUES ('YOUR_FEEDER_UUID', 'y30u', 'Köfteci Yusuf', 4.5, TRUE, '{"full": "json"}');

-- 9. Save Highly Detailed Restaurant Info
INSERT INTO ys_restaurants_details (brand_feeder_id, ys_id, name, address, latitude, longitude, vertical_info)
VALUES ('YOUR_FEEDER_UUID', 'y30u', 'Köfteci Yusuf', 'Istanbul...', 41.0, 28.0, '{"vertical": "Restaurant"}')
RETURNING id;

-- 10. Get Menu Hierarchy for a Restaurant
SELECT m.name as menu, c.name as category, p.name as product, p.price
FROM ys_restaurants_details rd
JOIN ys_menus m ON rd.id = m.restaurant_details_id
JOIN ys_categories c ON m.id = c.menu_id
JOIN ys_products p ON c.id = p.category_id
WHERE rd.ys_id = 'y30u'
ORDER BY m.name, c.name;

