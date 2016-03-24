﻿// ----------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Shared.Protocol;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Service
{
    /// <summary>
    /// Mock blob management
    /// </summary>
    public class MockStorageBlobManagement : IStorageBlobManagement
    {
        public static string ContainerNotFound = "Container not found";

        public static string BlobNotFound = "Blob not found";

        /// <summary>
        /// Blob end point
        /// </summary>
        private string BlobEndPoint = "http://127.0.0.1/account/";

        /// <summary>
        /// Container list
        /// </summary>
        private List<CloudBlobContainer> containerList = new List<CloudBlobContainer>();

        public List<CloudBlobContainer> ContainerList
        {
            get
            {
                return containerList;
            }
        }

        public List<Tuple<CloudBlobContainer, BlobContinuationToken>> ContainerAndTokenList
        {
            get
            {
                List<Tuple<CloudBlobContainer, BlobContinuationToken>> containerAndTokenList = new List<Tuple<CloudBlobContainer, BlobContinuationToken>>(ContainerList.Count);
                foreach (CloudBlobContainer container in ContainerList)
                {
                    containerAndTokenList.Add(new Tuple<CloudBlobContainer, BlobContinuationToken>(container, null));
                }

                return containerAndTokenList;
            }
        }
        
        /// <summary>
        /// Container permissions list
        /// </summary>
        private Dictionary<string, BlobContainerPermissions> containerPermissions = new Dictionary<string, BlobContainerPermissions>();
        public Dictionary<string, BlobContainerPermissions> ContainerPermissions
        {
            get
            {
                return containerPermissions;
            }
        }

        /// <summary>
        /// Container blobs list
        /// </summary>
        private Dictionary<string, List<CloudBlob>> containerBlobs = new Dictionary<string, List<CloudBlob>>();
        public Dictionary<string, List<CloudBlob>> ContainerBlobs
        {
            get
            {
                return containerBlobs;
            }
        }

        /// <summary>
        /// Get a list of cloudblobcontainer in azure
        /// </summary>
        /// <param name="prefix">Container prefix</param>
        /// <param name="detailsIncluded">Container listing details</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of cloudblobcontainer</returns>
        public IEnumerable<CloudBlobContainer> ListContainers(string prefix, ContainerListingDetails detailsIncluded, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return ContainerList;
            }
            else
            {
                List<CloudBlobContainer> prefixContainerList = new List<CloudBlobContainer>();

                foreach (CloudBlobContainer container in ContainerList)
                {
                    if (container.Name.StartsWith(prefix))
                    {
                        prefixContainerList.Add(container);
                    }
                }

                return prefixContainerList;
            }
        }

        /// <summary>
        /// Get container permissions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The container's permission</returns>
        public BlobContainerPermissions GetContainerPermissions(CloudBlobContainer container, AccessCondition accessCondition = null, BlobRequestOptions options = null, OperationContext operationContext = null)
        {
            BlobContainerPermissions defaultPermission = new BlobContainerPermissions();
            defaultPermission.PublicAccess = BlobContainerPublicAccessType.Off;

            if (ContainerPermissions.ContainsKey(container.Name))
            {
                return ContainerPermissions[container.Name];
            }
            else
            {
                return defaultPermission;
            }
        }

        /// <summary>
        /// Get an CloudBlobContainer instance in local
        /// </summary>
        /// <param name="name">Container name</param>
        /// <returns>A CloudBlobContainer in local memory</returns>
        public CloudBlobContainer GetContainerReference(string name)
        {
            Uri containerUri = new Uri(String.Format("{0}{1}/", BlobEndPoint, name));
            string testName = "testaccount";
            Guid guid = Guid.NewGuid();
            string testKey = Convert.ToBase64String(guid.ToByteArray());
            StorageCredentials credentials = new StorageCredentials(testName, testKey);
            return new CloudBlobContainer(containerUri, credentials);
        }

        /// <summary>
        /// Create the container if not exists
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the container did not already exist and was created; otherwise false.</returns>
        public bool CreateContainerIfNotExists(CloudBlobContainer container, BlobRequestOptions requestOptions = null, OperationContext operationContext = null)
        {
            CloudBlobContainer containerRef =  GetContainerReference(container.Name);

            if (DoesContainerExist(containerRef, requestOptions, operationContext))
            {
                return false;
            }
            else
            {
                containerRef = GetContainerReference(container.Name);
                ContainerList.Add(containerRef);
                return true;
            }
        }

        /// <summary>
        /// Delete container
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        public void DeleteContainer(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            foreach (CloudBlobContainer containerRef in ContainerList)
            {
                if (container.Name == containerRef.Name)
                {
                    ContainerList.Remove(containerRef);
                    return;
                }
            }
        }

        /// <summary>
        /// Set container permissions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="permissions">The container's permission</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        public void SetContainerPermissions(CloudBlobContainer container, BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            String name = container.Name;

            if (ContainerPermissions.ContainsKey(name))
            {
                ContainerPermissions[name] = permissions;
            }
            else
            {
                ContainerPermissions.Add(name, permissions);
            }
        }

        /// <summary>
        /// Get blob reference with properties and meta data from server
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>Return an CloudBlob if the specific blob exists on azure, otherwise return null</returns>
        public CloudBlob GetBlobReferenceFromServer(CloudBlobContainer container, string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            string containerName = container.Name;

            if (ContainerBlobs.ContainsKey(containerName))
            {
                List<CloudBlob> blobList = ContainerBlobs[containerName];
                
                foreach (CloudBlob blob in blobList)
                {
                    if (blob.Name == blobName)
                    {
                        return blob;
                    }
                }
                
                return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// List all blobs in specified containers
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing(whether treat "container/" as directory)</param>
        /// <param name="blobListingDetails">Blob listing details</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlob</returns>
        public IEnumerable<IListBlobItem> ListBlobs(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, BlobRequestOptions options, OperationContext operationContext)
        {
            string containerName = container.Name;

            if (ContainerBlobs.ContainsKey(containerName))
            {
                List<CloudBlob> blobList = ContainerBlobs[containerName];
                
                if (string.IsNullOrEmpty(prefix))
                {
                    return blobList;
                }
                
                List<CloudBlob> prefixBlobs = new List<CloudBlob>();
                
                foreach (CloudBlob blob in blobList)
                {
                    if (blob.Name.StartsWith(prefix))
                    {
                        prefixBlobs.Add(blob);
                    }
                }
                
                return prefixBlobs;
            }
            else
            {
                return new List<CloudBlob>();
            }
        }

        /// <summary>
        /// Whether the container is exists or not
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the specific container exists, otherwise return false</returns>
        public bool DoesContainerExist(CloudBlobContainer container, BlobRequestOptions options, OperationContext operationContext)
        {
            if (null == container)
            {
                return false;
            }
            
            foreach (CloudBlobContainer containerRef in ContainerList)
            {
                if (containerRef.Name == container.Name)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Whether the blob is exists or not
        /// </summary>
        /// <param name="blob">A CloudBlob object</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>True if the specific blob exists, otherwise return false</returns>
        public bool DoesBlobExist(CloudBlob blob, BlobRequestOptions options, OperationContext operationContext)
        {
            CloudBlobContainer container = blob.Container;

            if (!ContainerBlobs.ContainsKey(container.Name))
            {
                return false;
            }
            else
            {
                List<CloudBlob> blobList = ContainerBlobs[container.Name];
                
                foreach (CloudBlob blobRef in blobList)
                {
                    if (blobRef.Name == blob.Name)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Delete azure blob
        /// </summary>
        /// <param name="blob">Cloudblob object</param>
        /// <param name="deleteSnapshotsOption">Delete snapshots option</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of CloudBlob</returns>
        public void DeleteCloudBlob(CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            CloudBlobContainer container = blob.Container;

            if (!this.DoesContainerExist(container, null, null))
            {
                throw new StorageException(ContainerNotFound);
            }
            else if (ContainerBlobs.ContainsKey(container.Name))
            {
                List<CloudBlob> blobList = ContainerBlobs[container.Name];
                
                foreach (CloudBlob blobRef in blobList)
                {
                    if (blobRef.Name == blob.Name)
                    {
                        blobList.Remove(blobRef);
                        return;
                    }
                }
            }

            throw new StorageException(BlobNotFound);
        }

        /// <summary>
        /// fetch container attributes
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void FetchContainerAttributes(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return;
        }

        /// <summary>
        /// fetch blob attributes
        /// </summary>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void FetchBlobAttributes(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return ;
        }

        /// <summary>
        /// set blob properties
        /// </summary>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void SetBlobProperties(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return;
        }

        /// <summary>
        /// set blob meta data
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public void SetBlobMetadata(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return;
        }

        /// <summary>
        /// Abort copy operation on specified blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="copyId">Copy id</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        public void AbortCopy(CloudBlob blob, string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return;
        }

        /// <summary>
        /// Get the service properties
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        /// <param name="type">Service type</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>The service properties of the specified service type</returns>
        public ServiceProperties GetStorageServiceProperties(StorageServiceType type, IRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException("No need to cover this in unit test since the logic is quite simple. For more details, please read GetAzureStorageServiceLogging.cs");
        }

        /// <summary>
        /// Set service properties
        /// </summary>
        /// <param name="account">Cloud storage account</param>
        /// <param name="type">Service type</param>
        /// <param name="properties">Service properties</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation context</param>
        public void SetStorageServiceProperties(StorageServiceType type, WindowsAzure.Storage.Shared.Protocol.ServiceProperties properties, IRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException("No need to cover this in unit test since there are no additional logics on this api");
        }

        /// <summary>
        /// List part of blobs.
        /// </summary>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing</param>
        /// <param name="blobListingDetails">Blob listing details.</param>
        /// <param name="maxResults">Max results.</param>
        /// <param name="currentToken">Current token.</param>
        /// <param name="options">Request options</param>
        /// <param name="operationContext">Operation Context.</param>
        /// <returns>BlobResultSegment object</returns>
        public BlobResultSegment ListBlobsSegmented(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException("Can not create a BlobResultSegment object");
        }

        /// <summary>
        /// Get a list of cloudblobcontainer in azure
        /// </summary>
        /// <param name="prefix">Container prefix</param>
        /// <param name="detailsIncluded">Container listing details</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <returns>An enumerable collection of cloudblobcontainer</returns>
        public ContainerResultSegment ListContainersSegmented(string prefix, ContainerListingDetails detailsIncluded, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            throw new NotImplementedException("Can not create a ContainerResultSegment object");
        }

        /// <summary>
        /// Async Get container presssions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cancellationToken">User cancellation token</param>
        /// <returns>A task object which retrieve the permission of the specified container</returns>
        public Task<BlobContainerPermissions> GetContainerPermissionsAsync(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => this.GetContainerPermissions(container,
                accessCondition, options, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously check whether the specified container exists.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="requestOptions">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously check whether the specified container exists </returns>
        public Task<bool> DoesContainerExistAsync(CloudBlobContainer container, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.DoesContainerExist(container, requestOptions, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously check whether the specified blob exists.
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously check whether the specified blob exists.</returns>
        public Task<bool> DoesBlobExistAsync(CloudBlob blob, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.DoesBlobExist(blob, options, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously get the blob reference from server
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>A task object that asynchronously get the blob reference from server</returns>
        public Task<CloudBlob> GetBlobReferenceFromServerAsync(CloudBlobContainer container, string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.GetBlobReferenceFromServer(container, blobName, accessCondition, options, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously fetch blob attributes
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously fetch blob attributes</returns>
        public Task FetchBlobAttributesAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.FetchBlobAttributes(blob, accessCondition, options, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously create a container if it doesn't exist.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessType">Blob container public access type</param>
        /// <param name="requestOptions">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously create a container if it doesn't exist.</returns>
        public Task<bool> CreateContainerIfNotExistsAsync(CloudBlobContainer container, BlobContainerPublicAccessType accessType, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.CreateContainerIfNotExists(container, requestOptions, operationContext)); 
        }

        /// <summary>
        /// Return a task that asynchronously delete the specified container.
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously delete the specified container.</returns>
        public Task DeleteContainerAsync(CloudBlobContainer container, AccessCondition accessCondition, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.DeleteContainer(container, accessCondition, requestOptions, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously abort the blob copy operation
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="abortCopyId">Copy id</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="abortRequestOption">Blob request options</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously abort the blob copy operation</returns>
        public Task AbortCopyAsync(CloudBlob blob, string copyId, AccessCondition accessCondition, BlobRequestOptions requestOption, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.AbortCopy(blob, copyId, accessCondition, requestOption, operationContext));
        }

        /// <summary>
        /// Set container permissions
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="permissions">The container's permission</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        public Task SetContainerPermissionsAsync(CloudBlobContainer container, BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.SetContainerPermissions(container, permissions, accessCondition, requestOptions, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously delete the specified blob
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="deleteSnapshotsOption">Snapshot delete option</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="requestOptions">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        /// <param name="cmdletCancellationToken">Cancellation token</param>
        /// <returns>Return a task that asynchronously delete the specified blob</returns>
        public Task DeleteCloudBlobAsync(CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions requestOptions, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.DeleteCloudBlob(blob, deleteSnapshotsOption, accessCondition, requestOptions, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously set blob properties
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public Task SetBlobPropertiesAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.SetBlobProperties(blob, accessCondition, options, operationContext));
        }

        /// <summary>
        /// Return a task that asynchronously set blob meta data
        /// </summary>
        /// <param name="blob">ICloud blob object</param>
        /// <param name="accessCondition">Access condition</param>
        /// <param name="options">Blob request options</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        public Task SetBlobMetadataAsync(CloudBlob blob, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cmdletCancellationToken)
        {
            return Task.Factory.StartNew(() => this.SetBlobMetadata(blob, accessCondition, options, operationContext));
        }

        /// <summary>
        /// List the blobs segmented in specified containers
        /// </summary>
        /// <param name="container">A cloudblobcontainer object</param>
        /// <param name="prefix">Blob prefix</param>
        /// <param name="useFlatBlobListing">Use flat blob listing(whether treat "container/" as directory)</param>
        /// <param name="blobListingDetails">Blob listing details</param>
        /// <param name="options">Blob request option</param>
        /// <param name="operationContext">Operation context</param>
        public Task<BlobResultSegment> ListBlobsSegmentedAsync(CloudBlobContainer container, string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            //BlobResultSegment is sealed without any public constructors.
            throw new NotImplementedException();
        }

        public Task<string> StartCopyAsync(CloudBlob blob, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the SAS token for an account.
        /// </summary>
        /// <param name="sharedAccessAccountPolicy">Shared access policy to generate the SAS token.</param>
        /// <returns>Account SAS token.</returns>
        public string GetStorageAccountSASToken(SharedAccessAccountPolicy sharedAccessAccountPolicy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The storage context
        /// </summary>
        public AzureStorageContext StorageContext
        {
            get { return null; }
        }
    }
}
