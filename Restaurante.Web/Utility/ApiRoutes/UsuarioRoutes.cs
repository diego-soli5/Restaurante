using Microsoft.Extensions.Options;
using Restaurante.Web.Utility.Options;

namespace Restaurante.Web.Utility.ApiRoutes
{
    public class UsuarioRoutes
    {
        private readonly ApiOptions _apiOptions;
        private readonly string Usuario;

        public UsuarioRoutes(IOptions<ApiOptions> options)
        {
            _apiOptions = options.Value;

            Usuario = $"{_apiOptions.Domain}/api/{nameof(Usuario)}";
        }

        public string ObtenerTodo
        {
            get
            {
                return $"{Usuario}/{nameof(ObtenerTodo)}";
            }
        }

        public string IniciarSesion
        {
            get
            {
                return $"{Usuario}/{nameof(IniciarSesion)}";
            }
        }

        public string Registrar
        {
            get
            {
                return $"{Usuario}/{nameof(Registrar)}";
            }
        }

        public string Eliminar
        {
            get
            {
                return $"{Usuario}/{nameof(Eliminar)}";
            }
        }

    }
}
