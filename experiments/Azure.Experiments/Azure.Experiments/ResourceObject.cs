using System.Collections.Generic;
using System.Linq;

namespace Azure.Experiments
{
    public abstract class ResourceObject<T> : AzureObject<T>
        where T : class
    {
        public string ResourceGroupName { get; }

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
            : this(name, rg, NoDependencies)
        {
        }
    }
}
