using System;
using System.Threading.Tasks;
using RMA70_LauncherLib.CoreIO;

namespace RMA70_LauncherExample
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("MojangAuth==========");
            var re = await IO.MojangAuth("","");
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