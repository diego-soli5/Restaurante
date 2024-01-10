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
    public class ClienteRepository : GenericRepository<TrestCliente>, IClienteRepository
    {
        public ClienteRepository(RestauranteContext context) : base(context)
        {
        }
    }
}
