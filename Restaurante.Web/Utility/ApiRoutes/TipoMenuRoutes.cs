using Microsoft.Extensions.Options;
using Restaurante.Web.Utility.Options;

namespace Restaurante.Web.Utility.ApiRoutes
{
    public class TipoMenuRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string TipoMenu;

        public TipoMenuRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            TipoMenu = $"{_apiOptions.Domain}/api/{nameof(TipoMenu)}";
        }

        public string Obtener
        {
            get
            {
                return $"{TipoMenu}/{nameof(Obtener)}";
            }
        }

        public string ObtenerTodo
        {
            get
            {
                return $"{TipoMenu}/{nameof(ObtenerTodo)}";
            }
        }

        public string Crear
        {
            get
            {
                return $"{TipoMenu}/{nameof(Crear)}";
            }
        }

        public string Actualizar
        {
            get
            {
                return $"{TipoMenu}/{nameof(Actualizar)}";
            }
        }

        public string Eliminar
        {
            get
            {
                return $"{TipoMenu}/{nameof(Eliminar)}";
            }
        }

    }
}
