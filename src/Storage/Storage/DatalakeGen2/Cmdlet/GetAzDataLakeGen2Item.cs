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

    /// <summary>
    /// list azure blobs in specified azure FileSystem
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2Item"), OutputType(typeof(AzureDataLakeGen2Item))]
    public class GetDataLakeGen2ItemCommand : StorageCloudBlobCmdletBase
    {

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = true, HelpMessage =
                "The path in the specified FileSystem that should be retrieved. Can be a file or folder " +
                "In the format 'folder/file.txt' or 'folder1/folder2/'")]
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

            CloudBlobContainer container = GetCloudBlobContainerByName(localChannel, this.FileSystem).ConfigureAwait(false).GetAwaiter().GetResult();

            try
            {
                CloudBlob blob = (CloudBlob)container.GetBlobReferenceFromServer(this.Path);
                WriteDataLakeGen2Item(Channel, (CloudBlockBlob)blob, null, fetchPermission: true);
            }
            catch (StorageException e) when (e.IsNotFoundException())
            {
                CloudBlobDirectory blobDir = container.GetDirectoryReference(this.Path);
                blobDir.FetchAttributes();
                WriteDataLakeGen2Item(localChannel, blobDir, null, fetchPermission: true);
            }

        }
    }
}
