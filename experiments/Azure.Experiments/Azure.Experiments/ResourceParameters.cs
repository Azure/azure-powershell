using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    public abstract class ResourceParameters<T> : Parameters<T>
        where T : class
    {
        public abstract ResourceGroupParameters ResourceGroup { get; }

        public abstract IEnumerable<Parameters> ResourceDependencies { get; }

        public sealed override bool HasCommonLocation => true;

        public sealed override IEnumerable<Parameters> Dependencies 
            => ResourceDependencies.Concat(new[] { ResourceGroup });
    }
}
