namespace RestaurantDataService.Models;

public class MenuCategoryModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }

    public int? MenuId { get; set; }
    public string? MenuName { get; set;}
 
    public int? MenuCategoryId { get; set; }
    public Guid? MenuCategoryCode { get; set; }
    public string? MenuCategoryName { get; set; }
    public string? MenuCategoryDescription { get; set; }
    public bool? MenuCategoryIsPopularCategory { get; set; }
    public int? MenuCategoryPartnerId { get; set; }
    public string? MenuCategoryPartnerCode { get; set; }
    public string? MenuCategoryPartnerTitle { get; set; }
}