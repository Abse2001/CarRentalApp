using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Models
{
    internal class BookingInfo
    {
            public Car Car { get; set; }
            public required Customer Customer { get; set; }
            public decimal TotalPrice { get; set; }
            public DateTime BookingDate { get; set; }
            public DateTime BookingStartAt { get; set; }
            public DateTime BookingEndAt { get; set; }
            public User BookedBuy { get; set; }
        
}
}
