using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourceGroupParameters : Parameters<ResourceGroup>
    {
        public ResourceGroupParameters(string name)
        {
            Name = name;
        }

        public override bool HasCommonLocation => false;

        public override string Name { get; }

        public override IEnumerable<Parameters> Dependencies => NoDependencies;

        public override string GetLocation(ResourceGroup value)
            => value.Location;

        protected override Task<ResourceGroup> GetAsync(
            Context context, IGetParameters getParameters)
            => context.CreateResource().ResourceGroups.GetAsync(Name);
    }
}
