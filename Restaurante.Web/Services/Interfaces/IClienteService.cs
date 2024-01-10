using Restaurante.Web.Models.Cliente;
using Restaurante.Web.Models.HttpClientService;

namespace Restaurante.Web.Services.Interfaces
{
    public interface IClienteService
    {
        Task<HttpRequestResult<List<ClienteDTO>>> ObtenerTodo(string token);

        Task<HttpRequestResult<Response>> Crear(ClienteCrearDTO clienteCrearDTO, string token);

        Task<HttpRequestResult<Response>> Actualizar(ClienteDTO clienteDTO, string token);

        Task<HttpRequestResult<Response>> Eliminar(int id, string token);
    }
}
