using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Reservacion;

namespace Restaurante.Web.Services.Interfaces
{
    public interface IReservacionService
    {
        Task<HttpRequestResult<List<ReservacionDTO>>> ObtenerTodo(string token);

        Task<HttpRequestResult<Response>> Crear(ReservacionCrearDTO reservacionDTO, string token);

        Task<HttpRequestResult<Response>> Actualizar(ReservacionDTO reservacionDTO, string token);

        Task<HttpRequestResult<Response>> Eliminar(int id, string token);
    }
}
