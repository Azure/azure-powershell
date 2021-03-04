using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1;
using Microsoft.Azure.Commands.Common.KeyVault.Version2016_10_1.Models;
using System;


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
            try
            {
                return this.WrappedKeyVaultClient.Vaults.Get(resourceGroupName, vaultName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
