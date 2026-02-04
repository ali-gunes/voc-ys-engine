export interface YemeksepetiVendorResponse {
    status_code: number;
    data: Data;
}

export interface Data {
    chain?: Chain;
    city?: City;
    customer_phone?: string;
    id: number;
    name: string;
    code: string;
    address: string;
    budget?: number;
    deals?: Deal[];
    cuisines?: Cuisine[];
    delivery_duration_range?: DeliveryDurationRange;
    pickup_duration_range?: number;
    delivery_fee_source?: string;
    description?: string;
    distance?: number;
    experiments?: Experiment[];
    favorite?: string;
    has_delivery_provider?: boolean;
    is_active?: boolean;
    is_delivery_enabled?: boolean;
    is_pickup_enabled?: boolean;
    is_premium?: boolean;
    is_preorder_enabled?: boolean;
    is_promoted?: boolean;
    is_test?: boolean;
    is_vat_disabled?: boolean;
    is_vat_included_in_product_price?: boolean;
    is_vat_visible?: boolean;
    is_vat_included?: boolean;
    is_voucher_enabled?: boolean;
    is_super_vendor?: boolean;
    latitude?: number;
    longitude?: number;
    location?: string;
    location_event?: string;
    logo?: string;
    hero_image?: string;
    hero_listing_image?: string;
    loyalty_percentage_amount?: number;
    loyalty_program_enabled?: boolean;
    minimum_delivery_fee?: number;
    minimum_delivery_time?: number;
    minimum_order_amount?: number;
    minimum_pickup_time?: number;
    original_delivery_fee?: number;
    topic_ratings?: TopicRating[];
    review_number?: number;
    review_with_comment_number?: number;
    schedules?: Schedule[];
    service_fee?: number;
    service_fee_percentage_amount?: number;
    tag?: string;
    tags?: Tag[];
    trade_register_number?: string;
    url_key?: string;
    characteristics?: Characteristics;
    vendor_legal_information?: VendorLegalInformation;
    vertical?: string;
    vertical_segment?: string;
    vertical_parent?: string;
    web_path?: string;
    is_partner_cashback_disabled?: boolean;
    other_vendors_in_chain?: number;
    menus?: Menu[];
    metadata?: Metadata;
}

export interface Menu {
    ab_sorting_applied?: boolean;
    id: number;
    name: string;
    type?: string;
    opening_time?: string;
    closing_time?: string;
    menu_categories?: MenuCategory[];
}

export interface MenuCategory {
    id: number;
    code: string;
    name: string;
    description?: string;
    products?: Product[];
    partner?: MenuCategoryPartner;
    is_popular_category?: boolean;
}

export interface MenuCategoryPartner {
    id: number;
    code: string;
    title: string;
}

export interface Product {
    id: number;
    code: string;
    name: string;
    description?: string;
    master_category_id?: number;
    file_path?: string;
    is_sold_out?: boolean;
    is_express_item?: boolean;
    is_alcoholic_item?: boolean;
    product_variations?: ProductVariation[];
    half_type?: string;
    is_bundle?: boolean;
}

export interface ProductVariation {
    id: number;
    code: string;
    remote_code?: string;
    container_price?: number;
    price: number;
    topping_ids?: number[];
    topping_properties?: ProductVariationToppingProperty[];
}

export interface ProductVariationToppingProperty {
    id: number;
    use_original_price?: boolean;
}

export interface VendorLegalInformation {
    legal_name?: string;
    address_line_1?: string;
    trade_register_number?: string;
}

export interface Characteristics {
    cuisines?: Cuisine[];
    food_characteristics?: FoodCharacteristic[];
    primary_cuisine?: PrimaryCuisine;
}

export interface PrimaryCuisine {
    id: number;
    name: string;
    url_key?: string;
    main?: boolean;
}

export interface FoodCharacteristic {
    id: number;
    name: string;
    is_halal?: boolean;
    is_vegetarian?: boolean;
}

export interface Tag {
    code: string;
    text: string;
}

export interface Schedule {
    id: number;
    weekday: number;
    opening_type: string;
    opening_time: string;
    closing_time: string;
}

export interface TopicRating {
    topic: string;
    score: number;
}

export interface Experiment {
    experiment_id: string;
    experiment_variation: string;
    is_participating: boolean;
}

export interface DeliveryDurationRange {
    lower_limit_in_minutes?: number;
    upper_limit_in_minutes?: number;
}

export interface Cuisine {
    id: number;
    name: string;
    url_key?: string;
    main?: boolean;
}

export interface Deal {
    code: string;
    offer_type?: string;
    type?: string;
    voucher_type?: string;
    minimum_order_value?: number;
    maximum_discount_amount?: number;
    value?: number;
    title?: string;
    description?: string;
    start_date?: string;
    end_date?: string;
    is_pro?: boolean;
    is_new_customer?: boolean;
    seq_priority?: number;
    source?: string;
    conditions?: DealCondition[];
    quantity?: number;
    used_quantity?: number;
    is_full_basket_applicable?: boolean;
    is_bogo?: boolean;
}

export interface DealCondition {
    discount_type?: string;
    discount_amount?: number;
    condition_type?: string;
    condition_object_names?: string[];
}

export interface Chain {
    id: number;
    name: string;
    main_vendor_id?: number;
}

export interface City {
    id: number;
    name: string;
}

export interface Metadata {
    is_delivery_available?: boolean;
    is_pickup_available?: boolean;
    available_in?: string;
    has_discount?: boolean;
    timezone?: string;
    is_flood_feature_closed?: boolean;
}

export interface AutocompleteResponse {
    suggestions: {
        items: SuggestionGroup[];
    };
    deeplinks: {
        vendors: any[];
    };
}

export interface SuggestionGroup {
    headline: string;
    suggestion_type: string;
    items: SuggestionItem[];
}

export interface SuggestionItem {
    keyword: string;
    tracking_code: string;
}
