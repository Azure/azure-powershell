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

    [Cmdlet(VerbsCommon.Remove, StorageNouns.TableStoredAccessPolicy, SupportsShouldProcess = true), OutputType(typeof(Boolean))]
    public class RemoveAzureStorageTableStoredAccessPolicyCommand : StorageCloudTableCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Table Name",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Table { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified policy is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        public RemoveAzureStorageTableStoredAccessPolicyCommand()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RemoveAzureStorageTableStoredAccessPolicyCommand class.
        /// </summary>
        /// <param name="channel">IStorageTableManagement channel</param>
        public RemoveAzureStorageTableStoredAccessPolicyCommand(IStorageTableManagement channel)
        {
            Channel = channel;
            EnableMultiThread = false;
        }

        internal bool RemoveAzureTableStoredAccessPolicy(IStorageTableManagement localChannel, string tableName, string policyName)
        {
            bool success = false;
            string result = string.Empty;

            //Get existing permissions
            CloudTable table = localChannel.GetTableReference(tableName);
            TablePermissions tablePermissions = localChannel.GetTablePermissions(table);

            //remove the specified policy
            if (!tablePermissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            if (ShouldProcess(policyName, "Remove policy"))
            {
                tablePermissions.SharedAccessPolicies.Remove(policyName);
                localChannel.SetTablePermissions(table, tablePermissions);
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
            if (String.IsNullOrEmpty(Table) || String.IsNullOrEmpty(Policy)) return;
            bool success = RemoveAzureTableStoredAccessPolicy(Channel, Table, Policy);
            string result = string.Empty;

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

