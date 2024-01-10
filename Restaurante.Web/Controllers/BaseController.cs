using Microsoft.AspNetCore.Mvc;
using Restaurante.Web.Filters;
using System.Security.Claims;

namespace Restaurante.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string CurrentToken => User.FindFirstValue("Token");
        protected int CurrentUserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
