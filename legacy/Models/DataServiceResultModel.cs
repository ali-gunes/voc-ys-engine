namespace RestaurantDataService.Models;

public class DataServiceResultModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? ServiceName { get; set; }
    public bool? Result { get; set; }
    public bool? HasValidResponse { get; set; }
}