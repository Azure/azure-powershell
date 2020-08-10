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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobTag", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true),OutputType(typeof(Boolean))]
    public class SetAzStorageAzureBlobTagCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobPipelineParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline paremeter set name
        /// </summary>
        private const string ContainerPipelineParameterSet = "ContainerPipeline";

        /// <summary>
        /// blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParameterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(ParameterSetName = ContainerPipelineParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        public string Blob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(HelpMessage = "Container name", Mandatory = true, Position = 1,
            ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(HelpMessage = "Blob Tags", Mandatory = true)]
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

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        public SetAzStorageAzureBlobTagCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzStorageAzureBlobTagCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }     

        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);
        }

        internal async Task SetBlobTag(long taskId, IStorageBlobManagement localChannel, BlobBaseClient blob, bool isValidBlob)
        {
            if (!isValidBlob)
            {
                ValidatePipelineCloudBlobTrack2(blob);
            }

            await blob.SetTagsAsync(
                this.BlobTag.Cast<DictionaryEntry>().ToDictionary(d => (string)d.Key, d => (string)d.Value),
                this.BlobRequestConditions, this.CmdletCancellationToken).ConfigureAwait(false);

            OutputStream.WriteObject(taskId, this.BlobTag);
        }

        internal async Task SetBlobTag(long taskId, IStorageBlobManagement localChannel, CloudBlobContainer container, string blobName)
        {
            if (!NameUtil.IsValidBlobName(blobName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
            }

            ValidatePipelineCloudBlobContainer(container);

            BlobContainerClient track2container = AzureStorageContainer.GetTrack2BlobContainerClient(container, this.Channel.StorageContext, ClientOptions);

            BlobBaseClient blobClient = Util.GetTrack2BlobClient(track2container, blobName, localChannel.StorageContext, null, false, null, ClientOptions);

            await SetBlobTag(taskId, localChannel, blobClient, true).ConfigureAwait(false);
        }

        internal async Task SetBlobTag(long taskId, IStorageBlobManagement localChannel, string containerName, string blobName)
        {
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);
            await SetBlobTag(taskId, localChannel, container, blobName).ConfigureAwait(false);
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = null;
            IStorageBlobManagement localChannel = Channel;
            
            string blobName = BlobName;
            if (ParameterSetName == BlobPipelineParameterSet)
            {
                blobName = this.BlobBaseClient.Name;
            }

            if (ShouldProcess(blobName, "Set blob Tags"))
            {
                switch (ParameterSetName)
                {
                    case BlobPipelineParameterSet:
                        taskGenerator = (taskId) => SetBlobTag(taskId, localChannel, this.BlobBaseClient, false);
                        break;
                    case ContainerPipelineParameterSet:
                        CloudBlobContainer localContainer = CloudBlobContainer;
                        string localName = BlobName;
                        taskGenerator = (taskId) => SetBlobTag(taskId, localChannel, localContainer, localName);
                        break;
                    case NameParameterSet:
                    default:
                        string localContainerName = ContainerName;
                        string localBlobName = BlobName;
                        taskGenerator = (taskId) => SetBlobTag(taskId, localChannel, localContainerName, localBlobName);
                        break;
                }
                RunTask(taskGenerator);
            }
        }
    }
}
