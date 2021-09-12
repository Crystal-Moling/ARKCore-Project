using System.Collections.Generic;
using System.Threading.Tasks;

using RMA70_LauncherLib.Core.Authentication;
using RMA70_LauncherLib.Core.Locator;

namespace RMA70_LauncherLib.LibIO
{
    public class IO
    {
        
        #region InitializationIO

        public static void InitializationCore()
        {
            
        }

        #endregion
        
        #region DownloaderIO

        

        #endregion

        #region LauncherIO

        

        #endregion
        
        #region LocatorIO

        /// <summary>
        /// 返回Java路径列表
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> LocateJava()
        {
            return JavaLocator.FindJava();
        }

        /// <summary>
        /// 返回版本列表
        /// </summary>
        public static void LocateMinecraft()
        {
            return;
        }

        #endregion

        #region AuthIO

        private static string _username;
        private static string _password;
        private static AuthResult _result;

        /// <summary>
        /// 初始化认证信息
        /// </summary>
        /// <param name="username">邮箱</param>
        /// <param name="password">密码</param>
        public static void InitializationAuthData(string username, string password)
        {
            _username = username;
            _password = password;
        }
        
        /// <summary>
        /// 使用密码认证用户,需要初始化认证信息
        /// </summary>
        /// <returns></returns>
        public static async Task<(string Username, string AccessToken, bool Verified)> MojangAuth()
        {
            var ygg = new Yggdrasil(_username,_password);
            _result = await ygg.AuthAsync();
            return (_result.Username,_result.AccessToken,_result.Verified);
        }

        /// <summary>
        /// 刷新一个有效的accessToken,需要初始化认证信息
        /// </summary>
        /// <returns></returns>
        public static async Task<string> RefreahMojangAuth()
        {
            var ygg = new Yggdrasil(_username,_password);
            var re1 = await ygg.RefreshAsync(_result.AccessToken);
            _result = re1;
            return _result.AccessToken;
        }
        
        /// <summary>
        /// 检查accessToken是否可用于Minecraft服务器的认证,需要初始化认证信息
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ValidateMojangAuth()
        {
            var ygg = new Yggdrasil(_username,_password);
            return await ygg.ValidateAsync(_result.AccessToken);
        }
        
        /// <summary>
        /// 使用client/access令牌对使accessToken失效,需要初始化认证信息
        /// </summary>
        /// <returns></returns>
        public async Task<bool> InvalidateMojangAuth()
        {
            var ygg = new Yggdrasil(_username,_password);
            await ygg.InvalidateAsync(_result.AccessToken, _result.ClientToken);
            return await ygg.ValidateAsync(_result.AccessToken);
        }
        
        /// <summary>
        /// 使用帐号的用户名和密码使accessToken失效,需要初始化认证信息
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SignOutMojangAuth()
        {
            var ygg = new Yggdrasil(_username,_password);
            await ygg.InvalidateAsync(_result.AccessToken, _result.ClientToken);
            return await ygg.ValidateAsync(_result.AccessToken);
        }

        #endregion

    }
}