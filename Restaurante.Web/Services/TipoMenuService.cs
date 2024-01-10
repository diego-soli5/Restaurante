using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.TipoMenu;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Services
{
    public class TipoMenuService : BaseService, ITipoMenuService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiRoutesProvider _routesProvider;

        public TipoMenuService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            _httpClientService = httpClientService;
            _routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<List<TipoMenuDTO>>> ObtenerTodo(string token)
        {
            string url = _routesProvider.TipoMenu.ObtenerTodo;

            var result = await _httpClientService.Get<List<TipoMenuDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Crear(TipoMenuCrearDTO tipoMenuCrearDTO, string token)
        {
            string url = _routesProvider.TipoMenu.Crear;

            var result = await _httpClientService.Post<Response>(url, tipoMenuCrearDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Actualizar(TipoMenuDTO tipoMenuDTO, string token)
        {
            string url = _routesProvider.TipoMenu.Actualizar + $"/{tipoMenuDTO.Id}";

            var result = await _httpClientService.Put<Response>(url, tipoMenuDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Eliminar(int id, string token)
        {
            string url = _routesProvider.TipoMenu.Eliminar + $"/{id}";

            var result = await _httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

    }
}
