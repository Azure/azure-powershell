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

using Microsoft.Azure.Commands.Sql.Security.Model;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Security.Cmdlet
{
    /// <summary>
    /// Base class for the cmdlets that set all the properties relate to auditing.
    /// </summary>
    public abstract class SetAuditingSettingsBase : SqlDatabaseSecurityCmdletBase
    {
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage account to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the storage account")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the names of the event types to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Event types to audit")]
        [ValidateSet(Constants.Access, Constants.Schema, Constants.Data, Constants.Security, Constants.RevokePermissions, Constants.All, Constants.None, IgnoreCase = true)]
        public string[] EventType { get; set; }

        protected override bool writeResult() { return PassThru; }

        protected override void UpdatePolicy(AuditingPolicy policy)
        {
            base.UpdatePolicy(policy);
            policy.IsEnabled = true;
            if (StorageAccountName != null) policy.StorageAccountName = StorageAccountName;
            if (EventType != null && EventType.Length != 0) policy.EventType = EventType;
        }

    }
}
