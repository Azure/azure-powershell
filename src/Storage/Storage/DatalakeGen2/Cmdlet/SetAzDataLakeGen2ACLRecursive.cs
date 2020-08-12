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
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
    using global::Azure.Storage.Files.DataLake;
    using global::Azure.Storage.Files.DataLake.Models;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// create a new azure FileSystem
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "DataLakeGen2AclRecursive", SupportsShouldProcess = true), OutputType(typeof(PSACLRecursiveChangeResult))]
    public class SetAzDataLakeGen2AclRecursiveCommand : DataLakeGen2ACLRecursiveBaseCmdlet
    {
        /// <summary>
        /// Initializes a new instance of the SetAzDataLakeGen2ItemCommand class.
        /// </summary>
        public SetAzDataLakeGen2AclRecursiveCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzDataLakeGen2ItemCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzDataLakeGen2AclRecursiveCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        /// <summary>
        /// execute command
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IStorageBlobManagement localChannel = Channel;
            progressRecord = GetProgressRecord("Set");
            continuationToken = this.ContinuationToken;

            bool foundAFolder = false;

            DataLakeFileClient fileClient = null;
            DataLakeDirectoryClient dirClient = null;

            DataLakeFileSystemClient fileSystem = GetFileSystemClientByName(localChannel, this.FileSystem);
            foundAFolder = GetExistDataLakeGen2Item(fileSystem, this.Path, out fileClient, out dirClient);


            if (foundAFolder)
            {
                if (ShouldProcess(dirClient.Uri.ToString(), "Set Acl recursively on Directory: "))
                {
                    //do
                    //{
                        dirClient.SetAccessControlRecursive(PSPathAccessControlEntry.ParseAccessControls(this.Acl),
                            GetProgressHandler(),
                            this.accessControlChangeOptions,
                            continuationToken);
                    //} while (continuationToken != null && totalFailureCount == 0);
                }
            }
            else
            {
                if (ShouldProcess(fileClient.Uri.ToString(), "Set Acl recursively on File: "))
                {
                    //do
                    //{
                        fileClient.SetAccessControlRecursive(PSPathAccessControlEntry.ParseAccessControls(this.Acl),
                            GetProgressHandler(),
                            this.accessControlChangeOptions,
                            continuationToken);
                    //} while (continuationToken != null &&  totalFailureCount == 0);
                }
            }
            WriteResult();
        }
    }
}
