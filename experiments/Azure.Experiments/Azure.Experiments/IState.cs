using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Experiments
{
    public interface IState
    {
        ResourceGroup GetResourceGroup(string name);
        T Get<T>(ResourceConfig<T> resourceConfig)
            where T : class;
        T Get<T>(IChildResourceConfig<T> childResourceConfig)
            where T : class;
    }
}
