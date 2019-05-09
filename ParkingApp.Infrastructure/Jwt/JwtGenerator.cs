using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ParkingApp.Infrastructure.Jwt
{
    public class JwtGenerator : ITokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IdentityOptions _identityOptions;

        public JwtGenerator(IOptions<JwtSettings> jwtSettings,IdentityOptions identityOptions)
        {
            _jwtSettings = jwtSettings.Value;
            _identityOptions = identityOptions;
        }

        public string GenerateToken(string userName,string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.NameId,userName),
                new Claim(ClaimsIdentity.DefaultNameClaimType,userName),
                new Claim(_identityOptions.ClaimsIdentity.RoleClaimType,role), 
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Audience,
                claims: claims,
                expires:DateTime.Now.AddMonths(3),
                signingCredentials:credentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
