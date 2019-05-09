using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingApp.Infrastructure.Jwt
{
    public interface ITokenGenerator
    {
        string GenerateToken(string userName,string role);
    }
}
