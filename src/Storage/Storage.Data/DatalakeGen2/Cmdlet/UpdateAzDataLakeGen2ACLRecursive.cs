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
    using global::Azure.Storage.Files.DataLake;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// create a new azure FileSystem
    /// </summary>
    [Cmdlet("Update", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2AclRecursive", SupportsShouldProcess = true), OutputType(typeof(PSACLRecursiveChangeResult))]
    public class UpdateAzDataLakeGen2AclRecursiveCommand : DataLakeGen2ACLRecursiveBaseCmdlet
    {
        /// <summary>
        /// Initializes a new instance of the UpdateAzDataLakeGen2AclRecursiveCommand class.
        /// </summary>
        public UpdateAzDataLakeGen2AclRecursiveCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the UpdateAzDataLakeGen2AclRecursiveCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public UpdateAzDataLakeGen2AclRecursiveCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// Update ACL recusive async function
        /// </summary>
        protected override async Task OperationAclResusive(long taskId)
        {
            IStorageBlobManagement localChannel = Channel;
            progressRecord = GetProgressRecord("Update", taskId);
            continuationToken = this.ContinuationToken;

            bool foundAFolder = false;

            DataLakeFileClient fileClient = null;
            DataLakeDirectoryClient dirClient = null;

            DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
            foundAFolder = GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient);


            if (foundAFolder)
            {
                if (ShouldProcess(dirClient.Uri.ToString(), "Update Acl recursively on Directory: "))
                {
                    await dirClient.UpdateAccessControlRecursiveAsync(PSPathAccessControlEntry.ParseAccessControls(this.Acl),
                        continuationToken,
                        GetAccessControlChangeOptions(taskId),
                        CmdletCancellationToken).ConfigureAwait(false);

                    SetProgressComplete();
                    WriteResult(taskId);
                }
            }
            else
            {
                if (ShouldProcess(fileClient.Uri.ToString(), "Update Acl recursively on File: "))
                {
                    await fileClient.UpdateAccessControlRecursiveAsync(PSPathAccessControlEntry.ParseAccessControls(this.Acl),
                        continuationToken,
                        GetAccessControlChangeOptions(taskId),
                        CmdletCancellationToken).ConfigureAwait(false);

                    SetProgressComplete();
                    WriteResult(taskId);
                }
            }
        }
    }
}
