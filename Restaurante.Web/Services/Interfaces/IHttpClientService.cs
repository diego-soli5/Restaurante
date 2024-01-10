using Restaurante.Web.Models.HttpClientService;

namespace Restaurante.Web.Services.Interfaces
{
    public interface IHttpClientService
    {
        /// <summary>
        /// Hace una peticion GET que espera recibir data en JSON.
        /// </summary>
        /// <typeparam name="TData">El tipo de data que se espera recibir.</typeparam>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult<TData>> Get<TData>(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion GET que recibe UNICAMENTE archivos.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<Blob> Get(string url, string authToken = null);

        /// <summary>
        /// Hace una peticion POST.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult> Post(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion POST que envía UNICAMENTE archivos.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="filesToSend">Arreglo de archivos para enviar en el Form-Data de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult> Post(string url, IFormFile[] filesToSend, string authToken = null);

        /// <summary>
        /// Hace una peticion POST que espera recibir data en JSON.
        /// </summary>
        /// <typeparam name="TData">El tipo de dato que se espera recibir.</typeparam>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult<TData>> Post<TData>(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion PUT.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult> Put(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion PUT que espera recibir data en JSON.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult<TData>> Put<TData>(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion DELETE.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult> Delete(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion DELETE que espera recibir data en JSON.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult<TData>> Delete<TData>(string url, object dataToSend = null, string authToken = null);

        /// <summary>
        /// Hace una peticion PATCH.
        /// </summary>
        /// <param name="url">Url para realizar la petición.</param>
        /// <param name="dataToSend">Contenido para agregar al body de la petición.</param>
        /// <param name="authToken">Token de autorización para realizar la petición.</param>
        /// <returns></returns>
        Task<HttpRequestResult> Patch(string url, object dataToSend = null, string authToken = null);
    }
}
