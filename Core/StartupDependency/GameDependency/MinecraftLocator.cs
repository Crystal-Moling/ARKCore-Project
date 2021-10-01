using System.IO;

namespace RMA70_LauncherLib.Core.StartupDependency.GameDependency
{
    public class MinecraftLocator
    {
        public void LocateMinecraft()
        {
            try
            {
                var versions = Directory.GetFiles(@".minecraft\");
            }
            catch
            {
                // ignored
            }
        }
    }
}