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
        private ArmClient _armClient;
        private string _subscription;
        private IClientFactory _clientFactory;

        public Track2KeyVaultManagementClient(IClientFactory clientFactory, IAzureContext context)
        {
            _clientFactory = clientFactory;
            _armClient = _clientFactory.CreateArmClient(context, AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId);
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
