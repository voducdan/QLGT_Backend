using Microsoft.IdentityModel.Tokens;
using QLGT_API.Constants;
using QLGT_API.Model;
using QLGT_API.Models;
using QLGT_API.Repository;
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
        private UserService userService;

        public string GenerateAccessToken(string authSecret, UserModel userModel, DateTime accessTokenExpiration)
        {

            var claims = new[] {
                new Claim(Key.JWTUserIdKey, userModel.ID_ACCOUNT.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSecret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: claims,
                                              expires: accessTokenExpiration,
                                              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel GetUser(string token)
        {

            UserModel? user = null;
            var validator = new JwtSecurityTokenHandler();
            var jwtToken = validator.ReadJwtToken(token);
            var userClaim = jwtToken.Claims.FirstOrDefault(ww => ww.Type == Key.JWTUserIdKey);
            if (userClaim != null)
            {
                int userId = Convert.ToInt32(userClaim.Value);
                user = userService.GetUser_id(userId);
                if (user != null) return user;
                
            }
           return null;
        }       

    }
}
