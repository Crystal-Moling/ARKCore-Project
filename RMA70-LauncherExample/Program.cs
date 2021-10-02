using System;
using System.Threading.Tasks;
using RMA70_LauncherLib.Core.DataProcess.NetworkOperation.Authentication;
using RMA70_LauncherLib.CoreIO;

namespace RMA70_LauncherExample
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            
            var ygg = new Yggdrasil("","");
            
            var re = await ygg.AuthAsync();
            Console.WriteLine(re.Username);
            Console.WriteLine(re.AccessToken);
            Console.WriteLine(re.Verified);

            Console.WriteLine("JavaPath============");
            Console.WriteLine(IO.LocateJava());
            
            Console.WriteLine("Minecraft===========");
            Console.WriteLine(IO.LocateMinecraft(".minecraft"));
            
        }
    }
}