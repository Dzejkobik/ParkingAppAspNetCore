using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.Database;

namespace ParkingApp.Infrastructure.Repositories
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ParkingLotRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<ParkingLot>> GetAllParkingLotsAsync()
        {
            return await _applicationDbContext.ParkingLots.ToListAsync();
        }

        public async Task AddParkingLotAsync(ParkingLot parkingLot)
        {
            await _applicationDbContext.ParkingLots.AddAsync(parkingLot);
        }
    }
}
