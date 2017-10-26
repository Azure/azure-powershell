using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class GetContext
    {
        public Context Context { get; }

        public GetContext(Context context)
        {
            Context = context;
        }

        public async Task<T> GetOrNullAsync<T>(Parameters<T> parameters)
        {
            var result = await Map.GetOrAdd(
                parameters, _ => GetObjectOrNullAsync(parameters));
            return (T)result;
        }

        private async Task<object> GetObjectOrNullAsync<T>(Parameters<T> parameters)
        {
            try
            {
                return await parameters.GetAsync(this); 
            }
            catch
            {
                return null;
            }
        }

        private ConcurrentDictionary<Parameters, Task<object>> Map { get; }
            = new ConcurrentDictionary<Parameters, Task<object>>();
    }
}
