using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Restaurante.Web.Filters;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Models.Usuario;
using Restaurante.Web.Models;

namespace Restaurante.Web.Controllers
{
    [Authorize]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _usuarioService.ObtenerTodo(CurrentToken);

            var clientesDTO = result.Data;

            return View(clientesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegistrarDTO usuarioRegistrarDTO)
        {
            var result = await _usuarioService.Registrar(usuarioRegistrarDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpGet]
        [IsAuthenticatedFilter]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != null)
                ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string usuario, string contrasena, string returnUrl)
        {
            var result = await _usuarioService.IniciarSesion(new PeticionLoginDTO(usuario, contrasena));

            if (result.Success)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name, result.Data.TcNombre),
                    new Claim(ClaimTypes.Email,result.Data.TcCorreoElectronico),
                    new Claim("Token", result.Data.Token)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ViewData["LoginMessage"] = result.Message;

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult UnauthorizedView()
        {
            return View();
        }

        [HttpPost("Usuario/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var respuesta = new Respuesta();

            if (id == CurrentUserId)
            {
                respuesta.Message = "No puede eliminar su propio usuario.";
                respuesta.Success = false;

                return Ok(respuesta);
            }

            var result = await _usuarioService.Eliminar(id, CurrentToken);

            respuesta.Success = result.Success;
            respuesta.Message = result.Message;

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTabla()
        {
            var result = await _usuarioService.ObtenerTodo(CurrentToken);

            var clientesDTO = result.Data;

            return PartialView("_ListadoUsuariosPartial", clientesDTO);

        }
    }
}
