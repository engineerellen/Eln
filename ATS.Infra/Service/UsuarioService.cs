using System.Collections.Generic;
using System.Linq;
using ATS.Domain.Interfaces;
using ATS.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ATS.Infra.Service
{
    public class UsuarioService<TEntity> : IService<TEntity> where TEntity : BaseEntity
    {

        public string GerarTokenJWT(string email, string _issuer,string _key, string _audience)
        {
            var issuer = _issuer;
            var audience = _audience;
            var expiry = DateTime.Now.AddMinutes(120);
            var key = _key + email;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, audience: audience, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}