using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System.Threading.Tasks;

namespace Microsoft.Azure.Experiments
{
    public sealed class ResourceGroupParameters : Parameters<ResourceGroup>
    {
        public ResourceGroupParameters(string name) : base(name, NoDependencies)
        {
        }

        public override bool HasCommonLocation => false;

        public override string GetLocation(ResourceGroup value)
            => value.Location;

        protected override Task<ResourceGroup> GetAsync(
            Context context, IGetParameters getParameters)
            => context.CreateResource().ResourceGroups.GetAsync(Name);
    }
}
