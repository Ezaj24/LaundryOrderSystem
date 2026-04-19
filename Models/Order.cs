namespace LaundryOrderSystem.Models;

public enum OrderStatus
{
    Received,
    Processing,
    Ready,
    Delivered
}

public class Garment
{
    public string Type { get; set; }

    public int Quantity { get; set; }

    public decimal PricePerItem { get; set; }

}

public class Order
{
    public string OrderId { get; set; }

    public string CustomerName { get; set; }

    public string PhoneNumber { get; set; }

    public List<Garment> Garments { get; set; }

    public decimal TotalBill { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }


}