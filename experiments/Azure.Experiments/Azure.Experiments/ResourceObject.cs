using System.Collections.Generic;
using System.Linq;

namespace Azure.Experiments
{
    public abstract class ResourceObject<T, C> : AzureObject<T, C>
        where T : class
    {
        protected string ResourceGroupName { get; }

        protected ResourceObject(
            string name,
            ResourceGroupObject rg,
            IEnumerable<AzureObject> dependencies) 
            : base(name, dependencies.Concat(new[] { rg }))
        {
            ResourceGroupName = rg.Name;
        }

        protected ResourceObject(
            string name,
            ResourceGroupObject rg)
            : this(name, rg, Enumerable.Empty<AzureObject>())
        {
        }
    }
}
