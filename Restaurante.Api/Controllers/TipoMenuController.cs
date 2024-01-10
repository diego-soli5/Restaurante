using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Api.Filters;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.DTO.TipoMenu;
using Restaurante.LogicaNegocio.Services.Interfaces;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class TipoMenuController : ControllerBase
    {
        private readonly ITipoMenuService _tipoMenuService;

        public TipoMenuController(ITipoMenuService tipoMenuService)
        {
            _tipoMenuService = tipoMenuService;
        }

        [HttpGet(nameof(Obtener) + "/{id}")]
        public IActionResult Obtener(int id)
        {
            var tipoMenuDTO = _tipoMenuService.ObtenerPorId(id);

            var respuesta = new Response(tipoMenuDTO, null);

            return Ok(respuesta);
        }

        [HttpGet(nameof(ObtenerTodo))]
        public IActionResult ObtenerTodo()
        {
            var tipoMenuDTO = _tipoMenuService.ObtenerTodo();

            var respuesta = new Response(tipoMenuDTO, null);

            return Ok(respuesta);
        }

        [HttpPost(nameof(Crear))]
        public IActionResult Crear(TipoMenuCrearDTO tipoMenuCrearDTO)
        {
            bool result = _tipoMenuService.Crear(tipoMenuCrearDTO);

            var respuesta = new Response("Tipo de menu creado correctamente.");

            return Ok(respuesta);
        }

        [HttpPut(nameof(Actualizar) + "/{id}")]
        public IActionResult Actualizar(int id, TipoMenuDTO tipoMenuDTO)
        {
            bool result = _tipoMenuService.Actualizar(tipoMenuDTO, id);

            var respuesta = new Response("Tipo de menu actualizado correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Eliminar) + "/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool result = _tipoMenuService.Eliminar(id);

            var respuesta = new Response("Tipo de menu eliminado correctamente.");

            return Ok(respuesta);
        }
    }
}
