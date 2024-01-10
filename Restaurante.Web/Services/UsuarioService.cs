using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Usuario;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly ApiRoutesProvider _routesProvider;

        public UsuarioService(IHttpClientService httpClientService,
                              ApiRoutesProvider routesProvider)
        {
            _httpClientService = httpClientService;
            _routesProvider = routesProvider;
        }

        public async Task<HttpRequestResult<List<UsuarioDTO>>> ObtenerTodo(string token)
        {
            string url = _routesProvider.Usuario.ObtenerTodo;

            var result = await _httpClientService.Get<List<UsuarioDTO>>(url, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult<ResultadoLoginDTO>> IniciarSesion(PeticionLoginDTO peticionLoginDTO)
        {
            string url = _routesProvider.Usuario.IniciarSesion;

            var result = await _httpClientService.Post<ResultadoLoginDTO>(url, peticionLoginDTO);

            CheckRequestResult(result, false);

            return result;
        }

        public async Task<HttpRequestResult<Response>> Registrar(UsuarioRegistrarDTO usuarioRegistrarDTO, string token)
        {
            string url = _routesProvider.Usuario.Registrar;

            var result = await _httpClientService.Post<Response>(url, usuarioRegistrarDTO, authToken: token);

            CheckRequestResult(result);

            return result;
        }

        public async Task<HttpRequestResult> Eliminar(int id, string token)
        {
            string url = _routesProvider.Usuario.Eliminar + $"/{id}";

            var result = await _httpClientService.Delete<Response>(url,authToken: token);

            CheckRequestResult(result);

            return result;
        }
    }
}
