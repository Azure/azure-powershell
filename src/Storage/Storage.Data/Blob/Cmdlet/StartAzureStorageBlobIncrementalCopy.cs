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
    using Adapters;
    using Azure.Commands.Common.Authentication.Abstractions;
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// Start an Incremental copy operation from a Page blob snapshot to the specified destination Page blob.
    /// </summary>
    [Cmdlet("Start", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobIncrementalCopy", SupportsShouldProcess = true, DefaultParameterSetName = ContainerParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class StartAzureStorageBlobIncrementalCopy : StorageCloudBlobCmdletBase
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
        /// Source uri parameter set
        /// </summary>
        private const string UriParameterSet = "UriPipeline";

        [Alias("SrcICloudBlob", "SrcCloudBlob", "ICloudBlob", "SourceICloudBlob", "SourceCloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        public CloudPageBlob CloudBlob { get; set; }

        [Alias("SourceCloudBlobContainer")]
        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Alias("SourceBlob")]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerParameterSet, Mandatory = true)]
        [Parameter(HelpMessage = "Blob name", ParameterSetName = ContainerNameParameterSet, Mandatory = true)]
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

        [Alias("SourceBlobSnapshotTime")]
        [Parameter(HelpMessage = "Source Blob Snapshot Time", ParameterSetName = ContainerParameterSet, Mandatory = true)]
        [Parameter(HelpMessage = "Source Blob Snapshot Time", ParameterSetName = ContainerNameParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset? SrcBlobSnapshotTime { get; set; }

        [Alias("SrcUri", "SourceUri")]
        [Parameter(HelpMessage = "Source blob uri", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = UriParameterSet)]
        public string AbsoluteUri { get; set; }

        [Alias("DestinationContainer")]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination container name", Mandatory = true, ParameterSetName = ContainerParameterSet)]
        public string DestContainer { get; set; }

        [Alias("DestinationBlob")]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = true, ParameterSetName = UriParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Destination blob name", Mandatory = false, ParameterSetName = ContainerParameterSet)]
        public string DestBlob { get; set; }

        [Alias("DestICloudBlob", "DestinationCloudBlob", "DestinationICloudBlob")]
        [Parameter(HelpMessage = "Destination CloudBlob object", Mandatory = true, ParameterSetName = BlobToBlobParameterSet)]
        public CloudPageBlob DestCloudBlob { get; set; }

        [Alias("SrcContext", "SourceContext")]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerNameParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = BlobToBlobParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerParameterSet)]
        [Parameter(HelpMessage = "Source Azure Storage Context Object", ParameterSetName = UriParameterSet)]
        public override IStorageContext Context { get; set; }

        [Alias("DestinationContext")]
        [Parameter(HelpMessage = "Destination Storage context object", Mandatory = false)]
        public IStorageContext DestContext { get; set; }

        private bool skipSourceChannelInit;

        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

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
                    copyAction = () => StartCopyBlob(srcChannel, destChannel, SrcContainer, SrcBlob, SrcBlobSnapshotTime, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case UriParameterSet:
                    copyAction = () => StartCopyBlob(destChannel, AbsoluteUri, DestContainer, DestBlob, (Context != null? GetCmdletStorageContext(Context): null));
                    target = AbsoluteUri;
                    break;

                case BlobParameterSet:
                    copyAction = () => StartCopyBlob(destChannel, CloudBlob, DestContainer, DestBlob);
                    target = CloudBlob.Name;
                    break;

                case ContainerParameterSet:
                    copyAction = () => StartCopyBlob(srcChannel, destChannel, CloudBlobContainer.Name, SrcBlob, SrcBlobSnapshotTime, DestContainer, DestBlob);
                    target = SrcBlob;
                    break;

                case BlobToBlobParameterSet:
                    copyAction = () => StartCopyBlob(destChannel, CloudBlob, DestCloudBlob);
                    target = CloudBlob.Name;
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
        /// <param name="destChannel"></param>
        /// <param name="srcCloudBlob">Source CloudBlob object</param>
        /// <param name="destCloudBlob">Destination CloudBlob object</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, CloudPageBlob srcCloudBlob, CloudPageBlob destCloudBlob)
        {
            VerifyIncrementalCopySourceBlob(srcCloudBlob);

            Func<long, Task> taskGenerator = (taskId) => StartCopyAsync(taskId, destChannel, srcCloudBlob, destCloudBlob);
            RunTask(taskGenerator);
        }

        /// <summary>
        /// Start copy operation by source CloudBlob object
        /// </summary>
        /// <param name="destChannel"></param>
        /// <param name="srcCloudBlob">Source CloudBlob object</param>
        /// <param name="destContainer">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement destChannel, CloudPageBlob srcCloudBlob, string destContainer, string destBlobName)
        {
            if (string.IsNullOrEmpty(destBlobName))
            {
                destBlobName = srcCloudBlob.Name;
            }

            CloudPageBlob destBlob = this.GetDestBlob(destChannel, destContainer, destBlobName);

            this.StartCopyBlob(destChannel, srcCloudBlob, destBlob);
        }

        /// <summary>
        /// Start copy operation by source uri
        /// </summary>
        /// <param name="destChannel"></param>
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

                    StartCopyBlob(destChannel, VerifyIncrementalCopySourceBlob(blobReference), destContainer, destBlobName);
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
        /// <param name="SrcBlobSnapshotTime"></param>
        /// <param name="destContainerName">Destinaion container name</param>
        /// <param name="destBlobName">Destination blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private void StartCopyBlob(IStorageBlobManagement SrcChannel, IStorageBlobManagement destChannel, string srcContainerName, string srcBlobName, DateTimeOffset? SrcBlobSnapshotTime, string destContainerName, string destBlobName)
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
            CloudBlob blob = GetBlobReferenceFromServerWithContainer(SrcChannel, container, srcBlobName, accessCondition, options, OperationContext, SrcBlobSnapshotTime);

            this.StartCopyBlob(destChannel, VerifyIncrementalCopySourceBlob(blob), destContainerName, destBlobName);
        }

        private async Task StartCopyFromBlob(long taskId, IStorageBlobManagement destChannel, CloudPageBlob srcBlob, CloudPageBlob destBlob)
        {
            try
            {
                await StartCopyFromUri(taskId, destChannel, srcBlob.GenerateUriWithCredentials(), destBlob).ConfigureAwait(false);
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

        private async Task StartCopyFromUri(long taskId, IStorageBlobManagement destChannel, Uri srcUri, CloudPageBlob destBlob)
        {
            //Don't need to verify the Dest Exist and warn user for overwrite, since incremental Copy won't overwrite the dest blob, but will create a new snapshot for it.
            string copyId = await destChannel.StartIncrementalCopyAsync(destBlob, new CloudPageBlob(srcUri), null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
            this.OutputStream.WriteVerbose(taskId, String.Format(Resources.CopyDestinationBlobPending, destBlob.Name, destBlob.Container.Name, copyId));
            this.WriteCloudBlobObject(taskId, destChannel, destBlob);
        }

        private CloudPageBlob GetDestBlob(IStorageBlobManagement destChannel, string destContainerName, string destBlobName)
        {
            NameUtil.ValidateContainerName(destContainerName);
            NameUtil.ValidateBlobName(destBlobName);

            CloudBlobContainer container = destChannel.GetContainerReference(destContainerName);
            CloudPageBlob destBlob = container.GetPageBlobReference(destBlobName);

            return destBlob;
        }

        /// <summary>
        /// Start copy using transfer mangager by source CloudBlob object
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="sourceBlob">Source blob</param>
        /// <param name="destBlob">Destination blob</param>
        /// <returns>Destination CloudBlob object</returns>
        private async Task StartCopyAsync(long taskId, IStorageBlobManagement destChannel, CloudPageBlob sourceBlob, CloudPageBlob destBlob)
        {
            NameUtil.ValidateBlobName(sourceBlob.Name);
            NameUtil.ValidateContainerName(destBlob.Container.Name);
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

            CloudPageBlob sourceBlob = new CloudPageBlob(uri);
            //try
            //{
            await sourceBlob.FetchAttributesAsync(null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
            VerifyIncrementalCopySourceBlob(sourceBlob);

            //}
            //catch (StorageException) 
            //{
            //    //The source blob don't have read permission
            //    //We should no block the copy in this case, 
            //}
            CloudPageBlob destBlob = GetDestBlob(destChannel, destContainer.Name, destBlobName);

            await this.StartCopyFromUri(taskId, destChannel, uri, destBlob);
        }

        /// <summary>
        /// Get DestinationBlob with specified copy id
        /// </summary>
        /// <param name="destChannel">IStorageBlobManagement channel object</param>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">Blob name</param>
        /// <returns>Destination CloudBlob object</returns>
        private CloudPageBlob GetDestinationBlobWithCopyId(IStorageBlobManagement destChannel, CloudBlobContainer container, string blobName)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions options = RequestOptions;
            CloudPageBlob blob = (CloudPageBlob)destChannel.GetBlobReferenceFromServer(container, blobName, accessCondition, options, OperationContext);
            return blob;
        }

        /// <summary>
        /// Check if the Source Blob is a Page Blob Snapshot
        /// </summary>
        /// <param name="blob">Source Blob</param>
        /// <returns>Source Blob</returns>
        private CloudPageBlob VerifyIncrementalCopySourceBlob(CloudBlob blob)
        {
            if (blob.Properties.BlobType != BlobType.PageBlob && blob.IsSnapshot == true)
            {
                throw new ArgumentException(String.Format("Blob {0} with Type {1} is not supported as incremental copy source, only page blob snapshot is supported as incremental copy source.", blob.Name, blob.Properties.BlobType));
            }
            return (CloudPageBlob)blob;
        }
    }
}
