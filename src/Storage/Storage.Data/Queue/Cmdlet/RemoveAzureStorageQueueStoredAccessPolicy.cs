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

    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueueStoredAccessPolicy", SupportsShouldProcess = true), OutputType(typeof(Boolean))]
    public class RemoveAzureStorageQueueStoredAccessPolicyCommand : StorageQueueBaseCmdlet
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Queue Name",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Queue { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified policy is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        public RemoveAzureStorageQueueStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public RemoveAzureStorageQueueStoredAccessPolicyCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        internal bool RemoveAzureQueueStoredAccessPolicy(string queueName, string policyName)
        {
            bool success = false;

            QueueClient queueClient = Util.GetTrack2QueueClient(queueName, (AzureStorageContext)this.Context, this.ClientOptions);
            IEnumerable<QueueSignedIdentifier> signedIdentifiers = queueClient.GetAccessPolicy(this.CmdletCancellationToken).Value;

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
                throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            if (ShouldProcess(policyName, "Remove policy"))
            {
                List<QueueSignedIdentifier> newSignedIdentifiers = new List<QueueSignedIdentifier>(signedIdentifiers);
                newSignedIdentifiers.Remove(signedIdentifier);

                queueClient.SetAccessPolicy(newSignedIdentifiers, this.CmdletCancellationToken);
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Queue) || String.IsNullOrEmpty(Policy)) return;
            bool success = RemoveAzureQueueStoredAccessPolicy(Queue, Policy);
            string result;
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
