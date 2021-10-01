using Newtonsoft.Json;

namespace RMA70_LauncherLib.Core.DataProcess.NetworkOperation.Authentication
{
    internal class AuthPayload
    {
        internal string Username { get; set; }
        internal string Password { get; set; }
        internal string ClientToken { get; set; }

        internal string GetAuthPayload()
        {
            return JsonConvert.SerializeObject(new
            {
                agent = new
                {
                    name = "Minecraft",
                    version = 1
                },
                username = Username,
                password = Password,
                clientToken = ClientToken
            });
        }

        internal string GetRefreshPayload(string accessToken)
        {
            return JsonConvert.SerializeObject(new
            {
                accessToken,
                clientToken = ClientToken
            });
        }
        
        internal string GetValidatePayload(string accessToken)
        {
            return JsonConvert.SerializeObject(new
            {
                accessToken,
                clientToken = ClientToken
            });
        }
        
        internal string GetInvalidatePayload(string accessToken, string clientToken)
        {
            return JsonConvert.SerializeObject(new
            {
                accessToken, clientToken
            });
        }
        
        internal string GetSignOutPayload()
        {
            return JsonConvert.SerializeObject(new
            {
                username = Username,
                password = Password
            });
        }
    }
}