using AndPlace.Data.Domain.Context;
using AndPlace.Data.Domain.Models.Accounting;
using AndPlace.Data.Domain.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AndPlace.Api.Controllers.Menu;

[ApiController]
[Route("api/[controller]")]
public class QueryMenuController : Controller
{
    #region MenuSections

    [HttpGet("menuSection/all")]
    public async Task<ActionResult<List<MenuSectionModel>>> GetAllMenuSections()
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
    public async Task<ActionResult<MenuSectionModel>> GetMenuSectionById(Guid id)
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
                .FirstAsync();
        }

        throw new InvalidOperationException("Menu sections table not found");
    }

    #endregion

    #region Product

    [HttpGet("product/all")]
    public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
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
    public async Task<ActionResult<ProductModel>> GetProductById(Guid id)
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
                .FirstAsync();
        }

        throw new InvalidOperationException("Products table not found");
    }

    #endregion
    
    #region IngredientAccounting

    [HttpGet("ingredientAccounting/all")]
    public async Task<ActionResult<List<IngredientAccountingModel>>> GetAllIngredientsAccounting()
    {
        await using var ctx = new MenuContext();
        if (ctx.Products != null)
        {
            return await ctx.IngredientsAccounting
                .AsNoTracking()
                .ToListAsync();
        }

        throw new InvalidOperationException("IngredientAccounting table not found");
    }
    
    [HttpGet("ingredientAccounting/{id}")]
    public async Task<ActionResult<IngredientAccountingModel>> GetIngredientAccountingById(Guid id)
    {
        await using var ctx = new MenuContext();
        if (ctx.Products != null)
        {
            return await ctx.IngredientsAccounting
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Include(i => i.Ingredient)
                .FirstAsync();
        }

        throw new InvalidOperationException("IngredientAccounting table not found");
    }

    #endregion
}