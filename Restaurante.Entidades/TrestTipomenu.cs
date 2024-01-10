using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurante.Entidades
{
    public partial class TrestTipomenu : EntidadBase
    {
        public TrestTipomenu()
        {
            TrestMenu = new HashSet<TrestMenu>();
        }

        //public int TnIdTipoMenu { get; set; }
        public string TcDscTipoMenu { get; set; }

        public virtual ICollection<TrestMenu> TrestMenu { get; set; }
    }
}
