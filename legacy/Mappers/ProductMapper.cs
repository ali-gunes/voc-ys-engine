using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class ProductMapper
{
     public static ProductModel MapResponseToProduct(YemeksepetiVendorResponseModel response, int menuIndex,
          int menuCategoryIndex, int productIndex)
     {
          ProductModel product = new ProductModel()
          {
               CreatedOn = DateTime.UtcNow,
               RestaurantId = response?.Data?.RestaurantId,
               YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
               MenuId = response?.Data?.Menus?[menuIndex].MenuId,
               MenuName = response?.Data?.Menus?[menuIndex].MenuName,
               MenuCategoryId = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryId,
               MenuCategoryCode = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryCode,
               MenuCategoryName = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].MenuCategoryName,
               ProductId = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductId,
               ProductCode = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductCode,
               ProductName = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductName,
               ProductPrice = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductVariations?[0].ProductPrice,
               ProductDescription = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductDescription,
               ProductMasterCategoryId = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductMasterCategoryId,
               ProductImage = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductImage,
               ProductIsSoldOut = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductIsSoldOut,
               ProductIsExpressItem = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductIsExpressItem,
               ProductIsAlcoholicItem = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductIsAlcoholicItem,
               ProductHalfType = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductHalfType,
               ProductIsBundle = response?.Data?.Menus?[menuIndex].MenuCategories?[menuCategoryIndex].Products?[productIndex].ProductIsBundle
          };

          return product;
     }
}