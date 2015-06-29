using System;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Commands.Management.Storage;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.Azure.Commands.Compute.Extension.DSC
{
    public class VirtualMachineDscExtensionBaseCmdlet : VirtualMachineExtensionBaseCmdlet
    {
        private StorageManagementClientWrapper _storageClientWrapper;

        protected string ExtensionNamespace = "Microsoft.Powershell";
        protected string ExtensionName = "DSC";
        protected string DefaultContainerName = "windows-powershell-dsc";
        protected string DefaultExtensionVersion = "1.*";

        //why do we need this?
        internal static readonly Version CurrentProtocolVersion = new Version(2, 0, 0, 0);

        private IStorageManagementClient StorageClient
        {
            get
            {
                if (_storageClientWrapper == null)
                {
                    _storageClientWrapper = new StorageManagementClientWrapper(Profile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp
                    };
                }

                return _storageClientWrapper.StorageManagementClient;
            }

            set { _storageClientWrapper = new StorageManagementClientWrapper(value); }
        }

        public StorageCredentials GetStorageCredentials(String resourceGroupName, AzureStorageContext storageContext)
        {
            StorageCredentials credentials = null;

            if (storageContext != null)
            {
                credentials = storageContext.StorageAccount.Credentials;
            }
            else
            {
                //var storageAccountName = Profile.Context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount);
                if (StorageClient.StorageAccounts != null)
                {
                    StorageAccountListResponse response = StorageClient.StorageAccounts.ListByResourceGroup(resourceGroupName);

                }
                if (!string.IsNullOrEmpty(storageAccountName) && StorageClient.StorageAccounts != null)
                {

                    var keys = StorageClient.StorageAccounts.ListKeys(resourceGroupName, storageAccountName);

                    if (keys != null && keys.StorageAccountKeys != null)
                    {
                        var storageAccountKey = string.IsNullOrEmpty(keys.StorageAccountKeys.Key1) ? keys.StorageAccountKeys.Key2 : keys.StorageAccountKeys.Key1;

                        credentials = new StorageCredentials(storageAccountName, storageAccountKey);
                    }
                }
            }

            if (credentials == null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                        new UnauthorizedAccessException(Properties.Resources.AzureVMDscDefaultStorageCredentialsNotFound),
                        "CredentialsNotFound",
                        ErrorCategory.PermissionDenied,
                        null));
            }

            if (string.IsNullOrEmpty(credentials.AccountName))
            {
                ThrowInvalidArgumentError(Properties.Resources.AzureVMDscStorageContextMustIncludeAccountName);
            }

            return credentials;
        }

        //TODO: Move this to a common Exception class for DSC
        public void ThrowInvalidArgumentError(string format, params object[] args)
        {
            ThrowTerminatingError(
                new ErrorRecord(
                    new ArgumentException(string.Format(CultureInfo.CurrentUICulture, format, args)),
                    "InvalidArgument",
                    ErrorCategory.InvalidArgument,
                    null));
        }
    }
}
