using System;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IClient
    {
        T GetClient<T>()
            where T : class, IDisposable;
    }
}
