using Newtonsoft.Json;

namespace RestaurantDataService.Models;

public class YemeksepetiVendorResponseModel
{
    [JsonProperty("status_code")]
    public int? StatusCode { get; set; }
    
    [JsonProperty("data")]
    public Data? Data { get; set; }
}

public class Data
{
    [JsonProperty("chain")]
    public Chain? Chain { get; set; }  //chain
    
    [JsonProperty("city")]
    public City? City { get; set; }  //city
    
    [JsonProperty("customer_phone")]
    public string? RestaurantPhone { get; set; }  //general
    
    [JsonProperty("id")]
    public int? RestaurantId { get; set; }  //general
    
    [JsonProperty("name")]
    public string? RestaurantName { get; set; }  //general
    
    [JsonProperty("code")]
    public string? YemeksepetiRestaurantCode { get; set; }  //general
    
    [JsonProperty("address")]
    public string? RestaurantAddress { get; set; }  //general
    
    [JsonProperty("budget")]
    public int? BudgetLevel { get; set; }  //general
    
    [JsonProperty("deals")]
    public List<Deals>? Deals { get; set; }  //deals
    
    [JsonProperty("cuisines")]
    public List<Cuisines>? Cuisines { get; set; }  //cuisines
    
    [JsonProperty("delivery_duration_range")]
    public DeliveryDurationRange? DeliveryDurationRange { get; set; }  //delivery
    
    [JsonProperty("pickup_duration_range")]
    public int? PickupDurationRange { get; set; }  //pickup
    
    [JsonProperty("delivery_fee_source")]
    public string? DeliveryFeeSource { get; set; }  //delivery
    
    [JsonProperty("description")]
    public string? RestaurantDescription { get; set; }  //general
    
    [JsonProperty("distance")]
    public double? RestaurantDistance { get; set; }  //general
    
    [JsonProperty("experiments")]
    public List<Experiments>? Experiments { get; set; }  //experiments
    
    [JsonProperty("favorite")]
    public string? RestaurantFavorite { get; set; }  //general
    
