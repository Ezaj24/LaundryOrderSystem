using LaundryOrderSystem.Models;

namespace LaundryOrderSystem.DTOs;

public class GarmentDto
{
    public string Type { get; set; }

    public int Quantity { get; set; }

    public decimal PricePerItem { get; set; }


}

public class CreateOrderDto
{
    public string CustomerName { get; set; }

    public string PhoneNumber { get; set; }

    public List<GarmentDto> Garments { get; set; }  
}

public class UpdateStatusDto
{
    public string Status { get; set; }

}