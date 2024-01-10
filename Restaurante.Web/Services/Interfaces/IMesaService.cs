using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Mesa;

namespace Restaurante.Web.Services.Interfaces
{
    public interface IMesaService
    {
        Task<HttpRequestResult<List<MesaDTO>>> ObtenerTodo(string token);
        Task<HttpRequestResult<Response>> Crear(MesaCrearDTO mesaCrearDTO, string token);
        Task<HttpRequestResult<Response>> Actualizar(MesaDTO mesaDTO, string token);
        Task<HttpRequestResult<Response>> Eliminar(int id, string token);
    }
}
