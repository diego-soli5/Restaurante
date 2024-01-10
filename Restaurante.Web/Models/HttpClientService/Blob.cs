namespace Restaurante.Web.Models.HttpClientService
{
    public class Blob
    {
        public Blob() { }

        public Blob(byte[] bytes, string contentType) 
        { 
            Bytes = bytes;
            ContentType = contentType;
        }

        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}
