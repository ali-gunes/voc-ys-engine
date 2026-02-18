namespace RestaurantDataService.Models;

public class RestaurantModel
{
    public int? RestaurantId { get; set; } 
    public string? RestaurantName { get; set; }
    public string? RestaurantPhone { get; set; }
    public string? RestaurantAddress { get; set; }
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? RestaurantDescription { get; set; }
    public string? RestaurantUrlKey { get; set; }
    public string? RestaurantWebUrl { get; set; }
    public string? RestaurantLogoUrl { get; set; }
    public string? RestaurantHeroImage { get; set; }
    public string? RestaurantHeroListingImage { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? RestaurantLocation { get; set; }
    public string? RestaurantLocationEvent { get; set; }
    public double? RestaurantDistance { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsPremium { get; set; }
    public bool? IsPreOrderEnabled { get; set; }
    public bool? IsPromoted { get; set; }
    public bool? IsTest { get; set; }
    public bool? IsVoucherEnabled { get; set; }
    public bool? IsSuperVendor { get; set; }
    public bool? IsPartnerCashbackDisabled { get; set; }
    public int? MinimumOrderAmount { get; set; }
    public int? BudgetLevel { get; set; }
    public int? ServiceFee { get; set; }
    public int? ServiceFeePercentageAmount { get; set; }
    public int? ReviewNumber { get; set; }
    public int? ReviewWithCommentNumber { get; set; }
    public string? RestaurantFavorite { get; set; }
    public string? RestaurantTag { get; set; }
    public string? Vertical { get; set; }
    public string? VerticalSegment { get; set; }
    public string? VerticalParent { get; set; }
    public bool? IsDeliveryAvailable { get; set; }
    public bool? IsPickupAvailable { get; set; }
    public string? AvailableIn  { get; set; }
    public bool? HasDiscount { get; set; }
    public string? Timezone { get; set; }
    public bool? IsFloodFeatureClosed { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}