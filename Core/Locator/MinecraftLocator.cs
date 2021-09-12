using System.IO;

namespace RMA70_LauncherLib.Core.Locator
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