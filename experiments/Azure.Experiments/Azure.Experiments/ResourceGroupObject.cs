using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class ResourceGroupObject : AzureObject<
        ResourceGroup, IResourceGroupsOperations>
    {
        public ResourceGroupObject(string name) 
            : base(name, NoDependencies)
        {
        }        

        protected override IResourceGroupsOperations CreateClient(Context c)
            => new ResourceManagementClient(c.Credentials)
                {
                    SubscriptionId = c.SubscriptionId
                }
                .ResourceGroups;

        protected override Task<ResourceGroup> CreateAsync(IResourceGroupsOperations c)
            => c.CreateOrUpdateAsync(
                Name,
                new ResourceGroup { Location = "eastus" });

        protected override Task<ResourceGroup> GetOrThrowAsync(IResourceGroupsOperations c)
            => c.GetAsync(Name);

        protected override Task DeleteAsync(IResourceGroupsOperations c)
            => c.DeleteAsync(Name);
    }
}
