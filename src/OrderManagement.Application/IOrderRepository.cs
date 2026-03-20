using OrderManagement.Domain;

public interface IOrderRepository
{
    Task AddAsync(Order order);
}