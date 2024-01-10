using Restaurante.Web.Models.Cliente;
using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiRoutesProvider _routesProvider;

        public ClienteService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            _httpClientService = httpClientService;
            _routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<List<ClienteDTO>>> ObtenerTodo(string token)
        {
            string url = _routesProvider.Cliente.ObtenerTodo;

            var result = await _httpClientService.Get<List<ClienteDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Crear(ClienteCrearDTO clienteCrearDTO, string token)
        {
            string url = _routesProvider.Cliente.Crear;

            var result = await _httpClientService.Post<Response>(url, clienteCrearDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Actualizar(ClienteDTO clienteDTO, string token)
        {
            string url = _routesProvider.Cliente.Actualizar + $"/{clienteDTO.Id}";

            var result = await _httpClientService.Put<Response>(url, clienteDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Eliminar(int id, string token)
        {
            string url = _routesProvider.Cliente.Eliminar + $"/{id}";

            var result = await _httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
