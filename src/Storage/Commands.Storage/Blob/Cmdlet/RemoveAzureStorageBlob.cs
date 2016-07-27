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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    [Cmdlet(VerbsCommon.Remove, StorageNouns.Blob, DefaultParameterSetName = NameParameterSet, SupportsShouldProcess = true),
        OutputType(typeof(Boolean))]
    public class RemoveStorageAzureBlobCommand : StorageCloudBlobCmdletBase
    {
        /// <summary>
        /// Blob Pipeline parameter set name
        /// </summary>
        private const string BlobPipelineParameterSet = "BlobPipeline";

        /// <summary>
        /// container pipeline paremeter set name
        /// </summary>
        private const string ContainerPipelineParameterSet = "ContainerPipeline";

        /// <summary>
        /// blob name and container name parameter set
        /// </summary>
        private const string NameParameterSet = "NamePipeline";

        [Alias("ICloudBlob")]
        [Parameter(HelpMessage = "CloudBlob Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = BlobPipelineParameterSet)]
        public CloudBlob CloudBlob { get; set; }

        [Parameter(HelpMessage = "CloudBlobContainer Object", Mandatory = true,
            ValueFromPipelineByPropertyName = true, ParameterSetName = ContainerPipelineParameterSet)]
        public CloudBlobContainer CloudBlobContainer { get; set; }

        [Parameter(ParameterSetName = ContainerPipelineParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        [Parameter(ParameterSetName = NameParameterSet, Mandatory = true, Position = 0, HelpMessage = "Blob name")]
        public string Blob
        {
            get { return BlobName; }
            set { BlobName = value; }
        }
        private string BlobName = String.Empty;

        [Parameter(HelpMessage = "Container name", Mandatory = true, Position = 1,
            ParameterSetName = NameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Container
        {
            get { return ContainerName; }
            set { ContainerName = value; }
        }
        private string ContainerName = String.Empty;

        [Parameter(HelpMessage = "Only delete blob snapshots")]
        public SwitchParameter DeleteSnapshot
        {
            get { return deleteSnapshot; }
            set { deleteSnapshot = value; }
        }
        private bool deleteSnapshot;

        [Parameter(HelpMessage = "Force to remove the blob and its snapshot")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force = false;

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified blob is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        public RemoveStorageAzureBlobCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveStorageAzureBlobCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveStorageAzureBlobCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// remove the azure blob 
        /// </summary>
        /// <param name="blob">Cloudblob object</param>
        /// <param name="isValidBlob">whether the Cloudblob parameter is validated</param>
        /// <returns>true if the blob is removed successfully, false if user cancel the remove operation</returns>
        internal async Task RemoveAzureBlob(long taskId, IStorageBlobManagement localChannel, CloudBlob blob, bool isValidBlob)
        {
            if (!isValidBlob)
            {
                ValidatePipelineCloudBlob(blob);
            }

            ValidateBlobType(blob);

            DeleteSnapshotsOption deleteSnapshotsOption = DeleteSnapshotsOption.None;
            bool retryDeleteSnapshot = false;

            if (IsSnapshot(blob))
            {
                if (deleteSnapshot)
                {
                    throw new ArgumentException(String.Format(Resources.CannotDeleteSnapshotForSnapshot, blob.Name, blob.SnapshotTime));
                }
            }
            else
            {
                if (deleteSnapshot)
                {
                    deleteSnapshotsOption = DeleteSnapshotsOption.DeleteSnapshotsOnly;
                }
                else if (force)
                {
                    deleteSnapshotsOption = DeleteSnapshotsOption.IncludeSnapshots;
                }
                else
                {
                    retryDeleteSnapshot = true;
                }
            }

            try
            {
                await DeleteCloudAsync(taskId, localChannel, blob, deleteSnapshotsOption);
                retryDeleteSnapshot = false;
            }
            catch (StorageException e)
            {
                if (e.IsConflictException() && retryDeleteSnapshot)
                {
                    //If x-ms-delete-snapshots is not specified on the request and the blob has associated snapshots, the Blob service returns status code 409 (Conflict).
                    retryDeleteSnapshot = true;
                }
                else
                {
                    throw;
                }
            }

            if (retryDeleteSnapshot)
            {
                string message = string.Format(Resources.ConfirmRemoveBlobWithSnapshot, blob.Name, blob.Container.Name);

                if (await OutputStream.ConfirmAsync(message))
                {
                    deleteSnapshotsOption = DeleteSnapshotsOption.IncludeSnapshots;
                    await DeleteCloudAsync(taskId, localChannel, blob, deleteSnapshotsOption);
                }
                else
                {
                    string result = String.Format(Resources.RemoveBlobCancelled, blob.Name, blob.Container.Name);
                    OutputStream.WriteVerbose(taskId, result);
                }
            }
        }

        internal async Task DeleteCloudAsync(long taskId, IStorageBlobManagement localChannel, CloudBlob blob, DeleteSnapshotsOption deleteSnapshotsOption)
        {
            AccessCondition accessCondition = null;
            BlobRequestOptions requestOptions = null;

            await localChannel.DeleteCloudBlobAsync(blob, deleteSnapshotsOption, accessCondition,
                    requestOptions, OperationContext, CmdletCancellationToken);

            string result = String.Format(Resources.RemoveBlobSuccessfully, blob.Name, blob.Container.Name);

            OutputStream.WriteVerbose(taskId, result);

            if (PassThru)
            {
                OutputStream.WriteObject(taskId, true);
            }
        }

        /// <summary>
        /// remove azure blob
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        /// <param name="blobName">blob name</param>
        /// <returns>true if the blob is removed successfully, false if user cancel the remove operation</returns>
        internal async Task RemoveAzureBlob(long taskId, IStorageBlobManagement localChannel, CloudBlobContainer container, string blobName)
        {
            if (!NameUtil.IsValidBlobName(blobName))
            {
                throw new ArgumentException(String.Format(Resources.InvalidBlobName, blobName));
            }

            ValidatePipelineCloudBlobContainer(container);
            AccessCondition accessCondition = null;
            BlobRequestOptions requestOptions = null;

            CloudBlob blob = null;

            try
            {
                blob = await localChannel.GetBlobReferenceFromServerAsync(container, blobName, accessCondition,
                      requestOptions, OperationContext, CmdletCancellationToken);
            }
            catch (InvalidOperationException)
            {
                blob = null;
            }

            if (null == blob && container.ServiceClient.Credentials.IsSharedKey)
            {
                throw new ResourceNotFoundException(String.Format(Resources.BlobNotFound, blobName, container.Name));
            }
            else
            {
                //Construct the blob as CloudBlockBlob no matter what's the real blob type
                //We can't get the blob type if Credentials only have the delete permission and don't have read permission.
                blob = container.GetBlockBlobReference(blobName);
            }

            await RemoveAzureBlob(taskId, localChannel, blob, true);
        }

        /// <summary>
        /// remove azure blob
        /// </summary>
        /// <param name="containerName">container name</param>
        /// <param name="blobName">blob name</param>
        /// <returns>true if the blob is removed successfully, false if user cancel the remove operation</returns>
        internal async Task RemoveAzureBlob(long taskId, IStorageBlobManagement localChannel, string containerName, string blobName)
        {
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);
            await RemoveAzureBlob(taskId, localChannel, container, blobName);
        }

        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = null;
            IStorageBlobManagement localChannel = Channel;

            string action = "Remove blob";
            if (deleteSnapshot)
            {
                action = "Remove snapshots of blob";
            }
            else if (force)
            {
                action = "Remove blob and snapshots";
            }

            string blobName = BlobName;
            if (ParameterSetName == BlobPipelineParameterSet)
            {
                blobName = CloudBlob.Name;
            }

            if (ShouldProcess(blobName, action))
            { 
                switch (ParameterSetName)
                {
                    case BlobPipelineParameterSet:
                        CloudBlob localBlob = CloudBlob;
                        taskGenerator = (taskId) => RemoveAzureBlob(taskId, localChannel, localBlob, false);
                        break;

                    case ContainerPipelineParameterSet:
                        CloudBlobContainer localContainer = CloudBlobContainer;
                        string localName = BlobName;
                        taskGenerator = (taskId) => RemoveAzureBlob(taskId, localChannel, localContainer, localName);
                        break;

                    case NameParameterSet:
                    default:
                        string localContainerName = ContainerName;
                        string localBlobName = BlobName;
                        taskGenerator = (taskId) => RemoveAzureBlob(taskId, localChannel, localContainerName, localBlobName);
                        break;
                }
                RunTask(taskGenerator);
            }
        }
    }
}