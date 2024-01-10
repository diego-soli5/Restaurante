using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurante.Entidades
{
    public partial class TrestMenu : EntidadBase
    {
        public TrestMenu()
        {
            TrestReservacion = new HashSet<TrestReservacion>();
        }

        //public int TnIdMenu { get; set; }
        public string TcDscMenu { get; set; }
        public int TnIdTipoMenu { get; set; }
        public decimal TdPrecio { get; set; }

        public virtual TrestTipomenu TrestTipomenu { get; set; }
        public virtual ICollection<TrestReservacion> TrestReservacion { get; set; }
    }
}
