using System.Collections.Generic;
using System.Threading.Tasks;
using RMA70_LauncherLib.Core.DataProcess.NetworkOperation.Authentication;
using RMA70_LauncherLib.Core.Locator;

namespace RMA70_LauncherLib.CoreIO
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

        #endregion

    }
}