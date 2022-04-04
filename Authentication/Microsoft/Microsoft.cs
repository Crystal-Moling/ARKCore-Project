using System;
using System.Net;
using System.Threading.Tasks;
using ARKCore.Utils;
using Newtonsoft.Json.Linq;

namespace ARKCore.Authentication.Microsoft
{
    public partial class Microsoft
    {
        private readonly Uri _tokenUri = new Uri(@"https://login.live.com/oauth20_authorize.srf?client_id=000000004C12AE6F&redirect_uri=https://login.live.com/oauth20_desktop.srf&scope=service::user.auth.xboxlive.com::MBI_SSL&display=touch&response_type=token&locale=en");
        
    }

    public partial class Microsoft
    {
        public String/*async Task<StringMsAuthResult>*/ GetToken()
        {
            var result = HttpHelper.GetHttpAsync(_tokenUri.ToString());
            /*
            var response = JObject.Parse(result.Content);
            return result.StatusCode == HttpStatusCode.Found
                ? new MsAuthResult
                {
                    AccessToken = response["access_token"]?.ToString(),
                    RefreshToken = response["refresh_token"]?.ToString(),
                    ERROR = false
                }
                : new MsAuthResult
                {
                    ERROR = true
                };*/
            return result.Result.Content;
        }
    }
}
