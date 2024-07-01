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
    using System.Threading.Tasks;

    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageQueueStoredAccessPolicy"), OutputType(typeof(PSObject))]
    public class GetAzureStorageQueueStoredAccessPolicyCommand : StorageQueueBaseCmdlet
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Queue Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Queue { get; set; }

        [Parameter(Position = 1,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        public string Policy { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        public GetAzureStorageQueueStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageQueueStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageBlobManagement channel</param>
        public GetAzureStorageQueueStoredAccessPolicyCommand(IStorageQueueManagement channel)
        {
            Channel = channel;
        }

        internal async Task GetAzureQueueStoredAccessPolicyAsync(long taskId, string queueName, string policyName)
        {

            QueueClient queueClient = Util.GetTrack2QueueClient(queueName, (AzureStorageContext)this.Context, this.ClientOptions);
            IEnumerable<QueueSignedIdentifier> signedIdentifiers = (await queueClient.GetAccessPolicyAsync(this.CmdletCancellationToken)).Value;

            if (!String.IsNullOrEmpty(policyName))
            {
                QueueSignedIdentifier queueSignedIdentifier = null;
                foreach (QueueSignedIdentifier identifier in signedIdentifiers)
                {
                    if (identifier.Id == policyName)
                    {
                        queueSignedIdentifier = identifier;
                    }
                }
                if (queueSignedIdentifier == null)
                {
                    throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
                }
                else
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<QueueSignedIdentifier>(queueSignedIdentifier));
                }
            }
            else
            {
                foreach (QueueSignedIdentifier identifier in signedIdentifiers)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<QueueSignedIdentifier>(identifier));
                }
            }
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Queue)) return;
            Task taskGenerator(long taskId) => GetAzureQueueStoredAccessPolicyAsync(taskId, Queue, Policy);
            RunTask(taskGenerator);
        }
    }
}
