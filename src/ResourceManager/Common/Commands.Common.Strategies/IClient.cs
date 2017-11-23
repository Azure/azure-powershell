using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Common.Strategies
{
    public interface IClient
    {
        T GetClient<T>()
            where T : ServiceClient<T>;
    }
}
