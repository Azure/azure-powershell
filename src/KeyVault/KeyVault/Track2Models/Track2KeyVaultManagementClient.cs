using Azure.ResourceManager;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.KeyVault.Models;
using Azure.ResourceManager.Resources;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    internal class Track2KeyVaultManagementClient
    {
        private Track2TokenCredential _credential;

        private ArmClient _armClient;
        private string _subscription;

        public Track2KeyVaultManagementClient(IAuthenticationFactory authFactory, IAzureContext context)
        {
            var accesstoken = authFactory.Authenticate(context.Account, context.Environment, context.Tenant.Id, null, ShowDialog.Never, null);
            _credential = new Track2TokenCredential(accesstoken.AccessToken);
            _armClient = new ArmClient(_credential);
            _subscription = context.Subscription.Id;
        }

        private ResourceGroup GetResourceGroup(string resourcegroup) =>
            _armClient.GetResourceGroup(
                Track2VaultManagementClient.ConstructResourceIdentifier(_subscription, resourcegroup));

        public IEnumerable<Vault> ListVaults(string resourcegroup) => 
            GetResourceGroup(resourcegroup).GetVaults().GetAll();

        public Vault GetVault(string resourcegroup, string vaultName) =>
            _armClient.GetVault(Track2VaultManagementClient.ConstructResourceIdentifier(
                _subscription, resourcegroup, Track2VaultManagementClient.VaultsResourceType, vaultName));

        public Vault CreateVault(string resourcegroup, string vaultName, VaultCreateOrUpdateParameters parameters) =>
            GetResourceGroup(resourcegroup).GetVaults().CreateOrUpdate(vaultName, parameters).Value;
        
    }
}
