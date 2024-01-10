using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Restaurante.Api.Models;
using Restaurante.LogicaNegocio.Exceptions;

namespace Restaurante.Api.Filters
{
    public class ExceptionManagerFilter : Controller, IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IModelMetadataProvider _modelMetadata;

        public ExceptionManagerFilter(IWebHostEnvironment hostEnvironment,
                                      IModelMetadataProvider modelMetadata)
        {
            _hostEnvironment = hostEnvironment;
            _modelMetadata = modelMetadata;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is BusinessException)
            {
                var excNegocio = exception as BusinessException;

                var respuesta = new Response(exception.Message);

                if (excNegocio.StatusCode.HasValue)
                {
                    context.Result = StatusCode(excNegocio.StatusCode.Value, respuesta);
                }
                else
                {
                    context.Result = BadRequest(respuesta);
                }

            }
            else
            {
                context.Result = StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = exception.Message });
            }
        }
    }
}
