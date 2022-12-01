namespace CarRentCalculator.Entities
{
    public sealed class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfAvailableCars { get; set; }
        public CarModel(int id, string name, int availableCars)
        {
            Id = id;
            Name = name;
            NumberOfAvailableCars = availableCars;
        }
        public int CarsId { get; set; }
        public Car Car { get; set; }
    }
}
