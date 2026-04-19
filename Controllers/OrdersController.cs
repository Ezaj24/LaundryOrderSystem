using LaundryOrderSystem.DTOs;
using LaundryOrderSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaundryOrderSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDto dto)
        {
            var order = _orderService.CreateOrder(dto);
            return Ok(order);
        }

        [HttpPatch("{orderId}/status")]
        public IActionResult UpdateStatus(string orderId, [FromBody] UpdateStatusDto dto)
        {
            var order = _orderService.UpdateStatus(orderId, dto.Status);
            if (order == null) return NotFound("Order not found");
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetAllOrders([FromQuery] string? status, [FromQuery] string? search)
        {
            var orders = _orderService.GetAllOrders(status, search);
            return Ok(orders);
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            var dashboard = _orderService.GetDashboard();
            return Ok(dashboard);
        }
    }
}