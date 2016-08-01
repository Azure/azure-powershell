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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Storage.Auth;
using System;
using Rsrc = Microsoft.Azure.Commands.Compute.Properties.Resources;

namespace Microsoft.Azure.Commands.Compute.StorageServices
{
    public class StorageCredentialsFactory
    {
        private StorageManagementClient client;
        private AzureSubscription currentSubscription;
        public string resourceGroupName { get; set; }

        public static bool IsChannelRequired(Uri destination)
        {
            return String.IsNullOrEmpty(destination.Query);
        }

        public StorageCredentialsFactory()
        {
            this.resourceGroupName = null;
        }

        public StorageCredentialsFactory(string resourceGroupName, StorageManagementClient client, AzureSubscription currentSubscription)
        {
            this.resourceGroupName = resourceGroupName;
            this.client = client;
            this.currentSubscription = currentSubscription;
        }

        public StorageCredentials Create(BlobUri destination)
        {
            if (IsChannelRequired(destination.Uri))
            {
                if (currentSubscription == null)
                {
                    throw new ArgumentException(Rsrc.StorageCredentialsFactoryCurrentSubscriptionNotSet, "SubscriptionId");
                }
                var storageKeys = this.client.StorageAccounts.ListKeys(this.resourceGroupName, destination.StorageAccountName);
                return new StorageCredentials(destination.StorageAccountName, storageKeys.Key1);
            }

            return new StorageCredentials(destination.Uri.Query);
        }
    }
}
