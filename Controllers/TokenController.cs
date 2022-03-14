using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GerenciadorDeCursos.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorDeCursos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController
    {
        public static string GenerateToken(Usuario usuario)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(Settings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Role, usuario.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(8),                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}