    [JsonProperty("has_delivery_provider")]
    public bool? HasDeliveryProvider { get; set; }  //delivery
    
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }  //general
    
    [JsonProperty("is_delivery_enabled")]
    public bool? IsDeliveryEnabled { get; set; }  //delivery
    
    [JsonProperty("is_pickup_enabled")]
    public bool? IsPickupEnabled { get; set; }  //pickup
    
    [JsonProperty("is_premium")]
    public bool? IsPremium { get; set; }  //general
    
    [JsonProperty("is_preorder_enabled")]
    public bool? IsPreOrderEnabled { get; set; }  //general
    
    [JsonProperty("is_promoted")]
    public bool? IsPromoted { get; set; }  //general
    
    [JsonProperty("is_test")]
    public bool? IsTest { get; set; }  //general
    
    [JsonProperty("is_vat_disabled")]
    public bool? IsVatDisabled { get; set; }  //vat
    
    [JsonProperty("is_vat_included_in_product_price")]
    public bool? IsVatIncludedInProductPrice { get; set; }  //vat
    
    [JsonProperty("is_vat_visible")]
    public bool? IsVatVisible { get; set; }  //vat
    
    [JsonProperty("is_vat_included")]
    public bool? IsVatIncluded { get; set; }  //vat
    
    [JsonProperty("is_voucher_enabled")]
    public bool? IsVoucherEnabled { get; set; }  //general
    
    [JsonProperty("is_super_vendor")]
    public bool? IsSuperVendor { get; set; }  //general
    
    [JsonProperty("latitude")]
    public double? Latitude { get; set; }  //general
    
    [JsonProperty("longitude")]
    public double? Longitude { get; set; }  //general
    
    [JsonProperty("location")]
    public string? RestaurantLocation { get; set; }  //general
    
    [JsonProperty("location_event")]
    public string? RestaurantLocationEvent { get; set; }  //general
    
    [JsonProperty("logo")]
    public string? RestaurantLogoUrl { get; set; }  //general
    
    [JsonProperty("hero_image")]
    public string? RestaurantHeroImage { get; set; }  //general
    
    [JsonProperty("hero_listing_image")]
    public string? RestaurantHeroListingImage { get; set; }  //general
    
    [JsonProperty("loyalty_percentage_amount")]
    public int? RestaurantLoyaltyPercentageAmount { get; set; }  //loyalty
    
    [JsonProperty("loyalty_program_enabled")]
    public bool? RestaurantLoyaltyProgramEnabled { get; set; }  //loyalty
    
    [JsonProperty("minimum_delivery_fee")]
    public int? MinimumDeliveryFee { get; set; }  //delivery
    
    [JsonProperty("minimum_delivery_time")]
    public int? MinimumDeliveryTime { get; set; }  //delivery
    
    [JsonProperty("minimum_order_amount")]
    public int? MinimumOrderAmount { get; set; }  //general
    
    [JsonProperty("minimum_pickup_time")]
    public int? MinimumPickupTime { get; set; }  //pickup
    
    [JsonProperty("original_delivery_fee")]
    public int? OriginalDeliveryFee { get; set; }  //delivery
    
    [JsonProperty("topic_ratings")]
    public List<TopicRatings>? TopicRatings { get; set; }  //ratings
    
    [JsonProperty("review_number")]
    public int? ReviewNumber { get; set; }  //general
    
    [JsonProperty("review_with_comment_number")]
    public int? ReviewWithCommentNumber { get; set; }  //general
    
    [JsonProperty("schedules")]
    public List<Schedules>? Schedules { get; set; }  //schedules
    
    [JsonProperty("service_fee")]
    public int? ServiceFee { get; set; }  //general
    
    [JsonProperty("service_fee_percentage_amount")]
    public int? ServiceFeePercentageAmount { get; set; }  //general
    
    [JsonProperty("tag")]
    public string? RestaurantTag { get; set; }  //general
    
    [JsonProperty("tags")]
    public List<Tags>? RestaurantTags { get; set; }  //tags
    
    [JsonProperty("trade_register_number")]
    public string? RestaurantTradeRegisterNumber { get; set; }  //legal
    
    [JsonProperty("url_key")]
    public string? RestaurantUrlKey { get; set; }  //general
    
    [JsonProperty("characteristics")]
    public Characteristics? Characteristics { get; set; }  //characteristics
    
    [JsonProperty("vendor_legal_information")]
    public VendorLegalInformation? VendorLegalInformation { get; set; }  //legal
    
    [JsonProperty("vertical")]
    public string? Vertical { get; set; }  //general
    
    [JsonProperty("vertical_segment")]
    public string? VerticalSegment { get; set; }  //general
    
    [JsonProperty("vertical_parent")]
    public string? VerticalParent { get; set; }  //general
    
    [JsonProperty("web_path")]
    public string? RestaurantWebUrl { get; set; }  //general
    
    [JsonProperty("is_partner_cashback_disabled")]
    public bool? IsPartnerCashbackDisabled { get; set; }  //general
    
    [JsonProperty("other_vendors_in_chain")]
    public int? OtherVendorsInChain { get; set; }  //chain
    
    [JsonProperty("menus")]
    public List<Menus>? Menus { get; set; }  //menu, menucategories, products
    
    [JsonProperty("metadata")]
    public Metadata? Metadata { get; set; }  //metadata
}

public class Menus
{
    [JsonProperty("ab_sorting_applied")]
    public bool? AbSortingApplied { get; set; }  //menus
    
    [JsonProperty("id")]
    public int? MenuId { get; set; }  //menus
    
    [JsonProperty("name")]
    public string? MenuName { get; set; }  //menus
    
    [JsonProperty("type")]
    public string? MenuType { get; set; }  //menus
    
    [JsonProperty("opening_time")]
    public string? MenuOpeningTime { get; set; }  //menus
    
    [JsonProperty("closing_time")]
    public string? MenuClosingTime { get; set; }  //menus
    
    [JsonProperty("menu_categories")]
    public List<MenuCategories>? MenuCategories { get; set; }  //menus, menucategories
    
