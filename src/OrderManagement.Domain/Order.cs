using System;
using System.Collections.Generic;
using System.Linq;
public class Order
{
    private readonly List<OrderItem> _items = new();

    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; }
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public IReadOnlyCollection<OrderItem> Items => _items;

    public decimal Total => _items.Sum(i => i.Price * i.Quantity);

    public Order(Guid userId)
    {
        UserId = userId;
    }

    public void AddItem(string name, decimal price, int quantity)
    {
       if (quantity <= 0) { throw new Exception("Invalid quantity"); }
       _items.Add(new OrderItem(name, price, quantity));
    }

    public void MarkAsPaid()
    {
        if (Status != OrderStatus.Pending) { throw new Exception("Invalid transition"); }
        Status = OrderStatus.Paid;
    }
}