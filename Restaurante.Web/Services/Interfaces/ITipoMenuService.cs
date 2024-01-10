using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.TipoMenu;

namespace Restaurante.Web.Services.Interfaces
{
    public interface ITipoMenuService
    {
        Task<HttpRequestResult<List<TipoMenuDTO>>> ObtenerTodo(string token);

        Task<HttpRequestResult<Response>> Crear(TipoMenuCrearDTO mesaCrearDTO, string token);

        Task<HttpRequestResult<Response>> Actualizar(TipoMenuDTO mesaDTO, string token);

        Task<HttpRequestResult<Response>> Eliminar(int id, string token);
    }
}
