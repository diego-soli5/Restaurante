using Restaurante.Web.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Restaurante.Web.Models.HttpClientService;
using Newtonsoft.Json;
using System.Net.Http;

namespace Restaurante.Web.Services
{
    public class HttpClientService : IHttpClientService
    {
        #region DEPENDENCIES
        private readonly IHttpClientFactory _clientFactory;
        #endregion

        #region CONSTRUCTOR
        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #endregion

        #region GET
        public async Task<HttpRequestResult<TData>> Get<TData>(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult<TData> result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);
                
                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }

        public async Task<Blob> Get(string url, string authToken = null)
        {
            byte[] fileBytes = null;
            string contentType = null;

            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                        {
                            if (httpResponseMessage.Content != null)
                            {
                                fileBytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();

                                if (httpResponseMessage.Content.Headers.Contains("Content-Type"))
                                {
                                    contentType = httpResponseMessage.Content.Headers.GetValues("Content-Type").FirstOrDefault();
                                }
                            }
                        }
                    }
                }
            }

            return new Blob(fileBytes, contentType);
        }
        #endregion

        #region POST
        public async Task<HttpRequestResult> Post(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }

        public async Task<HttpRequestResult<TData>> Post<TData>(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult<TData> result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }

        public async Task<HttpRequestResult> Post(string url, IFormFile[] filesToSend, string authToken = null)
        {
            HttpRequestResult result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                if (filesToSend != null)
                    AddDataToRequest(request, filesToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }
        #endregion

        #region PUT
        public async Task<HttpRequestResult> Put(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }

        public async Task<HttpRequestResult<TData>> Put<TData>(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult<TData> result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Put, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }
        #endregion

        #region PATCH
        public async Task<HttpRequestResult> Patch(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Patch, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }
        #endregion

        #region DELETE
        public async Task<HttpRequestResult<TData>> Delete<TData>(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult<TData> result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Delete, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }

        public async Task<HttpRequestResult> Delete(string url, object dataToSend = null, string authToken = null)
        {
            HttpRequestResult result = new();

            using (var request = new HttpRequestMessage(HttpMethod.Delete, url))
            {
                if (dataToSend != null)
                    AddDataToRequest(request, dataToSend);

                using (var client = _clientFactory.CreateClient())
                {
                    if (!string.IsNullOrEmpty(authToken))
                        AddAuthorizationHeader(client, authToken);

                    using (var httpResponseMessage = await client.SendAsync(request))
                    {
                        ManageResponseMessage(result, httpResponseMessage);

                        return result;
                    }
                }
            }
        }
        #endregion

        #region UTILITY METHODS
        private void AddDataToRequest(HttpRequestMessage request, object dataToSend)
        {
            if (dataToSend == null)
                throw new ArgumentNullException(nameof(dataToSend), $"Unexpected null value at {nameof(AddDataToRequest)}.");

            if (dataToSend is IFormFile[])
            {
                var filesToSend = dataToSend as IFormFile[];

                var form = new MultipartFormDataContent();

                filesToSend.ToList().ForEach(file =>
                {
                    var streamContent = new StreamContent(file.OpenReadStream());

                    streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
                    streamContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = file.Name, FileName = file.FileName };

                    form.Add(streamContent, "file", file.FileName);

                    request.Content = form;
                });
            }
            else
            {
                string json = JsonConvert.SerializeObject(dataToSend);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
        }

        private void AddAuthorizationHeader(HttpClient client, string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
                throw new ArgumentNullException(nameof(authToken), $"Unexpected null value at {nameof(AddAuthorizationHeader)}.");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        }

        #region ManageResponseMessage
        private async void ManageResponseMessage(HttpRequestResult result, HttpResponseMessage httpResponseMessage)
        {
            result.StatusCode = (int)httpResponseMessage.StatusCode;

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK ||
                httpResponseMessage.StatusCode == HttpStatusCode.BadRequest ||
                httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                if (httpResponseMessage.Content != null)
                {
                    string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<Response>(jsonResult);

                    result.Message = response.Message;
                }
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError ||
                     httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (httpResponseMessage.Content != null)
                {
                    try
                    {

                        string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                        var response = JsonConvert.DeserializeObject<Response>(jsonResult);
                        if (response != null)
                        {
                            result.Message = response.Message;
                        }
                        else
                        {
                            result.Message = "Ocurrió un error interno en el servidor.";
                        }
                    }
                    catch (Exception)
                    {
                        result.Message = "Ocurrió un error interno en el servidor.";
                    }

                }
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Created ||
                     httpResponseMessage.StatusCode == HttpStatusCode.NoContent)
            {
                result.Message = $"El servidor respondió con un código de estado exitoso {result.StatusCode}.";
            }
            else
            {
                result.Message = $"El servidor respondió con un código de estado {result.StatusCode}.";
            }
        }


        private async void ManageResponseMessage<TData>(HttpRequestResult<TData> result, HttpResponseMessage httpResponseMessage)
        {
            result.StatusCode = (int)httpResponseMessage.StatusCode;

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK ||
                httpResponseMessage.StatusCode == HttpStatusCode.BadRequest ||
                httpResponseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                if (httpResponseMessage.Content != null)
                {
                    string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                    var response = JsonConvert.DeserializeObject<Response>(jsonResult);

                    result.Message = response.Message;

                    if (response.Data != null)
                    {
                        result.Data = JsonConvert.DeserializeObject<TData>(response.Data.ToString());
                    }
                }
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError ||
                     httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (httpResponseMessage.Content != null)
                {
                    try
                    {
                        string jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();

                        var response = JsonConvert.DeserializeObject<Response>(jsonResult);

                        if (response != null)
                        {
                            result.Message = response.Message;

                            if (response.Data != null)
                            {
                                result.Data = JsonConvert.DeserializeObject<TData>(response.Data.ToString());
                            }
                        }
                        else
                        {
                            result.Message = "Ocurrió un error interno en el servidor.";
                        }
                    }
                    catch (Exception)
                    {
                        result.Message = "Ocurrió un error interno en el servidor.";
                    }

                }
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.Created ||
                     httpResponseMessage.StatusCode == HttpStatusCode.NoContent)
            {
                result.Message = $"El servidor respondió con un código de estado exitoso {result.StatusCode}.";
            }
            else
            {
                result.Message = $"El servidor respondió con un código de estado {result.StatusCode}.";
            }
        }
        #endregion

        #endregion
    }
}
