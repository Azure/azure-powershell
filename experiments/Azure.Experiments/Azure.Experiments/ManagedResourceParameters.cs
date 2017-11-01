using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Experiments
{
    /// <summary>
    /// Managed resource parameters.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ManagedResourceParameters<T> : ResourceParameters<T>
        where T : class
    {
        public abstract ResourceGroupParameters ResourceGroup { get; }

        public abstract IEnumerable<ResourceParameters> ResourceDependencies { get; }

        public sealed override bool HasCommonLocation => true;

        /// <summary>
        /// Resource dependencies and a resource group.
        /// </summary>
        public sealed override IEnumerable<ResourceParameters> Dependencies 
            => ResourceDependencies.Concat(new[] { ResourceGroup });
    }
}
