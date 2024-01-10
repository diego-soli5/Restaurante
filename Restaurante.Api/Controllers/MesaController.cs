using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Api.Filters;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.DTO.Menu;
using Restaurante.LogicaNegocio.DTO.Mesa;
using Restaurante.LogicaNegocio.Services.Interfaces;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet(nameof(Obtener) + "/{id}")]
        public IActionResult Obtener(int id)
        {
            var mesaDTO = _mesaService.ObtenerPorId(id);

            var respuesta = new Response(mesaDTO, null);

            return Ok(respuesta);
        }

        [HttpGet(nameof(ObtenerTodo))]
        public IActionResult ObtenerTodo()
        {
            var mesaDTO = _mesaService.ObtenerTodo();

            var respuesta = new Response(mesaDTO, null);

            return Ok(respuesta);
        }

        [HttpPost(nameof(Crear))]
        public IActionResult Crear(MesaCrearDTO mesaCrearDTO)
        {
            bool result = _mesaService.Crear(mesaCrearDTO);

            var respuesta = new Response("Mesa creada correctamente.");

            return Ok(respuesta);
        }

        [HttpPut(nameof(Actualizar) + "/{id}")]
        public IActionResult Actualizar(int id, MesaDTO mesaDTO)
        {
            bool result = _mesaService.Actualizar(mesaDTO, id);
            
            var respuesta = new Response("Mesa actualizada correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Eliminar) + "/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool result = _mesaService.Eliminar(id);

            var respuesta = new Response("Mesa eliminada correctamente.");

            return Ok(respuesta);
        }
    }
}
