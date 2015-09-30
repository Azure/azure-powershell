﻿﻿// ----------------------------------------------------------------------------------
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
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.File;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.DataMovement;
    using Microsoft.WindowsAzure.Storage.File;

    [Cmdlet(VerbsLifecycle.Start, StorageNouns.CopyBlob, ConfirmImpact = ConfirmImpact.High, DefaultParameterSetName = ContainerNameParameterSet),
       OutputType(typeof(AzureStorageBlob))]
    public class StartAzureStorageBlobCopy : StorageDataMovementCmdletBase
    {
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

        [Alias("SrcICloudBlob", "SrcCloudBlob", "ICloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerParameterSet, Mandatory = true, Position = 0)]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerNameParameterSet, Mandatory = true, Position = 0)]
        public string SrcBlob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(HelpMessage = "Source Container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcContainer
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(HelpMessage = "Source share name", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcShareName { get; set; }

        [Parameter(HelpMessage = "Source share", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [ValidateNotNull]
        public CloudFileShare SrcShare { get; set; }

        [Parameter(HelpMessage = "Source file directory", Mandatory = true, ParameterSetName = DirParameterSet)]
        [ValidateNotNull]
        public CloudFileDirectory SrcDir { get; set; }

        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Source file path", Mandatory = true, ParameterSetName = DirParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcFilePath { get; set; }

        [Parameter(HelpMessage = "Source file", Mandatory = true, ValueFromPipeline = true, ParameterSetName = FileParameterSet)]
        [Parameter(HelpMessage = "Source file", Mandatory = true, ValueFromPipeline = true, ParameterSetName = FileToBlobParameterSet)]
        [ValidateNotNull]
        public CloudFile SrcFile { get; set; }

        [Alias("SrcUri")]
        [Parameter(HelpMessage = "Source blob uri", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = DirParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = FileParameterSet)]
        public string DestContainer { get; set; }

        [Parameter(HelpMessage = "Destination blob name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ShareNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ShareParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = DirParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = FileParameterSet)]
        public string DestBlob { get; set; }

        [Alias("DestICloudBlob")]
        [Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = FileToBlobParameterSet)]
        public CloudBlob DestCloudBlob { get; set; }

        [Alias("SrcContext")]
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
        public override AzureStorageContext Context { get; set; }

        [Parameter(HelpMessage = "Destination Storage context object", Mandatory = false)]
        public AzureStorageContext DestContext { get; set; }

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

        protected async Task EnqueueStartCopyJob(TransferJob startCopyJob, DataMovementUserData userData)
        {
            await this.RunTransferJob(startCopyJob, userData);

            this.OutputStream.WriteVerbose(userData.TaskId, startCopyJob.CopyId);
            Dictionary<string, string> destBlobPath = userData.Data as Dictionary<string, string>;

            if (destBlobPath != null)
            {
                var destChannel = userData.Channel;
                this.OutputStream.WriteVerbose(userData.TaskId, String.Format(Resources.CopyDestinationBlobPending, destBlobPath["Blob"], destBlobPath["Container"], startCopyJob.CopyId));
                CloudBlobContainer container = destChannel.GetContainerReference(destBlobPath["Container"]);
                CloudBlob destBlob = this.GetDestinationBlobWithCopyId(destChannel, container, destBlobPath["Blob"]);
                if (destBlob != null)
                {
                    this.WriteCloudBlobObject(userData.TaskId, destChannel, destBlob);
                }
            }
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
                    destChannel = CreateChannel(DestContext);
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

            switch (ParameterSetName)
            {
                case ContainerNameParameterSet:
                    StartCopyBlob(srcChannel, destChannel, SrcContainer, SrcBlob, DestContainer, DestBlob);
                    break;

                case UriParameterSet:
                    StartCopyBlob(destChannel, AbsoluteUri, DestContainer, DestBlob, Context);
                    break;

                case BlobParameterSet:
                    StartCopyBlob(destChannel, CloudBlob, DestContainer, DestBlob);
                    break;

                case ContainerParameterSet:
                    StartCopyBlob(srcChannel, destChannel, CloudBlobContainer.Name, SrcBlob, DestContainer, DestBlob);
                    break;

                case BlobToBlobParameterSet:
                    StartCopyBlob(destChannel, CloudBlob, DestCloudBlob);
                    break;
                case ShareNameParameterSet:
                    this.StartCopyFromFile(
                        this.GetFileChannel(),
                        destChannel,
                        this.SrcShareName,
                        this.SrcFilePath,
                        this.DestContainer,
                        this.DestBlob);
                    break;
                case ShareParameterSet:
                    this.StartCopyFromFile(
                        destChannel,
                        this.SrcShare.GetRootDirectoryReference(),
                        this.SrcFilePath,
                        this.DestContainer,
                        this.DestBlob);
                    break;
                case DirParameterSet:
                    StartCopyFromFile(
                        destChannel,
                        this.SrcDir,
                        this.SrcFilePath,
                        this.DestContainer,
                        this.DestBlob);
                    break;
                case FileParameterSet:
                    StartCopyFromFile(
                        destChannel,
                        this.SrcFile,
                        this.DestContainer,
                        this.DestBlob);
                    break;
                case FileToBlobParameterSet:
                    StartCopyFromFile(
                        destChannel,
                        this.SrcFile,
                        this.DestCloudBlob);
                    break;
            }
        }

        /// <summary>
        /// Start copy operation by source and destination CloudBlob object
        /// </summary>
        /// <param name="srcCloudBlob">Source CloudBlob object</param>
        /// <param name="destCloudBlob">Destination CloudBlob object</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, CloudBlob srcCloudBlob, CloudBlob destCloudBlob)
        {
            ValidateBlobType(srcCloudBlob);

            Func<long, Task> taskGenerator = (taskId) => StartCopyInTransferManager(taskId, destChannel, srcCloudBlob, destCloudBlob);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// Start copy operation by source CloudBlob object
        /// </summary>
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

        /// <summary>
        /// Start copy operation by source uri
        /// </summary>
        /// <param name="srcCloudBlob">Source uri</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
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
                Func<long, Task> taskGenerator = (taskId) => StartCopyInTransferManager(taskId, destChannel, new Uri(srcUri), container, destBlobName);
                RunTask(taskGenerator);
            }
        }

        /// <summary>
        /// Start copy operation by container name and blob name
        /// </summary>
        /// <param name="srcContainerName">Source container name</param>
        /// <param name="srcBlobName">Source blob name</param>
        /// <param name="destContainer">Destinaion container name</param>
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

        private async Task StartCopyFromFile(long taskId, IStorageBlobManagement destChannel, CloudFile srcFile, CloudBlockBlob destBlob)
        {
            bool destExist = true;
            try
            {
                await destBlob.FetchAttributesAsync(null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
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

            if (!destExist || this.ConfirmOverwrite(srcFile.Uri.ToString(), destBlob.Uri.ToString()))
            {
                string copyId = await destBlob.StartCopyAsync(srcFile.GenerateCopySourceFile(), null, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
                this.OutputStream.WriteVerbose(taskId, String.Format(Resources.CopyDestinationBlobPending, destBlob.Name, destBlob.Container.Name, copyId));
                this.WriteCloudBlobObject(taskId, destChannel, destBlob);
            }
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

        /// <summary>
        /// Start copy using transfer mangager by source CloudBlob object
        /// </summary>
        /// <param name="blob">Source CloudBlob object</param>
        /// <param name="destContainer">Destination CloudBlobContainer object</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private async Task StartCopyInTransferManager(long taskId, IStorageBlobManagement DestChannel, CloudBlob sourceBlob, CloudBlob destBlob)
        {
            NameUtil.ValidateBlobName(sourceBlob.Name);
            NameUtil.ValidateContainerName(destBlob.Container.Name);
            NameUtil.ValidateBlobName(destBlob.Name);

            Dictionary<string, string> BlobPath = new Dictionary<string, string>()
            {
                {"Container", destBlob.Container.Name},
                {"Blob", destBlob.Name}
            };

            DataMovementUserData data = new DataMovementUserData()
            {
                Data = BlobPath,
                TaskId = taskId,
                Channel = DestChannel,
                Record = null
            };

            TransferJob startCopyJob = new TransferJob(new TransferLocation(sourceBlob), new TransferLocation(destBlob), TransferMethod.AsyncCopyInAzureStorageWithoutMonitor);

            await this.EnqueueStartCopyJob(startCopyJob, data);
        }

        /// <summary>
        /// Start copy using transfer mangager by source uri
        /// </summary>
        /// <param name="uri">source uri</param>
        /// <param name="destContainer">Destination CloudBlobContainer object</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private async Task StartCopyInTransferManager(long taskId, IStorageBlobManagement destChannel, Uri uri, CloudBlobContainer destContainer, string destBlobName)
        {
            NameUtil.ValidateContainerName(destContainer.Name);
            NameUtil.ValidateBlobName(destBlobName);
            Dictionary<string, string> BlobPath = new Dictionary<string, string>()
            {
                {"Container", destContainer.Name},
                {"Blob", destBlobName}
            };

            DataMovementUserData data = new DataMovementUserData()
            {
                Data = BlobPath,
                TaskId = taskId,
                Channel = destChannel,
                Record = null
            };

            TransferJob startCopyJob = new TransferJob(
                new TransferLocation(uri), 
                new TransferLocation(destContainer.GetBlockBlobReference(destBlobName)),
                TransferMethod.AsyncCopyInAzureStorageWithoutMonitor);

            await this.EnqueueStartCopyJob(startCopyJob, data);
        }

        /// <summary>
        /// Get DestinationBlob with specified copy id
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="copyId">Current CopyId</param>
        /// <returns>Destination CloudBlob object</returns>
        private CloudBlob GetDestinationBlobWithCopyId(IStorageBlobManagement destChannel, CloudBlobContainer container, string blobName)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;
            CloudBlob blob = destChannel.GetBlobReferenceFromServer(container, blobName, accessCondition, options, OperationContext);
            return blob;
        }
    }
}