    // Skipping Toppings object in Menus for now
    
    // Skipping Tags object in Menus for now
    
    // Skipping Default Sold Out Options for now
    // [JsonProperty("default_sold_out_options")]
    // public List<DefaultSoldOutOptions>? MenuDefaultSoldOutOptions { get; set; }  //menus
}

public class DefaultSoldOutOptions
{
    [JsonProperty("default")]
    public bool? DefaultSoldOutOptionIsDefault { get; set; }  //menus
    
    [JsonProperty("option")]
    public string? DefaultSoldOutOptionType { get; set; }  //menus
    
    [JsonProperty("text")]
    public string? DefaultSoldOutOptionText { get; set; }  //menus
}

public class MenuCategories
{
    [JsonProperty("id")]
    public int? MenuCategoryId { get; set; }  //menucategories
    
    [JsonProperty("code")]
    public Guid? MenuCategoryCode { get; set; }  //menucategories
    
    [JsonProperty("name")]
    public string? MenuCategoryName { get; set; }  //menucategories
    
    [JsonProperty("description")]
    public string? MenuCategoryDescription { get; set; }  //menucategories
    
    [JsonProperty("products")]
    public List<Products>? Products { get; set; }  //menucategories, products
    
    [JsonProperty("partner")]
    public MenuCategoryPartner? MenuCategoryPartner { get; set; }  //menucategories
    
    [JsonProperty("is_popular_category")]
    public bool? MenuCategoryIsPopularCategory { get; set; }  //menucategories
}

public class MenuCategoryPartner
{
    [JsonProperty("id")]
    public int? MenuCategoryPartnerId { get; set; }  //menucategories
    
    [JsonProperty("code")]
    public string? MenuCategoryPartnerCode { get; set; }  //menucategories
    
    [JsonProperty("title")]
    public string? MenuCategoryPartnerTitle { get; set; }  //menucategories
}

public class Products
{
    [JsonProperty("id")]
    public int? ProductId { get; set; }  //product
    
    [JsonProperty("code")]
    public Guid? ProductCode { get; set; }  //product
    
    [JsonProperty("name")]
    public string? ProductName { get; set; }  //product
    
    [JsonProperty("description")]
    public string? ProductDescription { get; set; }  //product
    
    [JsonProperty("master_category_id")]
    public int? ProductMasterCategoryId { get; set; }  //product
    
    [JsonProperty("file_path")]
    public string? ProductImage { get; set; }  //product
    
    [JsonProperty("is_sold_out")]
    public bool? ProductIsSoldOut { get; set; }  //product
    
    [JsonProperty("is_express_item")]
    public bool? ProductIsExpressItem { get; set; }  //product
    
    // Skip the additives list for now
    
    [JsonProperty("is_alcoholic_item")]
    public bool? ProductIsAlcoholicItem { get; set; }  //product
    
    // Skip the sold out options for now
    
    [JsonProperty("product_variations")]
    public List<ProductVariations>? ProductVariations { get; set; }  //productvariaton
    
    [JsonProperty("half_type")]
    public string? ProductHalfType { get; set; }  //product
    
    [JsonProperty("is_bundle")]
    public bool? ProductIsBundle { get; set; }  //product
}

public class ProductVariations
{
    [JsonProperty("id")]
    public int? ProductVariationId { get; set; }  //productvariation
    
    [JsonProperty("code")]
    public Guid? ProductVariationCode { get; set; }  //productvariation
    
    [JsonProperty("remote_code")]
    public string? ProductVariationRemoteCode { get; set; }  //productvariation
    
    [JsonProperty("container_price")]
    public double? ProductVariationContainerPrice { get; set; }  //productvariation
    
    [JsonProperty("price")]
    public double? ProductPrice { get; set; }  //product, productvariation
    
    [JsonProperty("topping_ids")]
    public List<int>? ProductVariationToppingIds { get; set; }  //productvariation
    
    [JsonProperty("topping_properties")]
    public List<ProductVariationsToppingProperties>? ProductVariationsToppingProperties { get; set; }  //productvariation
}

