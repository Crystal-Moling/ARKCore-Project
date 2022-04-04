using System.Net;
using System.Threading.Tasks;
using ARKCore.Extensions;
using ARKCore.Utils;
using Newtonsoft.Json.Linq;

namespace ARKCore.Authentication.Yggdrasil
{
    public partial class Yggdrasil
    {
        public string Username
        {
            get => _payload.Username;
            set => _payload.Username = value;
        }

        public string Password
        {
            get => _payload.Password;
            set => _payload.Password = value;
        }

        public string ClientToken
        {
            get => _payload.ClientToken;
            set => _payload.ClientToken = value;
        }

        private readonly AuthPayload _payload;
        public Yggdrasil(string username = "", string password = "", string clientToken = "")
        {
            _payload = new AuthPayload
            {
                Username = username,
                Password = password,
                ClientToken = clientToken
            };
        }

        private const string AuthDomain = "https://authserver.mojang.com/authenticate";
        private const string RefreshDomain = "https://authserver.mojang.com/refresh";
        private const string ValidateDomain = "https://authserver.mojang.com/validate";
        private const string InvalidateDomain = "https://authserver.mojang.com/invalidate";
        private const string SignOutDomain = "https://authserver.mojang.com/signout";

    }
    
    public partial class Yggdrasil
    {
        public async Task<YggAuthResult> AuthAsync()
        {
            var payload = _payload.GetAuthPayload();
            var result = await HttpHelper.PosHttpAsync(AuthDomain,payload);
            var response = JObject.Parse(result.Content);

            return result.StatusCode == HttpStatusCode.OK
                ? new YggAuthResult
                {
                    AccessToken = response["accessToken"]?.ToString(),
                    ClientToken = response["clientToken"]?.ToString(),
                    Username = response["selectedProfile"]?["name"]?.ToString(),
                    Uuid = response["selectedProfile"]?["id"]?.ToString(),
                    Verified = true
                }
                : new YggAuthResult
                {
                    Error = response["error"]?.ToString(),
                    ErrorMessage = response["errorMessage"]?.ToString(),
                    Verified = false
                };
        }
        
        public async Task<YggAuthResult> RefreshAsync(string accessToken)
        {
            var payload = _payload.GetRefreshPayload(accessToken);
            var result = await HttpHelper.PosHttpAsync(RefreshDomain,payload);
            var response = JObject.Parse(result.Content);

            return result.StatusCode == HttpStatusCode.OK
                ? new YggAuthResult
                {
                    AccessToken = response["accessToken"]?.ToString(),
                    ClientToken = response["clientToken"]?.ToString(),
                    Username = response["selectedProfile"]?["name"]?.ToString(),
                    Uuid = response["selectedProfile"]?["id"]?.ToString(),
                    Verified = true
                }
                : new YggAuthResult
                {
                    Error = response["error"]?.ToString(),
                    ErrorMessage = response["errorMessage"]?.ToString(),
                    Verified = false
                };
        }
        
        public async Task<bool> ValidateAsync(string accessToken)
        {
            var payload = _payload.GetValidatePayload(accessToken);
            var result = await HttpHelper.PosHttpAsync(ValidateDomain,payload);

            return result.StatusCode == HttpStatusCode.NoContent;
        }
        
        public async Task InvalidateAsync(string accessToken, string clientToken)
        {
            var payload = _payload.GetInvalidatePayload(accessToken,clientToken);
            await HttpHelper.PosHttpAsync(InvalidateDomain,payload);
        }
        
        public async Task SignOutAsync()
        {
            var payload = _payload.GetSignOutPayload();
            await HttpHelper.PosHttpAsync(SignOutDomain,payload);
        }
    }
    
    public partial class Yggdrasil
    {
        public YggAuthResult Auth() => AuthAsync().GetResult();
        public YggAuthResult Refresh(string accessToken) => RefreshAsync(accessToken).GetResult();
        public bool Validate(string accessToken) => ValidateAsync(accessToken).GetResult();
        public void Invalidate(string accessToken, string clientToken) => 
            InvalidateAsync(accessToken,clientToken).GetAwaiter().GetResult();
        public void SignOut() => SignOutAsync().GetAwaiter().GetResult();
    }
}