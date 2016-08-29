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
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// list azure blobs in specified azure container
    /// </summary>
    [Cmdlet(VerbsCommon.Get, StorageNouns.Blob, DefaultParameterSetName = NameParameterSet),
        OutputType(typeof(AzureStorageBlob))]
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
        /// get the CloudBlobContainer object by name if container exists
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <returns>return CloudBlobContianer object if specified container exists, otherwise throw an exception</returns>
        internal async Task<CloudBlobContainer> GetCloudBlobContainerByName(IStorageBlobManagement localChannel, string containerName, bool skipCheckExists = false)
        {
            if (!NameUtil.IsValidContainerName(containerName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, containerName));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);

            if (!skipCheckExists && container.ServiceClient.Credentials.IsSharedKey
                && !await localChannel.DoesContainerExistAsync(container, requestOptions, OperationContext, CmdletCancellationToken))
            {
                throw new ArgumentException(String.Format(Resources.ContainerNotFound, containerName));
            }

            return container;
        }

        /// <summary>
        /// list blobs by blob name and container name
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="blobName">blob name pattern</param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByName(long taskId, IStorageBlobManagement localChannel, string containerName, string blobName)
        {
            CloudBlobContainer container = null;
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;

            string prefix = string.Empty;

            if (String.IsNullOrEmpty(blobName) || WildcardPattern.ContainsWildcardCharacters(blobName))
            {
                container = await GetCloudBlobContainerByName(localChannel, containerName);
                prefix = NameUtil.GetNonWildcardPrefix(blobName);
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!String.IsNullOrEmpty(blobName))
                {
                    wildcard = new WildcardPattern(blobName, options);
                }

                Func<CloudBlob, bool> blobFilter = (blob) => wildcard == null || wildcard.IsMatch(blob.Name);
                await ListBlobsByPrefix(taskId, localChannel, containerName, prefix, blobFilter);
            }
            else
            {
                container = await GetCloudBlobContainerByName(localChannel, containerName, true);

                if (!NameUtil.IsValidBlobName(blobName))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
                }

                CloudBlob blob = await localChannel.GetBlobReferenceFromServerAsync(container, blobName, accessCondition, requestOptions, OperationContext, CmdletCancellationToken);

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
        internal async Task ListBlobsByPrefix(long taskId, IStorageBlobManagement localChannel, string containerName, string prefix, Func<CloudBlob, bool> blobFilter = null)
        {
            CloudBlobContainer container = await GetCloudBlobContainerByName(localChannel, containerName);

            BlobRequestOptions requestOptions = RequestOptions;
            bool useFlatBlobListing = true;
            BlobListingDetails details = BlobListingDetails.Snapshots | BlobListingDetails.Metadata | BlobListingDetails.Copy;

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
                    details, requestCount, continuationToken, requestOptions, OperationContext, CmdletCancellationToken);

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
                taskGenerator = (taskId) => ListBlobsByPrefix(taskId, localChannel, localContainerName, localPrefix);
            }
            else
            {
                string localContainerName = containerName;
                string localBlobName = blobName;
                taskGenerator = (taskId) => ListBlobsByName(taskId, localChannel, localContainerName, localBlobName);
            }

            RunTask(taskGenerator);
        }
    }
}