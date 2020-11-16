using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1.Models;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public class KeyVaultClient
    {
        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }
        public KeyVaultClient(IAzureContext context)
        {
            this.WrappedKeyVaultClient = AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }

        public KeyVaultManagementClient WrappedKeyVaultClient
        {
            get;
            private set;
        }

        public Vault GetKeyVault(string resourceGroupName, string vaultName)
        {
            //Vault vault = null;
            try
            {
                //this.WrappedKeyVaultClient.SubscriptionId = "3e929699-b7a4-46cc-97cf-8a95e04318b8";
                return this.WrappedKeyVaultClient.Vaults.Get(resourceGroupName, vaultName);
                //var res = this.WrappedKeyVaultClient.Vaults.ListBySubscription();
                //foreach (var item in res)
                //{
                //    vault = item;
                //}
                //return vault;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}