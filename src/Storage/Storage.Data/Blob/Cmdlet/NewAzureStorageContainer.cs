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
    using Microsoft.Azure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using global::Azure;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainer", DefaultParameterSetName = ContainerNameParameterSet),OutputType(typeof(AzureStorageContainer))]
    [Alias("New-" + Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DatalakeGen2FileSystem")]
    public class NewAzureStorageContainerCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Container Name parameter
        /// </summary>
        private const string ContainerNameParameterSet = "ContainerName";

        /// <summary>
        /// Container create with EncryptionScope parameter
        /// </summary>
        private const string EncryptionScopeParameterSet = "EncryptionScope";

        [Alias("N", "Container")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Container name",
            ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("PublicAccess")]
        [Parameter(Position = 1, Mandatory = false,
            HelpMessage = "Permission string Off/Blob/Container")]

        public BlobContainerPublicAccessType? Permission
        {
            get { return accessLevel; }
            set { accessLevel = value.Value; }
        }
        private BlobContainerPublicAccessType accessLevel = BlobContainerPublicAccessType.Off;

        [Parameter(HelpMessage = "Default the container to use specified encryption scope for all writes.",
            Mandatory = true,
            ParameterSetName = EncryptionScopeParameterSet)]
        [ValidateNotNullOrEmpty]
        public string DefaultEncryptionScope { get; set; }

        [Parameter(HelpMessage = "Prevent override of encryption scope from the container default.",
            Mandatory = true,
            ParameterSetName = EncryptionScopeParameterSet)]
        [ValidateNotNullOrEmpty]
        public bool PreventEncryptionScopeOverride
        {
            get
            {
                return preventEncryptionScopeOverride is null ? false : preventEncryptionScopeOverride.Value;
            }
            set
            {
                preventEncryptionScopeOverride = value;
            }
        }
        private bool? preventEncryptionScopeOverride;

        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerCommand class.
        /// </summary>
        public NewAzureStorageContainerCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageContainerCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// create a new azure container
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="localChannel">IStorageBlobManagement channel object</param>
        /// <param name="name">container name</param>
        /// <param name="accesslevel">access level in ("off", "blob", "container")</param>
        internal async Task CreateAzureContainer(long taskId, IStorageBlobManagement localChannel, string name, BlobContainerPublicAccessType accesslevel)
        {
            if (!NameUtil.IsValidContainerName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container = localChannel.GetContainerReference(name);
            BlobContainerClient containerClient = AzureStorageContainer.GetTrack2BlobContainerClient(container, localChannel.StorageContext);

            PublicAccessType containerPublicAccess = PublicAccessType.None;
            if (accesslevel == BlobContainerPublicAccessType.Blob)
            {
                containerPublicAccess = PublicAccessType.Blob;
            }
            else if (accesslevel == BlobContainerPublicAccessType.Container)
            {
                containerPublicAccess = PublicAccessType.BlobContainer;
            }

            global::Azure.Storage.Blobs.Models.BlobContainerEncryptionScopeOptions encryptionScopeOption = null;
            if (this.DefaultEncryptionScope != null)
            {
                encryptionScopeOption = new global::Azure.Storage.Blobs.Models.BlobContainerEncryptionScopeOptions()
                {
                    // parameterset can ensure the 2 parameters must be set together.
                    DefaultEncryptionScope = this.DefaultEncryptionScope,
                    PreventEncryptionScopeOverride = this.preventEncryptionScopeOverride.Value
                };
            }

            Response<BlobContainerInfo> responds  = await containerClient.CreateIfNotExistsAsync(containerPublicAccess, null, encryptionScopeOption, CmdletCancellationToken).ConfigureAwait(false);
            if (responds == null || responds.Value == null) // Container already exist so not created again
            {
                throw new ResourceAlreadyExistException(String.Format(Resources.ContainerAlreadyExists, name));
            }

            BlobContainerPermissions permissions = new BlobContainerPermissions() { PublicAccess = accesslevel };
            container.FetchAttributes();
            WriteCloudContainerObject(taskId, localChannel, container, permissions);
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            string localName = Name;
            Func<long, Task> taskGenerator = (taskId) => CreateAzureContainer(taskId, localChannel, localName, accessLevel);
            RunTask(taskGenerator);
        }
    }
}
