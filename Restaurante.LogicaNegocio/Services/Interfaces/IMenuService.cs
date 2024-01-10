using Restaurante.LogicaNegocio.DTO.Menu;
using System.Collections.Generic;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface IMenuService
    {
        public MenuDTO ObtenerPorId(int id);
        public IEnumerable<MenuDTO> ObtenerTodo();
        public bool Crear(MenuCrearDTO menuCrearDTO);
        public bool Actualizar(MenuDTO menuDTO, int id);
        public bool Eliminar(int id);
    }
}
