using System;

namespace Microsoft.Azure.Experiments
{
    public interface IClient
    {
        Context Context { get; }

        T GetClient<T>()
            where T : class, IDisposable;
    }
}
