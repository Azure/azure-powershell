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
    using global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobImmutabilityPolicy", DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true),OutputType(typeof(AzureStorageBlob))]
    public class RemoveStorageAzureBlobImmutabilityPolicyCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobPipelineParameterSet = "BlobPipeline";

        /// <summary>
        /// blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        [Parameter(HelpMessage = "BlobBaseClient Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSet)]
        [ValidateNotNull]
        public BlobBaseClient BlobBaseClient { get; set; }

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

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        public RemoveStorageAzureBlobImmutabilityPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveStorageAzureBlobImmutabilityPolicyCommand(IStorageBlobManagement channel)
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

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;

            string blobName = BlobName;
            if (ParameterSetName == BlobPipelineParameterSet)
            {
                blobName = BlobBaseClient.Name;
            }

            if (ShouldProcess(blobName, "Set Blob ImmutabilityPolicy:"))
            {
                switch (ParameterSetName)
                {
                    case BlobPipelineParameterSet:
                        break;
                    case NameParameterSet:
                    default:
                        string localContainerName = ContainerName;
                        string localBlobName = BlobName;
                        this.BlobBaseClient = Util.GetTrack2BlobServiceClient(localChannel.StorageContext, ClientOptions).GetBlobContainerClient(localContainerName).GetBlobBaseClient(blobName);
                        break;
                }
                this.BlobBaseClient.DeleteImmutabilityPolicy(cancellationToken: this.CmdletCancellationToken);

                BlobProperties blobProperties = this.BlobBaseClient.GetProperties(cancellationToken: this.CmdletCancellationToken).Value;
                this.BlobBaseClient = Util.GetTrack2BlobClientWithType(this.BlobBaseClient, localChannel.StorageContext, blobProperties.BlobType, ClientOptions);

                WriteObject(new AzureStorageBlob(this.BlobBaseClient, Channel.StorageContext, blobProperties, ClientOptions));
            }
        }
    }
}
