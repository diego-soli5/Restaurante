using Restaurante.LogicaNegocio.DTO.Cliente;
using System.Collections.Generic;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface IClienteService
    {
        public ClienteDTO ObtenerPorId(int id);
        public IEnumerable<ClienteDTO> ObtenerTodo();
        public bool Crear(ClienteCrearDTO clienteCrearDto);
        public bool Actualizar(ClienteDTO clienteDTO, int id);
        public bool Eliminar(int id);
    }
}
