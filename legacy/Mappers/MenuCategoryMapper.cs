using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class MenuCategoryMapper
{
    public static MenuCategoryModel MapResponseToMenuCategory(YemeksepetiVendorResponseModel response, int menuIndex, int menuCategoryIndex)
    {
        MenuCategoryModel menuCategory = new MenuCategoryModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            MenuId = response?.Data?.Menus?[menuIndex].MenuId,
            MenuName = response?.Data?.Menus?[menuIndex].MenuName,
            MenuCategoryId = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryId,
            MenuCategoryCode = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryCode,
            MenuCategoryName = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryName,
            MenuCategoryDescription = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryDescription,
            MenuCategoryIsPopularCategory = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryIsPopularCategory,
            MenuCategoryPartnerId = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryPartner?.MenuCategoryPartnerId,
            MenuCategoryPartnerCode = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryPartner?.MenuCategoryPartnerCode,
            MenuCategoryPartnerTitle = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryPartner?.MenuCategoryPartnerTitle
        };
        
        return menuCategory;
    }
}