using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string EventType { get; set; } = "Wedding";
        public string FunctionhallType { get; set; }
        public decimal Rate { get; set; }
        public int Capacity { get; set; }
        public int Beds { get; set; }
        public bool Availability { get; set; }
        public bool Maintenance { get; set; }
        public byte[] ImageData { get; set; }
        public string VenueLocation { get; set; } = "Big 8";

        // Backward compatibility alias for legacy code
        [System.ComponentModel.Browsable(false)]
        public string RoomType
        {
            get => FunctionhallType;
            set => FunctionhallType = value;
        }
    }
}
