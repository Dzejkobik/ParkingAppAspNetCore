using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Infrastructure.DTO;

namespace ParkingApp.Infrastructure.Services
{
    public interface IParkingLotService
    {
        List<ParkingLotDto> GetAllParkingLots();
    }
}
