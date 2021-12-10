using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.KeyVault;
using Azure.ResourceManager.Resources;

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.KeyVault.Track2Models
{
    public class Track2VaultCollection
    {
        private Track2TokenCredential _credential;

        public Track2VaultCollection(IAuthenticationFactory authFactory, IAzureContext context)
        {
            _credential = new Track2TokenCredential(new DataServiceCredential(authFactory, context, AzureEnvironment.Endpoint.ResourceManager)); 

            var accesstoken = authFactory.Authenticate(context.Account, context.Environment, context.Tenant.Id, null, ShowDialog.Never, null);
            _credential = new Track2TokenCredential(accesstoken.AccessToken);

            // _credential = ;
        }


        private VaultCollection CreateVaultCollection(string subscription, string resourcegroup) {
            var arm = new ArmClient(_credential).GetVault(new ResourceIdentifier(""));
            ResourceGroup rg = arm.GetSubscriptions().Get(subscription).Value.GetResourceGroups().Get(resourcegroup);
            return rg.GetVaults();
        } //=> new ArmClient(_credential).GetSubscription(subscription).GetResourceGroups().Get(resourcegroup).Value.GetVaults();

        public IEnumerable<Vault> ListVaults(string subscription, string resourcegroup)
        {
            VaultCollection vaultCollection = CreateVaultCollection(subscription, resourcegroup);
            return vaultCollection.GetAll();
        }
    }
}
