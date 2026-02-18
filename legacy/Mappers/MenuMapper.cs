using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class MenuMapper
{
    public static MenuModel MapResponseToMenu(YemeksepetiVendorResponseModel response, int index)
    {
        MenuModel menu = new MenuModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            AbSortingApplied = response?.Data?.Menus?[index].AbSortingApplied,
            MenuId = response?.Data?.Menus?[index].MenuId,
            MenuName = response?.Data?.Menus?[index].MenuName,
            MenuType = response?.Data?.Menus?[index].MenuType,
            MenuOpeningTime = response?.Data?.Menus?[index].MenuOpeningTime,
            MenuClosingTime = response?.Data?.Menus?[index].MenuClosingTime
        };

        return menu;
    }
}