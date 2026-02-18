namespace RestaurantDataService.Models;

public class ExperimentModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public string? ExperimentId { get; set; }
    public string? ExperimentVariation { get; set; }
    public bool? ExperimentIsParticipating { get; set; }
}