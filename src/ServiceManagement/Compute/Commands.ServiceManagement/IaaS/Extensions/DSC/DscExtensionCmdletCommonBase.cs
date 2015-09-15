// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Management.Automation;
using Microsoft.Azure.Common.Authentication;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC
{
    public static class DscExtensionCmdletCommonBase
    {
        internal const string VirtualMachineDscExtensionCmdletNoun = "AzureVMDscExtension";
        internal static readonly string DefaultExtensionVersion = "1.*";

        /// <summary>
        /// Attempts to get the user's credentials from the given Storage Context or the current subscription, if the former is null. 
        /// Throws a terminating error if the credentials cannot be determined.
        /// </summary>
        internal static StorageCredentials GetStorageCredentials(this AzurePSCmdlet cmdlet, AzureStorageContext storageContext)
        {
            StorageCredentials credentials = null;

            if (storageContext != null)
            {
                credentials = storageContext.StorageAccount.Credentials;
            }
            else
            {
                var storageAccountName = cmdlet.Profile.Context.Subscription.GetProperty(AzureSubscription.Property.StorageAccount);

                var storageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(
                        cmdlet.Profile, cmdlet.Profile.Context.Subscription, AzureEnvironment.Endpoint.ServiceManagement);

                if (!string.IsNullOrEmpty(storageAccountName) && storageClient != null)
                {
                    var keys = storageClient.StorageAccounts.GetKeys(storageAccountName);
                    
                    if (keys != null)
                    {
                        var storageAccountKey = string.IsNullOrEmpty(keys.PrimaryKey) ? keys.SecondaryKey : keys.PrimaryKey;

                        credentials = new StorageCredentials(storageAccountName, storageAccountKey);
                    }
                }
            }

            if (credentials == null)
            {
                cmdlet.ThrowTerminatingError(
                    new ErrorRecord(
                        new UnauthorizedAccessException(Resources.AzureVMDscDefaultStorageCredentialsNotFound),
                        "CredentialsNotFound",
                        ErrorCategory.PermissionDenied,
                        null));
            }

            if (string.IsNullOrEmpty(credentials.AccountName))
            {
                ThrowInvalidArgumentError(cmdlet, Resources.AzureVMDscStorageContextMustIncludeAccountName);
            }

            return credentials;
        }

        internal static void ThrowInvalidArgumentError(this AzurePSCmdlet cmdlet, string format, params object[] args)
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
