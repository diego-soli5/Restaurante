using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Mesa;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Services
{
    public class MesaService : BaseService, IMesaService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiRoutesProvider _routesProvider;

        public MesaService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            _httpClientService = httpClientService;
            _routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<List<MesaDTO>>> ObtenerTodo(string token)
        {
            string url = _routesProvider.Mesa.ObtenerTodo;

            var result = await _httpClientService.Get<List<MesaDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Crear(MesaCrearDTO mesaCrearDTO, string token)
        {
            string url = _routesProvider.Mesa.Crear;

            var result = await _httpClientService.Post<Response>(url, mesaCrearDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Actualizar(MesaDTO mesaDTO, string token)
        {
            string url = _routesProvider.Mesa.Actualizar + $"/{mesaDTO.Id}";

            var result = await _httpClientService.Put<Response>(url, mesaDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Eliminar(int id, string token)
        {
            string url = _routesProvider.Mesa.Eliminar + $"/{id}";

            var result = await _httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
