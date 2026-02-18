using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class RestaurantMapper
{
    public static RestaurantModel MapResponseToRestaurant(YemeksepetiVendorResponseModel response)
    {
        RestaurantModel restaurant = new RestaurantModel()
        {
            RestaurantId = response?.Data?.RestaurantId,
            RestaurantName = response?.Data?.RestaurantName,
            RestaurantPhone = response?.Data?.RestaurantPhone,
            RestaurantAddress = response?.Data?.RestaurantAddress,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            RestaurantDescription = response?.Data?.RestaurantDescription,
            RestaurantUrlKey = response?.Data?.RestaurantUrlKey,
            RestaurantWebUrl = response?.Data?.RestaurantWebUrl,
            RestaurantLogoUrl = response?.Data?.RestaurantLogoUrl,
            RestaurantHeroImage = response?.Data?.RestaurantHeroImage,
            RestaurantHeroListingImage = response?.Data?.RestaurantHeroListingImage,
            Latitude = response?.Data?.Latitude,
            Longitude = response?.Data?.Longitude,
            RestaurantLocation = response?.Data?.RestaurantLocation,
            RestaurantLocationEvent = response?.Data?.RestaurantLocationEvent,
            RestaurantDistance = response?.Data?.RestaurantDistance,
            IsActive = response?.Data?.IsActive,
            IsPremium = response?.Data?.IsPremium,
            IsPreOrderEnabled = response?.Data?.IsPreOrderEnabled,
            IsPromoted = response?.Data?.IsPromoted,
            IsTest = response?.Data?.IsTest,
            IsVoucherEnabled = response?.Data?.IsVoucherEnabled,
            IsSuperVendor = response?.Data?.IsSuperVendor,
            IsPartnerCashbackDisabled = response?.Data?.IsPartnerCashbackDisabled,
            MinimumOrderAmount = response?.Data?.MinimumOrderAmount,
            BudgetLevel = response?.Data?.BudgetLevel,
            ServiceFee = response?.Data?.ServiceFee,
            ServiceFeePercentageAmount = response?.Data?.ServiceFeePercentageAmount,
            ReviewNumber = response?.Data?.ReviewNumber,
            ReviewWithCommentNumber = response?.Data?.ReviewWithCommentNumber,
            RestaurantFavorite = response?.Data?.RestaurantFavorite,
            RestaurantTag = response?.Data?.RestaurantTag,
            Vertical = response?.Data?.Vertical,
            VerticalSegment = response?.Data?.VerticalSegment,
            VerticalParent = response?.Data?.VerticalParent,
            IsDeliveryAvailable = response?.Data?.Metadata?.MetadataIsDeliveryAvailable,
            IsPickupAvailable = response?.Data?.Metadata?.MetadataIsPickupAvailable,
            AvailableIn = response?.Data?.Metadata?.MetadataAvailableIn,
            HasDiscount = response?.Data?.Metadata?.MetadataHasDiscount,
            Timezone = response?.Data?.Metadata?.MetadataTimezone,
            IsFloodFeatureClosed = response?.Data?.Metadata?.MetadataIsFloodFeatureClosed,
            CreatedOn = DateTime.UtcNow
        };

        return restaurant;
    }
}