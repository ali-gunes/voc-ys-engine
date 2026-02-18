using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class ChainMapper
{
    public static ChainModel MapResponseToChain(YemeksepetiVendorResponseModel response)
    {
        ChainModel chain = new ChainModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            ChainId = response?.Data?.Chain?.ChainId,
            ChainName = response?.Data?.Chain?.ChainName,
            MainVendorId = response?.Data?.Chain?.MainVendorId,
            OtherVendorsInChain = response?.Data?.OtherVendorsInChain
        };
        
        return chain;
    }
}