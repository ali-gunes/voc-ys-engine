using Microsoft.VisualBasic;
using RestaurantDataService.Models;

namespace RestaurantDataService.Mappers;

public class ProductVariationMapper
{
    public static List<ProductVariationModel> MapResponseToProductVariation(YemeksepetiVendorResponseModel response)
    {
        List<ProductVariationModel> productVariationList = new List<ProductVariationModel>();
        ProductVariationModel productVariation = new ProductVariationModel()
        {
            CreatedOn = DateTime.UtcNow,
            RestaurantId = response?.Data?.RestaurantId,
            YemeksepetiRestaurantCode = response?.Data?.YemeksepetiRestaurantCode,
            
        };

        foreach (var menu in response?.Data?.Menus)
        {
            foreach (var menuCategory in menu.MenuCategories)
            {
                foreach (var product in menuCategory.Products)
                {
                    productVariation.ProductId = product.ProductId;
                    productVariation.ProductCode = product.ProductCode;
                    productVariation.ProductName = product.ProductName;

                    foreach (var variation in product.ProductVariations)
                    {
                        productVariation.ProductVariationId = variation.ProductVariationId;
                        productVariation.ProductVariationCode = variation.ProductVariationCode;
                        productVariation.ProductVariationRemoteCode = variation.ProductVariationRemoteCode;
                        productVariation.ProductVariationContainerPrice = variation.ProductVariationContainerPrice;
                        productVariation.ProductVariationToppingIds = string.Join(", ", variation.ProductVariationToppingIds.Select(i => i.ToString()).ToList());

                        if (variation.ProductVariationsToppingProperties != null &&
                            variation.ProductVariationsToppingProperties.Count != 0)
                        {
                            foreach (var toppingProperties in variation.ProductVariationsToppingProperties)
                            {
                                productVariation.ToppingPropertyId = toppingProperties.ProductVariationToppingPropertyId;
                                productVariation.ToppingPropertyUseOriginalPrice =
                                    toppingProperties.ProductVariationToppingPropertyUseOriginalPrice;
                            
                                productVariationList.Add(productVariation);
                            }
                        }
                        else
                        {
                            productVariationList.Add(productVariation);
                        }
                        
                    }
                }
            }
        }

        return productVariationList;
    }
}