using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Services
{
    public interface IParkingLotService
    {
        Task<ServiceResult<List<ParkingLotDtoGet>>> GetAllParkingLotsAsync();
    }
}
