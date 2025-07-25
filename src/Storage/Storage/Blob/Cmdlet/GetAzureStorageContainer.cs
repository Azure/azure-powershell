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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// List azure storage container
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainer", DefaultParameterSetName = NameParameterSet),OutputType(typeof(AzureStorageContainer))]
    [Alias("Get-" + Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerAcl", "Get-" + Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DatalakeGen2FileSystem")]
    public class GetAzureStorageContainerCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Default parameter set name
        /// </summary>
        private const string NameParameterSet = "ContainerName";

        /// <summary>
        /// Prefix parameter set name
        /// </summary>
        private const string PrefixParameterSet = "ContainerPrefix";

        [Alias("N", "Container")]
        [Parameter(Position = 0, HelpMessage = "Container Name",
            ValueFromPipeline = true,
             ValueFromPipelineByPropertyName = true,
           ParameterSetName = NameParameterSet)]
        [SupportsWildcards()]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Container Prefix",
            ParameterSetName = PrefixParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The max count of the containers that can return.")]
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

        [Parameter(Mandatory = false, HelpMessage = "Include deleted containers, by default list containers won't include deleted containers")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter IncludeDeleted { get; set; }
        
        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageContainerCommand class.
        /// </summary>
        public GetAzureStorageContainerCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageContainerCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageContainerCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// List containers by container name pattern.
        /// </summary>
        /// <param name="name">Container name pattern</param>
        /// <returns>An enumerable collection of cloudblob container</returns>
        internal IEnumerable<Tuple<AzureStorageContainer, BlobContinuationToken>> ListContainersByName(string name)
        {
            string prefix = string.Empty;

            if (String.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name))
            {
                prefix = NameUtil.GetNonWildcardPrefix(name);
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!string.IsNullOrEmpty(name))
                {
                    wildcard = new WildcardPattern(name, options);
                }

                Func<string, bool> containerFilter = (containerName) => null == wildcard || wildcard.IsMatch(containerName);

                IEnumerable<Tuple<AzureStorageContainer, BlobContinuationToken>> containerList = ListContainersByPrefix(prefix, containerFilter);

                foreach (var containerInfo in containerList)
                {
                    yield return containerInfo;
                }
            }
            else
            {
                if (!NameUtil.IsValidContainerName(name))
                {
                    throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
                }
                if (this.IncludeDeleted.IsPresent)
                {
                    WriteWarning("Can't get single deleted container, so -IncludeDeleted will be omit when get single container with -Name.");
                }

                CloudBlobContainer container = Channel.GetContainerReference(name);
                BlobContainerClient containerClient = AzureStorageContainer.GetTrack2BlobContainerClient(container, this.Channel.StorageContext, ClientOptions);
                global::Azure.Storage.Blobs.Models.BlobContainerProperties properties = null;

                try
                {
                    properties = containerClient.GetProperties(cancellationToken: this.CmdletCancellationToken);
                }
                catch (global::Azure.RequestFailedException e) when (e.Status == 404)
                { 
                    throw new ResourceNotFoundException(String.Format(Resources.ContainerNotFound, name));
                }
                yield return new Tuple<AzureStorageContainer, BlobContinuationToken>(new AzureStorageContainer(containerClient, Channel.StorageContext, properties), null);
            }
        }

        /// <summary>
        /// List containers by container name prefix
        /// </summary>
        /// <param name="prefix">Container name prefix</param>
        /// <param name="containerFilter"></param>
        /// <returns>An enumerable collection of cloudblobcontainer</returns>
        internal IEnumerable<Tuple<AzureStorageContainer, BlobContinuationToken>> ListContainersByPrefix(string prefix, Func<string, bool> containerFilter = null)
        {
            BlobServiceClient blobServiceClient = Util.GetTrack2BlobServiceClient(this.Channel.StorageContext, ClientOptions);
            BlobContainerTraits traits = BlobContainerTraits.Metadata;
            BlobContainerStates states = BlobContainerStates.None;
            if (this.IncludeDeleted.IsPresent)
            {
                states = BlobContainerStates.Deleted;
            }
            if (!string.IsNullOrEmpty(prefix) && !NameUtil.IsValidContainerPrefix(prefix))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, prefix));
            }

            int listCount = InternalMaxCount;
            int MaxListCount = 5000;
            int requestCount = MaxListCount;
            int realListCount = 0;
            string continuationToken = this.ContinuationToken is null ? null : this.ContinuationToken.NextMarker;

            do
            {
                requestCount = Math.Min(listCount, MaxListCount);
                realListCount = 0;

                IEnumerator<Page< BlobContainerItem >> enumerator = blobServiceClient.GetBlobContainers(traits, states, prefix, this.CmdletCancellationToken)
                    .AsPages(continuationToken, requestCount)
                    .GetEnumerator();

                Page<BlobContainerItem> page;
                enumerator.MoveNext();
                page = enumerator.Current;

                foreach (BlobContainerItem item in page.Values)
                {
                    if (containerFilter == null || containerFilter(item.Name))
                    {
                        yield return new Tuple<AzureStorageContainer, BlobContinuationToken>(
                            new AzureStorageContainer(item, Channel.StorageContext, blobServiceClient),
                            string.IsNullOrEmpty(page.ContinuationToken) ? null : new BlobContinuationToken() {  NextMarker = page.ContinuationToken});
                        realListCount++;
                    }
                    realListCount++;
                }
                continuationToken = page.ContinuationToken;

                if (InternalMaxCount != int.MaxValue)
                {
                    listCount -= realListCount;
                }
            }
            while (listCount > 0 && !string.IsNullOrEmpty(continuationToken));
        }

        /// <summary>
        /// Pack CloudBlobContainer and it's permission to AzureStorageContainer object
        /// </summary>
        /// <param name="containerList">An enumerable collection of CloudBlobContainer</param>
        /// <returns>An enumerable collection of AzureStorageContainer</returns>
        internal void PackCloudBlobContainerWithAcl(IEnumerable<Tuple<AzureStorageContainer, BlobContinuationToken>> containerList)
        {
            if (null == containerList)
            {
                return;
            }

            // Only write warning for SAS when use cmdlet alias Get-AzStorageContainerAcl, since the cmdlets alias specified get container ACL
            if (this.MyInvocation.Line.ToLower().Contains("get-azstoragecontaineracl"))
            {
                // Write warning when user SAS credential since get container ACL will fail
                AzureStorageContext storageContext = this.GetCmdletStorageContext();
                if (storageContext != null && storageContext.StorageAccount != null && storageContext.StorageAccount.Credentials != null && storageContext.StorageAccount.Credentials.IsSAS)
                {
                    WriteWarning("Get container permission will fail with SAS token credentials, it needs storage Account key credentials.");
                }
            }

            IStorageBlobManagement localChannel = Channel;
            foreach (Tuple<AzureStorageContainer, BlobContinuationToken> containerInfo in containerList)
            {
                containerInfo.Item1.ContinuationToken = containerInfo.Item2;
                containerInfo.Item1.SetTrack2Permission();
                WriteObject(containerInfo.Item1);
            }
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<Tuple<AzureStorageContainer, BlobContinuationToken>> containerList = null;

            if (PrefixParameterSet == ParameterSetName)
            {
                containerList = ListContainersByPrefix(Prefix);
            }
            else
            {
                containerList = ListContainersByName(Name);
            }

            PackCloudBlobContainerWithAcl(containerList);
        }
    }
}
