namespace RestaurantDataService.Models;

public class VatModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public bool? IsVatDisabled { get; set; }
    public bool? IsVatIncludedInProductPrice { get; set; }
    public bool? IsVatVisible { get; set; } 
    public bool? IsVatIncluded { get; set; }
}