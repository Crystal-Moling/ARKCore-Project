using System;
using System.Collections.Generic;
using System.IO;

namespace RMA70_LauncherLib.Core.StartupDependency.GameDependency
{
    public class MinecraftLocator
    {
        public static List<string> LocateMinecraft(String MinecraftDir)
        {
            List<String> Versions = new List<string>();
            try
            {
                DirectoryInfo verDir = new DirectoryInfo(MinecraftDir);
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
                            if (File.Exists(FullFileLacation + ".json")) 
                            { 
                                IsJsonFileExist = true;
                                Versions.Add(verdir + "\\" + verinfo);
                            }
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
            return Versions;
        }
    }
}