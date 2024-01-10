namespace Restaurante.Web.Models.Usuario
{
    public class ResultadoLoginDTO
    {
        public ResultadoLoginDTO() { }

        public ResultadoLoginDTO(string token, int id, string tcNombre, string tcCorreoElectronico)
        {
            Id = id;
            Token = token;
            TcNombre = tcNombre;
            TcCorreoElectronico = tcCorreoElectronico;
        }

        public int Id { get; set; }
        public string Token { get; set; }
        public string TcNombre { get; set; }
        public string TcCorreoElectronico { get; set; }
    }
}
