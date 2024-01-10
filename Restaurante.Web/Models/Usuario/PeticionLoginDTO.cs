namespace Restaurante.Web.Models.Usuario
{
    public class PeticionLoginDTO
    {
        public PeticionLoginDTO()
        {
        }

        public PeticionLoginDTO(string tcNombreUsuario, string tcContrasena)
        {
            TcNombreUsuario = tcNombreUsuario;
            TcContrasena = tcContrasena;
        }

        public string TcNombreUsuario { get; set; }
        public string TcContrasena { get; set; }
    }
}
