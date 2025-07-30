using System;
using System.Collections.Generic;

namespace CarRentalApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string DrivingLicenseNum { get; set; }
        public required string Nationality { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<int> CarIds { get; set; } = new List<int>();
    }
}
