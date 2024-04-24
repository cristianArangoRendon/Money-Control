using Microsoft.IdentityModel.Tokens;
using MoneyControl.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoneyControl.Infraestructure.Helpers
{
    public static class GenerateTokenHelper
    {
        public static string GenerateToken(UserInfoDTO User, string Signature, int Hours)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                       new Claim("name", User.name ?? ""),
                       new Claim("LastName", User.lastName ?? ""),
                       new Claim(ClaimTypes.Email, User.email ?? ""),
                       new Claim("id", User.id.ToString()),
                       new Claim("age", User.age.ToString())
                    }
                    ),
                Expires = DateTime.UtcNow.AddHours(Hours),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
