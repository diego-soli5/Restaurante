using System;

namespace Restaurante.LogicaNegocio.DTO.Reservacion
{
    public class ReservacionCrearDTO
    {
        public int TnIdCliente { get; set; }
        public int TnIdMesa { get; set; }
        public int TnIdMenu { get; set; }
        public int TnCantidad { get; set; }
        public DateTime TfFecReserva { get; set; }
    }
}
