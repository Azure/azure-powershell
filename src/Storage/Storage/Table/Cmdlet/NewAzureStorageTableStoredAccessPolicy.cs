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

    [Cmdlet(VerbsCommon.New, StorageNouns.TableStoredAccessPolicy), OutputType(typeof(String))]
    public class NewAzureStorageTableStoredAccessPolicyCommand : StorageCloudTableCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Table Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Table { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier. Need to be unique in the Table")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a table. Permissions can be any not-empty subset of \"audqr\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }


        /// <summary>
        /// Initializes a new instance of the NewAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        public NewAzureStorageTableStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the NewAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel</param>
        public NewAzureStorageTableStoredAccessPolicyCommand(IStorageTableManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        internal string CreateAzureTableStoredAccessPolicy(IStorageTableManagement localChannel, string tableName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission)
        {

            if (!NameUtil.IsValidStoredAccessPolicyName(policyName))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, policyName));
            }

            //Get existing permissions
            CloudTable table = localChannel.GetTableReference(tableName);
            TablePermissions tablePermissions = localChannel.GetTablePermissions(table);

            //Add new policy
            if (tablePermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ResourceAlreadyExistException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, policyName));
            }

            SharedAccessTablePolicy policy = new SharedAccessTablePolicy();
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessTablePolicy>(policy, startTime, expiryTime, permission);
            tablePermissions.SharedAccessPolicies.Add(policyName, policy);

            //Set permissions back to table
            localChannel.SetTablePermissions(table, tablePermissions);
            return policyName;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(Table) || String.IsNullOrEmpty(Policy)) return;
            string resultPolicy = CreateAzureTableStoredAccessPolicy(Channel, Table, Policy, StartTime, ExpiryTime, Permission);
            WriteObject(resultPolicy);
        }
    }
}
