using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class ExperimentMapper
{
    public static ExperimentModel MapResponseToExperiment(YemeksepetiVendorResponseModel response, int index)
    {
        ExperimentModel experiment = new ExperimentModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            ExperimentId = response?.Data?.Experiments?[index].ExperimentId,
            ExperimentVariation = response?.Data?.Experiments?[index].ExperimentVariation,
            ExperimentIsParticipating = response?.Data?.Experiments?[index].ExperimentIsParticipating
        };
        
        return experiment;
    }
}