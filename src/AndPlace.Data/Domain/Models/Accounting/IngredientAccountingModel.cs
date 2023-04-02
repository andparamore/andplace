namespace AndPlace.Data.Domain.Models.Accounting;

public class IngredientAccountingModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public Guid IngredientId { get; set; }

    public IngredientModel Ingredient { get; set; } = new IngredientModel();
    
    public int Count { get; set; }
}