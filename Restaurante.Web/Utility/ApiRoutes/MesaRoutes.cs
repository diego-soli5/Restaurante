using Microsoft.Extensions.Options;
using Restaurante.Web.Utility.Options;

namespace Restaurante.Web.Utility.ApiRoutes
{
    public class MesaRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string Mesa;

        public MesaRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            Mesa = $"{_apiOptions.Domain}/api/{nameof(Mesa)}";
        }

        public string Obtener
        {
            get
            {
                return $"{Mesa}/{nameof(Obtener)}";
            }
        }

        public string ObtenerTodo
        {
            get
            {
                return $"{Mesa}/{nameof(ObtenerTodo)}";
            }
        }

        public string Crear
        {
            get
            {
                return $"{Mesa}/{nameof(Crear)}";
            }
        }

        public string Actualizar
        {
            get
            {
                return $"{Mesa}/{nameof(Actualizar)}";
            }
        }

        public string Eliminar
        {
            get
            {
                return $"{Mesa}/{nameof(Eliminar)}";
            }
        }
    }
}
