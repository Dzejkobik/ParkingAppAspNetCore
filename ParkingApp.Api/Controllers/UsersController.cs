using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.Services;

namespace ParkingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser([FromBody] UserDto userDto)
        {
            var serviceResult = await _userService.CreateUserAsync(userDto);
            if (serviceResult.IsSuccessful)
            {
                return Ok();
            }

            return BadRequest(serviceResult.Message);
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignInUser([FromBody] UserDto userDto)
        {
            var serviceResult = await _userService.SignInAsync(userDto);
            if (serviceResult.IsSuccessful)
            {
                return Ok(serviceResult.Object);
            }

            return BadRequest(serviceResult.Message);
        }
    }
}
