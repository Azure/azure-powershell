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

using Microsoft.Azure.Commands.Sql.Auditing.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Services;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Auditing.Cmdlet
{
    /// <summary>
    /// Sets the auditing settings properties for a specific database.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseAuditing", SupportsShouldProcess = true), OutputType(typeof(DatabaseBlobAuditingSettingsModel))]
    public class SetAzureSqlDatabaseAuditing : SqlDatabaseAuditingSettingsCmdletBase
    {
        /// <summary>
        /// Gets or sets the state of the auditing policy
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = AuditingHelpMessages.StateHelpMessage)]
        [ValidateSet(SecurityConstants.Enabled, SecurityConstants.Disabled, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        /// <summary>
        ///  Defines whether the cmdlets will output the model object at the end of its execution
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        ///  Defines the set of audit action groups that would be used by the auditing settings
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = AuditingHelpMessages.AuditActionGroupsHelpMessage)]
        public AuditActionGroups[] AuditActionGroup { get; set; }

        /// <summary>
        ///  Defines the set of audit actions that would be used by the auditing settings
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = AuditingHelpMessages.AuditActionHelpMessage)]
        public string[] AuditAction { get; set; }

        /// <summary>
        /// Gets or sets the name of the storage account to use.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = AuditingHelpMessages.AuditStorageAccountNameHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        /// <summary>
        /// Gets or sets the type of the storage key.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = AuditingHelpMessages.StorageKeyTypeHelpMessage)]
        [ValidateSet(SecurityConstants.Primary, SecurityConstants.Secondary, IgnoreCase = false)]
        [ValidateNotNullOrEmpty]
        public string StorageKeyType { get; set; }

        /// <summary>
        /// Gets or sets the number of retention days for the audit logs.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = AuditingHelpMessages.RetentionInDaysHelpMessage)]
        [ValidateNotNullOrEmpty]
        public uint? RetentionInDays { get; internal set; }

        /// <summary>
        /// Returns true if the model object that was constructed by this cmdlet should be written out
        /// </summary>
        /// <returns>True if the model object should be written out, False otherwise</returns>
        protected override bool WriteResult() { return PassThru; }

        /// <summary>
        /// Updates the given model element with the cmdlet specific operation 
        /// </summary>
        /// <param name="model">A model object</param>
        protected override DatabaseBlobAuditingSettingsModel ApplyUserInputToModel(DatabaseBlobAuditingSettingsModel model)
        {
            base.ApplyUserInputToModel(model);

            model.AuditState = State == SecurityConstants.Enabled ? AuditStateType.Enabled : AuditStateType.Disabled;
            if (RetentionInDays != null)
            {
                model.RetentionInDays = RetentionInDays;
            }

            if (StorageAccountName != null)
            {
                model.StorageAccountName = StorageAccountName;
            }

            if (MyInvocation.BoundParameters.ContainsKey(SecurityConstants.StorageKeyType))
            {
                // the user enter a key type - we use it (and override the previously defined key type)
                model.StorageKeyType = (StorageKeyType == SecurityConstants.Primary)
                    ? StorageKeyKind.Primary
                    : StorageKeyKind.Secondary;
            }

            if (AuditActionGroup != null && AuditActionGroup.Length != 0)
            {
                model.AuditActionGroup = AuditActionGroup;
            }

            if (AuditAction != null && AuditAction.Length != 0)
            {
                model.AuditAction = AuditAction;
            }

            return model;
        }
    }
}
