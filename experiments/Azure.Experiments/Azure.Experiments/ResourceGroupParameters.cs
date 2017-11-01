using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    /// <summary>
    /// A resource group parameters.
    /// </summary>
    public sealed class ResourceGroupParameters : ResourceParameters<ResourceGroup>
    {
        public override bool HasCommonLocation => false;

        public override string Name { get; }

        public override IEnumerable<ResourceParameters> Dependencies => NoDependencies;

        public ResourceGroupParameters(string name)
        {
            Name = name;
        }

        public override string GetLocation(ResourceGroup value)
            => value.Location;

        protected override Task<ResourceGroup> GetAsync(IGetInfoContext getContext)
            => getContext.Context.CreateResourceManagementClient().ResourceGroups.GetAsync(Name);
    }
}
