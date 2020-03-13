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
    using global::Azure.Storage.Files.DataLake;
    using global::Azure;

    /// <summary>
    /// create a new azure FileSystem
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

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified FileSystem that should be move from. Can be a file or directory. " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'", ParameterSetName = ManualParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Datalake Gen2 Item Object to move from.",
            ValueFromPipeline = true, ParameterSetName = BlobParameterSet)]
        [ValidateNotNull]
        public AzureDataLakeGen2Item InputObject { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Dest FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string DestFileSystem { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Dest item path")]
        [ValidateNotNullOrEmpty]
        public string DestPath { get; set; }

        [Parameter(HelpMessage = "Force to remove the ImmutabilityPolicy.")]
        public SwitchParameter Force { get; set; }

        //[Parameter(Mandatory = false, HelpMessage = "The umask restricts the permissions of the file or directory to be created. The resulting permission is given by p & ^u, where p is the permission and u is the umask. Symbolic (rwxrw-rw-) is supported. ")]
        //[ValidateNotNullOrEmpty]
        //[ValidatePattern("([r-][w-][x-]){3}")]
        //public string Umask { get; set; }

        //[Parameter(Mandatory = false, HelpMessage = "This parameter determines the behavior of the rename operation. The value must be \"legacy\" or \"posix\", and the default value will be \"posix\". ")]
        //public PathRenameMode PathRenameMode
        //{
        //    get
        //    {
        //        return (pathRenameMode == null) ? PathRenameMode.Posix : pathRenameMode.Value;
        //    }
        //    set
        //    {
        //        pathRenameMode = value;
        //    }
        //}
        //private PathRenameMode? pathRenameMode = null;

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
            DataLakeFileClient srcBlob = null;
            DataLakeDirectoryClient srcBlobDir = null;
            if (ParameterSetName == ManualParameterSet)
            {
                DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
                foundAFolder = GetExistDataLakeGen2Item(fileSystem, this.Path, out srcBlob, out srcBlobDir);
            }
            else //BlobParameterSet
            {
                if (!InputObject.IsDirectory)
                {
                    srcBlob = InputObject.File;
                }
                else
                {
                    srcBlobDir = InputObject.Directory;
                    foundAFolder = true;
                }
            }

            //// Create Dest Blob Dir object
            //CloudBlobContainer destblobContainer = GetCloudBlobContainerByName(localChannel, this.DestFileSystem).ConfigureAwait(false).GetAwaiter().GetResult();


            if (foundAFolder)
            {
                if (ShouldProcess(srcBlobDir.Uri.ToString(), "Move Directory: "))
                {
                    // check dest exist
                    bool destExist = true;
                    DataLakeFileSystemClient destFileSystem = GetFileSystemClientByName(localChannel, this.DestFileSystem != null? this.DestFileSystem : this.FileSystem);
                    DataLakeDirectoryClient destBlobDir = destFileSystem.GetDirectoryClient(this.DestPath);
                    try
                    {
                        destBlobDir.GetProperties();
                    }
                    catch (RequestFailedException e) when (e.Status == 404)
                    {
                        destExist = false;
                    }

                    if (this.Force || !destExist || ShouldContinue(string.Format("Overwrite destination {0}", destBlobDir.Uri), ""))
                    {
                        destBlobDir = srcBlobDir.Rename(this.DestPath, this.DestFileSystem).Value;
                        WriteDataLakeGen2Item(localChannel, destBlobDir);
                    }
                }
            }
            else
            {
                // check dest exist
                bool destExist = true;
                DataLakeFileSystemClient destFileSystem = GetFileSystemClientByName(localChannel, this.DestFileSystem != null ? this.DestFileSystem : this.FileSystem);
                DataLakeFileClient destBlob = destFileSystem.GetFileClient(this.DestPath);
                try
                {
                    destBlob.GetProperties();
                }
                catch (RequestFailedException e) when (e.Status == 404)
                {
                    destExist = false;
                }

                if (this.Force || !destExist || ShouldContinue(string.Format("Overwrite destination {0}", destBlob.Uri), ""))
                {
                    if (ShouldProcess(srcBlob.Uri.ToString(), "Move File: "))
                    {
                        destBlob = srcBlob.Rename(this.DestPath, this.DestFileSystem).Value;
                        WriteDataLakeGen2Item(localChannel, destBlob);
                    }
                }
            }

        }
    }
}
