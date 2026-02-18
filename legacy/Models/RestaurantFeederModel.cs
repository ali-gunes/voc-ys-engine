namespace RestaurantDataService.Models;

public class RestaurantFeederModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string? YemeksepetiRestaurantId { get; set; }
    public bool? Status { get; set; }
    public int? CompletedServiceCount { get; set; }
    public int? FailedServiceCount { get; set; }
    public int? RetryCount { get; set; }
}