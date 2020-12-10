using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Management.Automation;
using System.Security;

namespace Microsoft.Azure.Commands.KeyVault.Commands
{
    public abstract class FullBackupRestoreCmdletBase : KeyVaultCmdletBase
    {
        protected const string InteractiveStorageUri = "InteractiveStorageUri";
        protected const string InputObjectStorageUri = "InputObjectStorageUri";
        protected const string InteractiveStorageName = "InteractiveStorageName";
        protected const string InputObjectStorageName = "InputObjectStorageName";

        [Parameter(ParameterSetName = InteractiveStorageUri, Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [Parameter(ParameterSetName = InteractiveStorageName, Mandatory = true, Position = 1,
            HelpMessage = "Name of the HSM.")]
        [Alias("HsmName")]
        public string Name { get; set; }

        [Parameter(ParameterSetName = InteractiveStorageUri, Mandatory = true,
            HelpMessage = "URI of the storage container where the backup is going to be stored.")]
        [Parameter(ParameterSetName = InputObjectStorageUri, Mandatory = true,
            HelpMessage = "URI of the storage container where the backup is going to be stored.")]
        public Uri StorageContainerUri { get; set; }

        [Parameter(ParameterSetName = InteractiveStorageName, Mandatory = true,
            HelpMessage = "Name of the storage account where the backup is going to be stored.")]
        [Parameter(ParameterSetName = InputObjectStorageName, Mandatory = true,
            HelpMessage = "Name of the storage account where the backup is going to be stored.")]
        public string StorageAccountName { get; set; }

        [Parameter(ParameterSetName = InteractiveStorageName, Mandatory = true,
            HelpMessage = "Name of the blob container where the backup is going to be stored.")]
        [Parameter(ParameterSetName = InputObjectStorageName, Mandatory = true,
            HelpMessage = "Name of the blob container where the backup is going to be stored.")]
        public string StorageContainerName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The shared access signature (SAS) token to authenticate the storage account.")]
        public SecureString SasToken { get; set; }

        [Parameter(ParameterSetName = InputObjectStorageUri, Mandatory = true, HelpMessage = "Managed HSM object")]
        [Parameter(ParameterSetName = InputObjectStorageName, Mandatory = true, HelpMessage = "Managed HSM object")]
        public PSManagedHsm HsmObject { get; set; }

        public override void ExecuteCmdlet()
        {
            PreprocessParameterSet();
            DoExecuteCmdlet();
        }

        /// <summary>
        /// Prepare parameters so the implementation doesn't care about parameter set
        /// </summary>
        private void PreprocessParameterSet()
        {
            if (this.IsParameterBound(c => c.HsmObject))
            {
                Name = HsmObject.Name;
            }

            if (this.IsParameterBound(c => c.StorageAccountName))
            {
                StorageContainerUri = new Uri($"https://{StorageAccountName}.{DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix)}/{StorageContainerName}");
            }
        }

        public abstract void DoExecuteCmdlet();
    }
}
