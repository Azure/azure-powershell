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
// ----------------------------------------------------------------------------------

using System;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage
{
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
                return (BlobRequestOptions) GetRequestOptions(StorageServiceType.Blob);
            }
        }

        /// <summary>
        /// Make sure the pipeline blob is valid and already existing
        /// </summary>
        /// <param name="blob">ICloudBlob object</param>
        internal void ValidatePipelineICloudBlob(ICloudBlob blob)
        {
            if (null == blob)
            {
                throw new ArgumentException(String.Format(Resources.ObjectCannotBeNull, typeof(ICloudBlob).Name));
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
        /// <param name="blob">ICloudBlob object</param>
        /// <returns>true if the specified blob is snapshot, otherwise false</returns>
        internal bool IsSnapshot(ICloudBlob blob)
        {
            return !string.IsNullOrEmpty(blob.Name) && blob.SnapshotTime != null;
        }

        /// <summary>
        /// Write ICloudBlob to output using specified service channel
        /// </summary>
        /// <param name="blob">The output ICloudBlob object</param>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        internal void WriteICloudBlobObject(long taskId, IStorageBlobManagement channel, ICloudBlob blob, BlobContinuationToken continuationToken = null)
        {
            AzureStorageBlob azureBlob = new AzureStorageBlob(blob);
            azureBlob.Context = channel.StorageContext;
            azureBlob.ContinuationToken = continuationToken;
            OutputStream.WriteObject(taskId, azureBlob);
        }

        /// <summary>
        /// Write ICloudBlob to output using specified service channel
        /// </summary>
        /// <param name="blob">The output ICloudBlob object</param>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        internal void WriteCloudContainerObject(long taskId, IStorageBlobManagement channel,
            CloudBlobContainer container, BlobContainerPermissions permissions, BlobContinuationToken continuationToken = null)
        {
            AzureStorageContainer azureContainer = new AzureStorageContainer(container, permissions);
            azureContainer.Context = channel.StorageContext;
            azureContainer.ContinuationToken = continuationToken;
            OutputStream.WriteObject(taskId, azureContainer);
        }
        
        /// <summary>
        /// Check whether the blob name is valid. If not throw an exception
        /// </summary>
        /// <param name="name">Blob name</param>
        protected void ValidateBlobName(string name)
        {
            if (!NameUtil.IsValidBlobName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, name));
            }
        }

        /// <summary>
        /// Check whether the container name is valid. If not throw an exception
        /// </summary>
        /// <param name="name">Container name</param>
        protected void ValidateContainerName(string name)
        {
            if (!NameUtil.IsValidContainerName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
            }
        }
    }
}