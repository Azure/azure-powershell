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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Storage.Queue;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.New, StorageNouns.QueueStoredAccessPolicy), OutputType(typeof(String))]
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

        internal string CreateAzureQueueStoredAccessPolicy(IStorageQueueManagement localChannel, string queueName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission)
        {

            if (!NameUtil.IsValidStoredAccessPolicyName(policyName))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, policyName));
            }

            //Get existing permissions
            CloudQueue queue = Channel.GetQueueReference(queueName);
            QueuePermissions queuePermissions = localChannel.GetPermissions(queue);

            //Add new policy
            if (queuePermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ResourceAlreadyExistException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, policyName));
            }

            SharedAccessQueuePolicy policy = new SharedAccessQueuePolicy();
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessQueuePolicy>(policy, startTime, expiryTime, permission);
            queuePermissions.SharedAccessPolicies.Add(policyName, policy);

            //Set permissions back to queue
            localChannel.SetPermissions(queue, queuePermissions);
            return policyName;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Queue) || String.IsNullOrEmpty(Policy)) return;
            string resultPolicy = CreateAzureQueueStoredAccessPolicy(Channel, Queue, Policy, StartTime, ExpiryTime, Permission);
            WriteObject(resultPolicy);
        }


    }
}
