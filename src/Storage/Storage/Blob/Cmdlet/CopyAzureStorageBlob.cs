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


namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Azure.Commands.Common.Authentication.Abstractions;
    using Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
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

        [Parameter(HelpMessage = "Block Blob Tier, valid values are Hot/Cool/Archive. See detail in https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blob-storage-tiers", Mandatory = false)]
        [PSArgumentCompleter("Hot", "Cool", "Archive")]
        [ValidateSet("Hot", "Cool", "Archive", IgnoreCase = true)]
        public string StandardBlobTier
        {
            get
            {
                return standardBlobTier is null ? null : standardBlobTier.Value.ToString();
            }

            set
            {
                if (value != null)
                {
                    standardBlobTier = ((StandardBlobTier)Enum.Parse(typeof(StandardBlobTier), value, true));
                }
                else
                {
                    standardBlobTier = null;
                }
            }
        }
        private StandardBlobTier? standardBlobTier = null;

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
            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainerName, destBlobName, Util.GetBlobType(srcBlobBaseClient));

            this.CopyBlobSync(destChannel, srcBlobBaseClient, destBlob);
        }

        private void CopyBlobSync(IStorageBlobManagement destChannel, BlobBaseClient srcCloudBlob, BlobBaseClient destCloudBlob)
        {
            Track2Models.BlobType srcBlobType = Util.GetBlobType(srcCloudBlob, true).Value;
            if (srcBlobType != Track2Models.BlobType.Block)
            {
                throw new ArgumentException(string.Format("The cmdlet currently only support souce blob and destination blob are both block blob. The source blob type is {0}.", srcBlobType));
            }

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
            if (srcBlobType != Track2Models.BlobType.Block)
            {
                throw new ArgumentException(string.Format("The cmdlet currently only support souce blob and destination blob are both block blob. The source blob type is {0}.", srcBlobType));
            }

            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName, srcBlobType);
            Func<long, Task> taskGenerator = (taskId) => CopyFromUri(taskId, destChannel, new Uri(srcUri), destBlob);
            RunTask(taskGenerator);
        }

        private async Task CopyFromUri(long taskId, IStorageBlobManagement destChannel, Uri srcUri, BlobBaseClient destBlob)
        {
            bool destExist = true;
            Track2Models.BlobType? destBlobType = Util.GetBlobType(destBlob);
            Track2Models.BlobProperties properties = null;

            try
            {
                properties = (await destBlob.GetPropertiesAsync(this.BlobRequestConditions, cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false)).Value;
                destBlobType = properties.BlobType;
            }
            catch (global::Azure.RequestFailedException e) when (e.Status == 404)
            {
                destExist = false;
            }
            if (destBlobType != null)
            {
                ValidateBlobTier(Util.convertBlobType_Track2ToTrack1(destBlobType), null, standardBlobTier, rehydratePriority);
            }

            if (!destExist || this.ConfirmOverwrite(srcUri.AbsoluteUri.ToString(), destBlob.Uri.ToString()))
            {
                Track2Models.BlobCopyFromUriOptions options = new Track2Models.BlobCopyFromUriOptions();

                // The Blob Type and Blob Tier must match, since already checked before
                if (standardBlobTier != null || rehydratePriority != null)
                {
                    options.AccessTier = Util.ConvertAccessTier_Track1ToTrack2(standardBlobTier);
                    options.RehydratePriority = Util.ConvertRehydratePriority_Track1ToTrack2(rehydratePriority);
                }
                options.SourceConditions = this.BlobRequestConditions;

                BlockBlobClient srcBlockblob = new BlockBlobClient(srcUri, ClientOptions);
                Track2Models.BlobProperties srcProperties = srcBlockblob.GetProperties(cancellationToken: this.CmdletCancellationToken).Value;

                //Prepare progress handler
                string activity = String.Format("Copy Blob {0} to {1}", srcBlockblob.Name, destBlob.Name);
                string status = "Prepare to Copy Blob";
                ProgressRecord pr = new ProgressRecord(OutputStream.GetProgressId(taskId), activity, status);
                IProgress<long> progressHandler = new Progress<long>((finishedBytes) =>
                {
                    if (pr != null)
                    {
                        // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                        pr.PercentComplete = 0 == srcProperties.ContentLength ? 100 : (int)(finishedBytes * 100 / srcProperties.ContentLength);
                        pr.StatusDescription = string.Format("Percent: {0}%.", pr.PercentComplete);
                        Console.WriteLine(finishedBytes);
                        this.OutputStream.WriteProgress(pr);
                    }
                });

                switch (destBlobType)
                {
                    case Track2Models.BlobType.Block:

                        BlockBlobClient destBlockBlob = (BlockBlobClient)Util.GetTrack2BlobClientWithType(destBlob, Channel.StorageContext, Track2Models.BlobType.Block, ClientOptions);

                        Track2Models.CommitBlockListOptions commitBlockListOptions = new Track2Models.CommitBlockListOptions();
                        commitBlockListOptions.HttpHeaders = new Track2Models.BlobHttpHeaders();
                        commitBlockListOptions.HttpHeaders.ContentType = srcProperties.ContentType;
                        commitBlockListOptions.HttpHeaders.ContentHash = srcProperties.ContentHash;
                        commitBlockListOptions.HttpHeaders.ContentEncoding = srcProperties.ContentEncoding;
                        commitBlockListOptions.HttpHeaders.ContentLanguage = srcProperties.ContentLanguage;
                        commitBlockListOptions.HttpHeaders.ContentDisposition = srcProperties.ContentDisposition;
                        commitBlockListOptions.Metadata = srcProperties.Metadata;
                        try
                        {
                            commitBlockListOptions.Tags = srcBlockblob.GetTags(cancellationToken: this.CmdletCancellationToken).Value.Tags;
                        }
                        catch (global::Azure.RequestFailedException e) when (e.Status == 403 || e.Status == 404 || e.Status == 401)
                        {
                            if (!this.Force && !OutputStream.ConfirmAsync("Can't get source blob Tags, so source blob tags won't be copied to dest blob. Do you want to continue the blob copy?").Result)
                            {
                                return;
                            }
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
                            destBlockBlob.StageBlockFromUri(srcUri, id, new global::Azure.HttpRange(copyoffset, blocksize), cancellationToken: this.CmdletCancellationToken);
                            copyoffset += blocksize;
                            progressHandler.Report(copyoffset);

                        }
                        destBlockBlob.CommitBlockList(blockIDs, commitBlockListOptions, this.CmdletCancellationToken);

                        break;
                    case Track2Models.BlobType.Page:
                    case Track2Models.BlobType.Append:
                    default:
                        throw new ArgumentException(string.Format("The cmdlet currently only support souce blob and destination blob are both block blob. The dest blob type is {0}.", destBlobType));
                }

                OutputStream.WriteObject(taskId, new AzureStorageBlob(destBlob, destChannel.StorageContext, null, options: ClientOptions));
            }
        }

        private BlobBaseClient GetDestBlob(IStorageBlobManagement destChannel, string destContainerName, string destBlobName, global::Azure.Storage.Blobs.Models.BlobType? blobType)
        {
            NameUtil.ValidateContainerName(destContainerName);
            NameUtil.ValidateBlobName(destBlobName);

            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(destChannel.GetContainerReference(destContainerName), destChannel.StorageContext, ClientOptions);
            BlobBaseClient destBlob = Util.GetTrack2BlobClient(container, destBlobName, destChannel.StorageContext, null, null, null, ClientOptions, blobType is null ? global::Azure.Storage.Blobs.Models.BlobType.Block : blobType.Value);
            return destBlob;
        }
    }
}
