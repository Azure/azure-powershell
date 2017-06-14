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
    [Cmdlet(VerbsCommon.Set, StorageNouns.ContainerStoredAccessPolicy, SupportsShouldProcess = true), OutputType(typeof(String))]
    public class SetAzureStorageContainerStoredAccessPolicyCommand : StorageCloudBlobCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Container name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Container { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a container. Permissions can be any non-empty subset of \"rdwl\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(HelpMessage = "Set StartTime as null for the policy")]
        public SwitchParameter NoStartTime { get; set; }

        [Parameter(HelpMessage = "Set ExpiryTime as null for the policy")]
        public SwitchParameter NoExpiryTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        public SetAzureStorageContainerStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageContainerStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzureStorageContainerStoredAccessPolicyCommand(IStorageBlobManagement channel)
            : base(channel)
        {
            EnableMultiThread = false;
        }

        internal string SetAzureContainerStoredAccessPolicy(IStorageBlobManagement localChannel, string containerName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission, bool noStartTime, bool noExpiryTime)
        {
            //Get existing permissions
            CloudBlobContainer container = localChannel.GetContainerReference(containerName);
            BlobContainerPermissions blobContainerPermissions = localChannel.GetContainerPermissions(container);

            //Set the policy with new value
            if (!blobContainerPermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            SharedAccessBlobPolicy policy = blobContainerPermissions.SharedAccessPolicies[policyName];
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessBlobPolicy>(policy, startTime, expiryTime, permission, noStartTime, noExpiryTime);
            blobContainerPermissions.SharedAccessPolicies[policyName] = policy;

            //Set permission back to container
            localChannel.SetContainerPermissions(container, blobContainerPermissions);
            WriteObject(AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessBlobPolicy>(blobContainerPermissions.SharedAccessPolicies, policyName));
            return policyName;
        }


        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Container) || String.IsNullOrEmpty(Policy)) return;
            if (NoStartTime && StartTime != null)
            {
                throw new ArgumentException(Resources.StartTimeParameterConflict);
            }

            if (NoExpiryTime && ExpiryTime != null)
            {
                throw new ArgumentException(Resources.ExpiryTimeParameterConflict);
            }

            if (ShouldProcess(Policy, "Set"))
            {
                SetAzureContainerStoredAccessPolicy(Channel, Container, Policy, StartTime, ExpiryTime, Permission, NoStartTime, NoExpiryTime);
            }
        }
    }
}
