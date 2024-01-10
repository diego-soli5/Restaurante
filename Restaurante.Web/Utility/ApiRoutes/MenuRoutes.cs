using Microsoft.Extensions.Options;
using Restaurante.Web.Utility.Options;

namespace Restaurante.Web.Utility.ApiRoutes
{
    public class MenuRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string Menu;

        public MenuRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            Menu = $"{_apiOptions.Domain}/api/{nameof(Menu)}";
        }

        public string Obtener
        {
            get
            {
                return $"{Menu}/{nameof(Obtener)}";
            }
        }

        public string ObtenerTodo
        {
            get
            {
                return $"{Menu}/{nameof(ObtenerTodo)}";
            }
        }

        public string Crear
        {
            get
            {
                return $"{Menu}/{nameof(Crear)}";
            }
        }

        public string Actualizar
        {
            get
            {
                return $"{Menu}/{nameof(Actualizar)}";
            }
        }

        public string Eliminar
        {
            get
            {
                return $"{Menu}/{nameof(Eliminar)}";
            }
        }
    }
}
