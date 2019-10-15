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
    /// list azure blobs in specified azure container
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlobFromDirectory", DefaultParameterSetName = ListDirPathParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class GetAzureStorageBlobFromDirectoryCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// prefix parameter set name
        /// </summary>
        private const string ListDirPathParameterSet = "ListDirPath";

        /// <summary>
        /// prefix parameter set name
        /// </summary>
        private const string ListDirObjectParameterSet = "ListDirObject";

        [Parameter(Mandatory = false, HelpMessage = "Blob or Blob Directory Relative Path in the specified Blob Directory.")]
        [Alias("BlobDirectoryRelativePath", "RelativePath")]
        [SupportsWildcards()]
        public string BlobRelativePath { get; set; }
        
        [Parameter( Mandatory = true, HelpMessage = "Container name", ParameterSetName = ListDirPathParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Blob Directory Path to list from.", ParameterSetName = ListDirPathParameterSet)]
        [ValidateNotNullOrEmpty]
        public string BlobDirectoryPath { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Blob Directory Object to list from.",
             ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ListDirObjectParameterSet)]
        [ValidateNotNull]
        public CloudBlobDirectory CloudBlobDirectory { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Include deleted blobs, by default get blob won't include deleted blobs")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeDeleted { get; set; }

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

        [Parameter(Mandatory = false, HelpMessage = "Fetch Blob Permission. This only works if Hierarchical Namespace is enabled for the account. ")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter FetchPermission { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobFromDirectoryCommand class.
        /// </summary>
        public GetAzureStorageBlobFromDirectoryCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobFromDirectoryCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageBlobFromDirectoryCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// get the CloudBlobDirectory object by name if container exists
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="directoryName">directory name</param>
        /// <returns>return CloudBlobDirectory object if specified container exists, otherwise throw an exception</returns>
        internal CloudBlobDirectory GetCloudBlobDirectoryByName(IStorageBlobManagement localChannel, string containerName, string directoryName, bool skipCheckExists = false)
        {
            if (!NameUtil.IsValidContainerName(containerName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, containerName));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);

            if (!skipCheckExists && container.ServiceClient.Credentials.IsSharedKey
                && !container.Exists())
            {
                throw new ArgumentException(String.Format(Resources.ContainerNotFound, containerName));
            }

            CloudBlobDirectory blobDir = container.GetDirectoryReference(directoryName);
            if (!skipCheckExists && !blobDir.Exists())
            {
                throw new ArgumentException(String.Format("Can not find the blob directory '{0}'.", blobDir.Uri));
            }

            return blobDir;
        }

        /// <summary>
        /// list blobs by blob name and container name
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="blobName">blob name pattern</param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobs(long taskId, IStorageBlobManagement localChannel, CloudBlobDirectory CloudBlobDirectory, string blobRelativePath, bool includeDeleted = false)
        {
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;

            if (String.IsNullOrEmpty(blobRelativePath) || WildcardPattern.ContainsWildcardCharacters(blobRelativePath) || includeDeleted)
            {
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!String.IsNullOrEmpty(blobRelativePath))
                {
                    wildcard = new WildcardPattern(CloudBlobDirectory.Prefix + blobRelativePath, options);
                }

                Func<CloudBlob, bool> blobFilter = (blob) => wildcard == null || wildcard.IsMatch(blob.Name);
                await ListBlobsByFilter(taskId, localChannel, CloudBlobDirectory, blobFilter, includeDeleted).ConfigureAwait(false);
            }
            else
            {
                if (!NameUtil.IsValidBlobName(blobRelativePath))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobRelativePath));
                }

                CloudBlob blob = await localChannel.GetBlobReferenceFromServerAsync(CloudBlobDirectory, blobRelativePath, accessCondition, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);

                if (null == blob)
                {
                    throw new ResourceNotFoundException(String.Format("Can not find blob '{0}' in blob directory {1}, or the blob type is unsupported.", blobRelativePath, CloudBlobDirectory.Uri));
                }
                else
                {
                    WriteCloudBlobObject(taskId, localChannel, blob, null, this.FetchPermission.IsPresent);
                }
            }
        }

        /// <summary>
        /// list blobs by Filter
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByFilter(long taskId, IStorageBlobManagement localChannel, CloudBlobDirectory CloudBlobDirectory, Func<CloudBlob, bool> blobFilter = null, bool includeDeleted = false)
        {
            BlobRequestOptions requestOptions = RequestOptions;
            bool useFlatBlobListing = true;
            BlobListingDetails details = BlobListingDetails.Snapshots | BlobListingDetails.Metadata | BlobListingDetails.Copy;
            if (includeDeleted)
            {
                details = details | BlobListingDetails.Deleted;
            }

            int listCount = InternalMaxCount;
            int MaxListCount = 5000;
            int requestCount = MaxListCount;
            int realListCount = 0;
            BlobContinuationToken continuationToken = ContinuationToken;

            do
            {
                requestCount = Math.Min(listCount, MaxListCount);
                realListCount = 0;
                BlobResultSegment blobResult = await CloudBlobDirectory.ListBlobsSegmentedAsync(useFlatBlobListing, details, requestCount, 
                        continuationToken, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);              

                foreach (IListBlobItem blobItem in blobResult.Results)
                {
                    CloudBlob blob = blobItem as CloudBlob;

                    if (blob == null)
                    {
                        continue;
                    }

                    if (blobFilter == null || blobFilter(blob))
                    {
                        WriteCloudBlobObject(taskId, localChannel, blob, null, this.FetchPermission.IsPresent);
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

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = null;
            IStorageBlobManagement localChannel = Channel;

            CloudBlobDirectory BlobDir;

            if (ParameterSetName == ListDirPathParameterSet)
            {
                BlobDir = GetCloudBlobDirectoryByName(localChannel, this.Container, this.BlobDirectoryPath);
            }
            else
            {
                BlobDir = this.CloudBlobDirectory;
            }

            taskGenerator = (taskId) => ListBlobs(taskId, localChannel, BlobDir, BlobRelativePath, includeDeleted: IncludeDeleted.IsPresent);

            RunTask(taskGenerator);
        }
    }
}
