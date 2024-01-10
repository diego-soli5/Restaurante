using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Web.Models;
using Restaurante.Web.Models.TipoMenu;
using Restaurante.Web.Services.Interfaces;

namespace Restaurante.Web.Controllers
{
    [Authorize]
    public class TipoMenuController : BaseController
    {
        private readonly ITipoMenuService _tipoMenuService;

        public TipoMenuController(ITipoMenuService tipoMenuService)
        {
            _tipoMenuService = tipoMenuService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _tipoMenuService.ObtenerTodo(CurrentToken);

            var tipoMenusDTO = result.Data;

            return View(tipoMenusDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(TipoMenuCrearDTO tipoMenuCrearDTO)
        {
            var result = await _tipoMenuService.Crear(tipoMenuCrearDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(TipoMenuDTO tipoMenuDTO)
        {
            var result = await _tipoMenuService.Actualizar(tipoMenuDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost("TipoMenu/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _tipoMenuService.Eliminar(id, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTabla()
        {
            var result = await _tipoMenuService.ObtenerTodo(CurrentToken);

            var tipoMenusDTO = result.Data;

            return PartialView("_ListadoTipoMenuPartial", tipoMenusDTO);

        }
    }
}
