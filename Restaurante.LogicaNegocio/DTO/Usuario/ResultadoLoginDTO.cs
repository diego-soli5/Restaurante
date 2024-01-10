namespace Restaurante.LogicaNegocio.DTO.Usuario
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

        public string Token { get; }
        public int Id { get; }
        public string TcNombre { get; }
        public string TcCorreoElectronico { get; }
    }
}
