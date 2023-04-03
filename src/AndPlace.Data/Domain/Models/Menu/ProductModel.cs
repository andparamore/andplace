using System.Runtime.Serialization;

namespace AndPlace.Data.Domain.Models.Menu;

public class ProductModel
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public Guid MenuSectionId { get; set; }

    [IgnoreDataMember]
    public MenuSectionModel? MenuSection { get; set; } 
    
    public IEnumerable<CompositionModel>? Compositions { get; set; }

    public decimal Price { get; set; }
}