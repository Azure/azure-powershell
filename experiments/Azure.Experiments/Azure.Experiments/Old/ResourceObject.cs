using System.Collections.Generic;
using System.Linq;

namespace Azure.Experiments
{
    public abstract class ResourceObject<T, P> : AzureObject<T, P>
        where T : class
        where P : struct, IInfoPolicy<T>
    {
        public string ResourceGroupName { get; }

        protected ResourceObject(
            ResourceGroupObject rg,
            IEnumerable<AzureObject> dependencies) 
            : base(dependencies.Concat(new[] { rg }))
        {
            ResourceGroupName = rg.Name;
        }

        protected ResourceObject(
            ResourceGroupObject rg)
            : this(rg, NoDependencies)
        {
        }
    }
}
