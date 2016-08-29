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

namespace Microsoft.WindowsAzure.Commands.Storage
{
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Base cmdlet for storage blob/container cmdlet
    /// </summary>
    public class StorageCloudBlobCmdletBase : StorageCloudCmdletBase<IStorageBlobManagement>
    {
        /// <summary>
        /// Initializes a new instance of the StorageCloudBlobCmdletBase class.
        /// </summary>
        public StorageCloudBlobCmdletBase()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the StorageCloudBlobCmdletBase class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public StorageCloudBlobCmdletBase(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// Blob request options
        /// </summary>
        public BlobRequestOptions RequestOptions
        {
            get
            {
                return (BlobRequestOptions)GetRequestOptions(StorageServiceType.Blob);
            }
        }

        protected static CloudBlob GetBlobReferenceFromServerWithContainer(
            IStorageBlobManagement localChannel,
            CloudBlobContainer container,
            string blobName,
            AccessCondition accessCondition = null,
            BlobRequestOptions requestOptions = null,
            OperationContext operationContext = null)
        {
            return GetBlobReferenceWrapper(() =>
                {
                    try
                    {
                        return localChannel.GetBlobReferenceFromServer(container, blobName, accessCondition, requestOptions, operationContext);
                    }
                    catch (InvalidOperationException)
                    {
                        return null;
                    }
                },
                blobName,
                container.Name);
        }

        protected static CloudBlob GetBlobReferenceWrapper(Func<CloudBlob> getBlobReference, string blobName, string containerName)
        {
            CloudBlob blob = getBlobReference();

            if (null == blob)
            {
                throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, blobName, containerName));
            }

            return blob;
        }

        /// <summary>
        /// Make sure the pipeline blob is valid and already existing
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        internal void ValidatePipelineCloudBlob(CloudBlob blob)
        {
            if (null == blob)
            {
                throw new ArgumentException(String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
            }

            if (!NameUtil.IsValidBlobName(blob.Name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blob.Name));
            }

            ValidatePipelineCloudBlobContainer(blob.Container);
            //BlobRequestOptions requestOptions = RequestOptions;

            //if (!Channel.DoesBlobExist(blob, requestOptions, OperationContext))
            //{
            //    throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, blob.Name, blob.Container.Name));
            //}
        }

        /// <summary>
        /// Make sure the container is valid and already existing 
        /// </summary>
        /// <param name="container">A CloudBlobContainer object</param>
        internal void ValidatePipelineCloudBlobContainer(CloudBlobContainer container)
        {
            if (null == container)
            {
                throw new ArgumentException(String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlobContainer).Name));
            }

            if (!NameUtil.IsValidContainerName(container.Name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, container.Name));
            }

            //BlobRequestOptions requestOptions = RequestOptions;

            //if (container.ServiceClient.Credentials.IsSharedKey 
            //    && !Channel.DoesContainerExist(container, requestOptions, OperationContext))
            //{
            //    throw new ResourceNotFoundException(String.Format(Resources.ContainerNotFound, container.Name));
            //}
        }

        /// <summary>
        /// Create blob client and storage service management channel if need to.
        /// </summary>
        /// <returns>IStorageManagement object</returns>
        protected override IStorageBlobManagement CreateChannel()
        {
            //Init storage blob management channel
            if (Channel == null || !ShareChannel)
            {
                Channel = new StorageBlobManagement(GetCmdletStorageContext());
            }

            return Channel;
        }

        /// <summary>
        /// Get a service channel object using specified storage account
        /// </summary>
        /// <param name="account">Cloud storage account object</param>
        /// <returns>IStorageBlobManagement channel object</returns>
        protected IStorageBlobManagement CreateChannel(AzureStorageContext context)
        {
            return new StorageBlobManagement(context);
        }

        /// <summary>
        /// whether the specified blob is a snapshot
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <returns>true if the specified blob is snapshot, otherwise false</returns>
        internal bool IsSnapshot(CloudBlob blob)
        {
            return !string.IsNullOrEmpty(blob.Name) && blob.SnapshotTime != null;
        }

        /// <summary>
        /// Write CloudBlob to output using specified service channel
        /// </summary>
        /// <param name="blob">The output CloudBlob object</param>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        internal void WriteCloudBlobObject(long taskId, IStorageBlobManagement channel, CloudBlob blob, BlobContinuationToken continuationToken = null)
        {
            AzureStorageBlob azureBlob = new AzureStorageBlob(blob);
            azureBlob.Context = channel.StorageContext;
            azureBlob.ContinuationToken = continuationToken;
            OutputStream.WriteObject(taskId, azureBlob);
        }

        /// <summary>
        /// Write CloudBlob to output using specified service channel
        /// </summary>
        /// <param name="blob">The output CloudBlob object</param>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        internal void WriteCloudContainerObject(long taskId, IStorageBlobManagement channel,
            CloudBlobContainer container, BlobContainerPermissions permissions, BlobContinuationToken continuationToken = null)
        {
            AzureStorageContainer azureContainer = new AzureStorageContainer(container, permissions);
            azureContainer.Context = channel.StorageContext;
            azureContainer.ContinuationToken = continuationToken;
            OutputStream.WriteObject(taskId, azureContainer);
        }

        protected void ValidateBlobType(CloudBlob blob)
        {
            if ((BlobType.BlockBlob != blob.BlobType)
                && (BlobType.PageBlob != blob.BlobType)
                && (BlobType.AppendBlob != blob.BlobType))
            {
                throw new InvalidOperationException(string.Format(
                    CultureInfo.CurrentCulture,
                    Resources.InvalidBlobType,
                    blob.BlobType,
                    blob.Name));
            }
        }

        protected bool ContainerIsEmpty(CloudBlobContainer container)
        {
            try
            {
                BlobContinuationToken blobToken = new BlobContinuationToken();
                IEnumerator<IListBlobItem> listedBlobs = container.ListBlobsSegmented("", true, BlobListingDetails.None, 1, blobToken, RequestOptions, OperationContext).Results.GetEnumerator();
                if (listedBlobs.MoveNext() && listedBlobs.Current != null)
                    return false;
                else
                    return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

    }
}