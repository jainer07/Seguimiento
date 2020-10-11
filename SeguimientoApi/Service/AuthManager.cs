using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace SeguimientoApi.Service
{
    public class AuthManager : IAuthManager
    {
        private readonly string Key;

        public AuthManager(string key)
        {
            Key = key;   
        }

        public string Authenticate(string userName, string pass)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenKey = Encoding.ASCII.GetBytes(Key);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(TokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var Token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(Token);
        }
    }
}
