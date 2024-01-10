using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Web.Models;
using Restaurante.Web.Models.Cliente;
using Restaurante.Web.Services.Interfaces;

namespace Restaurante.Web.Controllers
{
    [Authorize]
    public class ClienteController : BaseController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _clienteService.ObtenerTodo(CurrentToken);

            var clientesDTO = result.Data;

            return View(clientesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ClienteCrearDTO clienteCrearDTO)
        {
            var result = await _clienteService.Crear(clienteCrearDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(ClienteDTO clienteDTO)
        {
            var result = await _clienteService.Actualizar(clienteDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost("Cliente/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _clienteService.Eliminar(id, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTabla()
        {
            var result = await _clienteService.ObtenerTodo(CurrentToken);

            var clientesDTO = result.Data;

            return PartialView("_ListadoClientePartial", clientesDTO);

        }
    }
}
