using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Utility.Exceptions;

namespace Restaurante.Web.Services
{
    public class BaseService
    {
        public void CheckRequestResult(HttpRequestResult requestResult, bool validaUnauthorized = true)
        {
            if (!requestResult.Success)
            {
                if (requestResult.NotFound)
                {
                    throw new NotFoundException(requestResult.Message);
                }

                if (requestResult.Unauthorized && validaUnauthorized)
                {
                    throw new UnauthorizedException();
                }

                if (requestResult.InternalServerError)
                {
                    throw new Exception(requestResult.Message);
                }
            }
        }
    }
}
