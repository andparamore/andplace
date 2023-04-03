using System.Runtime.Serialization;
using AndPlace.Data.Domain.Models.Accounting;

namespace AndPlace.Data.Domain.Models.Menu;

public class CompositionModel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid IngredientId { get; set; }  = Guid.NewGuid();

    public IngredientModel? Ingredient { get; init; }
    
    public Guid ProductId { get; set; }
    
    [IgnoreDataMember]
    public ProductModel? Product { get; set; }
    
    public int Count { get; init; }
}