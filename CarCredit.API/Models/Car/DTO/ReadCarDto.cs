namespace CarCredit.API.Models.Car.DTO
{
    public class ReadCarDto
    {
        public int Id { get; set; }
        public int CarTypeId { get; set; }
        public string VIN { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Mileage { get; set; }
        public long Price { get; set; }
    }
}
