using Microsoft.EntityFrameworkCore;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.AccesoDatos.Repositories
{
    public class MesaRepository : GenericRepository<TrestMesa>, IMesaRepository
    {
        public MesaRepository(RestauranteContext context) : base(context)
        {
        }
    }
}
