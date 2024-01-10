using Newtonsoft.Json.Linq;
using Restaurante.Web.Models.HttpClientService;
using Restaurante.Web.Models.Usuario;

namespace Restaurante.Web.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<HttpRequestResult<List<UsuarioDTO>>> ObtenerTodo(string token);
        public Task<HttpRequestResult<ResultadoLoginDTO>> IniciarSesion(PeticionLoginDTO peticionLoginDTO);
        public Task<HttpRequestResult<Response>> Registrar(UsuarioRegistrarDTO usuarioRegistrarDTO, string token);
        public Task<HttpRequestResult> Eliminar(int id, string token);
    }
}
