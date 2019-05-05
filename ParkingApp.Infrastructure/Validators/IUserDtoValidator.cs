using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Infrastructure.DTO;
using ParkingApp.Infrastructure.ServicesResults;

namespace ParkingApp.Infrastructure.Validators
{
    public interface IUserDtoValidator
    {
        ServiceResult ValidateUserDto(UserDto userDto);
    }
}
