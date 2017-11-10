using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments
{
    public interface IState
    {
        ResourceGroup GetResourceGroup(string name);

        T Get<T>(ResourceConfig<T> resourceConfig)
            where T : class;

        T Get<T, P>(ChildResourceConfig<T, P> childResourceConfig)
            where T : class
            where P : class;
    }
}
