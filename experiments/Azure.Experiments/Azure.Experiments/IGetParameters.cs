using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public interface IGetParameters
    {
        Task<T> GetOrAdd<T>(Parameters<T> parameters, Func<Task<T>> get)
            where T : class;
    }
}
