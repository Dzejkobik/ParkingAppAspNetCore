using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingApp.Core.Domain;

namespace ParkingApp.Infrastructure.Repositories
{
    public interface IParkingLotRepository
    {
        Task<IEnumerable<ParkingLot>> GetAllParkingLotsAsync();
        Task AddParkingLotAsync(ParkingLot parkingLot);
    }
}
