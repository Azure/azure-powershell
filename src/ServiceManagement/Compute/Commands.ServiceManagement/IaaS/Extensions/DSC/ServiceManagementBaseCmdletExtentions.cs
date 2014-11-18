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
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions.DSC
{
    static class ServiceManagementBaseCmdletExtentions
    {
        /// <summary>
        /// Attempts to get the user's credentials from the given Storage Context or the current subscription, if the former is null. 
        /// Throws a terminating error if the credentials cannot be determined.
        /// </summary>
        public static StorageCredentials GetStorageCredentials(this ServiceManagementBaseCmdlet cmdlet, AzureStorageContext storageContext)
        {
            StorageCredentials credentials = null;

            if (storageContext != null)
            {
                credentials = storageContext.StorageAccount.Credentials;
            }
            else
            {
                var storageAccountName = cmdlet.CurrentContext.Subscription.GetProperty(AzureSubscription.Property.StorageAccount);
                
                if (!string.IsNullOrEmpty(storageAccountName))
                {
                    var keys = cmdlet.StorageClient.StorageAccounts.GetKeys(storageAccountName);
                    
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
                cmdlet.ThrowInvalidArgumentError(Resources.AzureVMDscStorageContextMustIncludeAccountName);
            }

            return credentials;
        }

        public static void ThrowInvalidArgumentError(this ServiceManagementBaseCmdlet cmdlet, string format, params object[] args)
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
