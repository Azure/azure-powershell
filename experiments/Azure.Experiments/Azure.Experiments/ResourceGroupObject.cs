using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class ResourceGroupObject : AzureObject<
        ResourceGroup, IResourceGroupsOperations>
    {
        public ResourceGroupObject(Context client, string name) 
            : base(name, NoDependencies)
        {
            Client = new ResourceManagementClient(client.Credentials)
                {
                    SubscriptionId = client.SubscriptionId
                }
                .ResourceGroups;
        }        

        protected override IResourceGroupsOperations CreateClient(Context c)
            => new ResourceManagementClient(c.Credentials)
                {
                    SubscriptionId = c.SubscriptionId
                }
                .ResourceGroups;

        protected override Task<ResourceGroup> CreateAsync(IResourceGroupsOperations _)
            => Client.CreateOrUpdateAsync(
                Name,
                new ResourceGroup { Location = "eastus" });

        protected override Task<ResourceGroup> GetOrThrowAsync(IResourceGroupsOperations _)
            => Client.GetAsync(Name);

        private IResourceGroupsOperations Client { get; }
    }
}
