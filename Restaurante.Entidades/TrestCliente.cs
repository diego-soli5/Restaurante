using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurante.Entidades
{
    public partial class TrestCliente : EntidadBase
    {
        public TrestCliente()
        {
            TrestReservacion = new HashSet<TrestReservacion>();
        }

        //public int TnIdCliente { get; set; }
        public string TcNombre { get; set; }
        public string TcAp1 { get; set; }
        public string TcAp2 { get; set; }
        public string TcNumTelefono { get; set; }
        public string TcCorreoElectronico { get; set; }

        public virtual ICollection<TrestReservacion> TrestReservacion { get; set; }
    }
}
