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

namespace Microsoft.Azure.Commands.Storage.Table.Cmdlet
{
    using Microsoft.Azure.Commands.Storage.Common;
    using Microsoft.Azure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Commands.Storage.Table;
    using Microsoft.Azure.Cosmos.Table;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile("latest-2019-04-30")]
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageTableStoredAccessPolicy!V2"), OutputType(typeof(SharedAccessTablePolicy))]
    public class GetAzureStorageTableStoredAccessPolicyCommand : StorageCloudTableCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Table Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Table { get; set; }

        [Parameter(Position = 1,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        public string Policy { get; set; }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        public GetAzureStorageTableStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GetAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel</param>
        public GetAzureStorageTableStoredAccessPolicyCommand(IStorageTableManagement channel)
        {
            Channel = channel;
        }

        internal async Task GetAzureTableStoredAccessPolicyAsync(long taskId, IStorageTableManagement localChannel, string tableName, string policyName)
        {
            SharedAccessTablePolicies shareAccessPolicies = await GetPoliciesAsync(localChannel, tableName, policyName).ConfigureAwait(false);

            if (!String.IsNullOrEmpty(policyName))
            {
                if (shareAccessPolicies.Keys.Contains(policyName))
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessTablePolicy>(shareAccessPolicies, policyName));
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, ResourceV2.PolicyNotFound, policyName));
                }
            }
            else
            {
                foreach (string key in shareAccessPolicies.Keys)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessTablePolicy>(shareAccessPolicies, key));
                }
            }
        }

        internal async Task<SharedAccessTablePolicies> GetPoliciesAsync(IStorageTableManagement localChannel, string tableName, string policyName)
        {
            CloudTable table = localChannel.GetTableReference(tableName);
            TablePermissions tablePermissions = await localChannel.GetTablePermissionsAsync(table).ConfigureAwait(false);
            return tablePermissions.SharedAccessPolicies;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Table)) return;
            Func<long, Task> taskGenerator = (taskId) => GetAzureTableStoredAccessPolicyAsync(taskId, Channel, Table, Policy);
            RunTask(taskGenerator);
        }
    }
}
