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
    using global::Azure;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// list azure blobs in specified azure FileSystem
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2DeletedItem"), OutputType(typeof(AzureDataLakeGen2DeletedItem))]
    public class GetAzDataLakeGen2DeletedItemCommand : StorageCloudBlobCmdletBase
    {

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that should be retrieved. Can be a directory " +
                "In the format 'directory1/directory2/', Skip set this parameter to list items from root directory of the Filesystem.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The max count of the blobs that can return.")]
        public int? MaxCount
        {
            get { return InternalMaxCount; }
            set
            {
                if (value.Value <= 0)
                {
                    InternalMaxCount = int.MaxValue;
                }
                else
                {
                    InternalMaxCount = value.Value;
                }
            }
        }

        private int InternalMaxCount = int.MaxValue;

        [Parameter(Mandatory = false, HelpMessage = "Continuation Token.")]
        public string ContinuationToken { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzDataLakeGen2DeletedItemCommand class.
        /// </summary>
        public GetAzDataLakeGen2DeletedItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzDataLakeGen2DeletedItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzDataLakeGen2DeletedItemCommand(IStorageBlobManagement channel)
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

            BlobRequestOptions requestOptions = RequestOptions;
            //bool useFlatBlobListing = this.Recurse.IsPresent ? true : false;

            IEnumerator<Page<PathDeletedItem>> enumerator = fileSystem.GetDeletedPaths(this.Path, this.CmdletCancellationToken)
                .AsPages(this.ContinuationToken, this.MaxCount)
                .GetEnumerator();

            Page<PathDeletedItem> page;
            enumerator.MoveNext();
            page = enumerator.Current;
            if (!string.IsNullOrEmpty(page.ContinuationToken) && (MaxCount == null || page.Values.Count < MaxCount.Value))
            {
                WriteWarning(string.Format("Not all result returned, to list the left items run this cmdlet again with parameter: '-ContinuationToken {0}'.", page.ContinuationToken));
            }
            foreach (PathDeletedItem item in page.Values)
            {
                WriteDataLakeGen2DeletedItem(localChannel, item, fileSystem, page.ContinuationToken);
            }
        }
    }
}
