using System.Runtime.Serialization;
using AndPlace.Data.Domain.Enums;

namespace AndPlace.Data.Domain.Models.Menu;

public class MenuSectionModel
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public string NameSection { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public DepartmentManufacturer DepartmentManufacturer { get; set; }
    
    [IgnoreDataMember]
    public IEnumerable<ProductModel>? Products { get; set; }
}