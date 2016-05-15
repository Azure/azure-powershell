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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class WindowsAzureSubscriptionExtensions
    {
        private static Dictionary<Guid, CloudStorageAccount> storageAccountCache = new Dictionary<Guid, CloudStorageAccount>();

        /// <summary>
        /// Get storage account details from the current storage account
        /// </summary>
        /// <param name="subscription">The subscription containing the account.</param>
        /// <param name="profile">The profile continuing the subscription.</param>
        /// <returns>Storage account details, usable with the windows azure storage data plane library.</returns>
        public static CloudStorageAccount GetCloudStorageAccount(this AzureSubscription subscription, AzureSMProfile profile)
        {
            if (subscription == null)
            {
                return null;
            }

            var account = subscription.GetProperty(AzureSubscription.Property.StorageAccount);
            try
            {
                return CloudStorageAccount.Parse(account);

            }
            catch
            {
                using (
                    var storageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(profile,
                        subscription, AzureEnvironment.Endpoint.ServiceManagement))
                {
                    return StorageUtilities.GenerateCloudStorageAccount(
                        storageClient, account);
                }
            }
        }
    }
}
