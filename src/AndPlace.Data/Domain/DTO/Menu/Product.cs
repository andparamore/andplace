using AndPlace.Data.Domain.Models.Menu;

namespace AndPlace.Data.Domain.DTO.Menu;

public class Product
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
    
    public Guid MenuSectionId { get; init; }

    public string? MenuSectionName { get; set; }

    public IEnumerable<CompositionModel> Ingredients { get; set; } = new List<CompositionModel>();

    public decimal Price { get; init; }
}