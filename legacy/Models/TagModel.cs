namespace RestaurantDataService.Models;

public class TagModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? TagCode { get; set; }
    public string? TagText { get; set; }
}