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
using System.Collections.Generic;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class WindowsAzureSubscriptionExtensions
    {
        private static Dictionary<Guid, CloudStorageAccount> storageAccountCache = new Dictionary<Guid,CloudStorageAccount>();

        public static CloudStorageAccount GetCloudStorageAccount(this AzureSubscription subscription)
        {
            if (subscription == null)
            {
                return null;
            }

            using (var storageClient = AzureSession.ClientFactory.CreateClient<StorageManagementClient>(subscription, AzureEnvironment.Endpoint.ServiceManagement))
            {
                return StorageUtilities.GenerateCloudStorageAccount(
                    storageClient, subscription.GetProperty(AzureSubscription.Property.StorageAccount));
            }
        }
    }
}
