using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class DealMapper
{
    public static List<DealModel> MapResponseToDeal(YemeksepetiVendorResponseModel response, int index)
    {
        List<DealModel> dealList = new List<DealModel>();
        DealModel deal = new DealModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            DealCode = response?.Data?.Deals?[index].DealCode,
            OfferType = response?.Data?.Deals?[index].OfferType,
            DealType = response?.Data?.Deals?[index].DealType,
            VoucherType = response?.Data?.Deals?[index].VoucherType,
            DealMinimumOrderValue = response?.Data?.Deals?[index].DealMinimumOrderValue,
            DealMaximumDiscountAmount = response?.Data?.Deals?[index].DealMaximumDiscountAmount,
            DealValue = response?.Data?.Deals?[index].DealValue,
            DealTitle = response?.Data?.Deals?[index].DealTitle,
            DealDescription = response?.Data?.Deals?[index].DealDescription,
            DealStartDate = response?.Data?.Deals?[index].DealStartDate,
            DealEndDate = response?.Data?.Deals?[index].DealEndDate,
            DealIsPro = response?.Data?.Deals?[index].DealIsPro,
            DealIsNewCustomer = response?.Data?.Deals?[index].DealIsNewCustomer,
            DealSeqPriority = response?.Data?.Deals?[index].DealSeqPriority,
            DealSource = response?.Data?.Deals?[index].DealSource,
            DealQuantity = response?.Data?.Deals?[index].DealQuantity,
            DealUsedQuantity = response?.Data?.Deals?[index].DealUsedQuantity,
            DealIsFullBasketApplicable = response?.Data?.Deals?[index].DealIsFullBasketApplicable,
            DealIsBuyOneGetOne = response?.Data?.Deals?[index].DealIsBuyOneGetOne,
        };

        if (response?.Data?.Deals?[index].DealConditions != null &&
            response?.Data?.Deals?[index].DealConditions?.Count != 0)
        {
            for (int i = 0; i < response?.Data?.Deals?[index].DealConditions?.Count; i++)
            {
                deal.DealConditionDiscountType =
                    response?.Data?.Deals?[index].DealConditions?[i].DealConditionDiscountType;
                deal.DealConditionDiscountAmount =
                    response?.Data?.Deals?[index].DealConditions?[i].DealConditionDiscountAmount;
                deal.DealConditionProductType =
                    response?.Data?.Deals?[index].DealConditions?[i].DealConditionProductType;
                deal.DealConditionObjectNames = string.Join(", ",
                    response?.Data?.Deals?[index].DealConditions?[i].DealConditionObjectNames);
            
                dealList.Add(deal);
            }
        }
        else
        {
            dealList.Add(deal);
        }
        
        return dealList;
    }
}