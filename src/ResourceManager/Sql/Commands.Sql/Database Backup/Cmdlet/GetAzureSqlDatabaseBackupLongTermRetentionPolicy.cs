﻿// ----------------------------------------------------------------------------------
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

using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseBackupLongTermRetentionPolicy",
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlDatabaseBackupLongTermRetentionPolicyModel))]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseLongTermRetentionPolicy")]
    public class GetAzureSqlDatabaseBackupLongTermRetentionPolicy : AzureSqlDatabaseBackupLongTermRetentionPolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets whether or not to use the Long Term Retention Vaults.
        /// </summary>
        [CmdletParameterBreakingChange("Current", "Parameter is being deprecated without being replaced. Future default behavior will assume -Current is always true.")]
        [Parameter(Mandatory = false,
            HelpMessage = "If not provided, the command returns the legacy Long Term Retention policy information. Otherwise, the command returns the current version of the Long Term Retention policy.")]
        public SwitchParameter Current { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> GetEntity()
        {
            return new List<AzureSqlDatabaseBackupLongTermRetentionPolicyModel>()
            {
                ModelAdapter.GetDatabaseBackupLongTermRetentionPolicy(
                    this.ResourceGroupName,
                    this.ServerName,
                    this.DatabaseName,
                    Current.IsPresent)
            };
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> PersistChanges(
            IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> entity)
        {
            return entity;
        }
    }
}
