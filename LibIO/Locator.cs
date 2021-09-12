using System.Collections.Generic;
using RMA70_LauncherLib.Core.Locator;

namespace RMA70_LauncherLib.LibIO
{
    public class Locator
    {
        /// <summary>
        /// 返回Java路径列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> LocateJava()
        {
            return JavaLocator.FindJava();
        }

        /// <summary>
        /// 返回版本列表
        /// </summary>
        public void LocateMinecraft()
        {
            return;
        }
    }
}