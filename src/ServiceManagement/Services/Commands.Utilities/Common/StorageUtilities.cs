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

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Linq;
    using System.Text;

    public class StorageUtilities
    {
        /// <summary>
        /// Create a cloud storage account using a service management storage client
        /// </summary>
        /// <param name="storageClient">The client to use to get storage account details.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>A CloudStorageAccount that can be used by windows azure storage library to manipulate objects in the storage account.</returns>
        public static CloudStorageAccount GenerateCloudStorageAccount(IStorageManagementClient storageClient, string accountName)
        {
            if (!TestMockSupport.RunningMocked)
            {
                var storageServiceResponse = storageClient.StorageAccounts.Get(accountName);

                Uri fileEndpoint = null;
                Uri blobEndpoint = null;
                Uri queueEndpoint = null;
                Uri tableEndpoint = null;

                if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 4)
                {
                    fileEndpoint =
                        GeneralUtilities.CreateHttpsEndpoint(
                            storageServiceResponse.StorageAccount.Properties.Endpoints[3].ToString());
                }

                if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 3)
                {
                    tableEndpoint =
                        GeneralUtilities.CreateHttpsEndpoint(
                            storageServiceResponse.StorageAccount.Properties.Endpoints[2].ToString());
                    queueEndpoint =
                        GeneralUtilities.CreateHttpsEndpoint(
                            storageServiceResponse.StorageAccount.Properties.Endpoints[1].ToString());
                }

                if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 1)
                {
                    blobEndpoint =
                        GeneralUtilities.CreateHttpsEndpoint(
                            storageServiceResponse.StorageAccount.Properties.Endpoints[0].ToString());
                }

                return new CloudStorageAccount(
                    GenerateStorageCredentials(storageClient, storageServiceResponse.StorageAccount.Name),
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
        /// <param name="storageClient">The RDFE storage management client.</param>
        /// <param name="accountName">The storage account name.</param>
        /// <returns>Storage credentials for the given account.</returns>
        public static StorageCredentials GenerateStorageCredentials(IStorageManagementClient storageClient,
           string accountName)
        {
            if (!TestMockSupport.RunningMocked)
            {
                var storageKeysResponse = storageClient.StorageAccounts.GetKeys(accountName);
                return new StorageCredentials(accountName,
                    storageKeysResponse.PrimaryKey);
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
            tableReference.CreateIfNotExists();
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
            blobContainer.CreateIfNotExists();
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
