using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class CityMapper
{
    public static CityModel MapResponseToCity(YemeksepetiVendorResponseModel response)
    {
        CityModel city = new CityModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            CityName = response?.Data?.City?.CityName,
            CityPostalCode = response?.Data?.City?.CityPostalCode
        };
        
        return city;
    }
}