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
            
            Console.WriteLine("Refresh=============");
            var re1 = await ygg.RefreshAsync(re.AccessToken);
            Console.WriteLine(re1.AccessToken);
            
            Console.WriteLine("Validate============");
            Console.WriteLine($"0:{await ygg.ValidateAsync(re.AccessToken)}");
            Console.WriteLine($"1:{await ygg.ValidateAsync(re1.AccessToken)}");
            
            Console.WriteLine("Invalidate==========");
            await ygg.InvalidateAsync(re1.AccessToken, re1.ClientToken);
            Console.WriteLine($"Invalidate:{await ygg.ValidateAsync(re1.AccessToken)}");

            Console.WriteLine("JavaPath============");
            Console.WriteLine(IO.LocateJava());
        }
    }
}