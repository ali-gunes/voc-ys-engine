namespace RestaurantDataService.Models;

public class PickupModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public int? PickupDurationRange { get; set; }
    public bool? IsPickupEnabled { get; set; }
    public int? MinimumPickupTime { get; set; }
}