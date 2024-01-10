using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Api.Filters;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.DTO.Menu;
using Restaurante.LogicaNegocio.Services.Interfaces;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet(nameof(Obtener) + "/{id}")]
        public IActionResult Obtener(int id)
        {
            var menuDTO = _menuService.ObtenerPorId(id);

            var respuesta = new Response(menuDTO, null);

            return Ok(respuesta);
        }

        [HttpGet(nameof(ObtenerTodo))]
        public IActionResult ObtenerTodo()
        {
            var menuDTO = _menuService.ObtenerTodo();

            var respuesta = new Response(menuDTO, null);

            return Ok(respuesta);
        }

        [HttpPost(nameof(Crear))]
        public IActionResult Crear(MenuCrearDTO menuCrearDTO)
        {
            bool result = _menuService.Crear(menuCrearDTO);

            var respuesta = new Response("Menu creado correctamente.");

            return Ok(respuesta);
        }

        [HttpPut(nameof(Actualizar) + "/{id}")]
        public IActionResult Actualizar(int id, MenuDTO menuDTO)
        {
            bool result = _menuService.Actualizar(menuDTO, id);

            var respuesta = new Response("Menu actualizado correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Eliminar) + "/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool result = _menuService.Eliminar(id);

            var respuesta = new Response("Menu eliminado correctamente.");

            return Ok(respuesta);
        }
    }
}
