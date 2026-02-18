using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class TopicRatingMapper
{
    public static TopicRatingModel MapResponseToTopicRating(YemeksepetiVendorResponseModel response, int index)
    {
        TopicRatingModel topicRating = new TopicRatingModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            TopicRatingType = response?.Data?.TopicRatings?[index].TopicRatingType,
            TopicRatingScore = response?.Data?.TopicRatings?[index].TopicRatingScore
        };
        
        return topicRating;
    }
}