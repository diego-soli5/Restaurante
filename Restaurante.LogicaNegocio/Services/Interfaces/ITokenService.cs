using Restaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface ITokenService
    {
        public (string, ClaimsPrincipal) GenerarJWT(TrestUsuario usuario);
    }
}
