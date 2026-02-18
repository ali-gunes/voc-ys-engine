namespace RestaurantDataService.Models;

public class DeliveryModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? DeliveryFeeSource { get; set; }
    public bool? HasDeliveryProvider { get; set; }
    public bool? IsDeliveryEnabled { get; set; }
    public int? MinimumDeliveryFee { get; set; }
    public int? MinimumDeliveryTime { get; set; }
    public int? OriginalDeliveryFee { get; set; }
    public int? DeliveryDurationLowerLimit { get; set; }
    public int? DeliveryDurationUpperLimit { get; set; }
}