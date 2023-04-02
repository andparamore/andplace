using AndPlace.Data.Domain.DTO;
using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Data.Domain.Models;
using AndPlace.Data.Domain.Models.Menu;

namespace AndPlace.Infrastructure.Interface.Helpers.Adapters;

public interface IProductAdapter
{
    Product MapToProduct(ProductModel productModel);
    
    ProductModel MapToProductModel(Product product);
}