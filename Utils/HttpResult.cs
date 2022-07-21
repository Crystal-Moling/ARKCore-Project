using System;
using System.Net;

namespace ARKCore.Utils
{
    public class HttpResult
    {
        public String Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public String RedirectTo { get; set; }
    }
}