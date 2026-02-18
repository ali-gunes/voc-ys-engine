namespace RestaurantDataService.Models;

public class ProductVariationModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    
    public int? ProductId { get; set; }
    public Guid? ProductCode { get; set; }
    public string? ProductName { get; set; }
    
    public int? ProductVariationId { get; set; }
    public Guid? ProductVariationCode { get; set; }
    public string? ProductVariationRemoteCode { get; set; }
    public double? ProductVariationContainerPrice { get; set; }
    public string? ProductVariationToppingIds { get; set; }
    public int? ToppingPropertyId { get; set; }
    public bool? ToppingPropertyUseOriginalPrice { get; set; }
}