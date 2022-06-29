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

namespace Microsoft.WindowsAzure.Commands.Storage.Model.Contract
{
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.Azure.Storage;
    using XSCL = Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using Microsoft.Azure.Storage.File.Protocol;
    using Microsoft.Azure.Storage.Queue;
    using XSCLProtocol = Microsoft.Azure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage;

    /// <summary>
    /// Blob management
    /// </summary>
    public class StorageBlobManagement : IStorageBlobManagement
    {
        /// <summary>
        /// Azure storage blob client
        /// </summary>
        private CloudBlobClient blobClient;

        /// <summary>
        /// Internal storage context
        /// </summary>
        private AzureStorageContext internalStorageContext;

        private CloudBlobClient BlobClient
        {
            get
            {
                if (this.blobClient == null)
                {
                    if (this.StorageContext.StorageAccount == null)
                    {
                        throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
                    }
                    else
                    {
                        this.blobClient = this.StorageContext.StorageAccount.CreateCloudBlobClient();
                    }
                }

                return this.blobClient;
            }
        }

        /// <summary>
        /// The azure storage context assoicated with this IStorageBlobManagement
        /// </summary>
        public AzureStorageContext StorageContext
        {
            get
            {
                return internalStorageContext;
            }
        }

        /// <summary>
        /// Init blob management
        /// </summary>
        /// <param name="context">a cloud blob object</param>
        public StorageBlobManagement(AzureStorageContext context)
        {
            internalStorageContext = context;
        }

        /// <summary>
        /// Get a list of CloudBlobContainer in azure
        /// </summary>
        /// <param name="prefix">Container prefix</param>
        /// <param name="detailsIncluded">Container listing details</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlobContainer</returns>
        public IEnumerable<CloudBlobContainer> ListContainers(string prefix, ContainerListingDetails detailsIncluded, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            //https://ahmet.im/blog/azure-listblobssegmentedasync-listcontainerssegmentedasync-how-to/
            BlobContinuationToken continuationToken = null;
            var results = new List<CloudBlobContainer>();
            do
            {
                try
                {
                    var response = BlobClient.ListContainersSegmentedAsync(prefix, detailsIncluded, null, continuationToken, options, operationContext).Result;
                    continuationToken = response.ContinuationToken;
                    results.AddRange(response.Results);
                }
                catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
                {
                    throw e.InnerException;
                }
            } while (continuationToken != null);
            return results;
        }

