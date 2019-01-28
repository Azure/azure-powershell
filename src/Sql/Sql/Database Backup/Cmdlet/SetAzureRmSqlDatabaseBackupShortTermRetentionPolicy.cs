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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Backup.Model;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseBackupShortTermRetentionPolicy",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PolicyByResourceServerDatabaseSet),
    OutputType(typeof(AzureSqlDatabaseBackupShortTermRetentionPolicyModel))]
    public class SetAzureRmSqlDatabaseBackupShortTermRetentionPolicy : AzureSqlDatabaseBackupShortTermRetentionPolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets backup retention days.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 3,
            HelpMessage = "The backup retention setting, in days.")]
        [ValidateNotNullOrEmpty]
        [ValidateRetentionDays]
        public int RetentionDays{ get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> results = new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>()
            {
                ModelAdapter.GetDatabaseBackupShortTermRetentionPolicy(
                    this.ResourceGroupName,
                    this.ServerName,
                    this.DatabaseName)
            };

            return results;
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> model)
        {
            return new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>()
            {
                new AzureSqlDatabaseBackupShortTermRetentionPolicyModel(
                    ResourceGroupName,
                    ServerName,
                    DatabaseName,
                    new Management.Sql.Models.BackupShortTermRetentionPolicy(retentionDays: RetentionDays))
            };
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> PersistChanges(IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> entity)
        {
            if (!ShouldProcess(DatabaseName)) return null;

            return new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>() {
                ModelAdapter.SetDatabaseBackupShortTermRetentionPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, entity.First())
            };
        }

        /// <summary>
        /// Custom validator for retention days.
        /// TODO: Remove when server-side enforcement has been deployed.
        /// </summary>
        class ValidateRetentionDaysAttribute : ValidateArgumentsAttribute
        {
            protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
            {
                // Retention is only accepted in week intervals.
                if ((int)arguments % 7 != 0)
                {
                    throw new PSArgumentException("Backup retention must be in 7-day intervals (7, 14, 21, etc.)");
                }
            }
        }
    }
}

