using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Web.Models;
using Restaurante.Web.Models.Reservacion;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.ViewModels.Reservacion;

namespace Restaurante.Web.Controllers
{
    [Authorize]
    public class ReservacionController : BaseController
    {
        private readonly IReservacionService _reservacionService;
        private readonly IClienteService _clienteService;
        private readonly IMesaService _mesaService;
        private readonly IMenuService _menuService;

        public ReservacionController(IReservacionService reservacionService,
                                     IClienteService clienteService,
                                     IMesaService mesaService,
                                     IMenuService menuService)
        {
            _reservacionService = reservacionService;
            _clienteService = clienteService;
            _mesaService = mesaService;
            _menuService = menuService;
        }

        public async Task<IActionResult> Index(string op)
        {
            var reservacionResult = await _reservacionService.ObtenerTodo(CurrentToken);
            var clienteResult = await _clienteService.ObtenerTodo(CurrentToken);
            var mesaResult = await _mesaService.ObtenerTodo(CurrentToken);
            var menuResult = await _menuService.ObtenerTodo(CurrentToken);
   

            var lstCliente = new List<SelectListItem>();
            var lstMesa = new List<SelectListItem>();
            var lstMenu = new List<SelectListItem>();

            clienteResult.Data.ToList().ForEach(ms =>
            {
                lstCliente.Add(new SelectListItem($"{ms.TcNombre} {ms.TcAp1} {ms.TcAp2}", ms.Id.ToString()));
            });

            mesaResult.Data.ToList().ForEach(ms =>
            {
                lstMesa.Add(new SelectListItem(ms.TcDscMesa, ms.Id.ToString()));
            });

            menuResult.Data.ToList().ForEach(ms =>
            {
                lstMenu.Add(new SelectListItem(ms.TcDscMenu, ms.Id.ToString()));
            });

            var menuViewModel = new ReservacionViewModel();
            menuViewModel.ClienteSelectListItems = lstCliente;
            menuViewModel.MesaSelectListItems = lstMesa;
            menuViewModel.MenuSelectListItems = lstMenu;
            menuViewModel.Reservaciones = reservacionResult.Data;

            if(op == "create")
            {
                ViewData["modalCreate"] = "S";
            }

            return View(menuViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ReservacionCrearDTO reservacionCrearDTO)
        {
            var result = await _reservacionService.Crear(reservacionCrearDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(ReservacionDTO reservacionDTO)
        {
            var result = await _reservacionService.Actualizar(reservacionDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost("Reservacion/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _reservacionService.Eliminar(id, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTabla()
        {
            var result = await _reservacionService.ObtenerTodo(CurrentToken);

            var reservacionesDTO = result.Data;

            return PartialView("_ListadoReservacionPartial", reservacionesDTO);

        }
    }
}
