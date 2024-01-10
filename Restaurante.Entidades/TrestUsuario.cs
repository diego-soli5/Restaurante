using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Restaurante.Entidades
{
    public partial class TrestUsuario : EntidadBase
    {
        //public int TnIdUsuario { get; set; }
        public string TcNombre { get; set; }
        public string TcNombreUsuario { get; set; }
        public string TcContrasena { get; set; }
        public string TcCorreoElectronico { get; set; }
    }
}
