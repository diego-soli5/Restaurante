using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Menu;

namespace Restaurante.Web.Services.Interfaces
{
    public interface IMenuService
    {
        public Task<HttpRequestResult<List<MenuDTO>>> ObtenerTodo(string token);

        public Task<HttpRequestResult<Response>> Crear(MenuCrearDTO menuCrearDTO, string token);

        public Task<HttpRequestResult<Response>> Actualizar(MenuDTO menuDTO, string token);

        public Task<HttpRequestResult<Response>> Eliminar(int id, string token);
    }
}
