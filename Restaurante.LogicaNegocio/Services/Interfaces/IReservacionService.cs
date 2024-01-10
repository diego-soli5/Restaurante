using Microsoft.AspNetCore.Http;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Reservacion;
using Restaurante.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface IReservacionService
    {
        public ReservacionDTO ObtenerPorId(int id);
        public IEnumerable<ReservacionDTO> ObtenerTodo();
        public bool Crear(ReservacionCrearDTO reservacionCrearDTO);
        public bool Actualizar(ReservacionDTO reservacionDTO, int id);
        public bool Eliminar(int id);
    }
}
