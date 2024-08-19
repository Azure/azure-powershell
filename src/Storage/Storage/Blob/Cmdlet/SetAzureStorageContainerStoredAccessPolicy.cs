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
    using global::Azure.Storage.Blobs;
    using global::Azure.Storage.Blobs.Models;
    using Microsoft.Azure.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageContainerStoredAccessPolicy", SupportsShouldProcess = true), OutputType(typeof(PSObject))]
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

        [Parameter(HelpMessage = "Permissions for a container. Permissions can be any non-empty subset of \"racwdxlt\", make the permission order also same as it.")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(HelpMessage = "Set StartTime as null for the policy")]
        public SwitchParameter NoStartTime { get; set; }

        [Parameter(HelpMessage = "Set ExpiryTime as null for the policy")]
        public SwitchParameter NoExpiryTime { get; set; }

        // Overwrite the useless parameter
        public override string TagCondition { get; set; }

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
            //Get container instance, Get existing permissions
            CloudBlobContainer container_Track1 = Channel.GetContainerReference(containerName);
            BlobContainerClient container = AzureStorageContainer.GetTrack2BlobContainerClient(container_Track1, Channel.StorageContext, ClientOptions);
            BlobContainerAccessPolicy accessPolicy = container.GetAccessPolicy(cancellationToken: CmdletCancellationToken).Value;
            IEnumerable<BlobSignedIdentifier> signedIdentifiers = accessPolicy.SignedIdentifiers;

            //Set the policy with new value
            BlobSignedIdentifier signedIdentifier = null;
            foreach (BlobSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == policyName)
                {
                    signedIdentifier = identifier;
                }
            }

            if (signedIdentifier == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }
            if (noStartTime)
            {
                signedIdentifier.AccessPolicy.PolicyStartsOn = DateTimeOffset.MinValue;
            }

            else if (startTime != null)
            {
                signedIdentifier.AccessPolicy.PolicyStartsOn = StartTime.Value.ToUniversalTime();
            }
            if (noExpiryTime)
            {
                signedIdentifier.AccessPolicy.PolicyExpiresOn = null;
            }
            else if (ExpiryTime != null)
            {
                signedIdentifier.AccessPolicy.PolicyExpiresOn = ExpiryTime.Value.ToUniversalTime();
            }

            if (this.Permission != null)
            {
                signedIdentifier.AccessPolicy.Permissions = this.Permission;
                signedIdentifier.AccessPolicy.Permissions = AccessPolicyHelper.OrderBlobPermission(this.Permission);
            }

            //Set permissions back to container
            container.SetAccessPolicy(accessPolicy.BlobPublicAccess, signedIdentifiers, BlobRequestConditions, CmdletCancellationToken);
            WriteObject(AccessPolicyHelper.ConstructPolicyOutputPSObject<BlobSignedIdentifier>(signedIdentifier));
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
