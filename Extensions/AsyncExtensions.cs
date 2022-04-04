
using System.Threading.Tasks;

namespace ARKCore.Extensions
{
    public static class AsyncExtensions
    {
        public static T GetResult<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }
    }
}