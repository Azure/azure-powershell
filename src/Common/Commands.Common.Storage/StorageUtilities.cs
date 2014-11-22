using System;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    public class StorageUtilities
    {
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
                fileEndpoint = GeneralUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[3].ToString());
            }
            
            if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 3)
            {
                tableEndpoint = GeneralUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[2].ToString());
                queueEndpoint = GeneralUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[1].ToString());
            }

            if (storageServiceResponse.StorageAccount.Properties.Endpoints.Count >= 1)
            {
                blobEndpoint = GeneralUtilities.CreateHttpsEndpoint(storageServiceResponse.StorageAccount.Properties.Endpoints[0].ToString());
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
