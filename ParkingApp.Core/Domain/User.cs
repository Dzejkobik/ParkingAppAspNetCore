using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace ParkingApp.Core.Domain
{
    public class User : IdentityUser
    {
        public ParkingSpot ParkingSpot { get; set; }
        public Transaction Transaction { get; set; }
    }
}
