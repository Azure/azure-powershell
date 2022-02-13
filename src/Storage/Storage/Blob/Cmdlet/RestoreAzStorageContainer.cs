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
    using global::Azure.Storage.Blobs;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// restore specified azure container
    /// </summary>
    [Cmdlet("Restore", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainer", SupportsShouldProcess = true),OutputType(typeof(Boolean))]
    public class RestoreAzureStorageContainerCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Container", "DeletedContainerName")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The name of the previously deleted container.",
             ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("DeletedContainerVersion, ")]
        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The version of the previously deleted container.",
             ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string VersionId { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the RestoreAzureStorageContainerCommand class.
        /// </summary>
        public RestoreAzureStorageContainerCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RestoreAzureStorageContainerCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RestoreAzureStorageContainerCommand(IStorageBlobManagement channel)
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
            if (ShouldProcess(this.Name, "Restore deleted container"))
            {
                if (!NameUtil.IsValidContainerName(this.Name))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidContainerName, this.Name));
                }

                BlobServiceClient blobServiceClient = Util.GetTrack2BlobServiceClient(this.Channel.StorageContext, ClientOptions);

                BlobContainerClient destContainerClient = blobServiceClient.UndeleteBlobContainer(this.Name, this.VersionId, this.Name, this.CmdletCancellationToken).Value;

                AzureStorageContainer destAzureStorageContainer = new AzureStorageContainer(destContainerClient, Channel.StorageContext);
                destAzureStorageContainer.SetTrack2Permission();

                WriteObject(destAzureStorageContainer);
            }
        }
    }
}
