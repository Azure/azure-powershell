using Azure;
using Azure.Core;
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

        private ResourceGroupResource GetResourceGroup(string resourceGroupName) =>
              _armClient.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(_subscription, resourceGroupName));


        public IEnumerable<VaultResource> ListVaults(string resourceGroupName) =>
            GetResourceGroup(resourceGroupName).GetVaults().GetAll();

        public VaultResource GetVault(string resourcegroup, string vaultName) =>
            _armClient.GetVaultResource(VaultResource.CreateResourceIdentifier(_subscription, resourcegroup, vaultName));

        public VaultResource CreateVault(string resourceGroupName, string vaultName, VaultCreateOrUpdateContent parameters) =>
            GetResourceGroup(resourceGroupName).GetVaults().CreateOrUpdate(WaitUntil.Completed, vaultName, parameters).WaitForCompletion();

    }
}
