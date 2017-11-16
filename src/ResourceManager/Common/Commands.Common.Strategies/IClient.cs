using Microsoft.Rest;
using System;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IClient
    {
        T GetClient<T>()
            where T : ServiceClient<T>;
    }
}
