using Microsoft.EntityFrameworkCore;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurante.AccesoDatos.Repositories
{
    public class UsuarioRepository : GenericRepository<TrestUsuario>, IUsuarioRepository
    {
        private readonly RestauranteContext _context;

        public UsuarioRepository(RestauranteContext context) : base(context)
        {
            _context = context;
        }

        public TrestUsuario ObtenerPorNombreUsuario(string nombreUsuario)
        {
            return _context.TrestUsuario.FirstOrDefault(u => u.TcNombreUsuario == nombreUsuario && u.TbEstado);
        }

        public TrestUsuario ObtenerPorCorreoElectronico(string correoElectronico)
        {
            return _context.TrestUsuario.FirstOrDefault(u => u.TcCorreoElectronico == correoElectronico && u.TbEstado);
        }
    }
}
