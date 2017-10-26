using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class GetMap
    {
        public async Task<T> GetOrAdd<T>(Parameters<T> parameters, Func<Task<T>> get)
            where T : class
        {
            var result = await Map.GetOrAdd(parameters, async _ => await get());
            return (T)result;
        }

        private ConcurrentDictionary<Parameters, Task<object>> Map { get; }
            = new ConcurrentDictionary<Parameters, Task<object>>();
    }
}
