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
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure;
    using global::Azure.Storage.Files.DataLake.Models;

    /// <summary>
    /// list azure blobs in specified azure FileSystem
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item"), OutputType(typeof(AzureDataLakeGen2Item))]
    public class GetDataLakeGen2ItemCommand : StorageCloudBlobCmdletBase
    {

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that should be retrieved. Can be a file or directory " +
                "In the format 'directory/file.txt' or 'directory1/directory2/'. Don't specify this parameter to get the root directory of the Filesystem.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }        
        
        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetDataLakeGen2ItemCommand class.
        /// </summary>
        public GetDataLakeGen2ItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetDataLakeGen2ItemCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;

            DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);

            DataLakeFileClient fileClient;
            DataLakeDirectoryClient dirClient;
            if (GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient))
            {
                // Directory
                WriteDataLakeGen2Item(localChannel, dirClient);
            }
            else 
            {
                //File
                WriteDataLakeGen2Item(Channel, fileClient);
            }

            //CloudBlob blob = (CloudBlob)container.GetBlobReferenceFromServer(this.Path);
            //Pageable<PathItem> items = fileSystem.GetPaths(this.Path);
            //PathItem current = items.GetEnumerator().Current;
            //if (current != null)
            //{
            //    if (current.IsDirectory != null && current.IsDirectory.Value) // Directory
            //    {
            //        DataLakeDirectoryClient dirClient = fileSystem.GetDirectoryClient(this.Path);
            //        WriteDataLakeGen2Item(localChannel, dirClient, null, fetchPermission: true);
            //    }
            //    else //File
            //    {
            //        DataLakeFileClient fileClient = fileSystem.GetFileClient(this.Path);
            //        WriteDataLakeGen2Item(Channel, fileClient, null, fetchPermission: true);
            //    }
            //}
            //else
            //{
            //    // TODO: through exception that the item not exist
            //}

        }
    }
}
