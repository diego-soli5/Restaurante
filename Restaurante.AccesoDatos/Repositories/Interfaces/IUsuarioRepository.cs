using Restaurante.Entidades;

namespace Restaurante.AccesoDatos.Repositories.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<TrestUsuario>
    {
        public TrestUsuario ObtenerPorNombreUsuario(string nombreUsuario);
        public TrestUsuario ObtenerPorCorreoElectronico(string correoElectronico);
    }
}
