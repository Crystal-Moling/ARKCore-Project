using System;
using System.Threading.Tasks;
using RestSharp;
using ARKCore.Extensions;

namespace ARKCore.Utils
{
    public partial class HttpHelper
    {
        private const  string UserAgent = "RMA70LauncherLib";
    }
    
    public partial class HttpHelper
    {
        public static HttpResult GetHttp(string uri) => GetHttpAsync(uri).GetResult();
        public static HttpResult PostHttp(string uri, string json) => PosHttpAsync(uri, json).GetResult();
    }
    
    public partial class HttpHelper
    {
        public static async Task<HttpResult> GetHttpAsync(string uri, string method = "GET")
        {
            var result = await new RestClient
            {
                BaseUrl = new Uri(uri),
                UserAgent = UserAgent,
                FollowRedirects = false
            }.ExecuteAsync(new RestRequest
            {
                Method = Method.GET
            });
            return new HttpResult
            {
                Content = result.Content,
                StatusCode = result.StatusCode
            };
        }
        public static async Task<HttpResult> PosHttpAsync(string uri, string json)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(uri),
                UserAgent = UserAgent
            };
            var request = new RestRequest(Method.POST);
            request.AddJsonBody(json);
            var result = await client.ExecuteAsync(request);
            return new HttpResult
            {
                Content = result.Content,
                StatusCode = result.StatusCode
            };
        }
    }
}