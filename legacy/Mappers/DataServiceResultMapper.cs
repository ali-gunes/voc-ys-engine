using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class DataServiceResultMapper
{
    public static DataServiceResultModel MapDataServiceResult(YemeksepetiVendorResponseModel response, string serviceName, PassThroughResultModel result)
    {
        DataServiceResultModel dataServiceResult = new DataServiceResultModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            ServiceName = serviceName,
            Result = result.DidWriteToTable,
            HasValidResponse = result.HasValidResponse
        };
        
        return dataServiceResult;
    }
}