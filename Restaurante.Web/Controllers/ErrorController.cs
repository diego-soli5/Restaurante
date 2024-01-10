using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Web.Utility.Exceptions;
using Restaurante.Web.ViewModels;

namespace Restaurante.Web.Controllers
{
    public class ErrorController : Controller
    {
        public async Task<IActionResult> Controlar()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error;

            if (exception != null)
            {
                if (exception is UnauthorizedException)
                {
                    await HttpContext.SignOutAsync();

                    TempData["Session"] = "La sesión ha expirado, por favor vuelve a iniciar sesión.";

                    return RedirectToAction("Login", "Usuario");
                }

                if (exception is NotFoundException)
                {
                    var notFoundException = exception as NotFoundException;

                    var viewModel = new NotFoundViewModel();

                    viewModel.Message = notFoundException.Message;

                    return View("NotFound", viewModel);
                }

                try
                {
                    System.IO.File.AppendAllText("C:/Restaurante/log.txt", $"{DateTime.Now} | {exception.Message} | {exception.InnerException?.Message}" + Environment.NewLine);
                }
                catch (Exception ex)
                {

                }
            }

            var errorViewModel = new ErrorViewModel(exception.Message);

            return View("Error", errorViewModel);

        }
    }
}
