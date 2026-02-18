using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class TagMapper
{
    public static TagModel MapResponseToTag(YemeksepetiVendorResponseModel response, int index)
    {
        TagModel tag = new TagModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            TagCode = response?.Data?.RestaurantTags?[index].TagCode,
            TagText = response?.Data?.RestaurantTags?[index].TagText
        };
        
        return tag;
    }
}