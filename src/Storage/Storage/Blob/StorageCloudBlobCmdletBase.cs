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
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using System.Collections;

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
            OperationContext operationContext = null,
            DateTimeOffset? snapshotTime = null)
        {
            return GetBlobReferenceWrapper(() =>
                {
                    try
                    {
                        return localChannel.GetBlobReferenceFromServer(container, blobName, accessCondition, requestOptions, operationContext, snapshotTime);
                    }
                    catch (InvalidOperationException)
                    {
                        return null;
                    }
                },
                blobName,
                container.Name);
        }

        protected static CloudBlob GetBlobSnapshotReferenceFromServerWithContainer(
            IStorageBlobManagement localChannel,
            CloudBlobContainer container,
            string blobName,
            DateTime SrcBlobSnapshotTime,
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
        /// Write a datalake gen2 item  to output. If the input blob represent a folder of datalake gen2 , will output a folder, else output a file of datalake gen2
        /// </summary>
        internal void WriteDataLakeGen2Item(IStorageBlobManagement channel, CloudBlockBlob blob, BlobContinuationToken continuationToken = null, bool fetchPermission = false, long? taskId = null)
        {
            AzureDataLakeGen2Item azureBlob = null;
            if (!isBlobDirectory(blob)) //normal blob
            {
                if (fetchPermission)
                {
                    blob.FetchAccessControls();
                }
                azureBlob = new AzureDataLakeGen2Item(blob);
            }
            else //blobDir
            {
                CloudBlobDirectory blobDir = blob.Container.GetDirectoryReference(blob.Name);
                blobDir.FetchAttributes();
                if (fetchPermission)
                {
                    blobDir.FetchAccessControls();
                }
                azureBlob = new AzureDataLakeGen2Item(blobDir);
            }
            azureBlob.Context = channel.StorageContext;
            azureBlob.ContinuationToken = continuationToken;
            if (taskId == null)
            {
                WriteObject(azureBlob);
            }
            else
            {
                OutputStream.WriteObject(taskId.Value, azureBlob);
            }
        }

        /// <summary>
        /// Write a datalake gen2 folder to output.
        /// </summary>
        internal void WriteDataLakeGen2Item(IStorageBlobManagement channel, CloudBlobDirectory blobDir, BlobContinuationToken continuationToken = null, bool fetchPermission = false)
        {

            if (fetchPermission)
            {
                blobDir.FetchAccessControls();
            }
            AzureDataLakeGen2Item azureBlob = new AzureDataLakeGen2Item(blobDir);
            azureBlob.Context = channel.StorageContext;
            azureBlob.ContinuationToken = continuationToken;
            WriteObject(azureBlob);
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

        protected void ValidateBlobTier(BlobType type, PremiumPageBlobTier? pageBlobTier = null, StandardBlobTier? standardBlobTier = null, RehydratePriority? rehydratePriority = null)
        {
            if ((pageBlobTier != null)
                && (type != BlobType.PageBlob))
            {
                throw new ArgumentOutOfRangeException("BlobType, PageBlobTier", String.Format("PremiumPageBlobTier can only be set to Page Blob. The Current BlobType is: {0}", type));
            }
            if ((standardBlobTier != null || rehydratePriority != null)
                && (type != BlobType.BlockBlob))
            {
                throw new ArgumentOutOfRangeException("BlobType, StandardBlobTier/RehydratePriority", String.Format("StandardBlobTier and RehydratePriority can only be set to Block Blob. The Current BlobType is: {0}", type));
            }
        }

        protected bool ContainerIsEmpty(CloudBlobContainer container)
        {
            try
            {
                BlobContinuationToken blobToken = new BlobContinuationToken();
                using (IEnumerator<IListBlobItem> listedBlobs = container
                    .ListBlobsSegmentedAsync("", true, BlobListingDetails.None, 1, blobToken, RequestOptions,
                        OperationContext).Result.Results.GetEnumerator())
                {
                    return !(listedBlobs.MoveNext() && listedBlobs.Current != null);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// decide if a blob object represent a folder of datalake gen2
        /// </summary>
        /// <param name="blob">the Blob Object</param>
        /// <returns>return true if it represent a folder of datalake gen2</returns>
        public static bool isBlobDirectory(CloudBlob blob)
        {
            if (blob.Metadata.Contains(new KeyValuePair<string, string>("hdi_isfolder", "true"))
                && blob.BlobType == BlobType.BlockBlob
                && blob.Properties.Length == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// get the CloudBlobContainer object by name if container exists
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <returns>return CloudBlobContianer object if specified container exists, otherwise throw an exception</returns>
        internal async Task<CloudBlobContainer> GetCloudBlobContainerByName(IStorageBlobManagement localChannel, string containerName, bool skipCheckExists = false)
        {
            if (!NameUtil.IsValidContainerName(containerName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, containerName));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);

            if (!skipCheckExists && container.ServiceClient.Credentials.IsSharedKey
                && !await localChannel.DoesContainerExistAsync(container, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false))
            {
                throw new ArgumentException(String.Format(Resources.ContainerNotFound, containerName));
            }

            return container;
        }

        /// <summary>
        /// Check if the DataLakeGen2 file exist, and return it if exist
        /// </summary>
        /// <param name="container">the container for the file</param>
        /// <param name="path">the path for the file</param>
        /// <returns>return the file object if exist, else return null</returns>
        public static CloudBlockBlob GetExistBlockBlob(CloudBlobContainer container, string path)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(path);
            if (blob.Exists() && !isBlobDirectory(blob))
            {
                return blob;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Check if the DataLakeGen2 folder exist, and return it if exist
        /// </summary>
        /// <param name="container">the container for the folder</param>
        /// <param name="path">the path for the folder</param>
        /// <returns>return the folder object if exist, else return null</returns>
        public static CloudBlobDirectory GetExistBlobDirectory(CloudBlobContainer container, string path)
        {
            CloudBlobDirectory blobDir = container.GetDirectoryReference(path);
            if (blobDir.Exists())
            {
                return blobDir;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Get an Exist DataLakeGen2Item
        /// </summary>
        /// <param name="container">the blob container</param>
        /// <param name="path">the path of the Items</param>
        /// <returns>return true if the item is a folder, else false</returns>
        public static bool GetExistDataLakeGen2Item(CloudBlobContainer container, string path, out CloudBlockBlob blob, out CloudBlobDirectory blobDir)
        {
            bool isFolder = false;
            CloudBlockBlob getBlob = GetExistBlockBlob(container, path);
            if (getBlob != null)
            {
                if (getBlob.Properties.BlobType != BlobType.BlockBlob)
                {
                    throw new System.ArgumentException(String.Format("The Item has invalid Blob Type for Datalake gen2: {2}, it should be: BlockBlob. Container: {0}, Path: {1} ", container.Name, path, getBlob.Properties.BlobType));
                }
                blob = (CloudBlockBlob)getBlob;
                blobDir = null;
                isFolder = false;
            }
            else
            {
                blobDir = GetExistBlobDirectory(container, path);
                if (blobDir != null)
                {
                    blob = null;
                    isFolder = true;
                }
                else
                {
                    throw new System.ArgumentException(String.Format("The Datalake gen2 Item not exist. Container: {0}, Path: {1} ", container.Name, path));
                }
            }
            return isFolder;
        }

        //only support the common properties for DatalakeGen2File
        protected static Dictionary<string, Action<BlobProperties, string>> validDatalakeGen2FileProperties =
            new Dictionary<string, Action<BlobProperties, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                {"ContentMD5", (p, v) => p.ContentMD5 = v},
                {"ContentType", (p, v) => p.ContentType = v},
            };

        //only support the common properties for DatalakeGen2Folder
        protected static Dictionary<string, Action<BlobProperties, string>> validDatalakeGen2FolderProperties =
            new Dictionary<string, Action<BlobProperties, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                //{"ContentMD5", (p, v) => p.ContentMD5 = v},
                //{"ContentType", (p, v) => p.ContentType = v},
            };

        /// <summary>
        /// Set properties to a datalake gen2 folder
        /// </summary>
        /// <param name="blobDir">datalake gen2 folder</param>
        /// <param name="BlobDirProperties">properties to set</param>
        /// <param name="setToServer">True will set to server, false only set to the local folder object</param>
        protected static void SetBlobDirProperties(CloudBlobDirectory blobDir, Hashtable BlobDirProperties, bool setToServer = true)
        {
            if (BlobDirProperties != null)
            {
                // Valid Blob Dir properties
                foreach (DictionaryEntry entry in BlobDirProperties)
                {
                    if (!validDatalakeGen2FolderProperties.ContainsKey(entry.Key.ToString()))
                    {
                        throw new ArgumentException(String.Format(Resources.InvalidBlobProperties, entry.Key.ToString(), entry.Value.ToString()));
                    }
                }

                foreach (DictionaryEntry entry in BlobDirProperties)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();
                    Action<BlobProperties, string> action = validDatalakeGen2FolderProperties[key];

                    if (action != null)
                    {
                        action(blobDir.Properties, value);
                    }
                }
                if (setToServer)
                {
                    blobDir.SetProperties();
                }
            }
        }

        /// <summary>
        /// Set properties to a datalake gen2 file
        /// </summary>
        /// <param name="blob">datalake gen2 file</param>
        /// <param name="BlobProperties">properties to set</param>
        /// <param name="setToServer">True will set to server, false only set to the local file object</param>
        protected static void SetBlobProperties(ICloudBlob blob, Hashtable BlobProperties, bool setToServer = true)
        {
            if (BlobProperties != null)
            {
                // Valid Blob Dir properties
                foreach (DictionaryEntry entry in BlobProperties)
                {
                    if (!validDatalakeGen2FileProperties.ContainsKey(entry.Key.ToString()))
                    {
                        throw new ArgumentException(String.Format(Resources.InvalidBlobProperties, entry.Key.ToString(), entry.Value.ToString()));
                    }
                }

                foreach (DictionaryEntry entry in BlobProperties)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();
                    Action<BlobProperties, string> action = validDatalakeGen2FileProperties[key];

                    if (action != null)
                    {
                        action(blob.Properties, value);
                    }
                }
                if (setToServer)
                {
                    blob.SetProperties();
                }
            }
        }

        /// <summary>
        /// Set Metadata to a datalake gen2 file
        /// </summary>
        /// <param name="blob">datalake gen2 file</param>
        /// <param name="Metadata">Metadata to set</param>
        /// <param name="setToServer">True will set to server, false only set to the local file object</param>
        protected static void SetBlobMetaData(ICloudBlob blob, Hashtable Metadata, bool setToServer = true)
        {
            if (Metadata != null)
            {
                foreach (DictionaryEntry entry in Metadata)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();

                    if (blob.Metadata.ContainsKey(key))
                    {
                        blob.Metadata[key] = value;
                    }
                    else
                    {
                        blob.Metadata.Add(key, value);
                    }
                }
                if (setToServer)
                {
                    blob.SetMetadata();
                }
            }
        }

        /// <summary>
        /// Set Metadata to a datalake gen2 folder
        /// </summary>
        /// <param name="blobDir">datalake gen2 folder</param>
        /// <param name="Metadata">Metadata to set</param>
        /// <param name="setToServer">True will set to server, false only set to the local folder object</param>
        protected static void SetBlobDirMetadata(CloudBlobDirectory blobDir, Hashtable Metadata, bool setToServer = true)
        {
            if (Metadata != null)
            {
                foreach (DictionaryEntry entry in Metadata)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();

                    if (blobDir.Metadata.ContainsKey(key))
                    {
                        blobDir.Metadata[key] = value;
                    }
                    else
                    {
                        blobDir.Metadata.Add(key, value);
                    }
                }
                if (setToServer)
                {
                    blobDir.SetMetadata();
                }
            }
        }
    }
}