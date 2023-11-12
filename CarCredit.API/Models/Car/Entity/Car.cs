using CarCredit.API.Interfaces;

namespace CarCredit.API.Models.Car.Entity
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int CarTypeId { get; set; }
        public string VIN { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public long Price { get; set; }
        public CarType.Entity.CarType CarType { get; set; }
        public Credit.Entity.Credit Credit { get; set; }

    }
}
