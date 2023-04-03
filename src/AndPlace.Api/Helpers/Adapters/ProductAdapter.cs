using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Data.Domain.Models.Menu;
using AndPlace.Infrastructure.Interface.Helpers.Adapters;

namespace AndPlace.Api.Helpers.Adapters;

public class ProductAdapter : IProductAdapter
{
    public Product MapToProduct(ProductModel productModel)
    {
        try
        {
            return new Product()
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                MenuSectionId = productModel.MenuSectionId,
                MenuSectionName = productModel.MenuSection?.NameSection,
                Price = productModel.Price,
                Ingredients = productModel.Compositions
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public ProductModel MapToProductModel(Product product)
    {
        try
        {
            return new ProductModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                MenuSectionId = product.MenuSectionId,
                Price = product.Price,
                Compositions = product.Ingredients
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}