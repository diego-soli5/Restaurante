using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Web.Models;
using Restaurante.Web.Models.Mesa;
using Restaurante.Web.Services.Interfaces;

namespace Restaurante.Web.Controllers
{
    [Authorize]
    public class MesaController : BaseController
    {
        private readonly IMesaService _mesaService;
        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mesaService.ObtenerTodo(CurrentToken);

            var mesasDTO = result.Data;

            return View(mesasDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MesaCrearDTO mesaCrearDTO)
        {
            var result = await _mesaService.Crear(mesaCrearDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(MesaDTO mesaDTO)
        {
            var result = await _mesaService.Actualizar(mesaDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost("Mesa/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _mesaService.Eliminar(id, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTabla()
        {
            var result = await _mesaService.ObtenerTodo(CurrentToken);

            var mesasDTO = result.Data;

            return PartialView("_ListadoMesasPartial", mesasDTO);

        }
    }
}
