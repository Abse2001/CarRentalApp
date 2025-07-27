using System;

namespace CarRentalApp.Models
{
    public class CarRental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentedAt { get; set; }
        public DateTime? ReturnedAt { get; set; }

        public DateTime DueDate { get; set; } // <- New field for expected return

    }
}