public class ProductVariationsToppingProperties
{
    [JsonProperty("id")]
    public int? ProductVariationToppingPropertyId { get; set; }  //productvariation
    
    // Variable name is too long, bad practice
    [JsonProperty("use_original_price")]
    public bool? ProductVariationToppingPropertyUseOriginalPrice { get; set; }  //productvariation
}

public class VendorLegalInformation
{
    [JsonProperty("legal_name")]
    public string? VendorLegalName { get; set; }  //legal
    
    [JsonProperty("address_line_1")]
    public string? VendorAddress { get; set; }  //legal
    
    [JsonProperty("trade_register_number")]
    public string? VendorTradeRegisterNumber { get; set; }  //legal
}

public class Characteristics
{
    [JsonProperty("cuisines")]
    public List<Cuisines>? CharacteristicCuisines { get; set; }  //characteristics
    
    [JsonProperty("food_characteristics")]
    public List<FoodCharacteristics>? FoodCharacteristics { get; set; }  //characteristics
    
    [JsonProperty("primary_cuisine")]
    public PrimaryCuisine? PrimaryCuisine { get; set; }  //characteristics
}

public class PrimaryCuisine
{
    [JsonProperty("id")]
    public int? PrimaryCuisineId { get; set; }  //characteristics
    
    [JsonProperty("name")]
    public string? PrimaryCuisineName { get; set; }  //characteristics
    
    [JsonProperty("url_key")]
    public string? PrimaryCuisineUrlKey { get; set; }  //characteristics
    
    [JsonProperty("main")]
    public bool? PrimaryCuisineIsMain { get; set; }  //characteristics
    
}

public class FoodCharacteristics
{
    [JsonProperty("id")]
    public int? FoodCharacteristicId { get; set; }  //characteristics
    
    [JsonProperty("name")]
    public string? FoodCharacteristicName { get; set; }  //characteristics
    
    [JsonProperty("is_halal")]
    public bool? FoodCharacteristicIsHalal { get; set; }  //characteristics
    
    [JsonProperty("is_vegetarian")]
    public bool? FoodCharacteristicIsVegetarian { get; set; }  //characteristics
}

public class Tags
{
    [JsonProperty("code")]
    public string? TagCode { get; set; }  //tags
    
    [JsonProperty("text")]
    public string? TagText { get; set; }  //tags
}

public class Schedules
{
    [JsonProperty("id")]
    public int? ScheduleId { get; set; }  //schedules
    
    [JsonProperty("weekday")]
    public int? ScheduleWeekday { get; set; }  //schedules
    
    [JsonProperty("opening_type")]
    public string? ScheduleOpeningType { get; set; }  //schedules
    
    [JsonProperty("opening_time")]
    public string? ScheduleOpeningTime { get; set; }  //schedules
    
    [JsonProperty("closing_time")]
    public string? ScheduleClosingTime { get; set; }  //schedules
}

public class TopicRatings
{
    [JsonProperty("topic")]
    public string? TopicRatingType { get; set; }  //ratings
    
    [JsonProperty("score")]
    public double? TopicRatingScore { get; set; }  //ratings
}

public class Experiments
{
    [JsonProperty("experiment_id")]
    public string? ExperimentId { get; set; }  //experiment
    
    [JsonProperty("experiment_variation")]
    public string? ExperimentVariation { get; set; }  //experiment
    
    [JsonProperty("is_participating")]
    public bool? ExperimentIsParticipating { get; set; }  //experiment
}

public class DeliveryDurationRange
{
    [JsonProperty("lower_limit_in_minutes")]
    public int? DeliveryDurationLowerLimit { get; set; }  //delivery
    
    [JsonProperty("upper_limit_in_minutes")]
    public int? DeliveryDurationUpperLimit { get; set; }  //delivery
}

public class Cuisines
{
    [JsonProperty("id")]
    public int? CuisineId { get; set; }  //cuisine
    
    [JsonProperty("name")]
    public string? CuisineName { get; set; }  //cuisine
    
