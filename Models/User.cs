using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Models
{

    public enum Role
    {
        Admin,
        User
    }
    internal class User
    {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string PasswordHash { get; set; }
            public Role UserRole { get; set; }
            public decimal Balance { get; set; } = 0;
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateCreated { get; set; } = DateTime.UtcNow;
            public DateTime? LastLogin { get; set; }
            public bool IsLocked { get; set; }
            public DateTime? DeletedAt { get; set; }
            public virtual ICollection<BookingInfo> Bookings { get; set; }
            public int NumberOfBookings { get; set; } = 0;
}
}
