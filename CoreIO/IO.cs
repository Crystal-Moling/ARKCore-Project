using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RMA70_LauncherLib.Core;
using RMA70_LauncherLib.Core.DataProcess.NetworkOperation.Authentication;
using RMA70_LauncherLib.Core.Locator;
using RMA70_LauncherLib.Core.StartupDependency.GameDependency;

namespace RMA70_LauncherLib.CoreIO
{
    public class IO
    {

        #region DownloaderIO

        

        #endregion

        #region LauncherIO

        

        #endregion
        
        #region LocatorIO

        /// <summary>
        /// 返回Java路径列表 Return Java path list
        /// </summary>
        /// <returns></returns>
        public static string LocateJava()
        {
            return JavaLocator.FindJava().ToString();
        }
        
        /// <summary>
        /// 返回版本列表 Return version list
        /// </summary>
        /// <param name="MCDir">.minecraft文件夹路径 .minecraft folder path</param>
        /// <returns></returns>
        public static string LocateMinecraft(String MCDir)
        {
            return MinecraftLocator.LocateMinecraft(MCDir + "/versions").ToString();
        }

        #endregion

        #region AuthIO

        private static AuthResult _result;

        /// <summary>
        /// 使用密码认证用户,需要初始化认证信息 Use password to authenticate users, need to initialize authentication information
        /// </summary>
        /// <param name="username">邮箱 email</param>
        /// <param name="password">密码 passwd</param>
        /// <returns></returns>
        public static async Task<(string Username, string AccessToken, bool Verified)> MojangAuth(string username, string password)
        {
            var ygg = new Yggdrasil(username,password);
            _result = await ygg.AuthAsync();
            CoreVariables.Username = _result.Username;
            CoreVariables.AccessToken = _result.AccessToken;
            return (_result.Username,_result.AccessToken,_result.Verified);
        }

        #endregion

    }
}