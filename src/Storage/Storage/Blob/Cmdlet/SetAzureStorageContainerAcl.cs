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

namespace Microsoft.WindowsAzure.Commands.Storage.Cmdlet
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
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;

    /// <summary>
    /// set access level for specified container
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerAcl"),OutputType(typeof(AzureStorageContainer))]
    public class SetAzureStorageContainerAclCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Container")]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Container Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Alias("PublicAccess")]
        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Permission string Off/Blob/Container")]
        public BlobContainerPublicAccessType Permission
        {
            get { return accessLevel; }
            set { accessLevel = value; }
        }
        private BlobContainerPublicAccessType accessLevel = BlobContainerPublicAccessType.Off;

        [Parameter(Mandatory = false, HelpMessage = "Display Container Information")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageContainerAclCommand class.
        /// </summary>
        public SetAzureStorageContainerAclCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageContainerAclCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzureStorageContainerAclCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// set the access level of specified container
        /// </summary>
        /// <param name="name">container name</param>
        /// <param name="accessLevel">access level in ("off", "blob", "container")</param>
        internal async Task SetContainerAcl(long taskId, IStorageBlobManagement localChannel, string name, BlobContainerPublicAccessType accessLevel)
        {
            if (!NameUtil.IsValidContainerName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;
            bool needUseTrack2 = false;

            CloudBlobContainer container = localChannel.GetContainerReference(name);

            // Get container permission and set the public access as input
            BlobContainerPermissions permissions = null;
            try
            {
                permissions = localChannel.GetContainerPermissions(container, null, requestOptions, OperationContext);
            }
            catch (StorageException e) when (e.IsNotFoundException())
            {
                throw new ResourceNotFoundException(String.Format(Resources.ContainerNotFound, name));
            }
            catch (StorageException e) when (e.IsConflictException())
            {
                // 409 Conflict, might caused by the container has an Stored access policy contains a permission that is not supported by Track1 SDK API veresion, so switch to Track2 SDK
                needUseTrack2 = true;
            }

            if (!needUseTrack2) // Track1
            {
                permissions.PublicAccess = accessLevel;

                await localChannel.SetContainerPermissionsAsync(container, permissions, accessCondition, requestOptions, OperationContext, CmdletCancellationToken).ConfigureAwait(false);

                if (PassThru)
                {
                    WriteCloudContainerObject(taskId, localChannel, container, permissions);
                }
            }
            else // Track2
            {
                BlobContainerClient containerClient = AzureStorageContainer.GetTrack2BlobContainerClient(container, this.Channel.StorageContext, ClientOptions);

                // Get container permission and set the public access as input
                BlobContainerAccessPolicy accessPolicy;

                accessPolicy = containerClient.GetAccessPolicy(null, this.CmdletCancellationToken);

                PublicAccessType publicAccessType = PublicAccessType.None;
                switch (accessLevel)
                {
                    case BlobContainerPublicAccessType.Blob:
                        publicAccessType = PublicAccessType.Blob;
                        break;
                    case BlobContainerPublicAccessType.Container:
                        publicAccessType = PublicAccessType.BlobContainer;
                        break;
                    case BlobContainerPublicAccessType.Off:
                        publicAccessType = PublicAccessType.None;
                        break;
                    default:
                    case BlobContainerPublicAccessType.Unknown:
                        throw new ArgumentOutOfRangeException("Permission");

                }
                await containerClient.SetAccessPolicyAsync(publicAccessType, accessPolicy.SignedIdentifiers, null, this.CmdletCancellationToken).ConfigureAwait(false);

                if (PassThru)
                {
                    AzureStorageContainer storageContainer = new AzureStorageContainer(container, null);
                    storageContainer.Context = localChannel.StorageContext;
                    storageContainer.SetTrack2Permission();
                    OutputStream.WriteObject(taskId, storageContainer);
                }
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            string localName = Name;
            IStorageBlobManagement localChannel = Channel;
            Func<long, Task> taskGenerator = (taskId) => SetContainerAcl(taskId, localChannel, localName, accessLevel);
            RunTask(taskGenerator);
        }
    }
}
