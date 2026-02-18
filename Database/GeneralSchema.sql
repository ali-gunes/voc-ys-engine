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
