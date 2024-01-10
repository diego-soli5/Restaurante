namespace Restaurante.Web.Models.HttpClientService
{
    public class HttpRequestResult 
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success => StatusCode == StatusCodes.Status200OK ||
                               StatusCode == StatusCodes.Status201Created ||
                               StatusCode == StatusCodes.Status204NoContent;
        public bool Unauthorized => StatusCode == StatusCodes.Status401Unauthorized;
        public bool NotFound => StatusCode == StatusCodes.Status404NotFound;
        public bool InternalServerError => StatusCode == StatusCodes.Status500InternalServerError;
    }

    public class HttpRequestResult<TData> : HttpRequestResult
    {
        public TData Data { get; set; }
    }
}
