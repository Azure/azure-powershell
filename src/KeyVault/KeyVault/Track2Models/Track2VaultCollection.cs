using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.Resources;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;

using System;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    public class Track2VaultCollection
    {

        VaultCollection _vaultCollection;
        private Track2TokenCredential _credential;

        public Track2VaultCollection(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _credential = new Track2TokenCredential(new DataServiceCredential(authFactory, context, AzureEnvironment.ExtendedEndpoint.ManagedHsmServiceEndpointResourceId)); 
        }

        private VaultCollection CreateVaultCollection(string subscription, string resourcegroup) => new ArmClient(_credential).GetSubscription(subscription).GetResourceGroups().Get(resourcegroup).Value.GetVaults();

        public void ListVaults(string subscription, string resourcegroup)
        {
            VaultCollection vaultCollection = CreateVaultCollection(subscription, resourcegroup);
        }
    }
}
