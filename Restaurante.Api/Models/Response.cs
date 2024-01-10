namespace Restaurante.Api.Models
{
    public class Response
    {
        public Response() { }
        public Response(string mensaje)
        {
            Message = mensaje;
        }
        public Response(object datos, string mensaje)
        {
            Data = datos;
            Message = mensaje;
        }

        public string Message { get; set; }
        public object Data { get; set; }
    }
}
