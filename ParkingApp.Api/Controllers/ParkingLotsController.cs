using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ParkingApp.Infrastructure.Jwt;
using ParkingApp.Infrastructure.Services;

namespace ParkingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotsController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;

        public ParkingLotsController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllParkingLots()
        {
            var list = await _parkingLotService.GetAllParkingLotsAsync();
            return Ok(list);
        }

        [HttpGet("ForAdmin")]
        [AuthorizeToken(Roles = "Admin")]
        public async Task<ActionResult> AddParkingLot()
        {
            return new ObjectResult(new
            {
                text = "xd"
            });
        }
    }
}
