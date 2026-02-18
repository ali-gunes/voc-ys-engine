namespace RestaurantDataService.Models;

public class LegalModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? RestaurantTradeRegisterNumber { get; set; }
    public string? VendorLegalName { get; set; }
    public string? VendorAddress { get; set; }
    public string? VendorTradeRegisterNumber { get; set; }
}