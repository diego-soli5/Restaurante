using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Web.Models;
using Restaurante.Web.Models.Menu;
using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.ViewModels.Menu;

namespace Restaurante.Web.Controllers
{
    [Authorize]
    public class MenuController : BaseController
    {
        private readonly IMenuService _menuService;
        private readonly ITipoMenuService _tipoMenuService;

        public MenuController(IMenuService menuService,
                              ITipoMenuService tipoMenuService)
        {
            _menuService = menuService;
            _tipoMenuService = tipoMenuService;
        }

        public async Task<IActionResult> Index()
        {
            var menuResult = await _menuService.ObtenerTodo(CurrentToken);
            var tipoMenuResult = await _tipoMenuService.ObtenerTodo(CurrentToken);

            var lst = new List<SelectListItem>();

            tipoMenuResult.Data.ToList().ForEach(ms =>
            {
                lst.Add(new SelectListItem(ms.TcDscTipoMenu, ms.Id.ToString()));
            });

            var menuViewModel = new MenuViewModel();
            menuViewModel.Menus = menuResult.Data;
            menuViewModel.TipoMenuSelectListItems = lst;

            return View(menuViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MenuCrearDTO menuCrearDTO)
        {
            var result = await _menuService.Crear(menuCrearDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(MenuDTO menuDTO)
        {
            var result = await _menuService.Actualizar(menuDTO, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpPost("Menu/Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _menuService.Eliminar(id, CurrentToken);

            var respuesta = new Respuesta(result.Success, result.Message, result.Data);

            return Ok(respuesta);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTabla()
        {
            var result = await _menuService.ObtenerTodo(CurrentToken);

            var menusDTO = result.Data;

            return PartialView("_ListadoMenuPartial", menusDTO);

        }
    }
}
