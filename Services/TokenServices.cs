using System;
using System.IndentityModel.Token.Jwt;
using Microsoft.IndentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using shop.Models;


namespace Shop.Services{
    public static class TokenServices
    {
        public static string GenerateToken(User user)
        {
           var tokenHandler = new JwtSecurityTokenHandler();
           var key = Encoding.ASCII.GetBytes(Settings.Secret);
           var tokenDescriptor = new SecurityTokenDescriptor;
           {
               Subject = new ClaimsIdentity(new Claim[]
               {
                   new Claim(ClaimTypes.Name, user.UserName.ToString()),
                   new Claim(ClaimTypes.Role, user.Role.ToString()),

               });
                DateTime Expires = DateTime.UtcNow.AddHours(2);
                SigningCredentials = 
               new SigningCredentials(
                   new SymmetricSecurityKey (Key), 
                   SecurityAlgorithms.HmacSha256Signature);

           };

           var token = tokenHandler.CreateToken(tokenDescriptor);
           return tokenHandler.WriteToken(token);


        }
    }
}