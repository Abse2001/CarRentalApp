namespace CarRentalApp.Components
{
    public class CarInfo
    {
        public string Make { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public string ImageName { get; }
        public decimal PaymentPerDay { get; }
        public string Status { get; }
        public int Year { get; }

        public CarInfo(string make, string model, decimal pay, string plate, string imageName, string status, int year)
        {
            Make = make;
            Model = model;
            LicensePlate = plate;
            ImageName = imageName;
            PaymentPerDay = pay;
            Status = status;
            Year = year;
        }
    }
}
