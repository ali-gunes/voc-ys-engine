namespace RestaurantDataService.Models;

public class MenuModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public bool? AbSortingApplied { get; set; }
    public int? MenuId { get; set; }
    public string? MenuName { get; set; }
    public string? MenuType { get; set; }
    public string? MenuOpeningTime { get; set; }
    public string? MenuClosingTime { get; set; }
}