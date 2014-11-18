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
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.DataMovement.TransferJobs;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Start, StorageNouns.CopyBlob, ConfirmImpact = ConfirmImpact.High, DefaultParameterSetName = NameParameterSet),
       OutputType(typeof(AzureStorageBlob))]
    public class StartAzureStorageBlobCopy : StorageDataMovementCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string SrcBlobParameterSet = "BlobPipeline";

        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string DestBlobPipelineParameterSet = "DestBlobPipeline";

        /// <summary>
        /// Container pipeline paremeter set name
        /// </summary>
        private const string ContainerPipelineParameterSet = "ContainerPipeline";

        /// <summary>
        /// Blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        /// <summary>
        /// Source uri parameter set
        /// </summary>
        private const string UriParameterSet = "UriPipeline";

        [Alias("SrcICloudBlob")]
        [Parameter(HelpMessage = "ICloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = SrcBlobParameterSet)]
        [Parameter(HelpMessage = "ICloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = DestBlobPipelineParameterSet)]
        public ICloudBlob ICloudBlob { get; set; }

        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParameterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(ParameterSetName = ContainerPipelineParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        public string SrcBlob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(HelpMessage = "Source Container name", Mandatory = true,
            ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SrcContainer
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Alias("SrcUri")]
        [Parameter(HelpMessage = "Source blob uri", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        [Parameter(HelpMessage = "Destination container name", Mandatory = true,
            ParameterSetName = NameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true,
            ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true,
            ParameterSetName = SrcBlobParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true,
            ParameterSetName = ContainerPipelineParameterSet)]
        public string DestContainer { get; set; }

        [Parameter(HelpMessage = "Destination blob name", Mandatory = true,
            ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false,
            ParameterSetName = NameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false,
            ParameterSetName = SrcBlobParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = false,
            ParameterSetName = ContainerPipelineParameterSet)]
        public string DestBlob { get; set; }

        [Parameter(HelpMessage = "Destination ICloudBlob object", Mandatory = true,
            ParameterSetName = DestBlobPipelineParameterSet)]
        public ICloudBlob DestICloudBlob { get; set; }

        [Alias("SrcContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            ValueFromPipelineByPropertyName = true, ParameterSetName = NameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            ValueFromPipelineByPropertyName = true, ParameterSetName = SrcBlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            ValueFromPipelineByPropertyName = true, ParameterSetName = DestBlobPipelineParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object",
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParameterSet)]
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

        protected async Task EnqueueStartCopyJob(BlobStartCopyJob startCopyJob, DataMovementUserData userData)
        {
            await this.RunTransferJob(startCopyJob, userData);

            this.OutputStream.WriteVerbose(userData.TaskId, startCopyJob.CopyId);
            Dictionary<string, string> destBlobPath = userData.Data as Dictionary<string, string>;

            if (destBlobPath != null)
            {
                var destChannel = userData.Channel;
                this.OutputStream.WriteVerbose(userData.TaskId, String.Format(Resources.CopyDestinationBlobPending, destBlobPath["Blob"], destBlobPath["Container"], startCopyJob.CopyId));
                CloudBlobContainer container = destChannel.GetContainerReference(destBlobPath["Container"]);
                ICloudBlob destBlob = this.GetDestinationBlobWithCopyId(destChannel, container, destBlobPath["Blob"]);
                if (destBlob != null)
                {
                    this.WriteICloudBlobObject(userData.TaskId, destChannel, destBlob);
                }
            }
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
                case NameParameterSet:
                    StartCopyBlob(srcChannel, destChannel, SrcContainer, SrcBlob, DestContainer, DestBlob);
                    break;

                case UriParameterSet:
                    StartCopyBlob(destChannel, AbsoluteUri, DestContainer, DestBlob, Context);
                    break;

                case SrcBlobParameterSet:
                    StartCopyBlob(destChannel, ICloudBlob, DestContainer, DestBlob);
                    break;

                case ContainerPipelineParameterSet:
                    StartCopyBlob(srcChannel, destChannel, CloudBlobContainer.Name, SrcBlob, DestContainer, DestBlob);
                    break;

                case DestBlobPipelineParameterSet:
                    StartCopyBlob(destChannel, ICloudBlob, DestICloudBlob);
                    break;
            }
        }

        /// <summary>
        /// Start copy operation by source and destination ICloudBlob object
        /// </summary>
        /// <param name="srcICloudBlob">Source ICloudBlob object</param>
        /// <param name="destICloudBlob">Destination ICloudBlob object</param>
        /// <returns>Destination ICloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, ICloudBlob srcICloudBlob, ICloudBlob destICloudBlob)
        {
            Func<long, Task> taskGenerator = (taskId) => StartCopyInTransferManager(taskId, destChannel, srcICloudBlob, destICloudBlob);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// Start copy operation by source ICloudBlob object
        /// </summary>
        /// <param name="srcICloudBlob">Source ICloudBlob object</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination ICloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, ICloudBlob srcICloudBlob, string destContainer, string destBlobName)
        {
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcICloudBlob.Name;
            }

            ValidateBlobName(destBlobName);

            CloudBlobContainer container = destChannel.GetContainerReference(destContainer);
            ICloudBlob destBlob = null;
            if (BlobType.PageBlob == srcICloudBlob.BlobType)
            {
                destBlob = container.GetPageBlobReference(destBlobName);
            }
            else if (BlobType.BlockBlob == srcICloudBlob.BlobType)
            {
                destBlob = container.GetBlockBlobReference(destBlobName);
            }
            else
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobType, srcICloudBlob.Name));
            }

            this.StartCopyBlob(destChannel, srcICloudBlob, destBlob);
        }

        /// <summary>
        /// Start copy operation by source uri
        /// </summary>
        /// <param name="srcICloudBlob">Source uri</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination ICloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, string srcUri, string destContainer, string destBlobName, AzureStorageContext context)
        {
            if (context != null)
            {
                Uri sourceUri = new Uri(srcUri);
                Uri contextUri = new Uri(context.BlobEndPoint);

                if (sourceUri.Host.ToLower() == contextUri.Host.ToLower())
                {
                    CloudBlobClient blobClient = context.StorageAccount.CreateCloudBlobClient();
                    ICloudBlob blobReference = blobClient.GetBlobReferenceFromServer(sourceUri);
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
        /// <returns>Destination ICloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement SrcChannel, IStorageBlobManagement destChannel, string srcContainerName, string srcBlobName, string destContainerName, string destBlobName)
        {
            ValidateBlobName(srcBlobName);
            ValidateContainerName(srcContainerName);
            ValidateContainerName(destContainerName);

            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcBlobName;
            }

            ValidateBlobName(destBlobName);

            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;
            CloudBlobContainer container = SrcChannel.GetContainerReference(srcContainerName);
            ICloudBlob blob = SrcChannel.GetBlobReferenceFromServer(container, srcBlobName, accessCondition, options, OperationContext);

            if (blob == null)
            {
                throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, srcBlobName, srcContainerName));
            }

            this.StartCopyBlob(destChannel, blob, destContainerName, destBlobName);
        }

        /// <summary>
        /// Start copy using transfer mangager by source ICloudBlob object
        /// </summary>
        /// <param name="blob">Source ICloudBlob object</param>
        /// <param name="destContainer">Destination CloudBlobContainer object</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination ICloudBlob object</returns>
        private async Task StartCopyInTransferManager(long taskId, IStorageBlobManagement DestChannel, ICloudBlob sourceBlob, ICloudBlob destBlob)
        {
            ValidateBlobName(sourceBlob.Name);
            ValidateContainerName(destBlob.Container.Name);
            ValidateBlobName(destBlob.Name);

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

            BlobStartCopyJob startCopyJob = new BlobStartCopyJob()
            {
                SourceBlob = sourceBlob,
                DestBlob = destBlob
            };

            await this.EnqueueStartCopyJob(startCopyJob, data);
        }

        /// <summary>
        /// Start copy using transfer mangager by source uri
        /// </summary>
        /// <param name="uri">source uri</param>
        /// <param name="destContainer">Destination CloudBlobContainer object</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination ICloudBlob object</returns>
        private async Task StartCopyInTransferManager(long taskId, IStorageBlobManagement destChannel, Uri uri, CloudBlobContainer destContainer, string destBlobName)
        {
            ValidateContainerName(destContainer.Name);
            ValidateBlobName(destBlobName);
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

            BlobStartCopyJob startCopyJob = new BlobStartCopyJob()
            {
                SourceUri = uri,
                DestBlob = destContainer.GetBlockBlobReference(destBlobName)
            };

            await this.EnqueueStartCopyJob(startCopyJob, data);
        }

        /// <summary>
        /// Get DestinationBlob with specified copy id
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <param name="copyId">Current CopyId</param>
        /// <returns>Destination ICloudBlob object</returns>
        private ICloudBlob GetDestinationBlobWithCopyId(IStorageBlobManagement destChannel, CloudBlobContainer container, string blobName)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;
            ICloudBlob blob = destChannel.GetBlobReferenceFromServer(container, blobName, accessCondition, options, OperationContext);
            return blob;
        }
    }
}
