using AndPlace.Data.Domain.Models.Menu;

namespace AndPlace.Data.Domain.Models.Accounting;

public class IngredientModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; init; } = string.Empty;
    
    public string Unit { get; init; } = string.Empty;

    public IngredientAccountingModel? IngredientAccounting { get; set; }
    
    public IEnumerable<CompositionModel>? Compositions { get; set; }
}