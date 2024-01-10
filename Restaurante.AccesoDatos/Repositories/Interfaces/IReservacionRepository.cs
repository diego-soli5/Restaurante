using Restaurante.Entidades;

namespace Restaurante.AccesoDatos.Repositories.Interfaces
{
    public interface IReservacionRepository : IGenericRepository<TrestReservacion>
    {
        TrestReservacion ValidarExistenciaReservacion(TrestReservacion reservacion);
    }
}
