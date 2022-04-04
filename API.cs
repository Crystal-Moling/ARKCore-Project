using System;
using System.Threading.Tasks;
using ARKCore.Authentication.Microsoft;
using ARKCore.Authentication.Yggdrasil;
using ARKCore.Utils;

namespace ARKCore
{
    public class API
    {
        #region AuthAPI

        private static YggAuthResult _yggResult;
        private static MsAuthResult _msResult;
        
        public static async Task<(string Username, string AccessToken, bool Verified)> MojangAuth(string username, string password)
        {
            var ygg = new Yggdrasil(username,password);
            _yggResult = await ygg.AuthAsync();
            CoreVariables.Username = _yggResult.Username;
            CoreVariables.AccessToken = _yggResult.AccessToken;
            return (_yggResult.Username,_yggResult.AccessToken,_yggResult.Verified);
        }

        public static String/*Task<(string AccessToken, string RefreshToken, bool ERROR)>*/ MicrosoftAuth()
        {
            var ms = new Authentication.Microsoft.Microsoft();
            /*_msResult = await ms.GetToken();
            CoreVariables.AccessToken = _msResult.AccessToken;
            CoreVariables.RefreshToken = _msResult.RefreshToken;
            return (_msResult.AccessToken, _msResult.RefreshToken, _msResult.ERROR);*/
            return ms.GetToken();
        }

        #endregion
    }
}