        /// <summary>
        /// Get container presssions
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The container's permission</returns>
        public BlobContainerPermissions GetContainerPermissions(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                return container.GetPermissionsAsync(accessCondition, options, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Get an CloudBlobContainer instance in local
        /// </summary>
        /// <param name="name">Container name</param>
        /// <returns>A CloudBlobContainer in local memory</returns>
        public CloudBlobContainer GetContainerReference(string name)
        {
            return this.BlobClient.GetContainerReference(name);
        }

        /// <summary>
        /// Get an BlobContainerClient instance in local
        /// </summary>
        /// <param name="name">Container name</param>
        /// <param name="options">Blob request options</param>
        /// <returns>A BlobContainerClient in local memory</returns>
        public BlobContainerClient GetBlobContainerClient(string name, BlobClientOptions options = null)
        {
            return GetBlobServiceClient(options).GetBlobContainerClient(name);
        }

        /// <summary>
        /// Get an BlobServiceClient instance in local
        /// </summary>
        /// <param name="options">Blob request options</param>
        /// <returns>A BlobServiceClient in local memory</returns>
        public BlobServiceClient GetBlobServiceClient(BlobClientOptions options = null)
        {
            if (blobServiceClient == null)
            {
                if (this.StorageContext.StorageAccount.Credentials.IsToken) //Oauth
                {
                    blobServiceClient = new BlobServiceClient(this.StorageContext.StorageAccount.BlobEndpoint, this.StorageContext.Track2OauthToken, options);
                }
                else if (this.StorageContext.StorageAccount.Credentials.IsSharedKey) //Shared Key
                {
                    blobServiceClient = new BlobServiceClient(this.StorageContext.StorageAccount.BlobEndpoint,
                        new StorageSharedKeyCredential(this.StorageContext.StorageAccountName, this.StorageContext.StorageAccount.Credentials.ExportBase64EncodedKey()), options);
                }
                else //sas, Anonymous
                {
                    blobServiceClient = new BlobServiceClient(this.StorageContext.StorageAccount.BlobEndpoint, options);
                }
            }
            return blobServiceClient;
        }
        private BlobServiceClient blobServiceClient = null;

        /// <summary>
        /// Create the container if not exists
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        public bool CreateContainerIfNotExists(CloudBlobContainer container, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext)
        {
            try
            {
                return container.CreateIfNotExistsAsync(requestOptions, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Delete container
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        public void DeleteContainer(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => container.DeleteAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Set container permissions
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="permissions">The container's permission</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        public void SetContainerPermissions(CloudBlobContainer container, BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => container.SetPermissionsAsync(permissions, accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Get blob reference with properties and meta data from server
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="SnapshotTime">Snapshot time to append.</param>
        /// <returns>Return an CloudBlob if the specific blob exists on azure, otherwise return null</returns>
        public CloudBlob GetBlobReferenceFromServer(CloudBlobContainer container, string blobName, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, DateTimeOffset? SnapshotTime = null)
        {
            try
            {
                CloudBlob blob = Util.GetBlobReferenceFromServer(container, blobName, accessCondition, options, operationContext, SnapshotTime);
                return blob;
            }
            catch (XSCL.StorageException e)
            {
                if (e.IsNotFoundException())
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// List all blobs in specified containers
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing(whether treat "container/" as directory)</param>
        /// <param name="blobListingDetails">Blob listing details</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlob</returns>
        public IEnumerable<IListBlobItem> ListBlobs(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            //https://ahmet.im/blog/azure-listblobssegmentedasync-listcontainerssegmentedasync-how-to/
            BlobContinuationToken continuationToken = null;
            var results = new List<IListBlobItem>();
            do
            {
                var response = container.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, null, continuationToken, options, operationContext).Result;
                continuationToken = response.ContinuationToken;
                results.AddRange(response.Results);
            } while (continuationToken != null);
            return results;
        }

        /// <summary>
        /// Whether the container exists or not
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the specific container exists, otherwise return false</returns>
        public bool DoesContainerExist(CloudBlobContainer container, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            if (null == container)
            {
                return false;
            }
            else
            {
                try
                {
                    return container.ExistsAsync(options, operationContext).Result;
                }
                catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Whether the blob is exists or not
        /// </summary>
        /// <param name="blob">An CloudBlob object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the specific blob exists, otherwise return false</returns>
        public bool DoesBlobExist(CloudBlob blob, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            if (null == blob)
            {
                return false;
            }
            else
            {
                try
                {
                    return blob.ExistsAsync(options, operationContext).Result;
                }
                catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Delete azure blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="deleteSnapshotsOption">Delete snapshots option</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlob</returns>
        public void DeleteCloudBlob(CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => blob.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Fetch container attributes
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void FetchContainerAttributes(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => container.FetchAttributesAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Fetch blob attributes
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void FetchBlobAttributes(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => blob.FetchAttributesAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Set blob properties
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void SetBlobProperties(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => blob.SetPropertiesAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Set blob meta data
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void SetBlobMetadata(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => blob.SetMetadataAsync(accessCondition, options, operationContext)).Wait();
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Abort copy operation on specified blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="copyId">Copy id</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        public void AbortCopy(CloudBlob blob, string copyId, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                Task.Run(() => blob.AbortCopyAsync(copyId, accessCondition, options, operationContext)).Wait();
            }
            catch (XSCL.StorageException e)
            {
                if (e.IsSuccessfulResponse())
                {
                    //The abort operation is successful, although get an exception
                    return;
                }
                else
                {
                    throw;
                }
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                if (((XSCL.StorageException)e.InnerException).IsSuccessfulResponse())
                {
                    //The abort operation is successful, although get an exception
                    return;
                }
                else
                {
                    throw e.InnerException;
                }
            }
        }

        /// <summary>
        /// Get the service properties
        /// </summary>
        /// <param name="type">Service type</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The service properties of the specified service type</returns>
        public XSCLProtocol.ServiceProperties GetStorageServiceProperties(StorageServiceType type, IRequestOptions options, XSCL.OperationContext operationContext)
        {
            XSCL.CloudStorageAccount account = StorageContext.StorageAccount;
            try
            {
                switch (type)
                {
                    case StorageServiceType.Blob:
                        return account.CreateCloudBlobClient().GetServicePropertiesAsync((BlobRequestOptions)options, operationContext).Result;
                    case StorageServiceType.Queue:
                        return account.CreateCloudQueueClient().GetServicePropertiesAsync((QueueRequestOptions)options, operationContext).Result;
                    case StorageServiceType.File:
                        FileServiceProperties fileServiceProperties = account.CreateCloudFileClient().GetServicePropertiesAsync((FileRequestOptions)options, operationContext).Result;
                        XSCLProtocol.ServiceProperties sp = new XSCLProtocol.ServiceProperties();
                        sp.Clean();
                        sp.Cors = fileServiceProperties.Cors;
                        sp.HourMetrics = fileServiceProperties.HourMetrics;
                        sp.MinuteMetrics = fileServiceProperties.MinuteMetrics;
                        return sp;
                    default:
                        throw new ArgumentException(Resources.InvalidStorageServiceType, "type");
                }
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Set service properties
        /// </summary>
        /// <param name="type">Service type</param>
        /// <param name="properties">Service properties</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        public void SetStorageServiceProperties(StorageServiceType type, XSCLProtocol.ServiceProperties properties, IRequestOptions options, XSCL.OperationContext operationContext)
        {
            XSCL.CloudStorageAccount account = StorageContext.StorageAccount;
            try
            {
                switch (type)
                {
                    case StorageServiceType.Blob:
                        Task.Run(() => account.CreateCloudBlobClient().SetServicePropertiesAsync(properties, (BlobRequestOptions)options, operationContext)).Wait();
                        break;
                    case StorageServiceType.Queue:
                        Task.Run(() => account.CreateCloudQueueClient().SetServicePropertiesAsync(properties, (QueueRequestOptions)options, operationContext)).Wait();
                        break;
                    case StorageServiceType.File:
                        if (null != properties.Logging)
                        {
                            throw new InvalidOperationException(Resources.FileNotSupportLogging);
                        }

                        FileServiceProperties fileServiceProperties = new FileServiceProperties();
                        fileServiceProperties.Cors = properties.Cors;
                        fileServiceProperties.HourMetrics = properties.HourMetrics;
                        fileServiceProperties.MinuteMetrics = properties.MinuteMetrics;
                        Task.Run(() => account.CreateCloudFileClient().SetServicePropertiesAsync(fileServiceProperties, (FileRequestOptions)options, operationContext)).Wait();
                        break;
                    default:
                        throw new ArgumentException(Resources.InvalidStorageServiceType, "type");
                }
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Get the SAS token for an account.
        /// </summary>
        /// <param name="sharedAccessAccountPolicy">Shared access policy to generate the SAS token.</param>
        /// <returns>Account SAS token.</returns>
        public string GetStorageAccountSASToken(XSCL.SharedAccessAccountPolicy sharedAccessAccountPolicy)
        {
            return StorageContext.StorageAccount.GetSharedAccessSignature(sharedAccessAccountPolicy);
        }

        /// <summary>
        /// Async Get container presssions
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">User cancellation token</param>
        /// <returns>A task object which retrieve the permission of the specified container</returns>
        public Task<BlobContainerPermissions> GetContainerPermissionsAsync(CloudBlobContainer container,
            AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext,
            CancellationToken cancellationToken)
        {
            return container.GetPermissionsAsync(accessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously check whether the specified container exists.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously check whether the specified container exists </returns>
        public Task<bool> DoesContainerExistAsync(CloudBlobContainer container, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return container.ExistsAsync(requestOptions, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously get the blob reference from server
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="snapshotTime">Snapshot time to append.</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously get the blob reference from server</returns>
        public async Task<CloudBlob> GetBlobReferenceFromServerAsync(CloudBlobContainer container, string blobName, DateTimeOffset? snapshotTime, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            try
            {
                CloudBlob blob = container.GetBlobReference(blobName, snapshotTime);
                await blob.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken).ConfigureAwait(false);

                return Util.GetCorrespondingTypeBlobReference(blob, operationContext);
            }
            catch (XSCL.StorageException e)
            {
                if (e.IsNotFoundException())
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Return a task that asynchronously fetch blob attributes
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously fetch blob attributes</returns>
        public Task FetchBlobAttributesAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously create a container if it doesn't exist.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessType">Blob container public access type</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously create a container if it doesn't exist.</returns>
        public Task<bool> CreateContainerIfNotExistsAsync(CloudBlobContainer container, BlobContainerPublicAccessType accessType, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return container.CreateIfNotExistsAsync(accessType, requestOptions, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously delete the specified container.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously delete the specified container.</returns>
        public Task DeleteContainerAsync(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return container.DeleteAsync(accessCondition, requestOptions, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously abort the blob copy operation
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="copyId">Copy id</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously abort the blob copy operation</returns>
        public Task AbortCopyAsync(CloudBlob blob, string copyId, AccessCondition accessCondition, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.AbortCopyAsync(copyId, accessCondition, requestOptions, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously set the container permission
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="permissions">Container permission</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Return a task that asynchronously set the container permission</returns>
        public Task SetContainerPermissionsAsync(CloudBlobContainer container, BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return container.SetPermissionsAsync(permissions, accessCondition, requestOptions, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously delete the specified blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="deleteSnapshotsOption">Snapshot delete option</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously delete the specified blob</returns>
        public Task DeleteCloudBlobAsync(CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions requestOptions, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.DeleteAsync(deleteSnapshotsOption, accessCondition, requestOptions, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously check whether the specified blob exists.
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously check whether the specified blob exists.</returns>
        public Task<bool> DoesBlobExistAsync(CloudBlob blob, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return blob.ExistsAsync(options, operationContext, cmdletCancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously set blob properties
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        public Task SetBlobPropertiesAsync(CloudBlob blob, AccessCondition accessCondition,
            BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return blob.SetPropertiesAsync(accessCondition, options, operationContext, cmdletCancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously set blob meta data
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        public Task SetBlobMetadataAsync(CloudBlob blob, AccessCondition accessCondition,
            BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return blob.SetMetadataAsync(accessCondition, options, operationContext, cmdletCancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously set Premium page blob Tier
        /// </summary>
        /// <param name="blob">CloudPageBlob object</param>
        /// <param name="tier">Premium pageblob Tier</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        public Task SetPageBlobTierAsync(CloudPageBlob blob, PremiumPageBlobTier tier, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return blob.SetPremiumBlobTierAsync(tier, options, operationContext, cmdletCancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously set block blob Tier
        /// </summary>
        /// <param name="blob">CloudBlockBlob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="tier">block blob Tier</param>
        /// <param name="rehydratePriority"></param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        public Task SetStandardBlobTierAsync(CloudBlockBlob blob, AccessCondition accessCondition, StandardBlobTier tier, RehydratePriority? rehydratePriority, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return blob.SetStandardBlobTierAsync(tier, rehydratePriority, accessCondition, options, operationContext, cmdletCancellationToken);
        }

        /// <summary>
        /// List the blobs segmented in specified containers
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing(whether treat "container/" as directory)</param>
        /// <param name="blobListingDetails">Blob listing details</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="currentToken">Current token.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return container.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// List part of blobs.
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing</param>
        /// <param name="blobListingDetails">Blob listing details.</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="currentToken">Current token.</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation Context.</param>
        /// <returns>BlobResultSegment object</returns>
        public BlobResultSegment ListBlobsSegmented(CloudBlobContainer container, string prefix, bool useFlatBlobListing,
            BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                return container.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Get a list of CloudBlobContainer in azure
        /// </summary>
        /// <param name="prefix">Container prefix</param>
        /// <param name="detailsIncluded">Container listing details</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="currentToken">Current token.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlobContainer</returns>
        public ContainerResultSegment ListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, XSCL.OperationContext operationContext)
        {
            try
            {
                return this.BlobClient.ListContainersSegmentedAsync(prefix, detailsIncluded, maxResults, currentToken, options, operationContext).Result;
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }

        /// <summary>
        /// Return a task that asynchronously start copy operation to a blob.
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="source">Uri to copying source</param>
        /// <param name="sourceAccessCondition">Access condition to source if it's file/blob in azure.</param>
        /// <param name="destAccessCondition">Access condition to Destination blob.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return copy id if succeeded.</returns>
        public Task<string> StartCopyAsync(CloudBlob blob, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously start copy operation to a PageBlob with PremiumPageBlobTier.
        /// </summary>
        /// <param name="blob">CloudPageBlob object</param>
        /// <param name="source">Uri to copying source</param>
        /// <param name="premiumPageBlobTier">The PremiumPageBlobTier of Destination blob</param>
        /// <param name="sourceAccessCondition">Access condition to source if it's file/blob in azure.</param>
        /// <param name="destAccessCondition">Access condition to Destination blob.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return copy id if succeeded.</returns>
        public Task<string> StartCopyAsync(CloudPageBlob blob, Uri source, PremiumPageBlobTier premiumPageBlobTier, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.StartCopyAsync(new CloudPageBlob(source), premiumPageBlobTier, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously start copy operation to a CloudBlockBlob with StandardBlobTier.
        /// </summary>
        /// <param name="blob">CloudBlob object whcih is a Block blob</param>
        /// <param name="source">Uri to copying source</param>
        /// <param name="standardBlobTier">Access condition to source if it's file/blob in azure.</param>
        /// <param name="rehydratePriority"></param>
        /// <param name="sourceAccessCondition">Access condition to source if it's file/blob in azure.</param>
        /// <param name="destAccessCondition">Access condition to Destination blob.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return copy id if succeeded.</returns>
        public Task<string> StartCopyAsync(CloudBlob blob, Uri source, StandardBlobTier? standardBlobTier, RehydratePriority? rehydratePriority, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.StartCopyAsync(source, standardBlobTier, rehydratePriority, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Return a task that asynchronously start Incremental copy operation to a page blob.
        /// </summary>
        /// <param name="blob">Dest CloudPageBlob object</param>
        /// <param name="source">Source Page Blob snapshot</param>
        /// <param name="destAccessCondition">Access condition to Destination blob.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return copy id if succeeded.</returns>
        public Task<string> StartIncrementalCopyAsync(CloudPageBlob blob, CloudPageBlob source, AccessCondition destAccessCondition, BlobRequestOptions options, XSCL.OperationContext operationContext, CancellationToken cancellationToken)
        {
            return blob.StartIncrementalCopyAsync(source, destAccessCondition, options, operationContext, cancellationToken);
        }

        /// <summary>
        /// Returns the sku name and account kind for the specified account
        /// </summary>
        /// <returns>the sku name and account kind</returns>
        public XSCLProtocol.AccountProperties GetAccountProperties()
        {
            return this.BlobClient.GetAccountPropertiesAsync().Result;
        }

        /// <summary>
        /// Get UserDelegationKey, this key will be used to get  UserDelegation SAS token
        /// </summary>
        /// <param name="keyStart">The key valid start time</param>
        /// <param name="keyEnd">The key valid end time</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The UserDelegationKey</returns>
        public UserDelegationKey GetUserDelegationKey(DateTimeOffset? keyStart, DateTimeOffset? keyEnd, AccessCondition accessCondition = null, BlobRequestOptions options = null, XSCL.OperationContext operationContext = null)
        {
            try
            {
                DateTimeOffset userDelegationKeyStartTime = keyStart == null ? DateTime.Now : keyStart.Value;
                DateTimeOffset userDelegationKeyEndTime = keyEnd == null ? userDelegationKeyStartTime.AddHours(1) : keyEnd.Value;

                //Check the Expire Time and Start Time, should remove this if server can rerturn clear error message
                Util.ValidateUserDelegationKeyStartEndTime(userDelegationKeyStartTime, userDelegationKeyEndTime);

                return this.BlobClient.GetUserDelegationKey(userDelegationKeyStartTime, userDelegationKeyEndTime, accessCondition, options, operationContext);
            }
            catch (AggregateException e) when (e.InnerException is XSCL.StorageException)
            {
                throw e.InnerException;
            }
        }
    }
}
