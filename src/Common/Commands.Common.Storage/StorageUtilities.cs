using System;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

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
    }
}
