using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Api.Filters;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.DTO.Reservacion;
using Restaurante.LogicaNegocio.Services.Interfaces;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class ReservacionController : ControllerBase
    {
        private readonly IReservacionService _reservacionService;

        public ReservacionController(IReservacionService reservacionService)
        {
            _reservacionService = reservacionService;
        }

        [HttpGet(nameof(Obtener) + "/{id}")]
        public IActionResult Obtener(int id)
        {
            var reservacionDTO = _reservacionService.ObtenerPorId(id);

            var respuesta = new Response(reservacionDTO, null);

            return Ok(respuesta);
        }

        [HttpGet(nameof(ObtenerTodo))]
        public IActionResult ObtenerTodo()
        {
            var reservacionDTO = _reservacionService.ObtenerTodo();

            var respuesta = new Response(reservacionDTO, null);

            return Ok(respuesta);
        }

        [HttpPost(nameof(Crear))]
        public IActionResult Crear(ReservacionCrearDTO reservacionCrearDTO)
        {
            bool result = _reservacionService.Crear(reservacionCrearDTO);

            var respuesta = new Response("Reservación creada correctamente.");

            return Ok(respuesta);
        }

        [HttpPut(nameof(Actualizar) + "/{id}")]
        public IActionResult Actualizar(int id, ReservacionDTO reservacionDTO)
        {
            bool result = _reservacionService.Actualizar(reservacionDTO, id);

            var respuesta = new Response("Reservación actualizada correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Eliminar) + "/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool result = _reservacionService.Eliminar(id);

            var respuesta = new Response("Reservación eliminada correctamente.");

            return Ok(respuesta);
        }
    }
}
