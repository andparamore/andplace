using System.Runtime.Serialization;
using AndPlace.Data.Domain.Models.Menu;

namespace AndPlace.Data.Domain.Models.Accounting;

public class IngredientModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; init; } = string.Empty;
    
    public string Unit { get; init; } = string.Empty;

    [IgnoreDataMember]
    public IngredientAccountingModel? IngredientAccounting { get; set; }
    
    [IgnoreDataMember]
    public IEnumerable<CompositionModel>? Compositions { get; set; }
}