    [JsonProperty("url_key")]
    public string? CuisineUrlKey { get; set; }  //cuisine
    
    [JsonProperty("main")]
    public bool? CuisineIsMain { get; set; }  //cuisine
}

public class Deals
{
    [JsonProperty("code")]
    public string? DealCode { get; set; }  //deals
    
    [JsonProperty("offer_type")]
    public string? OfferType { get; set; }  //deals
    
    [JsonProperty("type")]
    public string? DealType { get; set; }  //deals
    
    [JsonProperty("voucher_type")]
    public string? VoucherType { get; set; }  //deals
    
    [JsonProperty("minimum_order_value")]
    public int? DealMinimumOrderValue { get; set; }  //deals
    
    [JsonProperty("maximum_discount_amount")]
    public int? DealMaximumDiscountAmount { get; set; }  //deals
    
    [JsonProperty("value")]
    public int? DealValue { get; set; }  //deals
    
    [JsonProperty("title")]
    public string? DealTitle { get; set; }  //deals
    
    [JsonProperty("description")]
    public string? DealDescription { get; set; }  //deals
    
    [JsonProperty("start_date")]
    public string? DealStartDate { get; set; }  //deals
    
    [JsonProperty("end_date")]
    public string? DealEndDate { get; set; }  //deals
    
    [JsonProperty("is_pro")]
    public bool? DealIsPro { get; set; }  //deals
    
    [JsonProperty("is_new_customer")]
    public bool? DealIsNewCustomer { get; set; }  //deals
    
    [JsonProperty("seq_priority")]
    public int? DealSeqPriority { get; set; }  //deals
    
    [JsonProperty("source")]
    public string? DealSource { get; set; }  //deals
    
    [JsonProperty("conditions")]
    public List<DealConditions>? DealConditions { get; set; }  //deals
    
    [JsonProperty("quantity")]
    public int? DealQuantity { get; set; }  //deals
    
    [JsonProperty("used_quantity")]
    public int? DealUsedQuantity { get; set; }  //deals
    
    [JsonProperty("is_full_basket_applicable")]
    public bool? DealIsFullBasketApplicable { get; set; }  //deals
    
    [JsonProperty("is_bogo")]
    public bool? DealIsBuyOneGetOne { get; set; }  //deals
}

public class DealConditions
{
    [JsonProperty("discount_type")]
    public string? DealConditionDiscountType { get; set; }  //deals
    
    [JsonProperty("discount_amount")]
    public double? DealConditionDiscountAmount { get; set; }  //deals
    
    [JsonProperty("condition_type")]
    public string? DealConditionProductType { get; set; }  //deals
    
    [JsonProperty("condition_object_names")]
    public List<string>? DealConditionObjectNames { get; set; }  //deals
}

public class Chain
{
    [JsonProperty("id")]
    public int? ChainId { get; set; }  //chain
    
    [JsonProperty("name")]
    public string? ChainName { get; set; }  //chain
    
    [JsonProperty("main_vendor_id")]  // Specifies its main chain vendor
    public int? MainVendorId { get; set; }  //chain
}

public class City
{
    [JsonProperty("id")]
    public int? CityPostalCode { get; set; }  //city
    
    [JsonProperty("name")]
    public string? CityName { get; set; }  //city
}

public class Metadata
{
    [JsonProperty("is_delivery_available")]
    public bool? MetadataIsDeliveryAvailable { get; set; }  //general
    
    [JsonProperty("is_pickup_available")]
    public bool? MetadataIsPickupAvailable { get; set; }  //general
    
    [JsonProperty("available_in")]
    public string? MetadataAvailableIn { get; set; }  //general
    
    [JsonProperty("has_discount")]
    public bool? MetadataHasDiscount { get; set; }  //general
    
    [JsonProperty("timezone")]
    public string? MetadataTimezone { get; set; }  //general
    
    // Skipping Events object in Metadata for now
    
    // Skipping Close Reasons object in Metadata for now
    
    [JsonProperty("is_flood_feature_closed")]
    public bool? MetadataIsFloodFeatureClosed { get; set; }  //general
}