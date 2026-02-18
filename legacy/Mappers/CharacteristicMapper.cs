using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class CharacteristicMapper
{
    public static List<CharacteristicModel> MapResponseToCharacteristic(YemeksepetiVendorResponseModel response)
    {
        List<CharacteristicModel> characteristicList = new List<CharacteristicModel>();
        
        CharacteristicModel characteristic = new CharacteristicModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            PrimaryCuisineId = response?.Data?.Characteristics?.PrimaryCuisine?.PrimaryCuisineId,
            PrimaryCuisineName = response?.Data?.Characteristics?.PrimaryCuisine?.PrimaryCuisineName,
            PrimaryCuisineUrlKey = response?.Data?.Characteristics?.PrimaryCuisine?.PrimaryCuisineUrlKey,
            PrimaryCuisineIsMain = response?.Data?.Characteristics?.PrimaryCuisine?.PrimaryCuisineIsMain,
            
        };

        if (response?.Data?.Characteristics?.FoodCharacteristics != null &&
            response?.Data?.Characteristics?.FoodCharacteristics?.Count != 0)
        {
            for(int i = 0; i < response?.Data?.Characteristics?.FoodCharacteristics?.Count; i++)
            {
                characteristic.FoodCharacteristicId = response?.Data?.Characteristics?.FoodCharacteristics?[i].FoodCharacteristicId;
                characteristic.FoodCharacteristicName =
                    response?.Data?.Characteristics?.FoodCharacteristics?[i].FoodCharacteristicName;
                characteristic.FoodCharacteristicIsHalal =
                    response?.Data?.Characteristics?.FoodCharacteristics?[i].FoodCharacteristicIsHalal;
                characteristic.FoodCharacteristicIsVegetarian = response?.Data?.Characteristics?.FoodCharacteristics?[i]
                    .FoodCharacteristicIsVegetarian;
            
                characteristicList.Add(characteristic);
            }
        }
        else
        {
            characteristicList.Add(characteristic);
        }
        
        
        return characteristicList;
    } 
}