using System;
using System.Threading.Tasks;
using ARKCore.Utils;

namespace ARKCore.Authentication.Microsoft
{
    public partial class Microsoft
    {
        private const String AuthDomain = "https://login.live.com/oauth20_authorize.srf?client_id=00000000402b5328&response_type=code&scope=service%3A%3Auser.auth.xboxlive.com%3A%3AMBI_SSL&redirect_uri=https%3A%2F%2Flogin.live.com%2Foauth20_desktop.srf";
        private const String TokenDomain = "https://login.live.com/oauth20_token.srf";
        private const String XBLAuthDomain = "https://user.auth.xboxlive.com/user/authenticate";
        private const String XSTSAuthDomain = "https://xsts.auth.xboxlive.com/xsts/authorize";
        private const String MinecraftAuthDomain = "https://api.minecraftservices.com/authentication/login_with_xbox";
        private const String MinecraftProfileDomain = "https://api.minecraftservices.com/minecraft/profile";
    }

    public partial class Microsoft
    {
        public async Task<String> GetToken()
        {
            var result = await HttpHelper.GetHttpAsync(AuthDomain);
            return result.RedirectTo;
        }
    }
}
