using AndPlace.Data.Domain.Context;
using AndPlace.Data.Domain.DTO.Menu;
using AndPlace.Data.Domain.Models.Menu;
using AndPlace.Infrastructure.Interface.Helpers.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AndPlace.Api.Controllers.Menu;

[ApiController]
[Route("api/[controller]")]
public class QueryMenuController : Controller
{
    #region MenuSections

    [HttpGet("menuSection/all")]
    public async Task<ActionResult<List<MenuSectionModel>>> GetAllMenuSections(
        IMenuSectionAdapter menuSectionAdapter)
    {
        await using var ctx = new MenuContext();
        if (ctx.MenuSections != null)
        {
            return await ctx.MenuSections
                .AsNoTracking()
                .ToListAsync();
        }

        throw new InvalidOperationException("Menu sections table not found");
    }
    
    [HttpGet("menuSection/{id}")]
    public async Task<ActionResult<List<MenuSectionModel>>> GetMenuSectionById(
        IMenuSectionAdapter menuSectionAdapter,
        Guid id)
    {
        await using var ctx = new MenuContext();
        if (ctx.MenuSections != null)
        {
            return await ctx.MenuSections
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Include(s => s.Products)!
                .ThenInclude(p => p.Compositions)!
                .ThenInclude(c => c.Ingredient)
                .ToListAsync();
        }

        throw new InvalidOperationException("Menu sections table not found");
    }

    #endregion

    #region Product

    [HttpGet("product/all")]
    public async Task<ActionResult<List<ProductModel>>> GetAllProducts(
        IProductAdapter productAdapter)
    {
        await using var ctx = new MenuContext();
        if (ctx.Products != null)
        {
            return await ctx.Products
                .AsNoTracking()
                .ToListAsync();
        }

        throw new InvalidOperationException("Products table not found");
    }
    
    [HttpGet("product/{id}")]
    public async Task<ActionResult<List<ProductModel>>> GetProductById(
        IProductAdapter productAdapter,
        Guid id)
    {
        await using var ctx = new MenuContext();
        if (ctx.Products != null)
        {
            return await ctx.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Include(p => p.MenuSection)
                .Include(p => p.Compositions)!
                .ThenInclude(c => c.Ingredient)
                .ToListAsync();
        }

        throw new InvalidOperationException("Products table not found");
    }

    #endregion
    
}