using Microsoft.Extensions.Options;
using Restaurante.Web.Utility.Options;

namespace Restaurante.Web.Utility.ApiRoutes
{
    public class ReservacionRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string Reservacion;

        public ReservacionRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            Reservacion = $"{_apiOptions.Domain}/api/{nameof(Reservacion)}";
        }

        public string Obtener
        {
            get
            {
                return $"{Reservacion}/{nameof(Obtener)}";
            }
        }

        public string ObtenerTodo
        {
            get
            {
                return $"{Reservacion}/{nameof(ObtenerTodo)}";
            }
        }

        public string Crear
        {
            get
            {
                return $"{Reservacion}/{nameof(Crear)}";
            }
        }

        public string Actualizar
        {
            get
            {
                return $"{Reservacion}/{nameof(Actualizar)}";
            }
        }

        public string Eliminar
        {
            get
            {
                return $"{Reservacion}/{nameof(Eliminar)}";
            }
        }
    }
}
