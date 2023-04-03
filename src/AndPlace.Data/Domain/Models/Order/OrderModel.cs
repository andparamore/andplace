namespace AndPlace.Data.Domain.Models.Order;

public class OrderModel
{
    public Guid Id { get; set; }
    
    public IEnumerable<OrderItemModel>? OrderItem { get; set; }
    
    public Guid TableId { get; set; }
    
    public decimal Price { get; set; }
}