using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurante.Entidades
{
    public partial class TrestReservacion : EntidadBase
    {
        //public int TnNumReservacion { get; set; }
        public int TnIdCliente { get; set; }
        public int TnIdMesa { get; set; }
        public int TnIdMenu { get; set; }
        public int TnCantidad { get; set; }
        public DateTime TfFecReserva { get; set; }

        public virtual TrestCliente TnIdClienteNavigation { get; set; }
        public virtual TrestMenu TnIdMenuNavigation { get; set; }
        public virtual TrestMesa TnIdMesaNavigation { get; set; }
    }
}
