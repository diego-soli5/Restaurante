using Microsoft.AspNetCore.Mvc.Rendering;
using Restaurante.Web.Models.Reservacion;

namespace Restaurante.Web.ViewModels.Reservacion
{
    public class ReservacionViewModel
    {
        public List<ReservacionDTO> Reservaciones { get; set; }
        public IEnumerable<SelectListItem> ClienteSelectListItems { get; set; }
        public IEnumerable<SelectListItem> MesaSelectListItems { get; set; }
        public IEnumerable<SelectListItem> MenuSelectListItems { get; set; }
    }
}
