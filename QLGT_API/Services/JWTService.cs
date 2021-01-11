using Microsoft.IdentityModel.Tokens;
using QLGT_API.Constants;
using QLGT_API.Model;
using QLGT_API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QLGT_API.Services
{
    public class JWTService
    {
        public string GenerateAccessToken(string authSecret, UserModel userModel, DateTime accessTokenExpiration)
        {

            var claims = new[] {
                new Claim(Key.JWTUserIdKey, userModel.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: claims,
                                              expires: accessTokenExpiration,
                                              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
    }
}
