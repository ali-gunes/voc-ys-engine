namespace RestaurantDataService.Models;

public class PassThroughResultModel
{
    public bool DidWriteToTable { get; set; } = false;
    public bool HasValidResponse { get; set; } = false;
}