namespace CarCredit.API.Models.CarType.Entity
{
    public class CarType
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty; 
        public List<Car.Entity.Car> Cars { get; set; } = new();

    }
}
