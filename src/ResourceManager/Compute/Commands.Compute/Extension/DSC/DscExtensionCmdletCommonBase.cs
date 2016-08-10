using Microsoft.Azure.Commands.Management.Storage;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    static class DscExtensionCmdletCommonBase
    {
        private static StorageManagementClientWrapper _storageClientWrapper;

        private static IStorageManagementClient GetStorageClient(this Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet cmdlet)
        {
            if (_storageClientWrapper == null)
            {
                _storageClientWrapper = new StorageManagementClientWrapper(AzureRmProfileProvider.Instance.Profile.Context);
            }

            return _storageClientWrapper.StorageManagementClient;
        }

        internal static StorageCredentials GetStorageCredentials(this Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet cmdlet, String resourceGroupName, String storageAccountName)
        {
            StorageCredentials credentials = null;
            var storageClient = GetStorageClient(cmdlet);

            if (storageClient != null && storageClient.StorageAccounts != null)
            {
                var keys = storageClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);

                if (keys != null)
                {
                    var storageAccountKey = string.IsNullOrEmpty(keys.Key1) ? keys.Key2 : keys.Key1;

                    credentials = new StorageCredentials(storageAccountName, storageAccountKey);
                }
            }

            if (credentials == null)
            {
                cmdlet.ThrowTerminatingError(
                    new ErrorRecord(
                        new UnauthorizedAccessException(Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscDefaultStorageCredentialsNotFound),
                        "CredentialsNotFound",
                        ErrorCategory.PermissionDenied,
                        null));
            }

            if (string.IsNullOrEmpty(credentials.AccountName))
            {
                ThrowInvalidArgumentError(cmdlet, Microsoft.Azure.Commands.Compute.Properties.Resources.AzureVMDscStorageContextMustIncludeAccountName);
            }

            return credentials;
        }

        internal static void ThrowInvalidArgumentError(this Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet cmdlet, string format, params object[] args)
        {
            cmdlet.ThrowTerminatingError(
                new ErrorRecord(
                    new ArgumentException(string.Format(CultureInfo.CurrentUICulture, format, args)),
                    "InvalidArgument",
                    ErrorCategory.InvalidArgument,
                    null));
        }
    }
}
