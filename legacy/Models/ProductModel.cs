namespace RestaurantDataService.Models;

public class ProductModel
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
    
    public int? ProductId { get; set; }
    public Guid? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public double? ProductPrice {get; set;}
    public string? ProductDescription { get; set; }
    public int? ProductMasterCategoryId { get; set; }
    public string? ProductImage { get; set; }
    public bool? ProductIsSoldOut { get; set; }
    public bool? ProductIsExpressItem { get; set; }
    public bool? ProductIsAlcoholicItem { get; set; }
    public string? ProductHalfType { get; set; }
    public bool? ProductIsBundle { get; set; }
}