using System.Net;

namespace RMA70_LauncherLib.Core.DataProcess.NetworkOperation.Utils
{
    public class HttpResult
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}