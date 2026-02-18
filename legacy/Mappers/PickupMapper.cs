using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class PickupMapper
{
    public static PickupModel MapResponseToPickup(YemeksepetiVendorResponseModel response)
    {
        PickupModel pickup = new PickupModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            PickupDurationRange = response?.Data?.PickupDurationRange,
            IsPickupEnabled = response?.Data?.IsPickupEnabled,
            MinimumPickupTime = response?.Data?.MinimumPickupTime
        };
        
        return pickup;
    }
}