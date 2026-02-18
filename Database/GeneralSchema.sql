-- VoC Database Schema
-- Standard: PostgreSQL
-- Timezone: UTC (TIMESTAMPTZ)

-- Enable UUID extension
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- ==========================================
-- Core VoC Tables
-- ==========================================

-- 1. Users Table
CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    surname VARCHAR(255) NOT NULL,
    role VARCHAR(50) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash TEXT NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 2. Brands Table
CREATE TABLE IF NOT EXISTS brands (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    name VARCHAR(255) NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 3. Brand Feeder Table
CREATE TABLE IF NOT EXISTS brand_feeder (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    user_id UUID NOT NULL REFERENCES users(id) ON DELETE CASCADE,
    brand_id UUID NOT NULL REFERENCES brands(id) ON DELETE CASCADE,
    lat DECIMAL(10, 8) NOT NULL,
    long DECIMAL(11, 8) NOT NULL,
    competition_brand_ids JSONB DEFAULT '[]'::jsonb,
    
    -- Status and Retries
    yemeksepeti_status BOOLEAN NOT NULL DEFAULT FALSE,
    yemeksepeti_retry_count INT NOT NULL DEFAULT 0,
    
    trendyol_status BOOLEAN NOT NULL DEFAULT FALSE,
    trendyol_retry_count INT NOT NULL DEFAULT 0,
    
    getir_status BOOLEAN NOT NULL DEFAULT FALSE,
    getir_retry_count INT NOT NULL DEFAULT 0,
    
    migros_status BOOLEAN NOT NULL DEFAULT FALSE,
    migros_retry_count INT NOT NULL DEFAULT 0,
    
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- ==========================================
-- Utilities (Indices, Triggers)
-- ==========================================

CREATE INDEX IF NOT EXISTS idx_brand_feeder_brand_id ON brand_feeder(brand_id);
CREATE INDEX IF NOT EXISTS idx_brand_feeder_user_id ON brand_feeder(user_id);

-- Updated at trigger function
CREATE OR REPLACE FUNCTION update_updated_at_column()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at = CURRENT_TIMESTAMP;
    RETURN NEW;
END;
$$ language 'plpgsql';

CREATE TRIGGER update_users_updated_at BEFORE UPDATE ON users FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
CREATE TRIGGER update_brands_updated_at BEFORE UPDATE ON brands FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
CREATE TRIGGER update_brand_feeder_updated_at BEFORE UPDATE ON brand_feeder FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();

-- ==========================================
-- Yemeksepeti Specific Tables (Listing & Autocomplete)
-- ==========================================

-- 4. Yemeksepeti Listing Results
CREATE TABLE IF NOT EXISTS ys_listing (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    brand_feeder_id UUID NOT NULL REFERENCES brand_feeder(id) ON DELETE CASCADE,
    vendor_code VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    url_key VARCHAR(255),
    rating_value DECIMAL(3, 2),
    rating_count INT DEFAULT 0,
    distance_meters INT,
    delivery_fee DECIMAL(10, 2),
    min_order_value DECIMAL(10, 2),
    is_open BOOLEAN DEFAULT TRUE,
    delivery_time_min INT,
    delivery_time_max INT,
    raw_data JSONB, -- Store full VendorDataEntity response
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 5. Yemeksepeti Autocomplete Suggestions
CREATE TABLE IF NOT EXISTS ys_autocomplete (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    brand_feeder_id UUID NOT NULL REFERENCES brand_feeder(id) ON DELETE CASCADE,
    keyword VARCHAR(255) NOT NULL,
    suggestion_type VARCHAR(100),
    tracking_code VARCHAR(255),
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS idx_ys_listing_feeder ON ys_listing(brand_feeder_id);
CREATE INDEX IF NOT EXISTS idx_ys_autocomplete_feeder ON ys_autocomplete(brand_feeder_id);

-- ==========================================
-- Yemeksepeti Detailed Restaurant Data
-- ==========================================

-- 6. Yemeksepeti Detailed Restaurants
CREATE TABLE IF NOT EXISTS ys_restaurants_details (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    brand_feeder_id UUID NOT NULL REFERENCES brand_feeder(id) ON DELETE CASCADE,
    ys_id VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    phone VARCHAR(50),
    address TEXT,
    description TEXT,
    url_key VARCHAR(255),
    web_url TEXT,
    logo_url TEXT,
    hero_image_url TEXT,
    latitude DECIMAL(10, 8),
    longitude DECIMAL(11, 8),
    distance DECIMAL(10, 2),
    is_active BOOLEAN DEFAULT TRUE,
    is_premium BOOLEAN DEFAULT FALSE,
    minimum_order_amount DECIMAL(10, 2),
    budget_level INT,
    service_fee DECIMAL(10, 2),
    review_number INT DEFAULT 0,
    review_with_comment_number INT DEFAULT 0,
    vertical_info JSONB, -- {vertical, segment, parent}
    metadata JSONB, -- {is_delivery_available, is_pickup_available, timezone, etc}
    raw_data JSONB,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 7. Yemeksepeti Menus
CREATE TABLE IF NOT EXISTS ys_menus (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    restaurant_details_id UUID NOT NULL REFERENCES ys_restaurants_details(id) ON DELETE CASCADE,
    ys_menu_id INT,
    name VARCHAR(255) NOT NULL,
    menu_type VARCHAR(100),
    opening_time TIME,
    closing_time TIME,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 8. Yemeksepeti Categories
CREATE TABLE IF NOT EXISTS ys_categories (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    menu_id UUID NOT NULL REFERENCES ys_menus(id) ON DELETE CASCADE,
    ys_category_id INT,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    is_popular BOOLEAN DEFAULT FALSE,
    partner_info JSONB, -- {id, code, title}
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 9. Yemeksepeti Products
CREATE TABLE IF NOT EXISTS ys_products (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    category_id UUID NOT NULL REFERENCES ys_categories(id) ON DELETE CASCADE,
    ys_product_id INT,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL,
    image_url TEXT,
    is_sold_out BOOLEAN DEFAULT FALSE,
    is_alcoholic BOOLEAN DEFAULT FALSE,
    is_bundle BOOLEAN DEFAULT FALSE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 10. Yemeksepeti Product Variations
CREATE TABLE IF NOT EXISTS ys_product_variations (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    product_id UUID NOT NULL REFERENCES ys_products(id) ON DELETE CASCADE,
    ys_variation_id INT,
    name VARCHAR(255),
    price DECIMAL(10, 2) NOT NULL,
    container_price DECIMAL(10, 2),
    topping_ids JSONB, -- Array of IDs
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- 11. Yemeksepeti Detailed Reviews
CREATE TABLE IF NOT EXISTS ys_reviews_details (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    restaurant_details_id UUID NOT NULL REFERENCES ys_restaurants_details(id) ON DELETE CASCADE,
    user_name VARCHAR(255),
    comment TEXT,
    rating_total INT,
    rating_flavor INT,
    rating_service INT,
    rating_speed INT,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Indices
CREATE INDEX IF NOT EXISTS idx_ys_restaurants_details_feeder ON ys_restaurants_details(brand_feeder_id);
CREATE INDEX IF NOT EXISTS idx_ys_menus_restaurant ON ys_menus(restaurant_details_id);
CREATE INDEX IF NOT EXISTS idx_ys_categories_menu ON ys_categories(menu_id);
CREATE INDEX IF NOT EXISTS idx_ys_products_category ON ys_products(category_id);
CREATE INDEX IF NOT EXISTS idx_ys_variations_product ON ys_product_variations(product_id);
CREATE INDEX IF NOT EXISTS idx_ys_reviews_details_restaurant ON ys_reviews_details(restaurant_details_id);

-- Triggers for updated_at
CREATE TRIGGER update_ys_restaurants_details_updated_at BEFORE UPDATE ON ys_restaurants_details FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
CREATE TRIGGER update_ys_menus_updated_at BEFORE UPDATE ON ys_menus FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
CREATE TRIGGER update_ys_categories_updated_at BEFORE UPDATE ON ys_categories FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
CREATE TRIGGER update_ys_products_updated_at BEFORE UPDATE ON ys_products FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
CREATE TRIGGER update_ys_product_variations_updated_at BEFORE UPDATE ON ys_product_variations FOR EACH ROW EXECUTE PROCEDURE update_updated_at_column();
