using AndPlace.Data.Domain.Context;
using AndPlace.Data.Domain.DTO;
using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Infrastructure.Interface.Helpers.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AndPlace.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController
{
    [HttpGet("allMenuSections")]
    public async Task<ActionResult<List<MenuSection>>> GetMenuSections(
        IMenuSectionAdapter menuSectionAdapter)
    {
        await using var ctx = new MenuContext();
        if (ctx.MenuSections != null)
        {
            return await ctx.MenuSections
                .Include(s => s.Products)
                .Select(s => menuSectionAdapter.MapToMenuSection(s))
                .ToListAsync();
        }

        throw new InvalidOperationException("Menu sections table not found");
    }
    
    [HttpGet("allProducts")]
    public async Task<ActionResult<List<Product>>> GetProducts(
        IProductAdapter productAdapter)
    {
        await using var ctx = new MenuContext();
        if (ctx.Products != null)
        {
            return await ctx.Products
                .Include(p => p.MenuSection)
                .Select(p => productAdapter.MapToProduct(p))
                .ToListAsync();
        }

        throw new InvalidOperationException("Products table not found");
    }

    [HttpPost("addMenuSection")]
    public async Task AddMenuSection(
        IMenuSectionAdapter menuSectionAdapter,
        [FromBody] MenuSection menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Add(menuSectionAdapter.MapToMenuSectionModel(menuSection));
        await ctx.SaveChangesAsync();
    }
    
    [HttpPost("addProduct")]
    public async Task AddProduct(
        IProductAdapter productAdapter,
        [FromBody] Product product)
    {
        await using var ctx = new MenuContext();
        ctx.Add(productAdapter.MapToProductModel(product));
        await ctx.SaveChangesAsync();
    }
}