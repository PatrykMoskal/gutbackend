namespace Api.Models
{
    public class CarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int Year { get; set; }
        
        public int pricePerDay { get; set; }
        
        public int statusId { get; set; }
        
        public int reservationStatusId { get; set; }
        
        
    }
}