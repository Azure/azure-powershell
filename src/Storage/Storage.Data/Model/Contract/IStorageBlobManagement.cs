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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.Shared.Protocol;
    using XTable = Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Azure.Storage.Blobs;

    /// <summary>
    /// Blob management interface
    /// </summary>
    public interface IStorageBlobManagement : IStorageManagement
    {
        /// <summary>
        /// Get a list of cloudblobcontainer in azure
        /// </summary>
        /// <param name="prefix">Container prefix</param>
        /// <param name="detailsIncluded">Container listing details</param>
        /// <param name="options">Blob request options</param>
        /// <param name="OperationContext">Operation context</param>
        /// <returns>An enumerable collection of cloudblobcontainer</returns>
        IEnumerable<CloudBlobContainer> ListContainers(string prefix, ContainerListingDetails detailsIncluded, BlobRequestOptions options, OperationContext OperationContext);

        /// <summary>
        /// Get a list of cloudblobcontainer in azure
        /// </summary>
        /// <param name="prefix">Container prefix</param>
        /// <param name="detailsIncluded">Container listing details</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="continuationToken">Continuation token.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of cloudblobcontainer</returns>
        ContainerResultSegment ListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded, int? maxResults, BlobContinuationToken continuationToken, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Get container presssions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The container's permission</returns>
        BlobContainerPermissions GetContainerPermissions(CloudBlobContainer container, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null);

        /// <summary>
        /// Set container permissions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="permissions">The container's permission</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        void SetContainerPermissions(CloudBlobContainer container, BlobContainerPermissions permissions, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null);

        /// <summary>
        /// Get an CloudBlobContainer instance in local
        /// </summary>
        /// <param name="name">Container name</param>
        /// <returns>A CloudBlobContainer in local memory</returns>
        CloudBlobContainer GetContainerReference(String name);

        /// <summary>
        /// Get an BlobContainerClient instance in local
        /// </summary>
        /// <param name="name">Container name</param>
        /// <param name="options">Blob request options</param>
        /// <returns>A BlobContainerClient in local memory</returns>
        BlobContainerClient GetBlobContainerClient(string name, BlobClientOptions options = null);

        /// <summary>
        /// Get an BlobServiceClient instance in local
        /// </summary>
        /// <param name="options">Blob request options</param>
        /// <returns>A BlobServiceClient in local memory</returns>
        BlobServiceClient GetBlobServiceClient(BlobClientOptions options = null);

        /// <summary>
        /// Get blob reference with properties and meta data from server
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="SnapshotTime">Snapshot time to append.</param>
        /// <returns>Return an CloudBlob if the specific blob exists on azure, otherwise return null</returns>
        CloudBlob GetBlobReferenceFromServer(CloudBlobContainer container, string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, DateTimeOffset? SnapshotTime = null);

        /// <summary>
        /// Whether the container is exists or not
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="OperationContext">Operation context</param>
        /// <returns>True if the specific container exists, otherwise return false</returns>
        bool DoesContainerExist(CloudBlobContainer container, BlobRequestOptions options, OperationContext OperationContext);

        /// <summary>
        /// Whether the blob is exists or not
        /// </summary>
        /// <param name="blob">A CloudBlob object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="OperationContext">Operation context</param>
        /// <returns>True if the specific blob exists, otherwise return false</returns>
        bool DoesBlobExist(CloudBlob blob, BlobRequestOptions options, OperationContext OperationContext);

        /// <summary>
        /// Create the container if not exists
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="OperationContext">Operation context</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        bool CreateContainerIfNotExists(CloudBlobContainer container, BlobRequestOptions requestOptions, OperationContext OperationContext);

        /// <summary>
        /// Delete container
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="OperationContext">Operation context</param>
        void DeleteContainer(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, OperationContext OperationContext);

        /// <summary>
        /// List all blobs in specified containers
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing(whether treat "container/" as directory)</param>
        /// <param name="blobListingDetails">Blob listing details</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlob</returns>
        IEnumerable<IListBlobItem> ListBlobs(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Delete azure blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="deleteSnapshotsOption">Delete snapshots option</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlob</returns>
        void DeleteCloudBlob(CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Fetch container attributes
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        void FetchContainerAttributes(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Fetch blob attributes
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        void FetchBlobAttributes(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Set blob properties
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        void SetBlobProperties(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Set blob meta data
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        void SetBlobMetadata(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Abort copy operation on specified blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="copyId">Copy id</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        void AbortCopy(CloudBlob blob, string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Get the service properties
        /// </summary>
        /// <param name="type">Service type</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The service properties of the specified service type</returns>
        ServiceProperties GetStorageServiceProperties(StorageServiceType type, IRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Set service properties
        /// </summary>
        /// <param name="type">Service type</param>
        /// <param name="properties">Service properties</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        void SetStorageServiceProperties(StorageServiceType type, ServiceProperties properties, IRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Get the SAS token for an account.
        /// </summary>
        /// <param name="sharedAccessAccountPolicy">Shared access policy to generate the SAS token.</param>
        /// <returns>Account SAS token.</returns>
        string GetStorageAccountSASToken(SharedAccessAccountPolicy sharedAccessAccountPolicy);

        /// <summary>
        /// Async get container presssions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">User cancellation token</param>
        /// <returns>A task object which retrieve the permission of the specified container</returns>
        Task<BlobContainerPermissions> GetContainerPermissionsAsync(CloudBlobContainer container, AccessCondition accessCondition,
            BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Return a task that asynchronously check whether the specified container exists.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously check whether the specified container exists </returns>
        Task<bool> DoesContainerExistAsync(CloudBlobContainer container, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously check whether the specified blob exists.
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously check whether the specified blob exists.</returns>
        Task<bool> DoesBlobExistAsync(CloudBlob blob, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously get the blob reference from server
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="snapshotTime">Snapshot time to append.</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously get the blob reference from server</returns>
        Task<CloudBlob> GetBlobReferenceFromServerAsync(CloudBlobContainer container, string blobName, DateTimeOffset? snapshotTime, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously fetch blob attributes
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously fetch blob attributes</returns>
        Task FetchBlobAttributesAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously create a container if it doesn't exist.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessType">Blob container public access type</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously create a container if it doesn't exist.</returns>
        Task<bool> CreateContainerIfNotExistsAsync(CloudBlobContainer container, BlobContainerPublicAccessType accessType, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously delete the specified container.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously delete the specified container.</returns>
        Task DeleteContainerAsync(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously abort the blob copy operation
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="copyId">Copy id</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOption">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously abort the blob copy operation</returns>
        Task AbortCopyAsync(CloudBlob blob, string copyId, AccessCondition accessCondition, BlobRequestOptions requestOption, OperationContext operationContext, CancellationToken cmdletCancellationToken);

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
        Task<string> StartCopyAsync(CloudBlob blob, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

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
        Task<string> StartCopyAsync(CloudPageBlob blob, Uri source, PremiumPageBlobTier premiumPageBlobTier, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Return a task that asynchronously start copy operation to a CloudBlockBlob with StandardBlobTier.
        /// </summary>
        /// <param name="blob">CloudBlockBlob object</param>
        /// <param name="source">Uri to copying source</param>
        /// <param name="standardBlobTier">Access condition to source if it's file/blob in azure.</param>
        /// <param name="rehydratePriority"></param>
        /// <param name="sourceAccessCondition">Access condition to source if it's file/blob in azure.</param>
        /// <param name="destAccessCondition">Access condition to Destination blob.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Return copy id if succeeded.</returns>
        Task<string> StartCopyAsync(CloudBlob blob, Uri source, StandardBlobTier? standardBlobTier, RehydratePriority? rehydratePriority, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

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
        Task<string> StartIncrementalCopyAsync(CloudPageBlob blob, CloudPageBlob source, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// Return a task that asynchronously set the container permission
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="permissions">Container permission</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">cancellation token</param>
        /// <returns>Return a task that asynchronously set the container permission</returns>
        Task SetContainerPermissionsAsync(CloudBlobContainer container, BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously delete the specified blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="deleteSnapshotsOption">Snapshot delete option</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously delete the specified blob</returns>
        Task DeleteCloudBlobAsync(CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously set blob properties
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        Task SetBlobPropertiesAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously set blob meta data
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        Task SetBlobMetadataAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        ///// <summary>
        ///// Return a task that asynchronously set block blob Tier
        ///// </summary>
        ///// <param name="blob">CloudBlockBlob object</param>
        ///// <param name="tier">block blob Tier</param>
        ///// <param name="accessCondition">Access condition</param>
        ///// <param name="options">Blob request options</param>
        ///// <param name="operationContext">An object that represents the context for the current operation.</param>
        //Task SetBlockBlobTierAsync(CloudBlockBlob blob, BlockBlobTier tier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// Return a task that asynchronously set page blob Tier
        /// </summary>
        /// <param name="blob">CloudPageBlob object</param>
        /// <param name="tier">page blob Tier</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        Task SetPageBlobTierAsync(CloudPageBlob blob, PremiumPageBlobTier tier, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

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
        Task SetStandardBlobTierAsync(CloudBlockBlob blob, AccessCondition accessCondition, StandardBlobTier tier, RehydratePriority? rehydratePriority, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken);

        /// <summary>
        /// List the blobs segmented in specified containers
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing(whether treat "container/" as directory)</param>
        /// <param name="blobListingDetails">Blob listing details</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="currentToken">Current token.</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<BlobResultSegment> ListBlobsSegmentedAsync(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken);

        /// <summary>
        /// List part of blobs.
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing</param>
        /// <param name="blobListingDetails">Blob listing details.</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="currentToken">Current token.</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation Context.</param>
        /// <returns>BlobResultSegment object</returns>
        BlobResultSegment ListBlobsSegmented(CloudBlobContainer container, string prefix, bool useFlatBlobListing,
            BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken,
            BlobRequestOptions options, OperationContext operationContext);

        /// <summary>
        /// Returns the sku name and account kind for the specified account
        /// </summary>
        /// <returns>the sku name and account kind</returns>
        AccountProperties GetAccountProperties();

        /// <summary>
        /// Get UserDelegationKey, this key will be used to get  UserDelegation SAS token
        /// </summary>
        /// <param name="keyStart">The key valid start time</param>
        /// <param name="keyEnd">The key valid end time</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The UserDelegationKey</returns>
        UserDelegationKey GetUserDelegationKey(DateTimeOffset? keyStart, DateTimeOffset? keyEnd, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null);
    }
}
