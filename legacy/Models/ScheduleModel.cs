namespace RestaurantDataService.Models;

public class ScheduleModel
{
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? RestaurantId { get; set; } 
    public string? YemeksepetiRestaurantCode { get; set; }
    public int? ScheduleId { get; set; }
    public int? ScheduleWeekday { get; set; }
    public string? ScheduleOpeningType { get; set; }
    public string? ScheduleOpeningTime { get; set; }
    public string? ScheduleClosingTime { get; set; }
}