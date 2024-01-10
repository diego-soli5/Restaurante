using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Web.Models.Menu;
using Restaurante.Web.Models.TipoMenu;

namespace Restaurante.Web.ViewModels.Menu
{
    public class MenuViewModel
    {
        public List<MenuDTO> Menus { get; set; }
        public IEnumerable<SelectListItem> TipoMenuSelectListItems { get; set; }
    }
}
