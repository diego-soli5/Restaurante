using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Reservacion;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Services
{
    public class ReservacionService : BaseService, IReservacionService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiRoutesProvider _routesProvider;

        public ReservacionService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            _httpClientService = httpClientService;
            _routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<List<ReservacionDTO>>> ObtenerTodo(string token)
        {
            string url = _routesProvider.Reservacion.ObtenerTodo;

            var result = await _httpClientService.Get<List<ReservacionDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Crear(ReservacionCrearDTO reservacionDTO, string token)
        {
            string url = _routesProvider.Reservacion.Crear;

            var result = await _httpClientService.Post<Response>(url, reservacionDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Actualizar(ReservacionDTO reservacionDTO, string token)
        {
            string url = _routesProvider.Reservacion.Actualizar + $"/{reservacionDTO.Id}";

            var result = await _httpClientService.Put<Response>(url, reservacionDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Eliminar(int id, string token)
        {
            string url = _routesProvider.Reservacion.Eliminar + $"/{id}";

            var result = await _httpClientService.Delete<Response>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

    }
}
