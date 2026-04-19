using LaundryOrderSystem.DTOs;
using LaundryOrderSystem.Models;

namespace LaundryOrderSystem.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderDto dto);
        Order UpdateStatus(string orderId, string status);
        List<Order> GetAllOrders(string? status, string? search);
        object GetDashboard();
    }

    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders = new List<Order>();
        private int _counter = 1;

        public Order CreateOrder(CreateOrderDto dto)
        {
            var garments = dto.Garments.Select(g => new Garment
            {
                Type = g.Type,
                Quantity = g.Quantity,
                PricePerItem = g.PricePerItem
            }).ToList();

            decimal total = garments.Sum(g => g.Quantity * g.PricePerItem);

            var order = new Order
            {
                OrderId = $"LD-{_counter++:D3}",
                CustomerName = dto.CustomerName,
                PhoneNumber = dto.PhoneNumber,
                Garments = garments,
                TotalBill = total,
                Status = OrderStatus.Received,
                CreatedAt = DateTime.UtcNow
            };

            _orders.Add(order);
            return order;
        }

        public Order UpdateStatus(string orderId, string status)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) return null;

            if (Enum.TryParse<OrderStatus>(status, true, out var newStatus))
                order.Status = newStatus;

            return order;
        }

        public List<Order> GetAllOrders(string? status, string? search)
        {
            var query = _orders.AsQueryable();

            if (!string.IsNullOrEmpty(status) && Enum.TryParse<OrderStatus>(status, true, out var s))
                query = query.Where(o => o.Status == s);

            if (!string.IsNullOrEmpty(search))
                query = query.Where(o => o.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase)
                    || o.PhoneNumber.Contains(search));

            return query.ToList();
        }

        public object GetDashboard()
        {
            return new
            {
                TotalOrders = _orders.Count,
                TotalRevenue = _orders.Sum(o => o.TotalBill),
                OrdersPerStatus = _orders.GroupBy(o => o.Status)
                    .ToDictionary(g => g.Key.ToString(), g => g.Count())
            };
        }
    }
}