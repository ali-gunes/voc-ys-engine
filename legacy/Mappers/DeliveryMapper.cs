using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class DeliveryMapper
{
    public static DeliveryModel MapResponseToDelivery(YemeksepetiVendorResponseModel response)
    {
        DeliveryModel delivery = new DeliveryModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            DeliveryFeeSource = response?.Data?.DeliveryFeeSource,
            HasDeliveryProvider = response?.Data?.HasDeliveryProvider,
            IsDeliveryEnabled = response?.Data?.IsDeliveryEnabled,
            MinimumDeliveryFee = response?.Data?.MinimumDeliveryFee,
            MinimumDeliveryTime = response?.Data?.MinimumDeliveryTime,
            OriginalDeliveryFee = response?.Data?.OriginalDeliveryFee,
            DeliveryDurationLowerLimit = response?.Data?.DeliveryDurationRange?.DeliveryDurationLowerLimit,
            DeliveryDurationUpperLimit = response?.Data?.DeliveryDurationRange?.DeliveryDurationUpperLimit,
        };
        
        return delivery;
    }
}