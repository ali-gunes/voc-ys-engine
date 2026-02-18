namespace RestaurantDataService.Models;

public class CharacteristicModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public int? PrimaryCuisineId { get; set; }
    public string? PrimaryCuisineName { get; set; }
    public string? PrimaryCuisineUrlKey { get; set; }
    public bool? PrimaryCuisineIsMain { get; set; }
    public int? FoodCharacteristicId { get; set; }
    public string? FoodCharacteristicName { get; set; }
    public bool? FoodCharacteristicIsHalal { get; set; }
    public bool? FoodCharacteristicIsVegetarian { get; set; }
}