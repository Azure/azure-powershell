
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


namespace Microsoft.Azure.Commands.Common.Storage
{
    using System;
    using WindowsAzure.Storage;
    using WindowsAzure.Storage.Auth;
    using WindowsAzure.Storage.Blob;
    using WindowsAzure.Storage.Table;
    using System.Text;
    using Azure.Commands.Utilities.Common;
    using Azure.Management.Storage;

    public class StorageUtilities
    {
        /// <summary>
        /// Creates https endpoint from the given endpoint.
        /// </summary>
        /// <param name="endpointUri">The endpoint uri.</param>
        /// <returns>The https endpoint uri.</returns>
        public static Uri CreateHttpsEndpoint(string endpointUri)
        {
            UriBuilder builder = new UriBuilder(endpointUri) { Scheme = "https" };
            string endpoint = builder.Uri.GetComponents(
                UriComponents.AbsoluteUri & ~UriComponents.Port,
                UriFormat.UriEscaped);

            return new Uri(endpoint);
        }

        /// <summary>
        /// Create a cloud storage account using an ARM storage management client
        /// </summary>
        /// <param name="storageClient">The client to use to get storage account details.</param>
        /// <param name="resourceGroupName">The resource group contining the storage account.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>A CloudStorageAccount that can be used by windows azure storage library to manipulate objects in the storage account.</returns>
        public static CloudStorageAccount GenerateCloudStorageAccount(IStorageManagementClient storageClient,
            string resourceGroupName, string accountName)
        {
            if (!TestMockSupport.RunningMocked)
            {
                var storageServiceResponse = storageClient.StorageAccounts.GetProperties(resourceGroupName, accountName);
                Uri blobEndpoint = new Uri(storageServiceResponse.PrimaryEndpoints.Blob);
                Uri queueEndpoint = new Uri(storageServiceResponse.PrimaryEndpoints.Queue);
                Uri tableEndpoint = new Uri(storageServiceResponse.PrimaryEndpoints.Table);
                Uri fileEndpoint = new Uri(storageServiceResponse.PrimaryEndpoints.File);

                return new CloudStorageAccount(
                    GenerateStorageCredentials(storageClient, resourceGroupName, accountName),
                    blobEndpoint,
                    queueEndpoint,
                    tableEndpoint, 
                    fileEndpoint);
            }
            else
            {
                return new CloudStorageAccount(
                    new StorageCredentials(accountName,
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))),
                    new Uri(string.Format("https://{0}.blob.core.windows.net", accountName)),
                    new Uri(string.Format("https://{0}.queue.core.windows.net", accountName)),
                    new Uri(string.Format("https://{0}.table.core.windows.net", accountName)),                    
                    new Uri(string.Format("https://{0}.file.core.windows.net", accountName)));
            }
        }


        /// <summary>
        /// Create storage credentials for the given account
        /// </summary>
        /// <param name="storageClient">The ARM storage management client.</param>
        /// <param name="resourceGroupName">The resource group containing the storage account.</param>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>Storage credentials for the given account.</returns>
        public static StorageCredentials GenerateStorageCredentials(IStorageManagementClient storageClient,
            string resourceGroupName, string accountName)
        {
            if (!TestMockSupport.RunningMocked)
            {
                var storageKeysResponse = storageClient.StorageAccounts.ListKeys(resourceGroupName, accountName);
                return new StorageCredentials(accountName,
                    storageKeysResponse.Key1);
            }
            else
            {
                return new StorageCredentials(accountName,
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())));
            }
        }

        public static string GenerateTableStorageSasUrl(string connectionString, string tableName, DateTime expiryTime, SharedAccessTablePermissions permissions)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable tableReference = tableClient.GetTableReference(tableName);
            tableReference.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            var sasToken = tableReference.GetSharedAccessSignature(
                new SharedAccessTablePolicy()
                {
                    SharedAccessExpiryTime = expiryTime,
                    Permissions = permissions
                });

            return tableReference.Uri + sasToken;
        }

        public static string GenerateBlobStorageSasUrl(string connectionString, string blobContainerName, DateTime expiryTime, SharedAccessBlobPermissions permissions)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(blobContainerName);
            blobContainer.CreateIfNotExistsAsync().GetAwaiter().GetResult();
            var sasToken = blobContainer.GetSharedAccessSignature(
                new SharedAccessBlobPolicy()
                {
                    SharedAccessExpiryTime = expiryTime,
                    Permissions = permissions
                });

            return blobContainer.Uri + sasToken;
        }
    }
}
