using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class LoyaltyMapper
{
    public static LoyaltyModel MapResponseToLoyalty(YemeksepetiVendorResponseModel response)
    {
        LoyaltyModel loyalty = new LoyaltyModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            RestaurantLoyaltyPercentageAmount = response?.Data?.RestaurantLoyaltyPercentageAmount,
            RestaurantLoyaltyProgramEnabled = response?.Data?.RestaurantLoyaltyProgramEnabled
        };
        
        return loyalty;
    }
}