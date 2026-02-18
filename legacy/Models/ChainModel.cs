namespace RestaurantDataService.Models;

public class ChainModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public int? ChainId { get; set; }
    public string? ChainName { get; set; }
    public int? MainVendorId { get; set; }
    public int? OtherVendorsInChain { get; set; }
}