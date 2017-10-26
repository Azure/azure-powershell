using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public abstract class ResourceParameters<T> : Parameters<T>
        where T : class
    {
        public ResourceGroupParameters ResourceGroup { get; }

        public ResourceParameters(
            string name,
            ResourceGroupParameters resourceGroup,
            IEnumerable<Parameters> dependencies)
            : base(name, dependencies.Concat(new[] { resourceGroup }))
        {
            ResourceGroup = resourceGroup;
        }
    }
}
