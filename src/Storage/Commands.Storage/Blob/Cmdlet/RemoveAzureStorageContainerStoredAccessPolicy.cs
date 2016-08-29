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
    using Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Model.Contract;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, StorageNouns.ContainerStoredAccessPolicy, SupportsShouldProcess = true), OutputType(typeof(Boolean))]
    public class RemoveAzureStorageContainerStoredAccessPolicyCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container name",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified policy is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        public RemoveAzureStorageContainerStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveAzureStorageContainerStoredAccessPolicyCommand(IStorageBlobManagement channel)
            : base(channel)
        {
            EnableMultiThread = false;
        }

        internal bool RemoveAzureContainerStoredAccessPolicy(IStorageBlobManagement localChannel, string containerName, string policyName)
        {
            bool success = false;
            string result = string.Empty;

            //Get existing permissions
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);
            BlobContainerPermissions blobContainerPermissions = localChannel.GetContainerPermissions(container);

            //remove the specified policy
            if (!blobContainerPermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            if (ShouldProcess(policyName, "Remove policy"))
            {
                blobContainerPermissions.SharedAccessPolicies.Remove(policyName);
                localChannel.SetContainerPermissions(container, blobContainerPermissions);
                success = true;
            }

            return success;
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Container) || String.IsNullOrEmpty(Policy)) return;
            bool success = RemoveAzureContainerStoredAccessPolicy(Channel, Container, Policy);
            string result = string.Empty;

            if (success)
            {
                result = String.Format(CultureInfo.CurrentCulture, Resources.RemovePolicySuccessfully, Policy);
            }
            else
            {
                result = String.Format(CultureInfo.CurrentCulture, Resources.RemovePolicyCancelled, Policy);
            }

            WriteVerbose(result);

            if (PassThru)
            {
                WriteObject(success);
            }
        }
    }
}

