using System;
using System.Collections.Generic;
using System.Text;
using ParkingApp.Core.Domain;
using ParkingApp.Infrastructure.DTO;

namespace ParkingApp.Infrastructure.Mappers
{
    public static class Mapper
    {
        public static User Map(UserDto userDto)
        {
            var user = new User();
            user.Email = userDto.Email;
            user.UserName = userDto.UserName;
            return user;
        }
    }
}
