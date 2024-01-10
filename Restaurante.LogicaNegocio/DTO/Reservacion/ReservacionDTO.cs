using System;

namespace Restaurante.LogicaNegocio.DTO.Reservacion
{
    public class ReservacionDTO
    {
        public int Id { get; set; } //Id
        public int TnIdCliente { get; set; }
        public int TnIdMesa { get; set; }
        public int TnIdMenu { get; set; }
        public int TnCantidad { get; set; }
        public DateTime TfFecReserva { get; set; }

        //Cliente
        public string TcNombre { get; set; }

        //Mesa
        public string TcDscMesa { get; set; }

        //Menu
        public string TcDscMenu { get; set; }
    }
}
