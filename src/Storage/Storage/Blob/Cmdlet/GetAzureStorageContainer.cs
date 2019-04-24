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
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// List azure storage container
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainer", DefaultParameterSetName = NameParameterSet),OutputType(typeof(AzureStorageContainer))]
    [Alias("Get-" + Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerAcl")]
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
        internal IEnumerable<Tuple<CloudBlobContainer, BlobContinuationToken>> ListContainersByName(string name)
        {
            string prefix = string.Empty;
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;

            if (String.IsNullOrEmpty(name) || WildcardPattern.ContainsWildcardCharacters(name))
            {
                prefix = NameUtil.GetNonWildcardPrefix(name);
                WildcardOptions options = WildcardOptions.IgnoreCase | WildcardOptions.Compiled;
                WildcardPattern wildcard = null;

                if (!string.IsNullOrEmpty(name))
                {
                    wildcard = new WildcardPattern(name, options);
                }

                Func<CloudBlobContainer, bool> containerFilter = (container) => null == wildcard || wildcard.IsMatch(container.Name);

                IEnumerable<Tuple<CloudBlobContainer, BlobContinuationToken>> containerList = ListContainersByPrefix(prefix, containerFilter);

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

                CloudBlobContainer container = Channel.GetContainerReference(name);

                if (Channel.DoesContainerExist(container, requestOptions, OperationContext))
                {
                    //fetch container attributes
                    Channel.FetchContainerAttributes(container, accessCondition, requestOptions, OperationContext);
                    yield return new Tuple<CloudBlobContainer, BlobContinuationToken>(container, null);
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(Resources.ContainerNotFound, name));
                }
            }
        }

        /// <summary>
        /// List containers by container name prefix
        /// </summary>
        /// <param name="prefix">Container name prefix</param>
        /// <returns>An enumerable collection of cloudblobcontainer</returns>
        internal IEnumerable<Tuple<CloudBlobContainer, BlobContinuationToken>> ListContainersByPrefix(string prefix, Func<CloudBlobContainer, bool> containerFilter = null)
        {
            ContainerListingDetails details = ContainerListingDetails.Metadata;
            BlobRequestOptions requestOptions = RequestOptions;

            if (!string.IsNullOrEmpty(prefix) && !NameUtil.IsValidContainerPrefix(prefix))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, prefix));
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

                ContainerResultSegment containerResult = Channel.ListContainersSegmented(prefix, details, requestCount, continuationToken, requestOptions, OperationContext);

                foreach (CloudBlobContainer container in containerResult.Results)
                {
                    if (containerFilter == null || containerFilter(container))
                    {
                        yield return new Tuple<CloudBlobContainer, BlobContinuationToken>(container, containerResult.ContinuationToken);
                        realListCount++;
                    }
                }

                if (InternalMaxCount != int.MaxValue)
                {
                    listCount -= realListCount;
                }

                continuationToken = containerResult.ContinuationToken;
            }
            while (listCount > 0 && continuationToken != null);
        }

        /// <summary>
        /// Pack CloudBlobContainer and it's permission to AzureStorageContainer object
        /// </summary>
        /// <param name="containerList">An enumerable collection of CloudBlobContainer</param>
        /// <returns>An enumerable collection of AzureStorageContainer</returns>
        internal void PackCloudBlobContainerWithAcl(IEnumerable<Tuple<CloudBlobContainer, BlobContinuationToken>> containerList)
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
            foreach (Tuple<CloudBlobContainer, BlobContinuationToken> containerInfo in containerList)
            {
                Func<long, Task> generator = (taskId) => GetContainerPermission(taskId, localChannel, containerInfo.Item1, containerInfo.Item2);
                RunTask(generator);
            }
        }

        /// <summary>
        /// Async get container permission
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="taskId">Task id</param>
        /// <param name="context">Azure storage context</param>
        /// <returns></returns>
        internal async Task GetContainerPermission(long taskId, IStorageBlobManagement localChannel, CloudBlobContainer container, BlobContinuationToken continuationToken)
        {
            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;
            BlobContainerPermissions permissions = null;
            try
            {
                permissions = await localChannel.GetContainerPermissionsAsync(container, accessCondition,
                    requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);
            }
            catch (StorageException e) when (e.IsNotFoundException() || e.IsForbiddenException())
            {
                // 404 Not found, or 403 Forbidden means we don't have permission to query the Permission of the specified container.
                // Just skip return container permission in this case.
            }
            WriteCloudContainerObject(taskId, localChannel, container, permissions, continuationToken);
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IEnumerable<Tuple<CloudBlobContainer, BlobContinuationToken>> containerList = null;

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
