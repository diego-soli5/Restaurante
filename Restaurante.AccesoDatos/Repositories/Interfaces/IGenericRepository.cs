using Restaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccesoDatos.Repositories.Interfaces
{
    public interface IGenericRepository<TEntidad> where TEntidad : EntidadBase
    {
        TEntidad ObtenerPorId(int id, string includeProperties = null);
        IEnumerable<TEntidad> ObtenerTodo(string includeProperties = null);
        void Crear(TEntidad entidad);
        void Actualizar(TEntidad entidad);
        void Eliminar(TEntidad entidad);
    }
}
