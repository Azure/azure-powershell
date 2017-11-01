using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class GetInfoContext : IGetInfoContext
    {
        public Context Context { get; }

        public GetInfoContext(Context context)
        {
            Context = context;
        }

        public async Task<T> GetOrAdd<T>(
            ResourceParameters<T> parameters, Func<Task<T>> get)
            where T : class
        {
            var result = await Map.GetOrAdd(parameters, async _ => await get());
            return (T)result;
        }

        private ConcurrentDictionary<ResourceParameters, Task<object>> Map { get; }
            = new ConcurrentDictionary<ResourceParameters, Task<object>>();
    }
}
