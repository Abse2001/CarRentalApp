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
        public string Status { get; set; } // Available, Rented, Out of Service
        public string ImageName { get; set; } // New property for image file name

        public override string ToString()
        {
            return $"{Brand} {Model} ({Year}) - {PlateNumber}";
        }
    }
}
