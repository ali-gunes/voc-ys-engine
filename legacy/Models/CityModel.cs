namespace RestaurantDataService.Models;

public class CityModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? CityName { get; set; }
    public int? CityPostalCode { get; set; }
}