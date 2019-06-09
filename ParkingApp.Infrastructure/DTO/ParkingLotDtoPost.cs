using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Infrastructure.DTO
{
    public class ParkingLotDtoPost
    {
        public string Name { get; set; }
        public int NumberOfParkingSpots { get; set; }
        public decimal PriceForHour { get; set; }
        public string Location { get; set; }
    }
}
