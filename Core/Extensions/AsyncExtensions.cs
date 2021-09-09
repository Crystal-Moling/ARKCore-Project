using System.Threading.Tasks;

namespace RMA70_LauncherLib.Core.Extensions
{
    public static class AsyncExtensions
    {
        public static T GetResult<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}