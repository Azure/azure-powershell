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
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet(VerbsCommon.New, StorageNouns.Container),
        OutputType(typeof(AzureStorageContainer))]
    public class NewAzureStorageContainerCommand : StorageCloudBlobCmdletBase
    {
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
        /// <param name="name">container name</param>
        internal async Task CreateAzureContainer(long taskId, IStorageBlobManagement localChannel, string name, BlobContainerPublicAccessType accesslevel)
        {
            if (!NameUtil.IsValidContainerName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            CloudBlobContainer container = localChannel.GetContainerReference(name);

            BlobContainerPermissions permissions = new BlobContainerPermissions();

            permissions.PublicAccess = accesslevel;

            bool created = await localChannel.CreateContainerIfNotExistsAsync(container, permissions.PublicAccess, requestOptions, OperationContext, CmdletCancellationToken);

            if (!created)
            {
                throw new ResourceAlreadyExistException(String.Format(Resources.ContainerAlreadyExists, name));
            }

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
