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
    using Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("Move", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item", DefaultParameterSetName = ManualParameterSet, SupportsShouldProcess = true),OutputType(typeof(AzureDataLakeGen2Item))]
    public class MoveAzDataLakeGen2ItemCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// manually set the name parameter
        /// </summary>
        private const string ManualParameterSet = "ReceiveManual";

        /// <summary>
        /// Blob or BlobDir pipeline
        /// </summary>
        private const string BlobParameterSet = "ItemPipeline";

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "Container name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified container that should be move from. Can be a file or folder. " +
                "In the format 'folder/file.txt' or 'folder1/folder2/'", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Item Object to move from.",
            ValueFromPipeline = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2Item InputObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Dest Container name")]
        [ValidateNotNullOrEmpty]
        public string DestContainer { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Dest Blob path")]
        [ValidateNotNullOrEmpty]
        public string DestPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The umask restricts the permissions of the file or directory to be created. The resulting permission is given by p & ^u, where p is the permission and u is the umask. Symbolic (rwxrw-rw-) is supported. ")]
        [ValidateNotNullOrEmpty]
        [ValidatePattern("([r-][w-][x-]){3}")]
        public string Umask { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "This parameter determines the behavior of the rename operation. The value must be \"legacy\" or \"posix\", and the default value will be \"posix\". ")]
        public PathRenameMode PathRenameMode
        {
            get
            {
                return (pathRenameMode == null) ? PathRenameMode.Posix : pathRenameMode.Value;
            }
            set
            {
                pathRenameMode = value;
            }
        }
        private PathRenameMode? pathRenameMode = null;

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the MoveAzDataLakeGen2ItemCommand class.
        /// </summary>
        public MoveAzDataLakeGen2ItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MoveAzDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public MoveAzDataLakeGen2ItemCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }
        
        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            BlobRequestOptions requestOptions = RequestOptions;

            bool foundAFolder = false;
            CloudBlockBlob srcBlob = null;
            CloudBlobDirectory srcBlobDir = null;
            if (ParameterSetName == ManualParameterSet)
            {
                CloudBlobContainer container = GetCloudBlobContainerByName(localChannel, this.Container).ConfigureAwait(false).GetAwaiter().GetResult();
                foundAFolder = GetExistDataLakeGen2Item(container, this.Path, out srcBlob, out srcBlobDir);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    srcBlob = (CloudBlockBlob)InputObject.ICloudBlob;
                }
                else
                {
                    srcBlobDir = InputObject.CloudBlobDirectory;
                    foundAFolder = true;
                }
            }

            // Create Dest Blob Dir object
            CloudBlobContainer destblobContainer = GetCloudBlobContainerByName(localChannel, this.DestContainer).ConfigureAwait(false).GetAwaiter().GetResult();


            if (foundAFolder)
            {
                if (ShouldProcess(srcBlobDir.Uri.ToString(), "Move Folder: "))
                {
                    CloudBlobDirectory destBlobDir = destblobContainer.GetDirectoryReference(this.DestPath);
                    srcBlobDir.Move(destBlobDir.Uri, null, null, requestOptions, OperationContext,
                    this.Umask != null ? PathPermissions.ParseSymbolic(this.Umask) : null,
                    this.pathRenameMode);
                    destBlobDir.FetchAttributes();
                    WriteDataLakeGen2Item(localChannel, destBlobDir, null, fetchPermission: true);
                }
            }
            else
            {
                if (ShouldProcess(srcBlob.Uri.ToString(), "Move File: "))
                {
                    CloudBlockBlob destBlob = destblobContainer.GetBlockBlobReference(this.DestPath);
                    (srcBlob).Move(destBlob.Uri, null, null, requestOptions, OperationContext,
                    this.Umask != null ? PathPermissions.ParseSymbolic(this.Umask) : null,
                    this.pathRenameMode);
                    destBlob.FetchAttributes();
                    WriteDataLakeGen2Item(Channel, destBlob, null, fetchPermission: true);
                }
            }

        }
    }
}
