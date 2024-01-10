using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Menu;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Services
{
    public class MenuService : BaseService, IMenuService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiRoutesProvider _routesProvider;

        public MenuService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            _httpClientService = httpClientService;
            _routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<List<MenuDTO>>> ObtenerTodo(string token)
        {
            string url = _routesProvider.Menu.ObtenerTodo;

            var result = await _httpClientService.Get<List<MenuDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Crear(MenuCrearDTO menuCrearDTO, string token)
        {
            string url = _routesProvider.Menu.Crear;

            var result = await _httpClientService.Post<Response>(url, menuCrearDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Actualizar(MenuDTO menuDTO, string token)
        {
            string url = _routesProvider.Menu.Actualizar + $"/{menuDTO.Id}";

            var result = await _httpClientService.Put<Response>(url, menuDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Eliminar(int id, string token)
        {
            string url = _routesProvider.Menu.Eliminar + $"/{id}";

            var result = await _httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
