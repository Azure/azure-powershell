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
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2ChildItem"),OutputType(typeof(AzureDataLakeGen2Item))]
    public class GetAzDataLakeGen2ChildItemCommand : StorageCloudBlobCmdletBase
    {

        [Parameter(ValueFromPipeline = true, Position = 0, Mandatory = true, HelpMessage = "FileSystem name")]
        [ValidateNotNullOrEmpty]
        public string FileSystem { get; set; }

        [Parameter(ValueFromPipeline = true, Position = 1, Mandatory = false, HelpMessage =
                "The path in the specified FileSystem that should be retrieved. Can be a folder " +
                "In the format 'folder1/folder2/'")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Fetch Blob permission/ACL/owner.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter FetchPermission { get; set; }

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
        public BlobContinuationToken ContinuationToken { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        // Overwrite the useless parameter
        public override int? ConcurrentTaskCount { get; set; }

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
            CloudBlobContainer container = GetCloudBlobContainerByName(localChannel, this.FileSystem).ConfigureAwait(false).GetAwaiter().GetResult();

            BlobRequestOptions requestOptions = RequestOptions;
            bool useFlatBlobListing = this.Recurse.IsPresent ? true : false;
            BlobListingDetails details = BlobListingDetails.Metadata | BlobListingDetails.Copy;

            int listCount = InternalMaxCount;
            int MaxListCount = 5000;
            int requestCount = MaxListCount;
            int realListCount = 0;
            BlobContinuationToken continuationToken = ContinuationToken;

            do
            {
                requestCount = Math.Min(listCount, MaxListCount);
                realListCount = 0;
                BlobResultSegment blobResult = localChannel.ListBlobsSegmentedAsync(container, this.Path, useFlatBlobListing,
                    details, requestCount, continuationToken, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();

                foreach (IListBlobItem blobItem in blobResult.Results)
                {
                    CloudBlob blob = blobItem as CloudBlob;

                    if (blob == null)
                    {
                        CloudBlobDirectory blobDir = blobItem as CloudBlobDirectory;
                        if (blobDir == null)
                        {
                            continue;
                        }
                        else
                        {
                            WriteDataLakeGen2Item(localChannel, blobDir, blobResult.ContinuationToken, this.FetchPermission.IsPresent);
                            realListCount++;
                        }
                    }
                    else
                    {
                        WriteDataLakeGen2Item(localChannel, (CloudBlockBlob)blob, blobResult.ContinuationToken, this.FetchPermission.IsPresent);
                        realListCount++;
                    }
                }

                if (InternalMaxCount != int.MaxValue)
                {
                    listCount -= realListCount;
                }

                continuationToken = blobResult.ContinuationToken;
            }
            while (listCount > 0 && continuationToken != null);
        }
    }
}
