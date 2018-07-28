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
    [Cmdlet(VerbsCommon.New, StorageNouns.ContainerStoredAccessPolicy), OutputType(typeof(String))]
    public class NewAzureStorageContainerStoredAccessPolicyCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier. Need to be unique in the Container")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a container. Permissions can be any subset of \"rwdl\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        public NewAzureStorageContainerStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageContainerStoredAccessPolicyCommand(IStorageBlobManagement channel) :
            base(channel)
        {
            EnableMultiThread = false;
        }

        internal string CreateAzureContainerStoredAccessPolicy(IStorageBlobManagement localChannel, string containerName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission)
        {
            if (!NameUtil.IsValidStoredAccessPolicyName(policyName))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, policyName));
            }

            //Get existing permissions
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);
            BlobContainerPermissions blobContainerPermissions = localChannel.GetContainerPermissions(container);

            //Add new policy
            if (blobContainerPermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ResourceAlreadyExistException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, policyName));
            }

            SharedAccessBlobPolicy policy = new SharedAccessBlobPolicy();
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessBlobPolicy>(policy, startTime, expiryTime, permission);
            blobContainerPermissions.SharedAccessPolicies.Add(policyName, policy);

            //Set permissions back to container
            localChannel.SetContainerPermissions(container, blobContainerPermissions);
            return policyName;
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Container) || String.IsNullOrEmpty(Policy)) return;
            string resultPolicy = CreateAzureContainerStoredAccessPolicy(Channel, Container, Policy, StartTime, ExpiryTime, Permission);
            WriteObject(resultPolicy);
        }
    }
}
