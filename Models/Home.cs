using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Models
{
    public class Home
    {
        public int TotalRooms { get; set; }
        public int TotalCustomers { get; set; }
        public int CurrentReservations { get; set; }
        public int CheckInGuests { get; set; }
    }
}
