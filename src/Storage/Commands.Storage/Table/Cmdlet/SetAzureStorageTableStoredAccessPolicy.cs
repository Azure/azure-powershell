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

namespace Microsoft.WindowsAzure.Commands.Storage.Table.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.WindowsAzure.Commands.Storage.Table;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    [Cmdlet(VerbsCommon.Set, StorageNouns.TableStoredAccessPolicy, SupportsShouldProcess = true), OutputType(typeof(String))]
    public class SetAzureStorageTableStoredAccessPolicyCommand : StorageCloudTableCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Table Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Table { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a table. Permissions can be any not-empty subset of \"audqr\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expirty Time")]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(HelpMessage = "Set StartTime as null for the policy")]
        public SwitchParameter NoStartTime { get; set; }

        [Parameter(HelpMessage = "Set ExpiryTime as null for the policy")]
        public SwitchParameter NoExpiryTime { get; set; }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        public SetAzureStorageTableStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SetAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel</param>
        public SetAzureStorageTableStoredAccessPolicyCommand(IStorageTableManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        internal string SetAzureTableStoredAccessPolicy(IStorageTableManagement localChannel, string tableName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission, bool noStartTime, bool noExpiryTime)
        {
            DateTime? startTimeToSet = startTime;
            DateTime? expiryTimetoSet = expiryTime;

            //Get existing permissions
            CloudTable table = localChannel.GetTableReference(Table);
            TablePermissions tablePermissions = localChannel.GetTablePermissions(table);

            //Set the policy with new value
            if (!tablePermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            SharedAccessTablePolicy policy = tablePermissions.SharedAccessPolicies[policyName];
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessTablePolicy>(policy, startTime, expiryTime, permission, noStartTime, noExpiryTime);
            tablePermissions.SharedAccessPolicies[policyName] = policy;

            //Set permission back to table
            localChannel.SetTablePermissions(table, tablePermissions);
            WriteObject(AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessTablePolicy>(tablePermissions.SharedAccessPolicies, policyName));
            return policyName;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Table) || String.IsNullOrEmpty(Policy)) return;
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
                SetAzureTableStoredAccessPolicy(Channel, Table, Policy, StartTime, ExpiryTime, Permission, NoStartTime, NoExpiryTime);
            }
        }
    }
}


