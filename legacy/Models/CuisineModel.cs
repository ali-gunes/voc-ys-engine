namespace RestaurantDataService.Models;

public class CuisineModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public int? CuisineId { get; set; }
    public string? CuisineName { get; set; }
    public bool? CuisineIsMain { get; set; }
    public string? CuisineUrlKey { get; set; }
}