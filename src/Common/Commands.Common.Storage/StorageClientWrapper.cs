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
    using Microsoft.WindowsAzure.Management.Storage;
    using Microsoft.WindowsAzure.Management.Storage.Models;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Properties;
    using System;
    using System.Globalization;
    using System.IO;

    /// <summary>
    /// Wrapper class that encapsulates Blob functionality from the StorageClient API
    /// </summary>
    public class StorageClientWrapper : IStorageClientWrapper
    {
        public IStorageManagementClient StorageManagementClient { get; set; }

        public Func<Uri, StorageCredentials, CloudBlobClient> CloudBlobClientFactory { get; set; }

        public StorageClientWrapper(IStorageManagementClient storageManagementClient)
        {
            StorageManagementClient = storageManagementClient;
            CloudBlobClientFactory = (uri, cred) => new CloudBlobClient(uri, cred);
        }

        public void DeletePackageFromBlob(string storageName, Uri packageUri)
        {
            StorageAccountGetKeysResponse keys = StorageManagementClient.StorageAccounts.GetKeys(storageName);
            string storageKey = keys.PrimaryKey;
            var storageService = StorageManagementClient.StorageAccounts.Get(storageName);
            var blobStorageEndpoint = storageService.StorageAccount.Properties.Endpoints[0];
            var credentials = new StorageCredentials(storageName, storageKey);
            var client = new CloudBlobClient(blobStorageEndpoint, credentials);
            ICloudBlob blob = client.GetBlobReferenceFromServer(packageUri);
            blob.DeleteIfExists();
        }

        public Uri UploadFileToBlob(BlobUploadParameters parameters)
        {
            StorageAccountGetKeysResponse keys = StorageManagementClient.StorageAccounts.GetKeys(parameters.StorageName);
            string storageKey = keys.PrimaryKey;
            StorageAccountGetResponse storageService = StorageManagementClient.StorageAccounts.Get(parameters.StorageName);
            Uri blobEndpointUri = storageService.StorageAccount.Properties.Endpoints[0];
            return UploadFile(parameters.StorageName,
                StorageUtilities.CreateHttpsEndpoint(blobEndpointUri.ToString()),
                storageKey, parameters);
        }

        private Uri UploadFile(string storageName, Uri blobEndpointUri, string storageKey, BlobUploadParameters parameters)
        {
            var credentials = new StorageCredentials(storageName, storageKey);
            var client = new CloudBlobClient(blobEndpointUri, credentials);
            string blobName = parameters.FileRemoteName;
            if (string.IsNullOrEmpty(blobName))
            {
                blobName = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0}_{1}",
                    DateTime.UtcNow.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture),
                    Path.GetFileName(parameters.FileLocalPath));
            }

            CloudBlobContainer container = client.GetContainerReference(parameters.ContainerName);
            var wasCreated = container.CreateIfNotExists();
            if (wasCreated && parameters.ContainerPublic)
            {
                container.SetPermissions(new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            }

            CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

            if (blob.Exists())
            {
                if (parameters.OverrideIfExists)
                {
                    blob.DeleteIfExists();
                }
                else
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture,
                        Resources.BlobAlreadyExistsInTheAccount, blobName));
                }
            }

            using (FileStream readStream = File.OpenRead(parameters.FileLocalPath))
            {
                blob.UploadFromStream(readStream, AccessCondition.GenerateEmptyCondition(), parameters.BlobRequestOptions);
            }

            blob = container.GetBlockBlobReference(blobName);

            string sasContainerToken = string.Empty;

            if (!parameters.ContainerPublic)
            {
                //Set the expiry time and permissions for the blob.
                //Start time is specified as a few minutes in the past, to mitigate clock skew.
                //The shared access signature will be valid immediately.
                SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
                sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddHours(parameters.SasTokenDurationInHours);
                sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

                //Generate the shared access signature on the blob, setting the constraints directly on the signature.
                sasContainerToken = blob.GetSharedAccessSignature(sasConstraints);
            }

            string fullUrl = client.BaseUri + parameters.ContainerName + client.DefaultDelimiter + blobName + sasContainerToken;

            return new Uri(fullUrl);
        }
    }
}