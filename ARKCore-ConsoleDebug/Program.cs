using System;
using System.Threading.Tasks;
using ARKCore;

namespace ARKCore_ConsoleDebug
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("MojangAuth==========");
            var re_ygg = await API.MojangAuth("","");
            Console.WriteLine(re_ygg.Username);
            Console.WriteLine(re_ygg.AccessToken);
            Console.WriteLine(re_ygg.Verified);
            Console.WriteLine("MicrosoftAuth=======");
            /*var re_ms = await API.MicrosoftAuth();
            Console.WriteLine(re_ms.AccessToken);
            Console.WriteLine(re_ms.RefreshToken);
            Console.WriteLine(re_ms.ERROR);*/
            Console.WriteLine(API.MicrosoftAuth());
        }
    }
}