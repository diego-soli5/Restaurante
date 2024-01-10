using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccesoDatos.Repositories
{
    public class GenericRepository<TEntidad> : IGenericRepository<TEntidad> where TEntidad : EntidadBase
    {
        protected readonly DbSet<TEntidad> _dbEntity;

        public GenericRepository(DbContext context)
        {
            _dbEntity = context.Set<TEntidad>();
        }

        public IEnumerable<TEntidad> ObtenerTodo(string includeProperties = null)
        {
            IQueryable<TEntidad> query = _dbEntity;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.Where(t => t.TbEstado)
                        .AsEnumerable(); //Devuelve solo los que estan activos
        }

        public TEntidad ObtenerPorId(int id, string includeProperties = null)
        {
            IQueryable<TEntidad> query = _dbEntity;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.Where(t => t.TbEstado)
                        .FirstOrDefault(x => x.Id == id); //Devuelve solo los que estan activos
        }

        public void Crear(TEntidad entidad)
        {
            _dbEntity.Add(entidad);
        }

        public void Eliminar(TEntidad entidad)
        {
            _dbEntity.Remove(entidad);
        }

        public void Actualizar(TEntidad entidad)
        {
            _dbEntity.Update(entidad);
        }
    }
}
