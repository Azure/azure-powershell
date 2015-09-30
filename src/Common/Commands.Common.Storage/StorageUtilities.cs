
using Microsoft.Azure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    using System;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Table;
    using  Arm = Microsoft.Azure.Management.Storage;

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
        public static CloudStorageAccount GenerateCloudStorageAccount(Arm.StorageManagementClient storageClient, string resourceGroupName, string accountName)
        {
            var storageServiceResponse = storageClient.StorageAccounts.GetProperties(resourceGroupName, accountName);
            var storageKeysResponse = storageClient.StorageAccounts.ListKeys(resourceGroupName, accountName);
            Uri blobEndpoint = storageServiceResponse.StorageAccount.PrimaryEndpoints.Blob;
            Uri queueEndpoint = storageServiceResponse.StorageAccount.PrimaryEndpoints.Queue;
            Uri tableEndpoint = storageServiceResponse.StorageAccount.PrimaryEndpoints.Table;
            return new CloudStorageAccount(
                new StorageCredentials(storageServiceResponse.StorageAccount.Name, storageKeysResponse.StorageAccountKeys.Key1),
                blobEndpoint,
                queueEndpoint,
                tableEndpoint, null);
        }

        /// <summary>
        /// Create a cloud storage account using a service management storage client
        /// </summary>
        /// <param name="storageClient">The client to use to get storage account details.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>A CloudStorageAccount that can be used by windows azure storage library to manipulate objects in the storage account.</returns>
        public static CloudStorageAccount GenerateCloudStorageAccount(StorageManagementClient storageClient, string accountName)
        {
            var storageServiceResponse = storageClient.StorageAccounts.Get(accountName);
            var storageKeysResponse = storageClient.StorageAccounts.GetKeys(accountName);

            Uri fileEndpoint = null;
            Uri blobEndpoint = null;
            Uri queueEndpoint = null;
            Uri tableEndpoint = null;

            if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 4)
            {
                fileEndpoint = StorageUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[3].ToString());
            }
            
            if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 3)
            {
                tableEndpoint = StorageUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[2].ToString());
                queueEndpoint = StorageUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[1].ToString());
            }

            if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 1)
            {
                blobEndpoint = StorageUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[0].ToString());
            }

            return new CloudStorageAccount(
                new StorageCredentials(storageServiceResponse.StorageAccount.Name, storageKeysResponse.PrimaryKey),
                blobEndpoint,
                queueEndpoint,
                tableEndpoint,
                fileEndpoint);
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
