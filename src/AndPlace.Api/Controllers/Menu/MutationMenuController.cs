using AndPlace.Data.Domain.Context;
using AndPlace.Data.Domain.Models.Accounting;
using AndPlace.Data.Domain.Models.Menu;
using Microsoft.AspNetCore.Mvc;

namespace AndPlace.Api.Controllers.Menu;

[ApiController]
[Route("api/[controller]")]
public class MutationMenuController : Controller
{
    #region MenuSection

    [HttpPost("menuSection/add")]
    public async Task AddMenuSection([FromBody] MenuSectionModel menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Add(menuSection);
        await ctx.SaveChangesAsync();
    }
    
    [HttpPut("menuSection/update")]
    public async Task UpdateMenuSection([FromBody] MenuSectionModel menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Update(menuSection);
        await ctx.SaveChangesAsync();
    }
    
    //TODO: Починить все удаления.
    [HttpDelete("menuSection/delete")]
    public async Task DeleteMenuSection([FromBody] MenuSectionModel menuSection)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(menuSection);
        await ctx.SaveChangesAsync();
    }

    #endregion

    #region Product

    [HttpPost("product/add")]
    public async Task AddProduct([FromBody] ProductModel product)
    {
        await using var ctx = new MenuContext();
        ctx.Add(product);
        await ctx.SaveChangesAsync();
    }

    [HttpPut("product/update")]
    public async Task UpdateProduct([FromBody] ProductModel product)
    {
        await using var ctx = new MenuContext();
        ctx.Update(product);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("product/delete")]
    public async Task DeleteProduct([FromBody] ProductModel product)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(product);
        await ctx.SaveChangesAsync();
    }

    #endregion
    
    #region Composition

    [HttpPost("composition/add")]
    public async Task AddComposition([FromBody] CompositionModel composition)
    {
        await using var ctx = new MenuContext();
        ctx.Add(composition);
        await ctx.SaveChangesAsync();
    }

    [HttpPut("composition/update")]
    public async Task UpdateComposition([FromBody] CompositionModel composition)
    {
        await using var ctx = new MenuContext();
        ctx.Update(composition);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("composition/delete")]
    public async Task DeleteComposition([FromBody] CompositionModel composition)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(composition);
        await ctx.SaveChangesAsync();
    }

    #endregion
    
    #region Ingredient

    [HttpPost("ingredient/add")]
    public async Task AddIngredient([FromBody] IngredientModel ingredient)
    {
        await using var ctx = new MenuContext();
        ctx.Add(ingredient);
        await ctx.SaveChangesAsync();
    }

    [HttpPut("ingredient/update")]
    public async Task UpdateIngredient([FromBody] IngredientModel ingredient)
    {
        await using var ctx = new MenuContext();
        ctx.Update(ingredient);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("ingredient/delete")]
    public async Task DeleteIngredient([FromBody] IngredientModel ingredient)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(ingredient);
        await ctx.SaveChangesAsync();
    }

    #endregion
    
    #region IngredientAccounting

    [HttpPost("ingredientAccounting/add")]
    public async Task AddIngredientAccounting([FromBody] IngredientAccountingModel ingredientAccounting)
    {
        await using var ctx = new MenuContext();
        ctx.Add(ingredientAccounting);
        await ctx.SaveChangesAsync();
    }

    [HttpPut("ingredientAccounting/update")]
    public async Task UpdateIngredientAccounting([FromBody] IngredientAccountingModel ingredientAccounting)
    {
        await using var ctx = new MenuContext();
        ctx.Update(ingredientAccounting);
        await ctx.SaveChangesAsync();
    }
    
    [HttpDelete("ingredientAccounting/delete")]
    public async Task DeleteIngredientAccounting([FromBody] IngredientAccountingModel ingredientAccounting)
    {
        await using var ctx = new MenuContext();
        ctx.Remove(ingredientAccounting);
        await ctx.SaveChangesAsync();
    }

    #endregion
}