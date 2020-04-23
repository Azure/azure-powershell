﻿// ----------------------------------------------------------------------------------
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

    /// <summary>
    /// list azure blobs in specified azure container
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageBlob", DefaultParameterSetName = NameParameterSet),OutputType(typeof(AzureStorageBlob))]
    public class GetAzureStorageBlobCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// default parameter set name
        /// </summary>
        private const string NameParameterSet = "BlobName";

        /// <summary>
        /// prefix parameter set name
        /// </summary>
        private const string PrefixParameterSet = "BlobPrefix";

        [Parameter(Position = 0, HelpMessage = "Blob name", ParameterSetName = NameParameterSet)]
        [SupportsWildcards()]
        public string Blob
        {
            get
            {
                return blobName;
            }

            set
            {
                blobName = value;
            }
        }

        private string blobName = String.Empty;

        [Parameter(HelpMessage = "Blob Prefix", ParameterSetName = PrefixParameterSet)]
        public string Prefix
        {
            get
            {
                return blobPrefix;
            }

            set
            {
                blobPrefix = value;
            }
        }
        private string blobPrefix = String.Empty;

        [Alias("N", "Name")]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Container name",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Container
        {
            get
            {
                return containerName;
            }

            set
            {
                containerName = value;
            }
        }

        private string containerName = String.Empty;
        
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

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobCommand class.
        /// </summary>
        public GetAzureStorageBlobCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageBlobCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// list blobs by blob name and container name
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="blobName">blob name pattern</param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByName(long taskId, IStorageBlobManagement localChannel, string containerName, string blobName, bool includeDeleted = false)
        {
            CloudBlobContainer container = null;
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;

            string prefix = string.Empty;

            if (String.IsNullOrEmpty(blobName) || WildcardPattern.ContainsWildcardCharacters(blobName) || includeDeleted)
            {
                container = await GetCloudBlobContainerByName(localChannel, containerName).ConfigureAwait(false);
                prefix = NameUtil.GetNonWildcardPrefix(blobName);
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!String.IsNullOrEmpty(blobName))
                {
                    wildcard = new WildcardPattern(blobName, options);
                }

                Func<CloudBlob, bool> blobFilter = (blob) => wildcard == null || wildcard.IsMatch(blob.Name);
                await ListBlobsByPrefix(taskId, localChannel, containerName, prefix, blobFilter, includeDeleted).ConfigureAwait(false);
            }
            else
            {
                container = await GetCloudBlobContainerByName(localChannel, containerName, true).ConfigureAwait(false);

                if (!NameUtil.IsValidBlobName(blobName))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
                }

                CloudBlob blob = await localChannel.GetBlobReferenceFromServerAsync(container, blobName, accessCondition, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);

                if (null == blob)
                {
                    throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, blobName, containerName));
                }
                else
                {
                    WriteCloudBlobObject(taskId, localChannel, blob);
                }
            }
        }

        /// <summary>
        /// list blobs by blob prefix and container name
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="prefix">blob preifx</param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByPrefix(long taskId, IStorageBlobManagement localChannel, string containerName, string prefix, Func<CloudBlob, bool> blobFilter = null, bool includeDeleted = false)
        {
            CloudBlobContainer container = await GetCloudBlobContainerByName(localChannel, containerName).ConfigureAwait(false);

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
                BlobResultSegment blobResult = await localChannel.ListBlobsSegmentedAsync(container, prefix, useFlatBlobListing,
                    details, requestCount, continuationToken, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);

                foreach (IListBlobItem blobItem in blobResult.Results)
                {
                    CloudBlob blob = blobItem as CloudBlob;

                    if (blob == null)
                    {
                        continue;
                    }

                    if (blobFilter == null || blobFilter(blob))
                    {
                        WriteCloudBlobObject(taskId, localChannel, blob, blobResult.ContinuationToken);
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

            if (PrefixParameterSet == ParameterSetName)
            {
                string localContainerName = containerName;
                string localPrefix = blobPrefix;
                taskGenerator = (taskId) => ListBlobsByPrefix(taskId, localChannel, localContainerName, localPrefix, includeDeleted: IncludeDeleted.IsPresent);
            }
            else
            {
                string localContainerName = containerName;
                string localBlobName = blobName;
                taskGenerator = (taskId) => ListBlobsByName(taskId, localChannel, localContainerName, localBlobName, includeDeleted: IncludeDeleted.IsPresent);
            }

            RunTask(taskGenerator);
        }
    }
}
