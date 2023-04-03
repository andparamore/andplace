using AndPlace.Data.Domain.Context;
using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Data.Domain.Models.Menu;
using AndPlace.Infrastructure.Interface.Helpers.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace AndPlace.Api.Controllers.Menu;

[ApiController]
[Route("api/[controller]")]
public class MutationMenuController
{
    #region MenuSection

    [HttpPost("addMenuSection")]
    public async Task AddMenuSection(
        IMenuSectionAdapter menuSectionAdapter,
        [FromBody] MenuSectionModel menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Add(menuSection);
        await ctx.SaveChangesAsync();
    }
    
    [HttpPut("updateMenuSection")]
    public async Task UpdateMenuSection(
        IMenuSectionAdapter menuSectionAdapter,
        [FromBody] MenuSectionModel menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Update(menuSection);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("deleteMenuSection")]
    public async Task DeleteMenuSection(
        IMenuSectionAdapter menuSectionAdapter,
        [FromBody] MenuSectionModel menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(menuSection);
        await ctx.SaveChangesAsync();
    }

    #endregion

    #region Product

    [HttpPost("addProduct")]
    public async Task AddProduct(
        IProductAdapter productAdapter,
        [FromBody] ProductModel product)
    {
        await using var ctx = new MenuContext();
        ctx.Add(product);
        await ctx.SaveChangesAsync();
    }

    [HttpPut("updateProduct")]
    public async Task UpdateProduct(
        IProductAdapter productAdapter,
        [FromBody] ProductModel product)
    {
        await using var ctx = new MenuContext();
        ctx.Update(product);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("deleteProduct")]
    public async Task DeleteProduct(
        IProductAdapter productAdapter,
        [FromBody] ProductModel product)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(product);
        await ctx.SaveChangesAsync();
    }

    #endregion
}