using Microsoft.Extensions.Options;
using Restaurante.Web.Utility.Options;

namespace Restaurante.Web.Utility.ApiRoutes
{
    public class ClienteRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string Cliente;

        public ClienteRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            Cliente = $"{_apiOptions.Domain}/api/{nameof(Cliente)}";
        }

        public string Obtener
        {
            get
            {
                return $"{Cliente}/{nameof(Obtener)}";
            }
        }

        public string ObtenerTodo
        {
            get
            {
                return $"{Cliente}/{nameof(ObtenerTodo)}";
            }
        }

        public string Crear
        {
            get
            {
                return $"{Cliente}/{nameof(Crear)}";
            }
        }

        public string Actualizar
        {
            get
            {
                return $"{Cliente}/{nameof(Actualizar)}";
            }
        }

        public string Eliminar
        {
            get
            {
                return $"{Cliente}/{nameof(Eliminar)}";
            }
        }
    }
}
