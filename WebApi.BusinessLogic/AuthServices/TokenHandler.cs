using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.AuthModels;

namespace WebApi.BusinessLogic.AuthServices
{
    public class TokenHandler : ITokenHandler
    {
        public IConfiguration _configuration;
        public List<Claim> Claims { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
              _configuration= configuration;
        }
        public string CreateToken(RegisterDetailsDTO loginInfo)
        {
            Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,loginInfo.UserName),
                new Claim(ClaimTypes.Role,loginInfo.Role)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
