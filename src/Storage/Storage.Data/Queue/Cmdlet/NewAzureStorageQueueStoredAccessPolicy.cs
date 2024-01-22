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

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueueStoredAccessPolicy"), OutputType(typeof(String))]
    public class NewAzureStorageQueueStoredAccessPolicyCommand : StorageQueueBaseCmdlet
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Queue Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Queue { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier. Need to be unique in the Queue")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a queue. Permissions can be any not-empty subset of \"arup\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        public NewAzureStorageQueueStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public NewAzureStorageQueueStoredAccessPolicyCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Queue) || String.IsNullOrEmpty(Policy)) return;

            QueueClient queueClient = Util.GetTrack2QueueClient(this.Queue, (AzureStorageContext)this.Context, this.ClientOptions);
            IEnumerable<QueueSignedIdentifier> signedIdentifiers = queueClient.GetAccessPolicy(cancellationToken: CmdletCancellationToken).Value;

            // Check if the policy already exists
            foreach (QueueSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == this.Policy)
                {
                    throw new ResourceAlreadyExistException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, this.Policy));
                }
            }

            QueueSignedIdentifier signedIdentifier = new QueueSignedIdentifier();
            signedIdentifier.Id = this.Policy;
            signedIdentifier.AccessPolicy = new QueueAccessPolicy();
            if (this.StartTime != null)
            {
                signedIdentifier.AccessPolicy.StartsOn = this.StartTime;
            }
            if (this.ExpiryTime != null)
            {
                signedIdentifier.AccessPolicy.ExpiresOn = this.ExpiryTime;
            }
            if (!string.IsNullOrEmpty(this.Permission))
            {
                signedIdentifier.AccessPolicy.Permissions = AccessPolicyHelper.OrderQueuePermission(this.Permission);
            }

            List<QueueSignedIdentifier> newSignedIdentifiers = new List<QueueSignedIdentifier>(signedIdentifiers)
            {
                signedIdentifier
            };

            queueClient.SetAccessPolicy(newSignedIdentifiers);

            WriteObject(this.Policy);
        }
    }
}
