using AndPlace.Data.Domain.Enums;

namespace AndPlace.Data.Domain.DTO.Menu;

public class MenuSection
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public string NameSection { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
    
    public DepartmentManufacturer DepartmentManufacturer { get; init; }
}