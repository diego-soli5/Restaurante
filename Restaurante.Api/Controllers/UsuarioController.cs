using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Api.Filters;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.DTO.Usuario;
using Restaurante.LogicaNegocio.Services.Interfaces;
using System.Security.Claims;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [TypeFilter(typeof(ExceptionManagerFilter))]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioServicio)
        {
            _usuarioService = usuarioServicio;
        }

        [HttpGet(nameof(ObtenerTodo))]
        public IActionResult ObtenerTodo()
        {
            var usuariosDTO = _usuarioService.ObtenerTodo();

            return Ok(new Response(usuariosDTO, null));
        }

        [HttpPost(nameof(IniciarSesion))]
        [AllowAnonymous]
        public IActionResult IniciarSesion(PeticionLoginDTO login)
        {
            var resultado = _usuarioService.IniciarSesion(login);

            return Ok(new Response(resultado, null));
        }

        [HttpPost(nameof(Registrar))]
        public IActionResult Registrar(UsuarioRegistrarDTO usuarioRegistrarDTO)
        {
            var resultado = _usuarioService.Registrar(usuarioRegistrarDTO);

            var respuesta = new Response("Usuario registrado correctamente.");

            return Ok(respuesta);
        }

        [HttpDelete(nameof(Eliminar) + "/{id}")]
        public IActionResult Eliminar(int id)
        {
            var resultado = _usuarioService.Eliminar(id);

            var respuesta = new Response("Usuario eliminado correctamente.");

            return Ok(respuesta);
        }
    }
}
