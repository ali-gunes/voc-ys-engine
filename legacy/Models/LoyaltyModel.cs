namespace RestaurantDataService.Models;

public class LoyaltyModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public int? RestaurantLoyaltyPercentageAmount { get; set; }
    public bool? RestaurantLoyaltyProgramEnabled { get; set; }
}