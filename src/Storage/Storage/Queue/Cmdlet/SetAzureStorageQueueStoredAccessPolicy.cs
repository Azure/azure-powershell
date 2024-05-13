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

namespace Microsoft.WindowsAzure.Commands.Storage.Queue.Cmdlet
{
    using global::Azure.Storage.Queues;
    using global::Azure.Storage.Queues.Models;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueueStoredAccessPolicy", SupportsShouldProcess = true), OutputType(typeof(String))]
    public class SetAzureStorageQueueStoredAccessPolicyCommand : StorageQueueBaseCmdlet
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Queue Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Queue { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a queue. Permissions can be any not-empty subset of \"arup\".")]
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
        /// Initializes a new instance of the SetAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        public SetAzureStorageQueueStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public SetAzureStorageQueueStoredAccessPolicyCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        internal string SetAzureQueueStoredAccessPolicy(string queueName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission, bool noStartTime, bool noExpiryTime)
        {
            //Get existing permissions
            QueueClient queueClient = Util.GetTrack2QueueClient(queueName, (AzureStorageContext)this.Context, this.ClientOptions);
            IEnumerable<QueueSignedIdentifier> signedIdentifiers = queueClient.GetAccessPolicy(this.CmdletCancellationToken).Value;

            // Find the policy to set
            QueueSignedIdentifier signedIdentifier = null;
            foreach (QueueSignedIdentifier identifier in signedIdentifiers)
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
                signedIdentifier.AccessPolicy.StartsOn = null;
            }
            else if (startTime != null)
            {
                signedIdentifier.AccessPolicy.StartsOn = startTime.Value.ToUniversalTime();
            }

            if (noExpiryTime)
            {
                signedIdentifier.AccessPolicy.ExpiresOn = null;
            }
            else if (expiryTime != null)
            {
                signedIdentifier.AccessPolicy.ExpiresOn = expiryTime.Value.ToUniversalTime();
            }

            if (permission != null)
            {
                signedIdentifier.AccessPolicy.Permissions = AccessPolicyHelper.OrderQueuePermission(permission);
            }

            queueClient.SetAccessPolicy(signedIdentifiers, this.CmdletCancellationToken);
            WriteObject(AccessPolicyHelper.ConstructPolicyOutputPSObject<QueueSignedIdentifier>(signedIdentifier));
            return policyName;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Queue) || String.IsNullOrEmpty(Policy)) return;
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
                SetAzureQueueStoredAccessPolicy(Queue, Policy, StartTime, ExpiryTime, Permission, NoStartTime, NoExpiryTime);
            }
        }
    }
}
