using Microsoft.EntityFrameworkCore;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccesoDatos.Repositories
{
    public class ReservacionRepository : GenericRepository<TrestReservacion>, IReservacionRepository
    {
        private readonly RestauranteContext _context;

        public ReservacionRepository(RestauranteContext context) : base(context)
        {
            _context = context;
        }

        public TrestReservacion ValidarExistenciaReservacion(TrestReservacion reservacion)
        {
            return _context.TrestReservacion.Where(r => r.TbEstado && 
                                                        r.TfFecReserva == reservacion.TfFecReserva && 
                                                        r.TnIdMesa == reservacion.TnIdMesa &&
                                                        r.Id != reservacion.Id)
                                            .FirstOrDefault();
        }
    }
}
