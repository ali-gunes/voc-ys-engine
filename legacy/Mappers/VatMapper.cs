using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class VatMapper
{
    public static VatModel MapResponseToVat(YemeksepetiVendorResponseModel response)
    {
        VatModel vat = new VatModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            IsVatDisabled = response?.Data?.IsVatDisabled,
            IsVatIncludedInProductPrice = response?.Data?.IsVatIncludedInProductPrice,
            IsVatVisible = response?.Data?.IsVatVisible,
            IsVatIncluded = response?.Data?.IsVatIncluded
        };
        
        return vat;
    }
}