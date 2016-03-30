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
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    public class StorageCredentialsFactory
    {
        private StorageManagementClient client;
        private AzureSubscription currentSubscription;

        public static bool IsChannelRequired(Uri destination)
        {
            return String.IsNullOrEmpty(destination.Query);
        }

        public StorageCredentialsFactory()
        {
        }

        public StorageCredentialsFactory(StorageManagementClient client, AzureSubscription currentSubscription)
        {
            this.client = client;
            this.currentSubscription = currentSubscription;
        }

        public StorageCredentials Create(BlobUri destination)
        {
            if (IsChannelRequired(destination.Uri))
            {
                if(currentSubscription == null)
                {
                    throw new ArgumentException(Resources.StorageCredentialsFactoryCurrentSubscriptionNotSet, "SubscriptionId");
                }

                var storageKeys = this.client.StorageAccounts.GetKeys(destination.StorageAccountName);
                return new StorageCredentials(destination.StorageAccountName, storageKeys.PrimaryKey);
            }

            return new StorageCredentials(destination.Uri.Query);
        }
    }
}