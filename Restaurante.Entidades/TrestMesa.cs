using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurante.Entidades
{
    public partial class TrestMesa : EntidadBase
    {
        public TrestMesa()
        {
            TrestReservacion = new HashSet<TrestReservacion>();
        }

        //public int TnIdMesa { get; set; }
        public string TcDscMesa { get; set; }

        public virtual ICollection<TrestReservacion> TrestReservacion { get; set; }
    }
}
