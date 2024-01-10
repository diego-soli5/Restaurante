using Microsoft.AspNetCore.Http;
using Restaurante.Entidades;
using Restaurante.LogicaNegocio.DTO.Mesa;
using Restaurante.LogicaNegocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.LogicaNegocio.Services.Interfaces
{
    public interface IMesaService
    {
        public MesaDTO ObtenerPorId(int id);
        public IEnumerable<MesaDTO> ObtenerTodo();
        public bool Crear(MesaCrearDTO mesaCrearDTO);
        public bool Actualizar(MesaDTO mesaDTO, int id);
        public bool Eliminar(int id);
    }
}
