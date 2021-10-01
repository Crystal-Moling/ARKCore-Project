using System;
using System.IO;

namespace RMA70_LauncherLib.Core.StartupDependency.GameDependency
{
    public class MinecraftLocator
    {
        public void LocateMinecraft()
        {
            try
            {
                DirectoryInfo verDir = new DirectoryInfo(".minecraft/versions");
                FileSystemInfo[] verFDirs = verDir.GetFileSystemInfos();
                foreach (var VerFDir in verFDirs)
                {
                    if (verDir is DirectoryInfo)
                    {
                        DirectoryInfo verdir = new DirectoryInfo(VerFDir.FullName);
                        DirectoryInfo verinfo = new DirectoryInfo(VerFDir.Name);
                        String FullFileLacation = verdir + "\\" + verinfo + ".jar";
                        Boolean IsJarFileExist;
                        Boolean IsJsonFileExist;
                        if (File.Exists(FullFileLacation + ".jar"))
                        {
                            IsJarFileExist = true;
                            if (File.Exists(FullFileLacation + ".json")) { IsJsonFileExist = true; }
                            else { IsJsonFileExist = false; }
                        }
                        else { IsJarFileExist = false; }
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}