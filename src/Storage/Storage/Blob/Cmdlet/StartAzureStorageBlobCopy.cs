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

using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    using Adapters;
    using Azure.Commands.Common.Authentication.Abstractions;
    using Commands.Common;
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.File;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.IO;
    using System.Management.Automation;
    using System.Reflection;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using global::Azure.Storage.Blobs.Specialized;
    using global::Azure.Storage.Blobs;
    using Track2Models = global::Azure.Storage.Blobs.Models;
    using System.Collections;
    using System.Linq;

    [Cmdlet("Start", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobCopy", SupportsShouldProcess = true, DefaultParameterSetName = ContainerNameParameterSet),OutputType(typeof(AzureStorageBlob))]
    [Alias("Start-CopyAzureStorageBlob")]
    public class StartAzureStorageBlobCopy : StorageDataMovementCmdletBase, IModuleAssemblyInitializer
    {
        private const string BlobTypeMismatch = "Blob type of the blob reference doesn't match blob type of the blob.";

        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobParameterSet = "BlobInstance";

        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobToBlobParameterSet = "BlobInstanceToBlobInstance";

        /// <summary>
        /// Container pipeline paremeter set name
        /// </summary>
        private const string ContainerParameterSet = "ContainerInstance";

        /// <summary>
        /// Blob name and container name parameter set
        /// </summary>
        private const string ContainerNameParameterSet = "ContainerName";

        /// <summary>
        /// To copy from file with share name and file path to a blob represent with container name and blob name.
        /// </summary>
        private const string ShareNameParameterSet = "ShareName";

        /// <summary>
        /// To copy from file with share instance and file path to a blob represent with container name and blob name.
        /// </summary>
        private const string ShareParameterSet = "ShareInstance";

        /// <summary>
        /// To copy from file with file directory instance and file path to a blob with container name and blob name.
        /// </summary>
        private const string DirParameterSet = "DirInstance";

        /// <summary>
        /// To copy from file with file instance to a blob with container name and blob name.
        /// </summary>
        private const string FileParameterSet = "FileInstance";

        /// <summary>
        /// To copy from file with file instance to a blob with blob instance.
        /// </summary>
        private const string FileToBlobParameterSet = "FileInstanceToBlobInstance";

        /// <summary>
        /// Source uri parameter set
        /// </summary>
        private const string UriParameterSet = "UriPipeline";

        [Alias("SrcICloudBlob", "SrcCloudBlob", "ICloudBlob", "SourceICloudBlob", "SourceCloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = false,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

        [Alias("SourceCloudBlobContainer")]
        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Alias("SourceBlob")]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerParameterSet, Mandatory = true, Position = 0)]
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

        [Alias("SourceShareName")]
        [Parameter(HelpMessage = "Source share name", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcShareName { get; set; }

        [Alias("SourceShare")]
        [Parameter(HelpMessage = "Source share", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [ValidateNotNull]
        public CloudFileShare SrcShare { get; set; }

        [Alias("SourceDir")]
        [Parameter(HelpMessage = "Source file directory", Mandatory = true, ParameterSetName = DirParameterSet)]
        [ValidateNotNull]
        public CloudFileDirectory SrcDir { get; set; }

        [Alias("SourceFilePath")]
        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = DirParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcFilePath { get; set; }

        [Alias("SourceFile")]
        [Parameter(HelpMessage = "Source file", Mandatory = true, ValueFromPipeline = true, ParameterSetName = FileParameterSet)]
        [Parameter(HelpMessage = "Source file", Mandatory = true, ValueFromPipeline = true, ParameterSetName = FileToBlobParameterSet)]
        [ValidateNotNull]
        public CloudFile SrcFile { get; set; }

        [Alias("SrcUri", "SourceUri")]
        [Parameter(HelpMessage = "Source blob uri", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        [Alias("DestinationContainer")]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = DirParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = FileParameterSet)]
        public string DestContainer { get; set; }

        [Alias("DestinationBlob")]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = DirParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = FileParameterSet)]
        public string DestBlob { get; set; }

        [Alias("DestICloudBlob", "DestinationCloudBlob", "DestinationICloudBlob")]
        [Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = FileToBlobParameterSet)]
        public CloudBlob DestCloudBlob { get; set; }

        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Premium Page Blob Tier", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        public PremiumPageBlobTier PremiumPageBlobTier
        {
            get
            {
                return pageBlobTier.Value;
            }

            set
            {
                pageBlobTier = value;
            }
        }
        private PremiumPageBlobTier? pageBlobTier = null;

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

        [Parameter(HelpMessage = "Blob Tags", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag
        {
            get
            {
                return BlobTag;
            }

            set
            {
                BlobTag = value;
            }
        }
        private Hashtable BlobTag = null;

        [Alias("SrcContext", "SourceContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = DirParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = FileParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = FileToBlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ParameterSetName = UriParameterSet)]
        public override IStorageContext Context { get; set; }

        [Alias("DestinationContext")]
        [Parameter(HelpMessage = "Destination Storage context object", ValueFromPipelineByPropertyName = true, Mandatory = false)]
        public IStorageContext DestContext { get; set; }

        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Destination Blob. The blob request will fail when the destiantion blob tags not match the given tag conditions.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public virtual string DestTagCondition { get; set; }

        // Overwrite the parameter, function
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = UriParameterSet)]
        [ValidateNotNullOrEmpty]
        public override string TagCondition { get; set; }

        public override SwitchParameter AsJob { get; set; }

        protected override bool UseTrack2Sdk()
        {
            return true;
        }

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

            string target = string.Empty;
            Action copyAction = null;
            switch (ParameterSetName)
            {
                case ContainerNameParameterSet:
                    copyAction = () => StartCopyBlob(srcChannel, destChannel, SrcContainer, SrcBlob, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case UriParameterSet:
                    copyAction = () => StartCopyBlob(destChannel, AbsoluteUri, DestContainer, DestBlob, (Context != null ? GetCmdletStorageContext(Context) : null));
                    target = AbsoluteUri;
                    break;

                case BlobParameterSet:
                    if (CloudBlob is InvalidCloudBlob || UseTrack2Sdk())
                    {
                        copyAction = () => StartCopyBlob(destChannel, BlobBaseClient, DestContainer, DestBlob);
                        target = BlobBaseClient.Name;
                    }
                    else
                    {
                        copyAction = () => StartCopyBlob(destChannel, CloudBlob, DestContainer, DestBlob);
                        target = CloudBlob.Name;
                    }
                    break;

                case ContainerParameterSet:
                    copyAction = () => StartCopyBlob(srcChannel, destChannel, CloudBlobContainer.Name, SrcBlob, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case BlobToBlobParameterSet:
                    if (CloudBlob is InvalidCloudBlob || UseTrack2Sdk())
                    {
                        BlobBaseClient destBlobClient = AzureStorageBlob.GetTrack2BlobClient(DestCloudBlob, destChannel.StorageContext, ClientOptions);
                        copyAction = () => StartCopyBlob(destChannel, BlobBaseClient, destBlobClient);
                        target = BlobBaseClient.Name;
                    }
                    else
                    {
                        copyAction = () => StartCopyBlob(destChannel, CloudBlob, DestCloudBlob);
                        target = CloudBlob.Name;
                    }
                    break;
                case ShareNameParameterSet:
                    copyAction = () => StartCopyFromFile(
                        this.GetFileChannel(),
                        destChannel,
                        this.SrcShareName,
                        this.SrcFilePath,
                        this.DestContainer,
                        this.DestBlob);
                    target = SrcFilePath;
                    break;
                case ShareParameterSet:
                    copyAction = () => StartCopyFromFile(
                        destChannel,
                        this.SrcShare.GetRootDirectoryReference(),
                        this.SrcFilePath,
                        this.DestContainer,
                        this.DestBlob);
                    target = SrcFilePath;
                    break;
                case DirParameterSet:
                    copyAction = () => StartCopyFromFile(
                        destChannel,
                        this.SrcDir,
                        this.SrcFilePath,
                        this.DestContainer,
                        this.DestBlob);
                    target = SrcFilePath;
                    break;
                case FileParameterSet:
                    copyAction = () => StartCopyFromFile(
                        destChannel,
                        this.SrcFile,
                        this.DestContainer,
                        this.DestBlob);
                    target = SrcFile.Name;
                    break;
                case FileToBlobParameterSet:
                    copyAction = () => StartCopyFromFile(
                        destChannel,
                        this.SrcFile,
                        this.DestCloudBlob);
                    target = SrcFile.Name;
                    break;
            }

            if (copyAction != null && ShouldProcess(target, VerbsCommon.Copy))
            {
                copyAction();
            }
        }

        /// <summary>
        /// Start copy operation by source and destination CloudBlob object
        /// </summary>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="srcCloudBlob">Source CloudBlob object</param>
        /// <param name="destCloudBlob">Destination CloudBlob object</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, CloudBlob srcCloudBlob, CloudBlob destCloudBlob)
        {
            ValidateBlobType(srcCloudBlob);
            ValidateBlobTier(srcCloudBlob.BlobType, pageBlobTier, standardBlobTier, rehydratePriority);

            Func<long, Task> taskGenerator = (taskId) => StartCopyAsync(taskId, destChannel, srcCloudBlob, destCloudBlob);
            RunTask(taskGenerator);
        }

        private void StartCopyBlob(IStorageBlobManagement destChannel, BlobBaseClient srcCloudBlob, BlobBaseClient destCloudBlob)
        {
            global::Azure.Storage.Blobs.Models.BlobType srcBlobType = Util.GetBlobType(srcCloudBlob, true).Value;
            if (srcCloudBlob is BlobClient)
            {
                srcCloudBlob = Util.GetTrack2BlobClientWithType(srcCloudBlob, Channel.StorageContext, srcBlobType);
            }
            if (destCloudBlob is BlobClient)
            {
                destCloudBlob = Util.GetTrack2BlobClientWithType(destCloudBlob, destChannel.StorageContext, srcBlobType);
            }
            ValidateBlobTier(Util.convertBlobType_Track2ToTrack1(srcBlobType), pageBlobTier, standardBlobTier, rehydratePriority);

            Func<long, Task> taskGenerator = (taskId) => StartCopyAsync(taskId, destChannel, srcCloudBlob, destCloudBlob);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// Start copy operation by source CloudBlob object
        /// </summary>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="srcCloudBlob">Source CloudBlob object</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, CloudBlob srcCloudBlob, string destContainer, string destBlobName)
        {
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcCloudBlob.Name;
            }

            CloudBlob destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName, srcCloudBlob.BlobType);

            this.StartCopyBlob(destChannel, srcCloudBlob, destBlob);
        }

        private void StartCopyBlob(IStorageBlobManagement destChannel, BlobBaseClient srcCloudBlob, string destContainer, string destBlobName)
        {
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcCloudBlob.Name;
            }

            BlobBaseClient destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName, Util.GetBlobType(srcCloudBlob));

            this.StartCopyBlob(destChannel, srcCloudBlob, destBlob);
        }

        /// <summary>
        /// Start copy operation by source uri
        /// </summary>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="srcUri">Source uri</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <param name="context">a cloud blob object</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, string srcUri, string destContainer, string destBlobName, AzureStorageContext context)
        {
            if (context != null)
            {
                Uri sourceUri = new Uri(srcUri);
                Uri contextUri = new Uri(context.BlobEndPoint);

                if (sourceUri.Host.ToLower() == contextUri.Host.ToLower())
                {
                    CloudBlobClient blobClient = context.StorageAccount.CreateCloudBlobClient();
                    CloudBlob blobReference = null;

                    try
                    {
                        blobReference = Util.GetBlobReferenceFromServer(blobClient, sourceUri);
                    }
                    catch (InvalidOperationException)
                    {
                        blobReference = null;
                    }

                    if (null == blobReference)
                    {
                        throw new ResourceNotFoundException(String.Format(Resources.BlobUriNotFound, sourceUri.ToString()));
                    }

                    StartCopyBlob(destChannel, blobReference, destContainer, destBlobName);
                }
                else
                {
                    WriteWarning(String.Format(Resources.StartCopySourceContextMismatch, srcUri, context.BlobEndPoint));
                }
            }
            else
            {
                CloudBlobContainer container = destChannel.GetContainerReference(destContainer);
                Func<long, Task> taskGenerator = (taskId) => StartCopyAsync(taskId, destChannel, new Uri(srcUri), container, destBlobName);
                RunTask(taskGenerator);
            }
        }

        /// <summary>
        /// Start copy operation by container name and blob name
        /// </summary>
        /// <param name="SrcChannel"></param>
        /// <param name="destChannel"></param>
        /// <param name="srcContainerName">Source container name</param>
        /// <param name="srcBlobName">Source blob name</param>
        /// <param name="destContainerName">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement SrcChannel, IStorageBlobManagement destChannel, string srcContainerName, string srcBlobName, string destContainerName, string destBlobName)
        {
            NameUtil.ValidateBlobName(srcBlobName);
            NameUtil.ValidateContainerName(srcContainerName);

            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcBlobName;
            }

            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;
            CloudBlobContainer container = SrcChannel.GetContainerReference(srcContainerName);
            CloudBlob blob = GetBlobReferenceFromServerWithContainer(SrcChannel, container, srcBlobName, accessCondition, options, OperationContext);

            this.StartCopyBlob(destChannel, blob, destContainerName, destBlobName);
        }

        private void StartCopyFromFile(IStorageFileManagement srcChannel, IStorageBlobManagement destChannel, string srcShareName, string srcFilePath, string destContainerName, string destBlobName)
        {
            NamingUtil.ValidateShareName(srcShareName, false);
            CloudFileShare share = srcChannel.GetShareReference(srcShareName);

            this.StartCopyFromFile(destChannel, share.GetRootDirectoryReference(), srcFilePath, destContainerName, destBlobName);
        }

        private void StartCopyFromFile(IStorageBlobManagement destChannel, CloudFileDirectory srcDir, string srcFilePath, string destContainerName, string destBlobName)
        {
            string[] path = NamingUtil.ValidatePath(srcFilePath, true);
            CloudFile file = srcDir.GetFileReferenceByPath(path);

            this.StartCopyFromFile(destChannel, file, destContainerName, destBlobName);
        }

        private void StartCopyFromFile(IStorageBlobManagement destChannel, CloudFile srcFile, string destContainerName, string destBlobName)
        {
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcFile.GetFullPath();
            }

            CloudBlob destBlob = this.GetDestBlob(destChannel, destContainerName, destBlobName, BlobType.BlockBlob);

            this.StartCopyFromFile(destChannel, srcFile, destBlob);
        }

        private void StartCopyFromFile(IStorageBlobManagement destChannel, CloudFile srcFile, CloudBlob destBlob)
        {
            CloudBlockBlob destBlockBlob = destBlob as CloudBlockBlob;

            if (null == destBlockBlob)
            {
                throw new InvalidOperationException(Resources.OnlyCopyFromBlockBlobToAzureFile);
            }

            Func<long, Task> taskGenerator = (taskId) => this.StartCopyFromFile(taskId, destChannel, srcFile, destBlockBlob); ;
            RunTask(taskGenerator);
        }

        private async Task StartCopyFromBlob(long taskId, IStorageBlobManagement destChannel, CloudBlob srcBlob, CloudBlob destBlob)
        {
            try
            {
                Uri srcBlobUriWithCredentail = null;
                if (Channel!=null && destChannel != null && 
                    Channel.StorageContext!= null && destChannel.StorageContext != null 
                    && Channel.StorageContext.StorageAccountName == destChannel.StorageContext.StorageAccountName
                    && Channel.StorageContext.StorageAccount.Credentials.IsToken)
                {
                    // if inside same account, source blob can be anonumous
                    srcBlobUriWithCredentail = srcBlob.SnapshotQualifiedUri;
                }
                else
                {
                    srcBlobUriWithCredentail = srcBlob.GenerateUriWithCredentials();
                }
                await StartCopyFromUri(taskId, destChannel, srcBlobUriWithCredentail, destBlob).ConfigureAwait(false);
            }
            catch (StorageException ex)
            {
                if (0 == string.Compare(ex.Message, BlobTypeMismatch, StringComparison.OrdinalIgnoreCase))
                {
                    // Current use error message to decide whether it caused by blob type mismatch,
                    // We should ask xscl to expose an error code for this..
                    // Opened workitem 1487579 to track this.
                    throw new InvalidOperationException(Resources.DestinationBlobTypeNotMatch);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task StartCopyFromBlob(long taskId, IStorageBlobManagement destChannel, BlobBaseClient srcBlob, BlobBaseClient destBlob)
        {
            try
            {
                Uri srcBlobUriWithCredentail = null;
                if (Channel != null && destChannel != null &&
                    Channel.StorageContext != null && destChannel.StorageContext != null
                    && Channel.StorageContext.StorageAccountName == destChannel.StorageContext.StorageAccountName
                    && Channel.StorageContext.StorageAccount.Credentials.IsToken)
                {
                    // if inside same account, source blob can be anonumous
                    srcBlobUriWithCredentail = srcBlob.Uri;
                }
                else
                {
                    srcBlobUriWithCredentail = srcBlob.GenerateUriWithCredentials(Channel.StorageContext);
                }
                await StartCopyFromUri(taskId, destChannel, srcBlobUriWithCredentail, destBlob).ConfigureAwait(false);
            }
            catch (StorageException ex)
            {
                if (0 == string.Compare(ex.Message, BlobTypeMismatch, StringComparison.OrdinalIgnoreCase))
                {
                    // Current use error message to decide whether it caused by blob type mismatch,
                    // We should ask xscl to expose an error code for this..
                    // Opened workitem 1487579 to track this.
                    throw new InvalidOperationException(Resources.DestinationBlobTypeNotMatch);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task StartCopyFromUri(long taskId, IStorageBlobManagement destChannel, Uri srcUri, CloudBlob destBlob)
        {
            if (UseTrack2Sdk())
            {
                BlobClient destBlobClient = AzureStorageBlob.GetTrack2BlobClient(destBlob, destChannel.StorageContext, this.ClientOptions);
                await StartCopyFromUri(taskId, destChannel, srcUri, destBlobClient).ConfigureAwait(false);
                return;
            }
            else // use track1 SDK
            {
                bool destExist = true;
                try
                {
                    await destBlob.FetchAttributesAsync(null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                }
                catch (StorageException ex)
                {
                    if (ex.IsNotFoundException())
                    {
                        destExist = false;
                    }
                    else
                    {
                        throw;
                    }
                }

                ValidateBlobTier(destBlob.BlobType, pageBlobTier, standardBlobTier, rehydratePriority);

                if (!destExist || this.ConfirmOverwrite(srcUri.AbsoluteUri.ToString(), destBlob.Uri.ToString()))
                {
                    string copyId;

                    //Clean the Metadata of the destination Blob object, or the source metadata won't overwirte the dest blob metadata. See https://docs.microsoft.com/en-us/rest/api/storageservices/copy-blob
                    destBlob.Metadata.Clear();

                    // The Blob Type and Blob Tier must match, since already checked they are match at the begin of ExecuteCmdlet().
                    if (pageBlobTier != null)
                    {
                        copyId = await destChannel.StartCopyAsync((CloudPageBlob)destBlob, srcUri, pageBlobTier.Value, null, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                    }
                    else if (standardBlobTier != null || rehydratePriority != null)
                    {
                        copyId = await destChannel.StartCopyAsync(destBlob, srcUri, standardBlobTier, rehydratePriority, null, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        copyId = await destChannel.StartCopyAsync(destBlob, srcUri, null, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                    }

                    this.OutputStream.WriteVerbose(taskId, String.Format(Resources.CopyDestinationBlobPending, destBlob.Name, destBlob.Container.Name, copyId));
                    this.WriteCloudBlobObject(taskId, destChannel, destBlob);
                }
            }
        }

        private async Task StartCopyFromUri(long taskId, IStorageBlobManagement destChannel, Uri srcUri, BlobBaseClient destBlob)
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
                ValidateBlobTier(Util.convertBlobType_Track2ToTrack1(destBlobType), pageBlobTier, standardBlobTier, rehydratePriority);
            }

            if (!destExist || this.ConfirmOverwrite(srcUri.AbsoluteUri.ToString(), destBlob.Uri.ToString()))
            {
                Track2Models.BlobCopyFromUriOptions options = new global::Azure.Storage.Blobs.Models.BlobCopyFromUriOptions();

                // The Blob Type and Blob Tier must match, since already checked they are match at the begin of ExecuteCmdlet().
                if (pageBlobTier != null)
                {
                    options.AccessTier = Util.ConvertAccessTier_Track1ToTrack2(pageBlobTier);
                }
                else if (standardBlobTier != null || rehydratePriority != null)
                {
                    options.AccessTier = Util.ConvertAccessTier_Track1ToTrack2(standardBlobTier);
                    options.RehydratePriority = Util.ConvertRehydratePriority_Track1ToTrack2(rehydratePriority);
                }
                if (this.BlobTag != null)
                {
                    options.Tags = this.BlobTag.Cast<DictionaryEntry>().ToDictionary(d => (string)d.Key, d => (string)d.Value);
                }
                options.SourceConditions = this.BlobRequestConditions;
                if (this.DestTagCondition != null)
                {
                    options.DestinationConditions = new Track2Models.BlobRequestConditions();
                    options.DestinationConditions.TagConditions = DestTagCondition;
                }
                Track2Models.CopyFromUriOperation copyId = await destBlob.StartCopyFromUriAsync(srcUri, options, this.CmdletCancellationToken).ConfigureAwait(false);

                this.OutputStream.WriteVerbose(taskId, String.Format(Resources.CopyDestinationBlobPending, destBlob.Name, destBlob.BlobContainerName, copyId));
                OutputStream.WriteObject(taskId, new AzureStorageBlob(destBlob, destChannel.StorageContext, properties, options: ClientOptions));
            }
        }

        private async Task StartCopyFromFile(long taskId, IStorageBlobManagement destChannel, CloudFile srcFile, CloudBlockBlob destBlob)
        {
            await this.StartCopyFromUri(taskId, destChannel, srcFile.GenerateUriWithCredentials(), destBlob).ConfigureAwait(false);
        }

        private CloudBlob GetDestBlob(IStorageBlobManagement destChannel, string destContainerName, string destBlobName, BlobType blobType)
        {
            NameUtil.ValidateContainerName(destContainerName);
            NameUtil.ValidateBlobName(destBlobName);

            CloudBlobContainer container = destChannel.GetContainerReference(destContainerName);
            CloudBlob destBlob = null;
            if (BlobType.PageBlob == blobType)
            {
                destBlob = container.GetPageBlobReference(destBlobName);
            }
            else if (BlobType.BlockBlob == blobType)
            {
                destBlob = container.GetBlockBlobReference(destBlobName);
            }
            else if (BlobType.AppendBlob == blobType)
            {
                destBlob = container.GetAppendBlobReference(destBlobName);
            }
            else
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobType, blobType, destBlobName));
            }

            return destBlob;
        }

        private BlobBaseClient GetDestBlob(IStorageBlobManagement destChannel, string destContainerName, string destBlobName, global::Azure.Storage.Blobs.Models.BlobType? blobType)
        {
            NameUtil.ValidateContainerName(destContainerName);
            NameUtil.ValidateBlobName(destBlobName);

            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(destChannel.GetContainerReference(destContainerName), destChannel.StorageContext, ClientOptions);
            BlobBaseClient destBlob = Util.GetTrack2BlobClient(container, destBlobName, destChannel.StorageContext, null, null, null, ClientOptions, blobType is null ? global::Azure.Storage.Blobs.Models.BlobType.Block : blobType.Value);
            return destBlob;
        }

        /// <summary>
        /// Start copy using transfer mangager by source CloudBlob object
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="sourceBlob">Source CloudBlob object</param>
        /// <param name="destBlob">Destination CloudBlob object</param>
        /// <returns>Destination CloudBlob object</returns>
        private async Task StartCopyAsync(long taskId, IStorageBlobManagement destChannel, CloudBlob sourceBlob, CloudBlob destBlob)
        {
            NameUtil.ValidateBlobName(sourceBlob.Name);
            NameUtil.ValidateContainerName(destBlob.Container.Name);
            NameUtil.ValidateBlobName(destBlob.Name);

            await this.StartCopyFromBlob(taskId, destChannel, sourceBlob, destBlob).ConfigureAwait(false);
        }

        private async Task StartCopyAsync(long taskId, IStorageBlobManagement destChannel, BlobBaseClient sourceBlob, BlobBaseClient destBlob)
        {
            NameUtil.ValidateBlobName(sourceBlob.Name);
            NameUtil.ValidateContainerName(destBlob.BlobContainerName);
            NameUtil.ValidateBlobName(destBlob.Name);

            await this.StartCopyFromBlob(taskId, destChannel, sourceBlob, destBlob).ConfigureAwait(false);
        }

        /// <summary>
        /// Start copy using transfer mangager by source uri
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="uri">source uri</param>
        /// <param name="destContainer">Destination CloudBlobContainer object</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private async Task StartCopyAsync(long taskId, IStorageBlobManagement destChannel, Uri uri, CloudBlobContainer destContainer, string destBlobName)
        {
            NameUtil.ValidateContainerName(destContainer.Name);
            NameUtil.ValidateBlobName(destBlobName);

            CloudBlob sourceBlob = new CloudBlob(uri);
            BlobType destBlobType = BlobType.BlockBlob;
            try
            {
                await sourceBlob.FetchAttributesAsync(null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);

                //When the source Uri is a file Uri, will get BlobType.Unspecified, and should use block blob in destination
                if (sourceBlob.BlobType != BlobType.Unspecified)
                    destBlobType = sourceBlob.BlobType;
            }
            catch (StorageException)
            {
                //use block blob by default
                destBlobType = BlobType.BlockBlob;
            }
            CloudBlob destBlob = GetDestBlob(destChannel, destContainer.Name, destBlobName, destBlobType);

            await this.StartCopyFromUri(taskId, destChannel, uri, destBlob);
        }

        /// <summary>
        /// Get DestinationBlob with specified copy id
        /// </summary>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private CloudBlob GetDestinationBlobWithCopyId(IStorageBlobManagement destChannel, CloudBlobContainer container, string blobName)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;
            CloudBlob blob = destChannel.GetBlobReferenceFromServer(container, blobName, accessCondition, options, OperationContext);
            return blob;
        }

        public void OnImport()
        {
            try
            {
                PowerShell invoker = null;
                invoker = PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "AzureStorageStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // Ignore exception.
            }
        }

    }
}
