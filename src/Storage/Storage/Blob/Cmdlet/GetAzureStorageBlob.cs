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
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using global::Azure.Storage.Blobs.Specialized;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections.Generic;
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

        /// <summary>
        /// Single Blob set name
        /// </summary>
        private const string SingleBlobSnapshotTimeParameterSet = "SingleBlobSnapshotTime";

        /// <summary>
        /// Single Blob set name
        /// </summary>
        private const string SingleBlobVersionIDParameterSet = "SingleBlobVersionID";

        [Parameter(Position = 0, HelpMessage = "Blob name", ParameterSetName = NameParameterSet)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Blob name", ParameterSetName = SingleBlobSnapshotTimeParameterSet)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Blob name", ParameterSetName = SingleBlobVersionIDParameterSet)]
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
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Container name", ValueFromPipelineByPropertyName = true, ParameterSetName = NameParameterSet)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Container name", ValueFromPipelineByPropertyName = true, ParameterSetName = PrefixParameterSet)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Container name", ValueFromPipelineByPropertyName = true, ParameterSetName = SingleBlobSnapshotTimeParameterSet)]
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Container name", ValueFromPipelineByPropertyName = true, ParameterSetName = SingleBlobVersionIDParameterSet)]
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

        [Parameter(Mandatory = false, HelpMessage = "Include deleted blobs, by default get blob won't include deleted blobs", ParameterSetName = NameParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Include deleted blobs, by default get blob won't include deleted blobs", ParameterSetName = PrefixParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Include deleted blobs, by default get blob won't include deleted blobs", ParameterSetName = SingleBlobSnapshotTimeParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Include deleted blobs, by default get blob won't include deleted blobs", ParameterSetName = SingleBlobVersionIDParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeDeleted { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Blob versions will be listed only if this parameter is present, by default get blob won't include blob versions.", ParameterSetName = PrefixParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeVersion { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Include blob tags, by default get blob won't include blob tags.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeTag { get; set; }

        [Parameter(HelpMessage = "Blob SnapshotTime", Mandatory = true, ParameterSetName = SingleBlobSnapshotTimeParameterSet)]
        [ValidateNotNullOrEmpty]
        public DateTimeOffset? SnapshotTime { get; set; }

        [Parameter(HelpMessage = "Blob VersionId", Mandatory = true, ParameterSetName = SingleBlobVersionIDParameterSet)]
        [ValidateNotNullOrEmpty]
        public string VersionId { get; set; }

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

        private bool NeedWarningForContinuationToken = false;

        // Overwrite the parameter, function
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = NameParameterSet)]
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = SingleBlobSnapshotTimeParameterSet)]
        [Parameter(HelpMessage = "Optional Query statement to apply to the Tags of the Blob. The blob request will fail when the blob tags not match the given tag conditions.", Mandatory = false, ParameterSetName = SingleBlobVersionIDParameterSet)]
        [ValidateNotNullOrEmpty]
        public override string TagCondition { get; set; }

        protected override bool UseTrack2Sdk()
        {
            if (this.IncludeVersion.IsPresent || this.IncludeTag.IsPresent || this.VersionId != null)
            {
                return true;
            }
            return base.UseTrack2Sdk();
        }

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
        /// <param name="taskId">Task id</param>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="containerName">container name</param>
        /// <param name="blobName">blob name pattern</param>
        /// <param name="includeDeleted"></param>
        /// <param name="includeVersion"></param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByName(long taskId, IStorageBlobManagement localChannel, string containerName, string blobName, bool includeDeleted = false, bool includeVersion = false)
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

                Func<string, bool> blobFilter = (blobNameToFilte) => wildcard == null || wildcard.IsMatch(blobNameToFilte);
                await ListBlobsByPrefix(taskId, localChannel, containerName, prefix, blobFilter, includeDeleted, IncludeVersion).ConfigureAwait(false);
            }
            else
            {
                container = await GetCloudBlobContainerByName(localChannel, containerName, true).ConfigureAwait(false);
                BlobContainerClient track2container = AzureStorageContainer.GetTrack2BlobContainerClient(container, localChannel.StorageContext, ClientOptions);

                if (!NameUtil.IsValidBlobName(blobName))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
                }

                BlobBaseClient blobClient = null;
                if (UseTrack2Sdk()) // User Track2 SDK
                {
                    blobClient = Util.GetTrack2BlobClient(track2container, blobName, localChannel.StorageContext, this.VersionId, false, this.SnapshotTime is null ? null : this.SnapshotTime.Value.ToString("o"), ClientOptions);
                    global::Azure.Storage.Blobs.Models.BlobProperties blobProperties;
                    try
                    {
                        blobProperties = blobClient.GetProperties(BlobRequestConditions, cancellationToken: CmdletCancellationToken);
                    }
                    catch (global::Azure.RequestFailedException e) when (e.Status == 404)
                    {
                        throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, blobName, containerName));
                    }
                    blobClient = Util.GetTrack2BlobClient(track2container, blobName, localChannel.StorageContext, this.VersionId, blobProperties.IsLatestVersion, this.SnapshotTime is null ? null : this.SnapshotTime.Value.ToString("o"), ClientOptions, blobProperties.BlobType);

                    AzureStorageBlob outputBlob = new AzureStorageBlob(blobClient, localChannel.StorageContext, blobProperties, ClientOptions);
                    if (this.IncludeTag.IsPresent)
                    {
                        IDictionary<string, string> tags = (await blobClient.GetTagsAsync(null, this.CmdletCancellationToken).ConfigureAwait(false)).Value.Tags;
                        if (tags != null)
                        {
                            outputBlob.Tags = tags.ToHashtable();
                            outputBlob.TagCount = tags.Count;
                        }
                    }
                    OutputStream.WriteObject(taskId, outputBlob);
                }
                else // Use Track1 SDK
                {
                    CloudBlob blob = await localChannel.GetBlobReferenceFromServerAsync(container, blobName, this.SnapshotTime, accessCondition, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);

                    if (null == blob)
                    {
                        throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, blobName, containerName));
                    }
                    else
                    {
                        OutputStream.WriteObject(taskId, new AzureStorageBlob(blob, localChannel.StorageContext, ClientOptions));
                    }
                }
            }
        }

        /// <summary>
        /// list blobs by blob prefix and container name
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="containerName">container name</param>
        /// <param name="prefix">blob preifx</param>
        /// <param name="blobFilter"></param>
        /// <param name="includeDeleted"></param>
        /// <param name="includeVersion"></param>
        /// <returns>An enumerable collection of IListBlobItem</returns>
        internal async Task ListBlobsByPrefix(long taskId, IStorageBlobManagement localChannel, string containerName, string prefix, Func<string, bool> blobFilter = null, bool includeDeleted = false, bool includeVersion = false)
        {
            CloudBlobContainer container = await GetCloudBlobContainerByName(localChannel, containerName).ConfigureAwait(false);
            BlobContainerClient track2container = AzureStorageContainer.GetTrack2BlobContainerClient(container, localChannel.StorageContext, ClientOptions);

            int listCount = InternalMaxCount;
            int MaxListCount = 5000;
            int requestCount = MaxListCount;
            int realListCount = 0;
            BlobContinuationToken continuationToken = ContinuationToken;
            string track2ContinuationToken = this.ContinuationToken is null ? null : this.ContinuationToken.NextMarker;

            if (UseTrack2Sdk()) // For new feature only available on Track2 SDK, need list with Track2 SDK.
            {
                BlobTraits blobTraits = BlobTraits.Metadata | BlobTraits.CopyStatus; // | BlobTraits.Tags;
                BlobStates blobStates = BlobStates.Snapshots;
                if (includeDeleted)
                {
                    blobStates = blobStates | BlobStates.Deleted;
                }
                if (includeVersion)
                {
                    blobStates = blobStates | BlobStates.Version;
                }
                if (IncludeTag.IsPresent)
                {
                    blobTraits = blobTraits | BlobTraits.Tags;
                }

                do
                {
                    requestCount = Math.Min(listCount, MaxListCount);
                    realListCount = 0;
                    IEnumerator<Page<BlobItem>> enumerator = track2container.GetBlobs(blobTraits, blobStates, prefix, CmdletCancellationToken)
                        .AsPages(track2ContinuationToken, requestCount)
                        .GetEnumerator();

                    Page<BlobItem> page;
                    enumerator.MoveNext();
                    page = enumerator.Current;
                    foreach (BlobItem item in page.Values)
                    {
                        if (blobFilter == null || blobFilter(item.Name))
                        {
                            OutputStream.WriteObject(taskId, GetAzureStorageBlob(item, track2container, localChannel.StorageContext, page.ContinuationToken, ClientOptions));
                        }
                        realListCount++;
                    }
                    track2ContinuationToken = page.ContinuationToken;

                    if (InternalMaxCount != int.MaxValue)
                    {
                        listCount -= realListCount;
                    }
                } while (listCount > 0 && !string.IsNullOrEmpty(track2ContinuationToken));
            }
            else
            {
                BlobRequestOptions requestOptions = RequestOptions;
                bool useFlatBlobListing = true;
                BlobListingDetails details = BlobListingDetails.Snapshots | BlobListingDetails.Metadata | BlobListingDetails.Copy;
                if (includeDeleted)
                {
                    details = details | BlobListingDetails.Deleted;
                }

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

                        if (blobFilter == null || blobFilter(blob.Name))
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
        }

        public static AzureStorageBlob GetAzureStorageBlob(BlobItem blobItem, BlobContainerClient track2container, AzureStorageContext context, string continuationToken = null, BlobClientOptions options = null)
        {
            BlobBaseClient blobClient = Util.GetTrack2BlobClient(track2container, blobItem.Name, context, blobItem.VersionId, blobItem.IsLatestVersion, blobItem.Snapshot, options, blobItem.Properties.BlobType);
            AzureStorageBlob outputblob = new AzureStorageBlob(blobClient, context, options, blobItem);
            if (!string.IsNullOrEmpty(continuationToken))
            {
                BlobContinuationToken token = new BlobContinuationToken();
                token.NextMarker = continuationToken;
                outputblob.ContinuationToken = token;
            }
            return outputblob;
        }

        public static AzureStorageBlob GetAzureStorageBlob(TaggedBlobItem blobTagItem, BlobContainerClient track2container, AzureStorageContext context, string continuationToken = null, BlobClientOptions options = null)
        {
            BlobBaseClient blobClient = Util.GetTrack2BlobClient(track2container, blobTagItem.BlobName, context, options: options);
            AzureStorageBlob outputblob = new AzureStorageBlob(blobClient, context, options);
            if (!string.IsNullOrEmpty(continuationToken))
            {
                BlobContinuationToken token = new BlobContinuationToken();
                token.NextMarker = continuationToken;
                outputblob.ContinuationToken = token;
            }
            return outputblob;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = null;
            IStorageBlobManagement localChannel = Channel;

            if (ParameterSetName == PrefixParameterSet)
            {
                string localContainerName = containerName;
                string localPrefix = blobPrefix;
                taskGenerator = (taskId) => ListBlobsByPrefix(taskId, localChannel, localContainerName, localPrefix, includeDeleted: IncludeDeleted.IsPresent, includeVersion: IncludeVersion.IsPresent);
            }
            else
            {
                string localContainerName = containerName;
                string localBlobName = blobName;
                taskGenerator = (taskId) => ListBlobsByName(taskId, localChannel, localContainerName, localBlobName, includeDeleted: IncludeDeleted.IsPresent, includeVersion: IncludeVersion.IsPresent);
            }
            if (NeedWarningForContinuationToken)
            {
                WriteWarning(string.Format("Not all result returned, to list the left items run this cmdlet again with last blob's ContinuationToken."));
            }

            RunTask(taskGenerator);
        }
    }
}
