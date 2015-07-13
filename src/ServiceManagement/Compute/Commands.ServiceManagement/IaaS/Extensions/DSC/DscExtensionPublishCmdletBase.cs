using System;
using System.Management.Automation;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Extensions.DSC;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC
{
    public class DscExtensionPublishCmdletBase : DscExtensionCmdletCommonBase
    {
        public StorageManagementClient GetStorageClient()
        {
            return AzureSession.ClientFactory.CreateClient<StorageManagementClient>(
                Profile, Profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);
        }

        /// <summary>
        /// Attempts to get the user's credentials from the given Storage Context or the current subscription, if the former is null. 
        /// Throws a terminating error if the credentials cannot be determined.
        /// </summary>
        public StorageCredentials GetStorageCredentials(AzureStorageContext storageContext)
        {
            StorageCredentials credentials = null;

            if (storageContext != null)
            {
                credentials = storageContext.StorageAccount.Credentials;
            }
            else
            {
                var storageAccountName = this.Profile.Context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount);

                if (!string.IsNullOrEmpty(storageAccountName))
                {
                    var keys = GetStorageClient().StorageAccounts.GetKeys(storageAccountName);

                    if (keys != null)
                    {
                        var storageAccountKey = string.IsNullOrEmpty(keys.PrimaryKey) ? keys.SecondaryKey : keys.PrimaryKey;

                        credentials = new StorageCredentials(storageAccountName, storageAccountKey);
                    }
                }
            }

            if (credentials == null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new UnauthorizedAccessException(Resources.AzureVMDscDefaultStorageCredentialsNotFound),
                        "CredentialsNotFound",
                        ErrorCategory.PermissionDenied,
                        null));
            }

            if (string.IsNullOrEmpty(credentials.AccountName))
            {
                ThrowInvalidArgumentError(Resources.AzureVMDscStorageContextMustIncludeAccountName);
            }

            return credentials;
        }
    }
}
