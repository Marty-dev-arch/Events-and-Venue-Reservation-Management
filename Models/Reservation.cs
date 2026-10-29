using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Reservation_System.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string VenueLocation { get; set; } = "Big 8";
        public string EventType { get; set; } = "Wedding";
        public string FunctionhallType { get; set; }
        public DateTime CheckInDate { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public DateTime CheckOutDate { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public DateTime DateReserved { get; set; }
        public string Status { get; set; }

        // Backward compatibility alias for legacy code
        [System.ComponentModel.Browsable(false)]
        public string RoomType
        {
            get => FunctionhallType;
            set => FunctionhallType = value;
        }
    }
}
