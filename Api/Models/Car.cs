namespace Api.Models;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string LicensePlate { get; set; }
    public int StatusId { get; set; }
    public decimal PricePerDay { get; set; }

    public int ReservationStatus { get; set; }
}