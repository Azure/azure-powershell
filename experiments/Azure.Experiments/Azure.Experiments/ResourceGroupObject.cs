using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.ResourceManager;
using System.Threading.Tasks;

namespace Azure.Experiments
{
    public sealed class ResourceGroupObject : AzureObject<
        ResourceGroup, ResourceGroupPolicy>
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

        protected override Task<ResourceGroup> CreateAsync(string location)
            => Client.CreateOrUpdateAsync(
                Name,
                new ResourceGroup { Location = location });

        protected override Task<ResourceGroup> GetOrThrowAsync()
            => Client.GetAsync(Name);

        private IResourceGroupsOperations Client { get; }
    }
}
