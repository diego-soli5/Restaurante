using Restaurante.AccesoDatos.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurante.AccesoDatos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestauranteContext _context;

        public UnitOfWork(RestauranteContext context)
        {
            _context = context;
        }
        public IClienteRepository Cliente => new ClienteRepository(_context);
        public IMenuRepository Menu => new MenuRepository(_context);
        public IMesaRepository Mesa => new MesaRepository(_context);
        public IReservacionRepository Reservacion => new ReservacionRepository(_context);
        public ITipoMenuRepository TipoMenu => new TipoMenuRepository(_context);
        public IUsuarioRepository Usuario => new UsuarioRepository(_context);

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
