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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// remove specified azure container
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, StorageNouns.Container, SupportsShouldProcess = true),
        OutputType(typeof(Boolean))]
    public class RemoveAzureStorageContainerCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Container")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container Name",
             ValueFromPipeline = true,
           ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(HelpMessage = "Force to remove the container and all content in it")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }
        private bool force;

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified container is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageContainerCommand class.
        /// </summary>
        public RemoveAzureStorageContainerCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageContainerCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveAzureStorageContainerCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// remove azure container by container name
        /// </summary>
        /// <param name="name">container name</param>
        internal async Task RemoveAzureContainer(long taskId, IStorageBlobManagement localChannel, string name)
        {
            if (!NameUtil.IsValidContainerName(name))
            {
                throw new ArgumentException(String.Format(Resources.InvalidContainerName, name));
            }

            BlobRequestOptions requestOptions = RequestOptions;
            AccessCondition accessCondition = null;

            CloudBlobContainer container = localChannel.GetContainerReference(name);

            if (!await localChannel.DoesContainerExistAsync(container, requestOptions, OperationContext, CmdletCancellationToken))
            {
                throw new ResourceNotFoundException(String.Format(Resources.ContainerNotFound, name));
            }

            string result = string.Empty;
            bool removed = false;

            if (force || ContainerIsEmpty(container) || OutputStream.ConfirmAsync(String.Format("Remove container and all content in it: {0}", name)).Result)
            {
                await localChannel.DeleteContainerAsync(container, accessCondition, requestOptions, OperationContext, CmdletCancellationToken);
                result = String.Format(Resources.RemoveContainerSuccessfully, name);
                removed = true;
            }
            else
            {
                result = String.Format(Resources.RemoveContainerCancelled, name);
            }

            OutputStream.WriteVerbose(taskId, result);

            if (PassThru)
            {
                OutputStream.WriteObject(taskId, removed);
            }
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
            if (ShouldProcess(Name, "Remove container"))
            {
                string localName = Name;
                IStorageBlobManagement localChannel = Channel;
                Func<long, Task> taskGenerator = (taskId) => RemoveAzureContainer(taskId, localChannel, localName);
                RunTask(taskGenerator);
            }
        }
    }
}
