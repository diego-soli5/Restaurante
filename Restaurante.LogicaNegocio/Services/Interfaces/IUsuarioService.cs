using Restaurante.LogicaNegocio.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface IUsuarioService
    {
        public IEnumerable<UsuarioDTO> ObtenerTodo();
        public ResultadoLoginDTO IniciarSesion(PeticionLoginDTO peticionLogin);
        bool Registrar(UsuarioRegistrarDTO usuarioRegistrarDTO);
        public bool Eliminar(int id);
    }
}
