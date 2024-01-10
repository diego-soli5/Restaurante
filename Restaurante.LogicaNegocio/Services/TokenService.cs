using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.Options;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurante.LogicaNegocio.Services
{
    public class TokenService : ITokenService
    {
        private readonly AuthenticationOptions _options;

        public TokenService(IOptions<AuthenticationOptions> opciones)
        {
            _options = opciones.Value;
        }

        public (string, ClaimsPrincipal) GenerarJWT(TrestUsuario usuario)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
            var sigingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sigingCredentials);

            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.TcNombre),
                new Claim(ClaimTypes.Email,usuario.TcCorreoElectronico)
            };

            //identity | principal
            var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            //payload 
            var payload = new JwtPayload(
                _options.Issuer,
                _options.Audience,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(60));

            //signature
            var token = new JwtSecurityToken(header, payload);

            return (new JwtSecurityTokenHandler().WriteToken(token), principal);
        }
    }
}
