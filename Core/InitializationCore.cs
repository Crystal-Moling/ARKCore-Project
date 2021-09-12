using System.IO;

namespace RMA70_LauncherLib.Core
{
    public class InitializationCore
    {
        public void Initialization()
        {
            if (Directory.Exists(@".minecraft\")) { }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@".minecraft\");
                directoryInfo.Create();
            }
        }
    }
}