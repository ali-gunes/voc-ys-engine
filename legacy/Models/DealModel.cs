namespace RestaurantDataService.Models;

public class DealModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? DealCode { get; set; }
    public string? OfferType { get; set; }
    public string? DealType { get; set; } 
    public string? VoucherType { get; set; }
    public int? DealMinimumOrderValue { get; set; }
    public int? DealMaximumDiscountAmount { get; set; }
    public int? DealValue { get; set; }
    public string? DealTitle { get; set; }
    public string? DealDescription { get; set; }
    public string? DealStartDate { get; set; }
    public string? DealEndDate { get; set; }
    public bool? DealIsPro { get; set; }
    public bool? DealIsNewCustomer { get; set; }
    public int? DealSeqPriority { get; set; }
    public string? DealSource { get; set; }
    public int? DealQuantity { get; set; }
    public int? DealUsedQuantity { get; set; }
    public bool? DealIsFullBasketApplicable { get; set; }
    public bool? DealIsBuyOneGetOne { get; set; }
    public string? DealConditionDiscountType { get; set; }
    public double? DealConditionDiscountAmount { get; set; }
    public string? DealConditionProductType { get; set; }
    public string? DealConditionObjectNames { get; set; }
}