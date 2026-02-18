using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class LegalMapper
{
    public static LegalModel MapResponseToLegal(YemeksepetiVendorResponseModel response)
    {
        LegalModel legal = new LegalModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            RestaurantTradeRegisterNumber = response?.Data?.RestaurantTradeRegisterNumber,
            VendorLegalName = response?.Data?.VendorLegalInformation?.VendorLegalName,
            VendorAddress = response?.Data?.VendorLegalInformation?.VendorAddress,
            VendorTradeRegisterNumber = response?.Data?.VendorLegalInformation?.VendorTradeRegisterNumber
        };
        
        return legal;
    }
}