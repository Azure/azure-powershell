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
    using global::Azure.Storage.Files.DataLake.Models;
    using global::Azure;

    /// <summary>
    /// list azure blobs in specified azure FileSystem
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2ChildItem"),OutputType(typeof(AzureDataLakeGen2Item))]
    public class GetAzDataLakeGen2ChildItemCommand : StorageCloudBlobCmdletBase
    {

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that should be retrieved. Can be a directory " +
                "In the format 'directory1/directory2/', Skip set this parameter to list items from root directory of the Filesystem.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Alias("FetchPermission")]
        [Parameter(Mandatory = false, HelpMessage = "Fetch the datalake item properties and ACL.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter FetchProperty{ get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates if will recursively get the Child Item. The default is false.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Recurse { get; set; }

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

        [Alias("UserPrincipalName")]
        [Parameter(Mandatory = false, HelpMessage = "If speicify this parameter, the user identity values returned in the owner and group fields of each list entry will be transformed from Azure Active Directory Object IDs to User Principal Names. " 
            + "If not speicify this parameter, the values will be returned as Azure Active Directory Object IDs. Note that group and application Object IDs are not translated because they do not have unique friendly names.")]
        public SwitchParameter OutputUserPrincipalName { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzDataLakeGen2ChildItemCommand class.
        /// </summary>
        public GetAzDataLakeGen2ChildItemCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzDataLakeGen2ChildItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzDataLakeGen2ChildItemCommand(IStorageBlobManagement channel)
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
            bool useFlatBlobListing = this.Recurse.IsPresent ? true : false;

            int listCount = InternalMaxCount;
            Page<PathItem> page;
            do
            {
                IEnumerator<Page<PathItem>> enumerator = fileSystem.GetPaths(this.Path, this.Recurse, this.OutputUserPrincipalName.IsPresent)
                    .AsPages(this.ContinuationToken, listCount)
                    .GetEnumerator();

                enumerator.MoveNext();
                page = enumerator.Current;
                foreach (PathItem item in page.Values)
                {
                    WriteDataLakeGen2Item(localChannel, item, fileSystem, page.ContinuationToken, this.FetchProperty.IsPresent);
                }
                if (listCount != int.MaxValue)
                {
                    listCount -= page.Values.Count;
                }
                this.ContinuationToken = page.ContinuationToken;
            } while (!string.IsNullOrEmpty(this.ContinuationToken) && (listCount > 0));
        }
    }
}
