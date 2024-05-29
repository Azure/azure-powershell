using Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Exceptions;
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
        public string HsmName { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "The shared access signature (SAS) token to authenticate the storage account.")]
        public SecureString SasToken { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specified to use User Managed Identity to authenticate the storage account. Only valid when SasToken is not set.")]
        public SwitchParameter UseUserManagedIdentity { get; set; }

        [Parameter(ParameterSetName = InputObjectStorageUri, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Managed HSM object")]
        [Parameter(ParameterSetName = InputObjectStorageName, Mandatory = true, ValueFromPipeline = true, HelpMessage = "Managed HSM object")]
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
                HsmName = HsmObject.Name;
            }

            if (this.IsParameterBound(c => c.StorageAccountName))
            {
                StorageContainerUri = new Uri($"https://{StorageAccountName}.blob.{DefaultContext.Environment.GetEndpoint(AzureEnvironment.Endpoint.StorageEndpointSuffix)}/{StorageContainerName}");
            }

            if (this.IsParameterBound(c => c.SasToken) && SasToken == null)
            {
                throw new AzPSArgumentException(Resources.SasTokenNotNull, ErrorKind.UserError);
            }

            if (this.IsParameterBound(c => c.SasToken) && this.UseUserManagedIdentity.IsPresent)
            {
                throw new AzPSArgumentException(Resources.UseManagedIdentityAndSasTokenBothExist, ErrorKind.UserError);
            }

            if (!this.IsParameterBound(c => c.SasToken) && !this.UseUserManagedIdentity.IsPresent)
            {
                throw new AzPSArgumentException(Resources.UseManagedIdentityAndSasTokenNeitherExist, ErrorKind.UserError);
            }
        }

        public abstract void DoExecuteCmdlet();
    }
}
