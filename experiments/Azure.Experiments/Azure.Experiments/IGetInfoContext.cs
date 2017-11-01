using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public interface IGetInfoContext
    {
        Context Context { get; }

        Task<Info> GetOrAdd<Info>(ResourceParameters<Info> parameters, Func<Task<Info>> getOrThrow)
            where Info : class;
    }
}
