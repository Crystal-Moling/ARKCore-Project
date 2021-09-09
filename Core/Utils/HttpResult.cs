using System.Net;

namespace RMA70_LauncherLib.Core.Utils
{
    public class HttpResult
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}