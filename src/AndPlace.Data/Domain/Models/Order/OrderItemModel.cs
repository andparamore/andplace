using AndPlace.Data.Domain.Enums;

namespace AndPlace.Data.Domain.Models.Order;

public class OrderItemModel
{
    public Guid Id { get; init; }
    
    public Guid ProductId { get; init; }

    public string Name { get; set; } = string.Empty;
    
    public DepartmentManufacturer DepartmentManufacturer { get; set; }

    public decimal Price { get; set; }
    
    public Guid OrderId { get; set; }
    
    public OrderModel? Order { get; set; }
}