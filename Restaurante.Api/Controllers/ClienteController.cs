using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Api.Filters;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.DTO.Cliente;
using Restaurante.LogicaNegocio.Services.Interfaces;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet(nameof(Obtener) + "/{id}")]
        public IActionResult Obtener(int id)
        {
            var clienteDTO = _clienteService.ObtenerPorId(id);

            var respuesta = new Response(clienteDTO, null);

            return Ok(respuesta);
        }

        [HttpGet(nameof(ObtenerTodo))]
        public IActionResult ObtenerTodo()
        {
            var clientesDTO = _clienteService.ObtenerTodo();

            var respuesta = new Response(clientesDTO, null);

            return Ok(respuesta);
        }

        [HttpPost(nameof(Crear))]
        public IActionResult Crear(ClienteCrearDTO clienteCrearDTO)
        {
            bool result = _clienteService.Crear(clienteCrearDTO);

            var respuesta = new Response("Cliente creado correctamente.");

            return Ok(respuesta);
        }

        [HttpPut(nameof(Actualizar) + "/{id}")]
        public IActionResult Actualizar(int id, ClienteDTO clienteDTO)
        {
            bool result = _clienteService.Actualizar(clienteDTO, id);

            var respuesta = new Response("Cliente actualizado correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Eliminar) + "/{id}")]
        public IActionResult Eliminar(int id)
        {
            bool result = _clienteService.Eliminar(id);

            var respuesta = new Response("Cliente eliminado correctamente.");

            return Ok(respuesta);
        }
    }
}
