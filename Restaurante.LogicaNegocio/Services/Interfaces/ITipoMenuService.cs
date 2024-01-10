using Microsoft.AspNetCore.Http;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.TipoMenu;
using Restaurante.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface ITipoMenuService
    {
        public TipoMenuDTO ObtenerPorId(int id);

        public IEnumerable<TipoMenuDTO> ObtenerTodo();

        public bool Crear(TipoMenuCrearDTO tipoMenuCrearDTO);

        public bool Actualizar(TipoMenuDTO tipoMenuDTO, int id);

        public bool Eliminar(int id);
    }
}
