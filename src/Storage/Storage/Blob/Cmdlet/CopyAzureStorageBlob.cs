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


namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Azure.Commands.Common.Authentication.Abstractions;
    using Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using Track2Models = global::Azure.Storage.Blobs.Models;

    [Cmdlet("Copy", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlob", SupportsShouldProcess = true, DefaultParameterSetName = ContainerNameParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class CopyAzureStorageBlob : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobParameterSet = "BlobInstance";

        /// <summary>
        /// Blob name and container name parameter set
        /// </summary>
        private const string ContainerNameParameterSet = "ContainerName";

        /// <summary>
        /// Source uri parameter set
        /// </summary>
        private const string UriParameterSet = "UriPipeline";

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

        [Alias("SourceBlob")]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerNameParameterSet, Mandatory = true, Position = 0)]
        public string SrcBlob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Alias("SourceContainer")]
        [Parameter(HelpMessage = "Source Container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcContainer
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Alias("SrcUri", "SourceUri")]
        [Parameter(HelpMessage = "Source blob uri", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        [Alias("DestinationContainer")]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = BlobParameterSet)]
        //[Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        public string DestContainer { get; set; }

        [Alias("DestinationBlob")]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = BlobParameterSet)]
        //[Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        public string DestBlob { get; set; }

        [Parameter(HelpMessage = "Destination blob type", Mandatory = false, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob type", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob type", Mandatory = false, ParameterSetName = BlobParameterSet)]
        //[Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        [ValidateSet("Block", "Page", "Append", IgnoreCase = true)]
        public string DestBlobType { get; set; }

        [Parameter(HelpMessage = "Block Blob Tier, valid values are Hot/Cool/Archive/Cold. See detail in https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Hot", "Cool", "Archive", "Cold")]
        public string StandardBlobTier
        {
            get
            {
                return accesstier?.ToString();
            }

            set
            {
                if (value != null)
                {
                    accesstier = new AccessTier(value);
                    isBlockBlobAccessTier = true;
                }
                else
                {
                    accesstier = null;
                }
            }
        }
        private bool? isBlockBlobAccessTier = null;
        private AccessTier? accesstier = null;

        [Parameter(HelpMessage = "Block Blob RehydratePriority. Indicates the priority with which to rehydrate an archived blob. Valid values are High/Standard.", Mandatory = false)]
        [ValidateSet("Standard", "High", IgnoreCase = true)]
        public Azure.Storage.Blob.RehydratePriority RehydratePriority
        {
            get
            {
                return rehydratePriority.Value;
            }

            set
            {
                rehydratePriority = value;
            }
        }
        private Azure.Storage.Blob.RehydratePriority? rehydratePriority = null;

        [Parameter(HelpMessage = "Encryption scope to be used when making requests to the dest blob.",
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string EncryptionScope { get; set; }

        [Alias("SrcContext", "SourceContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ParameterSetName = UriParameterSet)]
        public override IStorageContext Context { get; set; }

        [Alias("DestinationContext")]
        [Parameter(HelpMessage = "Destination Storage context object", Mandatory = false)]
        public IStorageContext DestContext { get; set; }

        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }

        private bool skipSourceChannelInit;

        /// <summary>
        /// Create blob client and storage service management channel if need to.
        /// </summary>
        /// <returns>IStorageManagement object</returns>
        protected override IStorageBlobManagement CreateChannel()
        {
            //Init storage blob management channel
            if (skipSourceChannelInit)
            {
                return null;
            }
            else
            {
                return base.CreateChannel();
            }
        }

        /// <summary>
        /// Begin cmdlet processing
        /// </summary>
        protected override void BeginProcessing()
        {
            if (ParameterSetName == UriParameterSet)
            {
                skipSourceChannelInit = true;
            }

            base.BeginProcessing();
        }

        private IStorageFileManagement GetFileChannel()
        {
            return new StorageFileManagement(GetCmdletStorageContext());
        }

        /// <summary>
        /// Set up the Channel object for Destination container and blob
        /// </summary>
        internal IStorageBlobManagement GetDestinationChannel()
        {
            //If destChannel exits, reuse it.
            //If desContext exits, use it.
            //If Channl object exists, use it.
            //Otherwise, create a new channel.
            IStorageBlobManagement destChannel = default(IStorageBlobManagement);

            if (destChannel == null)
            {
                if (DestContext == null)
                {
                    if (Channel != null)
                    {
                        destChannel = Channel;
                    }
                    else
                    {
                        destChannel = base.CreateChannel();
                    }
                }
                else
                {
                    destChannel = CreateChannel(this.GetCmdletStorageContext(DestContext));
                }
            }

            return destChannel;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (AsJob.IsPresent)
            {
                if (ParameterSetName == UriParameterSet)
                {
                    skipSourceChannelInit = true;
                }
                DoBeginProcessing();
            }

            IStorageBlobManagement destChannel = GetDestinationChannel();
            IStorageBlobManagement srcChannel = Channel;

            if (!string.IsNullOrEmpty(this.EncryptionScope))
            {
                SetClientOptionsWithEncryptionScope(this.EncryptionScope);
            }

            string target = string.Empty;
            Action copyAction = null;
            switch (ParameterSetName)
            {
                case ContainerNameParameterSet:
                    copyAction = () => CopyBlobSync(srcChannel, destChannel, SrcContainer, SrcBlob, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case UriParameterSet:
                    copyAction = () => CopyBlobSync(destChannel, AbsoluteUri, DestContainer, DestBlob, (Context != null ? GetCmdletStorageContext(Context) : null));
                    target = AbsoluteUri;
                    break;

                case BlobParameterSet:
                    copyAction = () => CopyBlobSync(destChannel, BlobBaseClient, DestContainer, DestBlob);
                    target = BlobBaseClient.Name;
                    break;
            }

            if (copyAction != null && ShouldProcess(target, VerbsCommon.Copy))
            {
                copyAction();
            }

            if (AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        private void CopyBlobSync(IStorageBlobManagement SrcChannel, IStorageBlobManagement destChannel, string srcContainerName, string srcBlobName, string destContainerName, string destBlobName)
        {
            NameUtil.ValidateBlobName(srcBlobName);
            NameUtil.ValidateContainerName(srcContainerName);

            BlobBaseClient srcBlobBaseClient = Util.GetTrack2BlobServiceClient(SrcChannel.StorageContext, ClientOptions).GetBlobContainerClient(srcContainerName).GetBlobBaseClient(srcBlobName);

            this.CopyBlobSync(destChannel, srcBlobBaseClient, destContainerName, destBlobName);
        }

        private void CopyBlobSync(IStorageBlobManagement destChannel, BlobBaseClient srcBlobBaseClient, string destContainerName, string destBlobName)
        {
            NameUtil.ValidateContainerName(destContainerName);
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcBlobBaseClient.Name;
            }
            else
            {
                NameUtil.ValidateBlobName(destBlobName);
            }
            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainerName, destBlobName, null);

            this.CopyBlobSync(destChannel, srcBlobBaseClient, destBlob);
        }

        private void CopyBlobSync(IStorageBlobManagement destChannel, BlobBaseClient srcCloudBlob, BlobBaseClient destCloudBlob)
        {
            Track2Models.BlobType srcBlobType = Util.GetBlobType(srcCloudBlob, true).Value;

            if (srcCloudBlob is BlobClient)
            {
                srcCloudBlob = Util.GetTrack2BlobClientWithType(srcCloudBlob, Channel.StorageContext, srcBlobType, ClientOptions);
            }
            if (destCloudBlob is BlobClient)
            {
                destCloudBlob = Util.GetTrack2BlobClientWithType(destCloudBlob, destChannel.StorageContext, srcBlobType, ClientOptions);
            }

            Func<long, Task> taskGenerator = (taskId) => CopyFromUri(taskId, destChannel, srcCloudBlob.GenerateUriWithCredentials(Channel.StorageContext), destCloudBlob);
            RunTask(taskGenerator);
        }

        private void CopyBlobSync(IStorageBlobManagement destChannel, string srcUri, string destContainer, string destBlobName, AzureStorageContext context)
        {
            Track2Models.BlobType srcBlobType = Util.GetBlobType(new BlobBaseClient(new Uri(srcUri), ClientOptions), true).Value;

            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName, srcBlobType);
            Func<long, Task> taskGenerator = (taskId) => CopyFromUri(taskId, destChannel, new Uri(srcUri), destBlob);
            RunTask(taskGenerator);
        }

        private async Task CopyFromUri(long taskId, IStorageBlobManagement destChannel, Uri srcUri, BlobBaseClient destBlob)
        {
            bool destExist = true;
            Track2Models.BlobType? srcBlobType = Util.GetBlobType(new BlobBaseClient(srcUri, ClientOptions), true).Value;
            Track2Models.BlobType? destBlobType = Util.GetBlobType(new BlobBaseClient(srcUri, ClientOptions), true).Value;
            Track2Models.BlobProperties properties = null;

            try
            {
                properties = (await destBlob.GetPropertiesAsync(this.BlobRequestConditions, cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false)).Value;
                destBlobType = properties.BlobType;

                // Throw an exception if the input dest blob type and the existing dest blob's type given don't match
                if (!String.IsNullOrEmpty(this.DestBlobType) && !String.Equals(this.DestBlobType.ToLower(), destBlobType.ToString().ToLower()))
                {
                    throw new ArgumentException("Input dest blob type doesn't match with the actual dest blob type");
                }
            }
            catch (global::Azure.RequestFailedException e) when (e.Status == 404)
            {
                destExist = false;
            }

            if (!String.IsNullOrEmpty(this.DestBlobType))
            {
                switch (this.DestBlobType.ToLower())
                {
                    case "block":
                        destBlobType = Track2Models.BlobType.Block;
                        break;
                    case "page":
                        destBlobType = Track2Models.BlobType.Page;
                        break;
                    case "append":
                        destBlobType = Track2Models.BlobType.Append;
                        break;
                    default:
                        throw new ArgumentException("The input dest blob type is invalid");
                }   
            } else
            {
                if (destExist)
                { 
                    OutputStream.WriteDebug(string.Format("DestBlobType is not specified. Will use the existing dest blob type by default: {0}", destBlobType.ToString()));
                } 
                else
                { 
                    OutputStream.WriteDebug(string.Format("DestBlobType is not specified. Will use the source blob type by default: {0}", srcBlobType.ToString()));
                }
            }

            if (destBlobType != null)
            {
                ValidateBlobTier(Util.convertBlobType_Track2ToTrack1(destBlobType), null, isBlockBlobAccessTier, rehydratePriority);
                if (this.rehydratePriority != null && this.accesstier == null)
                {
                    throw new ArgumentException("RehydratePriority should only be specified when StandardBlobTier is specified.");
                }
            }

            if (!destExist || this.ConfirmOverwrite(srcUri.AbsoluteUri.ToString(), destBlob.Uri.ToString()))
            {

                BlobBaseClient srcBlobClient= new BlobBaseClient(srcUri, ClientOptions);
                Track2Models.BlobProperties srcProperties = srcBlobClient.GetProperties(cancellationToken: this.CmdletCancellationToken).Value;

                Track2Models.BlobHttpHeaders httpHeaders = new Track2Models.BlobHttpHeaders
                {
                    ContentType = srcProperties.ContentType,
                    ContentLanguage = srcProperties.ContentLanguage,
                    ContentHash = srcProperties.ContentHash,
                    ContentDisposition = srcProperties.ContentDisposition,
                    ContentEncoding = srcProperties.ContentEncoding
                };

                IDictionary<string, string> blobTags = null;

                try
                {
                    blobTags = srcBlobClient.GetTags(cancellationToken: this.CmdletCancellationToken).Value.Tags;
                }
                catch (global::Azure.RequestFailedException)
                {
                    if (!this.Force && !OutputStream.ConfirmAsync("Can't get source blob Tags, so source blob tags won't be copied to dest blob. Do you want to continue the blob copy?").Result)
                    {
                        return;
                    }
                }

                //Prepare progress handler
                string activity = String.Format("Copy Blob {0} to {1}", srcBlobClient.Name, destBlob.Name);
                string status = "Prepare to Copy Blob";
                ProgressRecord pr = new ProgressRecord(OutputStream.GetProgressId(taskId), activity, status);
                IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
                {
                    if (pr != null)
                    {
                        // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                        pr.PercentComplete = 0 == srcProperties.ContentLength ? 100 : (int)(finishedBytes * 100 / srcProperties.ContentLength);
                        pr.StatusDescription = string.Format("Percent: {0}%.", pr.PercentComplete);
                        this.OutputStream.WriteProgress(pr);
                    }
                });

                switch (destBlobType)
                {
                    case Track2Models.BlobType.Page:
                        PageBlobClient destPageBlob = (PageBlobClient)Util.GetTrack2BlobClientWithType(destBlob, destChannel.StorageContext, Track2Models.BlobType.Page, ClientOptions);

                        Track2Models.PageBlobCreateOptions pageBlobCreateOptions = new Track2Models.PageBlobCreateOptions();
                        pageBlobCreateOptions.HttpHeaders = httpHeaders;
                        pageBlobCreateOptions.Metadata = srcProperties.Metadata;
                        pageBlobCreateOptions.Tags = blobTags ?? null;

                        destPageBlob.Create(srcProperties.ContentLength, pageBlobCreateOptions, this.CmdletCancellationToken);
          
                        Track2Models.PageBlobUploadPagesFromUriOptions pageBlobUploadPagesFromUriOptions = new Track2Models.PageBlobUploadPagesFromUriOptions();
                        long pageCopyOffset = 0;
                        progressHandler.Report(pageCopyOffset);
                        long contentLenLeft = srcProperties.ContentLength;
                        while (contentLenLeft > 0)
                        {
                            long contentSize = contentLenLeft < size4MB ? contentLenLeft : size4MB;
                            destPageBlob.UploadPagesFromUri(srcUri, new global::Azure.HttpRange(pageCopyOffset, contentSize), new global::Azure.HttpRange(pageCopyOffset, contentSize), pageBlobUploadPagesFromUriOptions, this.CmdletCancellationToken);
                            pageCopyOffset += contentSize;
                            progressHandler.Report(pageCopyOffset);
                            contentLenLeft -= contentSize;
                        }
                        break;

                    case Track2Models.BlobType.Append:
                        AppendBlobClient destAppendBlob = (AppendBlobClient)Util.GetTrack2BlobClientWithType(destBlob, destChannel.StorageContext, Track2Models.BlobType.Append, ClientOptions);

                        Track2Models.AppendBlobCreateOptions appendBlobCreateOptions = new Track2Models.AppendBlobCreateOptions();
                        appendBlobCreateOptions.HttpHeaders = httpHeaders;
                        appendBlobCreateOptions.Metadata = srcProperties.Metadata;
                        appendBlobCreateOptions.Tags = blobTags ?? null;

                        destAppendBlob.Create(appendBlobCreateOptions, this.CmdletCancellationToken);

                        long appendCopyOffset = 0;
                        progressHandler.Report(appendCopyOffset);
                        long appendContentLenLeft = srcProperties.ContentLength;
                        while (appendContentLenLeft > 0)
                        {
                            long appendContentSize = appendContentLenLeft < size4MB ? appendContentLenLeft : size4MB;

                            Track2Models.AppendBlobAppendBlockFromUriOptions appendBlobAppendBlockFromUriOptions = new Track2Models.AppendBlobAppendBlockFromUriOptions
                            {
                                SourceRange = new global::Azure.HttpRange(appendCopyOffset, appendContentSize)
                            };

                            destAppendBlob.AppendBlockFromUri(srcUri, appendBlobAppendBlockFromUriOptions, this.CmdletCancellationToken);
                            appendCopyOffset += appendContentSize;
                            progressHandler.Report(appendContentSize);
                            appendContentLenLeft -= appendContentSize;
                        }
                        break;

                    default: // default: block
                        // When the source and dest blobs are both Block blobs and the size of the source blob is not larger than 256MiB, use CopyBlobFromUrl 
                        // Details can be found in https://learn.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url
                        if (srcBlobType is Track2Models.BlobType.Block && srcProperties.ContentLength <= size256MB)
                        {
                            BlobBaseClient destBlobClient = Util.GetTrack2BlobClientWithType(destBlob, destChannel.StorageContext, Track2Models.BlobType.Block, ClientOptions);
                            Track2Models.BlobCopyFromUriOptions options = new Track2Models.BlobCopyFromUriOptions();

                            // The Blob Type and Blob Tier must match, since already checked before
                            if (accesstier != null || rehydratePriority != null)
                            {
                                options.AccessTier = accesstier;
                                options.RehydratePriority = Util.ConvertRehydratePriority_Track1ToTrack2(rehydratePriority);
                            }
                            options.SourceConditions = this.BlobRequestConditions;
                            options.Metadata = srcProperties.Metadata;
                            options.Tags = blobTags ?? null;

                            destBlobClient.SyncCopyFromUri(srcUri, options, this.CmdletCancellationToken);

                            // Set rehydrate priority
                            if (rehydratePriority != null && accesstier != null)
                            {
                                destBlobClient.SetAccessTier(accesstier.Value,
                                        rehydratePriority: Util.ConvertRehydratePriority_Track1ToTrack2(rehydratePriority), cancellationToken: this.CmdletCancellationToken);
                            }
                            break;
                        }

                        BlockBlobClient destBlockBlob = (BlockBlobClient)Util.GetTrack2BlobClientWithType(destBlob, destChannel.StorageContext, Track2Models.BlobType.Block, ClientOptions);

                        Track2Models.CommitBlockListOptions commitBlockListOptions = new Track2Models.CommitBlockListOptions();
                        commitBlockListOptions.HttpHeaders = httpHeaders;
                        commitBlockListOptions.Metadata = srcProperties.Metadata;
                        commitBlockListOptions.Tags = blobTags ?? null;

                        if (accesstier != null)
                        {
                            commitBlockListOptions.AccessTier = accesstier;
                        }

                        long blockLength = GetBlockLength(srcProperties.ContentLength);
                        string[] blockIDs = GetBlockIDs(srcProperties.ContentLength, blockLength, destBlockBlob.Name);
                        long copyoffset = 0;
                        progressHandler.Report(copyoffset);
                        foreach (string id in blockIDs)
                        {
                            long blocksize = blockLength;
                            if (copyoffset + blocksize > srcProperties.ContentLength)
                            {
                                blocksize = srcProperties.ContentLength - copyoffset;
                            }
                            destBlockBlob.StageBlockFromUri(srcUri, id, new global::Azure.HttpRange(copyoffset, blocksize), null, null, null, cancellationToken: this.CmdletCancellationToken);
                            copyoffset += blocksize;
                            progressHandler.Report(copyoffset);

                        }
                        destBlockBlob.CommitBlockList(blockIDs, commitBlockListOptions, this.CmdletCancellationToken);

                        // Set rehydrate priority
                        if (rehydratePriority != null && accesstier != null)
                        {
                            destBlockBlob.SetAccessTier(accesstier.Value,
                                rehydratePriority: Util.ConvertRehydratePriority_Track1ToTrack2(rehydratePriority), cancellationToken: this.CmdletCancellationToken);
                        }
                        break;
                }

                OutputStream.WriteObject(taskId, new AzureStorageBlob(destBlob, destChannel.StorageContext, null, options: ClientOptions));
            }
        }

        private BlobBaseClient GetDestBlob(IStorageBlobManagement destChannel, string destContainerName, string destBlobName, global::Azure.Storage.Blobs.Models.BlobType? blobType)
        {
            NameUtil.ValidateContainerName(destContainerName);
            NameUtil.ValidateBlobName(destBlobName);

            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(destChannel.GetContainerReference(destContainerName), destChannel.StorageContext, ClientOptions);
            BlobBaseClient destBlob = Util.GetTrack2BlobClient(container, destBlobName, destChannel.StorageContext, null, null, null, ClientOptions, blobType);
            return destBlob;
        }
    }
}
