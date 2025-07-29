namespace CarRentalApp.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal RentalPricePerDay { get; set; }
        public string Status { get; set; }
        public string ImageName { get; set; }

        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - {PlateNumber}";
        }
    }
}
