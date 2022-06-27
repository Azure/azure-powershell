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
    using global::Azure;
    using global::Azure.Core;
    using global::Azure.Storage;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Specialized;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.Shared.Protocol;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Track2blobModel = global::Azure.Storage.Blobs.Models;

    /// <summary>
    /// Base cmdlet for storage blob/container cmdlet
    /// </summary>
    public class StorageCloudBlobCmdletBase : StorageCloudCmdletBase<IStorageBlobManagement>
    {
        [Parameter(HelpMessage = "Optional Tag expression statement to check match condition. The blob request will fail when the blob tags does not match the given expression." +
            "See details in https://docs.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations#tags-conditional-operations.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public virtual string TagCondition { get; set; }        

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

        public DataLakeClientOptions DataLakeClientOptions
        {
            get
            {
                if (dataLakeClientOptions == null)
                {
                    dataLakeClientOptions = new DataLakeClientOptions();
                    dataLakeClientOptions.AddPolicy(new UserAgentPolicy(ApiConstants.UserAgentHeaderValue), HttpPipelinePosition.PerCall);
                    return dataLakeClientOptions;
                }
                else
                {
                    return dataLakeClientOptions;
                }
            }
        }
        private DataLakeClientOptions dataLakeClientOptions = null;

        public BlobClientOptions ClientOptions
        {
            get
            {
                if (clientOptions == null)
                {
                    clientOptions = new BlobClientOptions();
                    clientOptions.AddPolicy(new UserAgentPolicy(ApiConstants.UserAgentHeaderValue), HttpPipelinePosition.PerCall);
                    return clientOptions;
                }
                else
                {
                    return clientOptions;
                }
            }
        }
        private BlobClientOptions clientOptions = null;

        public BlobClientOptions SetClientOptionsWithEncryptionScope(string encryptionScope)
        {
            if (clientOptions == null)
            {
                clientOptions = new BlobClientOptions();
                clientOptions.AddPolicy(new UserAgentPolicy(ApiConstants.UserAgentHeaderValue), HttpPipelinePosition.PerCall);
                clientOptions.EncryptionScope = encryptionScope;
                return clientOptions;
            }
            else
            {
                clientOptions.EncryptionScope = encryptionScope;
                return clientOptions;
            }

        }

        public global::Azure.Storage.Blobs.Models.BlobRequestConditions BlobRequestConditions
        {
            get
            {
                global::Azure.Storage.Blobs.Models.BlobRequestConditions requestConditions = new global::Azure.Storage.Blobs.Models.BlobRequestConditions();
                if (this.TagCondition != null)
                {
                    requestConditions.TagConditions = this.TagCondition;
                }
                return requestConditions;
            }
        }

        public global::Azure.Storage.Blobs.Models.PageBlobRequestConditions PageBlobRequestConditions
        {
            get
            {
                global::Azure.Storage.Blobs.Models.PageBlobRequestConditions requestConditions = new global::Azure.Storage.Blobs.Models.PageBlobRequestConditions();
                if (this.TagCondition != null)
                {
                    requestConditions.TagConditions = this.TagCondition;
                }
                return requestConditions;
            }
        }

        public global::Azure.Storage.Blobs.Models.AppendBlobRequestConditions AppendBlobRequestConditions
        {
            get
            {
                global::Azure.Storage.Blobs.Models.AppendBlobRequestConditions requestConditions = new global::Azure.Storage.Blobs.Models.AppendBlobRequestConditions();
                if (this.TagCondition != null)
                {
                    requestConditions.TagConditions = this.TagCondition;
                }
                return requestConditions;
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
        /// Make sure the pipeline blob is valid and already existing
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        internal void ValidatePipelineCloudBlobTrack2(BlobBaseClient blob)
        {
            if (null == blob)
            {
                throw new ArgumentException(String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
            }

            if (!NameUtil.IsValidBlobName(blob.Name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blob.Name));
            }

            if (!NameUtil.IsValidContainerName(blob.BlobContainerName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, blob.BlobContainerName));
            }
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
        /// <param name="context">Cloud storage account object</param>
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
        /// <param name="taskId">Task id</param>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        /// <param name="blob">A CloudBlob object</param>
        /// <param name="continuationToken">Continuation token.</param>
        internal void WriteCloudBlobObject(long taskId, IStorageBlobManagement channel, CloudBlob blob, BlobContinuationToken continuationToken = null)
        {
            AzureStorageBlob azureBlob = new AzureStorageBlob(blob, channel.StorageContext, ClientOptions);
            azureBlob.ContinuationToken = continuationToken;
            OutputStream.WriteObject(taskId, azureBlob);
        }

        /// <summary>
        /// Write a datalake gen2 file  to output
        /// </summary>
        internal void WriteDataLakeGen2Item(IStorageBlobManagement channel, DataLakeFileClient fileClient, long? taskId = null)
        {
            AzureDataLakeGen2Item azureDataLakeGen2Item = new AzureDataLakeGen2Item(fileClient);
            azureDataLakeGen2Item.Context = channel.StorageContext;
            if (taskId == null)
            {
                WriteObject(azureDataLakeGen2Item);
            }
            else
            {
                OutputStream.WriteObject(taskId.Value, azureDataLakeGen2Item);
            }
        }

        /// <summary>
        /// Write a datalake gen2 folder to output.
        /// </summary>
        internal void WriteDataLakeGen2Item(IStorageBlobManagement channel, DataLakeDirectoryClient dirClient)
        {
            AzureDataLakeGen2Item azureDataLakeGen2Item = new AzureDataLakeGen2Item(dirClient);
            azureDataLakeGen2Item.Context = channel.StorageContext;
            WriteObject(azureDataLakeGen2Item);
        }

        /// <summary>
        /// Write a datalake gen2 pathitem to output.
        /// </summary>
        internal void WriteDataLakeGen2Item(IStorageBlobManagement channel, PathItem item, DataLakeFileSystemClient fileSystem, string ContinuationToken = null, bool fetchProperties = false)
        {
            AzureDataLakeGen2Item azureDataLakeGen2Item = new AzureDataLakeGen2Item(item, fileSystem, fetchProperties);
            azureDataLakeGen2Item.Context = channel.StorageContext;
            azureDataLakeGen2Item.ContinuationToken = ContinuationToken;
            WriteObject(azureDataLakeGen2Item);
        }

        /// <summary>
        /// Write CloudBlob to output using specified service channel
        /// </summary>
        /// 
        /// <param name="taskId">Task id</param>
        /// <param name="channel">IStorageBlobManagement channel object</param>
        /// <param name="container">A CloudBlobContainer object</param>
        /// <param name="permissions">permissions of container</param>
        /// <param name="continuationToken">Continuation token.</param>
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
        /// decide if a object represent a folder of datalake gen2
        /// </summary>
        /// <param name="fileProperties">the PathProperties of the datalakeGen2 Object</param>
        /// <returns>return true if it represent a folder of datalake gen2</returns>
        public static bool isDirectory(PathProperties fileProperties)
        {
            if (fileProperties.Metadata.Contains(new KeyValuePair<string, string>("hdi_isfolder", "true"))
                && fileProperties.ContentLength == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// get the CloudBlobContainer object by name if container exists
        /// </summary>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="containerName">container name</param>
        /// <param name="skipCheckExists"></param>
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
        /// Get an Exist DataLakeGen2Item, return true is the item is a folder, return false if it's File
        /// </summary>
        /// <param name="fileSystem"></param>
        /// <param name="path">the path of the Items</param>
        /// <param name="fileClient"></param>
        /// <param name="dirClient"></param>
        /// <returns>return true if the item is a folder, else false</returns>
        public static bool GetExistDataLakeGen2Item(DataLakeFileSystemClient fileSystem, string path, out DataLakeFileClient fileClient, out DataLakeDirectoryClient dirClient)
        {
            try
            {
                if (string.IsNullOrEmpty(path))
                {
                    dirClient = fileSystem.GetDirectoryClient("");
                    fileClient = null;
                    return true;
                }

                fileClient = fileSystem.GetFileClient(path);
                PathProperties properties = fileClient.GetProperties().Value;
                if (isDirectory(properties))
                {
                    dirClient = fileSystem.GetDirectoryClient(path);
                    fileClient = null;
                    return true;
                }
                else
                {
                    dirClient = null;
                    return false;
                }
            }
            catch (RequestFailedException e) when (e.Status == 404)
            {
                // TODO: through exception that the item not exist
                throw new ArgumentException(string.Format("The Item in File System {0} on path {1} does not exist.", fileSystem.Name, path));
            }
        }

        //only support the common properties for DatalakeGen2File
        protected static Dictionary<string, Action<PathHttpHeaders, string>> validDatalakeGen2FileProperties =
            new Dictionary<string, Action<PathHttpHeaders, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                {"ContentMD5", (p, v) => p.ContentHash = Convert.FromBase64String(v)},
                {"ContentType", (p, v) => p.ContentType = v},
            };

        //only support the common properties for DatalakeGen2Folder
        protected static Dictionary<string, Action<PathHttpHeaders, string>> validDatalakeGen2FolderProperties =
            new Dictionary<string, Action<PathHttpHeaders, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
            };

        /// <summary>
        /// Set properties to a datalake gen2 Datalakegen2Item
        /// </summary>
        /// <param name="item">datalake gen2 Datalakegen2Item</param>
        /// <param name="BlobProperties">properties to set</param>
        /// <param name="setToServer">True will set to server, false only set to the local Datalakegen2Item object</param>
        protected static PathHttpHeaders SetDatalakegen2ItemProperties(DataLakePathClient item, Hashtable BlobProperties, bool setToServer = true)
        {
            if (BlobProperties != null)
            {
                // Valid Blob Dir properties
                foreach (DictionaryEntry entry in BlobProperties)
                {
                    if (!validDatalakeGen2FileProperties.ContainsKey(entry.Key.ToString()))
                    {
                        throw new ArgumentException(String.Format("InvalidDataLakeFileProperties", entry.Key.ToString(), entry.Value.ToString()));
                    }
                }

                PathHttpHeaders headers = new PathHttpHeaders();
                foreach (DictionaryEntry entry in BlobProperties)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();
                    Action<PathHttpHeaders, string> action = validDatalakeGen2FileProperties[key];

                    if (action != null)
                    {
                        action(headers, value);
                    }
                }
                if (setToServer && item != null)
                {
                    item.SetHttpHeaders(headers);
                }
                return headers;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Set Metadata to a datalake gen2 item
        /// </summary>
        /// <param name="item">datalake gen2 item</param>
        /// <param name="Metadata">Metadata to set</param>
        /// <param name="setToServer">True will set to server, false only set to the local Datalakegen2Item object</param>
        protected static IDictionary<string, string> SetDatalakegen2ItemMetaData(DataLakePathClient item, Hashtable Metadata, bool setToServer = true)
        {
            if (Metadata != null)
            {
                IDictionary<string, string> metadata = GetUpdatedMetaData(Metadata, null);
                if (setToServer && item != null)
                {
                    item.SetMetadata(metadata);
                }
                return metadata;
            }
            else
            {
                return null;
            }
        }

        public static IDictionary<string, string> GetUpdatedMetaData(Hashtable Metadata, IDictionary<string, string> originalMetadata = null)
        {
            if (Metadata != null)
            {
                IDictionary<string, string> metadata;
                if (originalMetadata == null)
                {
                    metadata = new Dictionary<string, string>();
                }
                else
                {
                    metadata = originalMetadata;
                    metadata.Remove("hdi_isfolder");
                }
                foreach (DictionaryEntry entry in Metadata)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();

                    if (metadata.ContainsKey(key))
                    {
                        metadata[key] = value;
                    }
                    else
                    {
                        metadata.Add(key, value);
                    }
                }
                return metadata;
            }
            else
            {
                return originalMetadata;
            }
        }

        /// <summary>
        /// Get Item string without SAS for confirmation string.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected static string GetDataLakeItemUriWithoutSas(DataLakePathClient item)
        {
            string uriString = item.Uri.ToString();
            int length = uriString.IndexOf("?");
            if (length < 0) // Not container "?"
            {
                return uriString;
            }
            else
            {
                return uriString.Substring(0, uriString.IndexOf("?"));
            }
        }

        /// <summary>
        /// get the DataLakeFileSystemClient object by name if DataLakeFileSystem exists
        /// </summary>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="fileSystemName">DataLakeFileSystem name</param>
        /// <param name="skipCheckExists"></param>
        /// <returns>return DataLakeFileSystemClient object if specified DataLakeFileSystem exists, otherwise throw an exception</returns>
        internal DataLakeFileSystemClient GetFileSystemClientByName(IStorageBlobManagement localChannel, string fileSystemName, bool skipCheckExists = false)
        {
            if (!NameUtil.IsValidContainerName(fileSystemName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, fileSystemName));
            }

            Uri fileSystemUri = localChannel.StorageContext.StorageAccount.CreateCloudBlobClient().GetContainerReference(fileSystemName).Uri;
            DataLakeFileSystemClient fileSystem;

            if (localChannel.StorageContext.StorageAccount.Credentials.IsToken) //Oauth
            {
                fileSystem = new DataLakeFileSystemClient(fileSystemUri, localChannel.StorageContext.Track2OauthToken, this.DataLakeClientOptions);
            }
            else if (localChannel.StorageContext.StorageAccount.Credentials.IsSAS) //SAS
            {
                fileSystem = new DataLakeFileSystemClient(new Uri (fileSystemUri.ToString() + "?" + Util.GetSASStringWithoutQuestionMark(localChannel.StorageContext.StorageAccount.Credentials.SASToken)), this.DataLakeClientOptions);
            }
            else if (localChannel.StorageContext.StorageAccount.Credentials.IsSharedKey) //Shared Key
            {
                fileSystem = new DataLakeFileSystemClient(fileSystemUri,
                     new StorageSharedKeyCredential(localChannel.StorageContext.StorageAccountName, localChannel.StorageContext.StorageAccount.Credentials.ExportBase64EncodedKey()), this.DataLakeClientOptions);
            }
            else //Anonymous
            {
                fileSystem = new DataLakeFileSystemClient(fileSystemUri, this.DataLakeClientOptions);
            }

            return fileSystem;
        }

        //only support the common blob properties for block blob and page blob
        //http://msdn.microsoft.com/en-us/library/windowsazure/ee691966.aspx
        protected static Dictionary<string, Action<BlobProperties, string>> validCloudBlobProperties =
            new Dictionary<string, Action<BlobProperties, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                {"ContentMD5", (p, v) => p.ContentMD5 = v},
                {"ContentType", (p, v) => p.ContentType = v},
            };

        /// <summary>
        /// check whether the blob properties is valid
        /// </summary>
        /// <param name="properties">Blob properties table</param>
        protected void ValidateBlobProperties(Hashtable properties)
        {
            if (properties == null)
            {
                return;
            }

            foreach (DictionaryEntry entry in properties)
            {
                if (!validCloudBlobProperties.ContainsKey(entry.Key.ToString()))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidBlobProperties, entry.Key.ToString(), entry.Value.ToString()));
                }
            }
        }

        /// <summary>
        /// set blob properties to a blob object
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="properties">blob properties hashtable</param>
        protected static void SetBlobProperties(CloudBlob blob, Hashtable properties)
        {
            if (properties == null)
            {
                return;
            }

            foreach (DictionaryEntry entry in properties)
            {
                string key = entry.Key.ToString();
                string value = entry.Value.ToString();
                Action<BlobProperties, string> action = validCloudBlobProperties[key];

                if (action != null)
                {
                    action(blob.Properties, value);
                }
            }
        }

        /// <summary>
        /// set blob metadata to a blob object
        /// </summary>
        /// <param name="blob">CloudBlob object</param>
        /// <param name="meta">meta data hashtable</param>
        protected static void SetBlobMeta(CloudBlob blob, Hashtable meta)
        {
            if (meta == null)
            {
                return;
            }

            foreach (DictionaryEntry entry in meta)
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
        }

        /// <summary>
        /// CreateBlobPropertiesObject, which will be set to server
        /// </summary>
        /// <param name="BlobProperties">properties to set</param>
        protected static Track2blobModel.BlobHttpHeaders CreateBlobHttpHeaders(Hashtable BlobProperties)
        {
            if (BlobProperties != null)
            {
                // Valid Blob Dir properties
                foreach (DictionaryEntry entry in BlobProperties)
                {
                    if (!validDatalakeGen2FileProperties.ContainsKey(entry.Key.ToString()))
                    {
                        throw new ArgumentException(String.Format("InvalidDataLakeFileProperties", entry.Key.ToString(), entry.Value.ToString()));
                    }
                }

                Track2blobModel.BlobHttpHeaders headers = new Track2blobModel.BlobHttpHeaders();
                foreach (DictionaryEntry entry in BlobProperties)
                {
                    string key = entry.Key.ToString();
                    string value = entry.Value.ToString();
                    Action<Track2blobModel.BlobHttpHeaders, string> action = validBlobProperties_Track2[key];

                    if (action != null)
                    {
                        action(headers, value);
                    }
                }
                return headers;
            }
            else
            {
                return null;
            }
        }

        //only support the common properties for Blob
        protected static Dictionary<string, Action<Track2blobModel.BlobHttpHeaders, string>> validBlobProperties_Track2 =
            new Dictionary<string, Action<Track2blobModel.BlobHttpHeaders, string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"CacheControl", (p, v) => p.CacheControl = v},
                {"ContentDisposition", (p, v) => p.ContentDisposition = v},
                {"ContentEncoding", (p, v) => p.ContentEncoding = v},
                {"ContentLanguage", (p, v) => p.ContentLanguage = v},
                {"ContentMD5", (p, v) => p.ContentHash = Convert.FromBase64String(v)},
                {"ContentType", (p, v) => p.ContentType = v},
            };

        //Update Blob Metadata
        protected static IDictionary<string, string> SetBlobMeta_Track2(IDictionary<string, string> originalMetaData, Hashtable meta)
        {
            if (meta == null)
            {
                return originalMetaData;
            }

            foreach (DictionaryEntry entry in meta)
            {
                string key = entry.Key.ToString();
                string value = entry.Value.ToString();

                if (originalMetaData.ContainsKey(key))
                {
                    originalMetaData[key] = value;
                }
                else
                {
                    originalMetaData.Add(key, value);
                }
            }
            return originalMetaData;
        }

        protected static Track2blobModel.AccessTier? GetAccessTier_Track2(StandardBlobTier? standardBlobTier, PremiumPageBlobTier? pageBlobTier)
        {
            if(standardBlobTier == null && pageBlobTier == null)
            {
                return null;
            }
            if (standardBlobTier != null)
            {
                switch (standardBlobTier.Value)
                {
                    case StandardBlobTier.Archive:
                        return Track2blobModel.AccessTier.Archive;
                    case StandardBlobTier.Cool:
                        return Track2blobModel.AccessTier.Cool;
                    case StandardBlobTier.Hot:
                        return Track2blobModel.AccessTier.Hot;
                    default:
                        return null;
                }
            }
            else //pageBlobTier != null
            {
                switch (pageBlobTier.Value)
                {
                    case PremiumPageBlobTier.P4:
                        return Track2blobModel.AccessTier.P4;
                    case PremiumPageBlobTier.P6:
                        return Track2blobModel.AccessTier.P6;
                    case PremiumPageBlobTier.P10:
                        return Track2blobModel.AccessTier.P10;
                    case PremiumPageBlobTier.P20:
                        return Track2blobModel.AccessTier.P20;
                    case PremiumPageBlobTier.P30:
                        return Track2blobModel.AccessTier.P30;
                    case PremiumPageBlobTier.P40:
                        return Track2blobModel.AccessTier.P40;
                    case PremiumPageBlobTier.P50:
                        return Track2blobModel.AccessTier.P50;
                    case PremiumPageBlobTier.P60:
                        return Track2blobModel.AccessTier.P60;
                    case PremiumPageBlobTier.P70:
                        return Track2blobModel.AccessTier.P70;
                    case PremiumPageBlobTier.P80:
                        return Track2blobModel.AccessTier.P80;
                    default:
                        return null;
                }
            }
        }

        // Convert Track1 Blob object to Track 2 blob Client
        public static BlobClient GetTrack2BlobClient(CloudBlob cloubBlob, AzureStorageContext context, BlobClientOptions options = null)
        {
            BlobClient blobClient;
            if (cloubBlob.ServiceClient.Credentials.IsToken) //Oauth
            {
                if (context == null)
                {
                    //TODO : Get Oauth context from current login user.
                    throw new System.Exception("Need Storage Context to convert Track1 Blob object in token credentail to Track2 Blob object.");
                }
                blobClient = new BlobClient(cloubBlob.SnapshotQualifiedUri, context.Track2OauthToken, options);

            }
            else if (cloubBlob.ServiceClient.Credentials.IsSAS) //SAS
            {
                string sas = Util.GetSASStringWithoutQuestionMark(cloubBlob.ServiceClient.Credentials.SASToken);
                string fullUri = cloubBlob.SnapshotQualifiedUri.ToString();
                if (cloubBlob.IsSnapshot)
                {
                    // Since snapshot URL already has '?', need remove '?' in the first char of sas
                    fullUri = fullUri + "&" + sas;
                }
                else
                {
                    fullUri = fullUri + "?" + sas;
                }
                blobClient = new BlobClient(new Uri(fullUri), options);
            }
            else if (cloubBlob.ServiceClient.Credentials.IsSharedKey) //Shared Key
            {
                blobClient = new BlobClient(cloubBlob.SnapshotQualifiedUri,
                    new StorageSharedKeyCredential(context.StorageAccountName, cloubBlob.ServiceClient.Credentials.ExportBase64EncodedKey()),
                    options);
            }
            else //Anonymous
            {
                blobClient = new BlobClient(cloubBlob.SnapshotQualifiedUri, options);
            }

            return blobClient;
        }

        // Convert Track1 Blob object to Track 2 page blob Client
        public static PageBlobClient GetTrack2PageBlobClient(CloudBlob cloubBlob, AzureStorageContext context, BlobClientOptions options = null)
        {
            PageBlobClient blobClient = (PageBlobClient)Util.GetTrack2BlobClientWithType(
                AzureStorageBlob.GetTrack2BlobClient(cloubBlob, context, options),
                context,
                Track2blobModel.BlobType.Page,
                options);
            return blobClient;
        }

        // Convert Track1 Blob object to Track 2 append blob Client
        public static AppendBlobClient GetTrack2AppendBlobClient(CloudBlob cloubBlob, AzureStorageContext context, BlobClientOptions options = null)
        {
            AppendBlobClient blobClient = (AppendBlobClient)Util.GetTrack2BlobClientWithType(
               AzureStorageBlob.GetTrack2BlobClient(cloubBlob, context, options),
               context,
               Track2blobModel.BlobType.Append,
               options);
            return blobClient;
        }

        protected virtual bool UseTrack2Sdk()
        {
            if (!string.IsNullOrEmpty(TagCondition))
            {
                return true;
            }
            return false;
        }

        protected void ThrowIfPremium(string exMsgFormat)
        {
            AccountProperties accountProperties = Channel.GetAccountProperties();
            if (accountProperties.SkuName.Contains("Premium"))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, exMsgFormat, Channel.StorageContext.StorageAccountName));
            }
        }
    }
}