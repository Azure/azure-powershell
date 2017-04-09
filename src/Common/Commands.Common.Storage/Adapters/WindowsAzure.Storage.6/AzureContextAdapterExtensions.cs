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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Management.Storage.Models;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common.Storage;

namespace Microsoft.WindowsAzure.Commands.Storage.Adapters
{
    public static class AzureContextAdapterExtensions
    {
        /// <summary>
        /// Get the current storage account.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <returns>The current storage account, or null, if no current storage account is set.</returns>
        public static CloudStorageAccount GetCurrentStorageAccount(this IAzureContext context)
        {
            if (context != null)
            {
                var storageConnectionString = context.GetCurrentStorageAccountConnectionString();
                try
                {
                    return
                        CloudStorageAccount.Parse(storageConnectionString);
                }
                catch
                {
                    var storageClient = AzureSession.Instance.ClientFactory.CreateClient<StorageManagementClient>(context, AzureEnvironment.Endpoint.ServiceManagement);
                    var provider = new RDFEStorageProvider(storageClient, context.Environment);
                    var service = provider.GetStorageService(storageConnectionString, null);
                    return (service.Context as AzureStorageContext).StorageAccount;
                }
            }

            return null;
        }

    }
}
