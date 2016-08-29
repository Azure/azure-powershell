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
    using System.Threading.Tasks;

    [Cmdlet(VerbsCommon.Get, StorageNouns.QueueStoredAccessPolicy), OutputType(typeof(SharedAccessQueuePolicy))]
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

        internal async Task GetAzureQueueStoredAccessPolicyAsync(long taskId, IStorageQueueManagement localChannel, string queueName, string policyName)
        {
            SharedAccessQueuePolicies shareAccessPolicies = await GetPoliciesAsync(localChannel, queueName, policyName);

            if (!String.IsNullOrEmpty(policyName))
            {
                if (shareAccessPolicies.Keys.Contains(policyName))
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessQueuePolicy>(shareAccessPolicies, policyName));
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
                }
            }
            else
            {
                foreach (string key in shareAccessPolicies.Keys)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessQueuePolicy>(shareAccessPolicies, key));
                }
            }
        }

        internal async Task<SharedAccessQueuePolicies> GetPoliciesAsync(IStorageQueueManagement localChannel, string queueName, string policyName)
        {
            CloudQueue queue = localChannel.GetQueueReference(queueName);
            QueuePermissions queuePermissions = await localChannel.GetPermissionsAsync(queue);
            return queuePermissions.SharedAccessPolicies;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Queue)) return;
            Func<long, Task> taskGenerator = (taskId) => GetAzureQueueStoredAccessPolicyAsync(taskId, Channel, Queue, Policy);
            RunTask(taskGenerator);
        }


    }
}
