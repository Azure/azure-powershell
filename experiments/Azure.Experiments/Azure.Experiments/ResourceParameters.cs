using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public abstract class ResourceParameters<T> : Parameters<T>
    {
        public ResourceGroupParameters ResourceGroup { get; }

        public sealed override IEnumerable<Parameters> Dependencies =>
            ResourceDependencies.Concat(new[] { ResourceGroup });

        public abstract IEnumerable<Parameters> ResourceDependencies { get; }

        public ResourceParameters(
            string name, ResourceGroupParameters resourceGroup)
            : base(name)
        {
            ResourceGroup = resourceGroup;
        }
    }
}
