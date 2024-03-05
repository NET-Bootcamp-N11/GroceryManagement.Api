using GroceryManagement.Domain.Entities.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace GroceryManagement.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private IConfiguration _config;
        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateToken(UserDTO userDTO)
        {
            IEnumerable<int> permissionsId = new List<int>();
            if (userDTO.Role == "Admin")
                permissionsId = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8,9,10,11 };
            else if (userDTO.Role == "Client")
                permissionsId = new List<int>() { 2,3,4,5,6,7 };

            string permmisionJson = JsonSerializer.Serialize(permissionsId);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWT:ExpireDate"]!);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture),ClaimValueTypes.Integer64),

                new Claim("UserName",userDTO.UserName!),
                new Claim("Password",userDTO.Password!),
                new Claim(ClaimValueTypes.Email,userDTO.Email),
                new Claim(ClaimTypes.Role,userDTO.Role),
                new Claim("permissions",permmisionJson)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: credentials);

            string Token = new JwtSecurityTokenHandler().WriteToken(token);
            return Token;


        }
    }
}
