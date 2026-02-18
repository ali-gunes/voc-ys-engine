using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class CuisineMapper
{
    public static CuisineModel MapResponseToCuisine(YemeksepetiVendorResponseModel response, int index)
    {
        CuisineModel cuisine = new CuisineModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            CuisineId = response?.Data?.Cuisines?[index].CuisineId,
            CuisineName = response?.Data?.Cuisines?[index].CuisineName,
            CuisineIsMain = response?.Data?.Cuisines?[index].CuisineIsMain,
            CuisineUrlKey = response?.Data?.Cuisines?[index].CuisineUrlKey
        };
        
        return cuisine;
    }
}