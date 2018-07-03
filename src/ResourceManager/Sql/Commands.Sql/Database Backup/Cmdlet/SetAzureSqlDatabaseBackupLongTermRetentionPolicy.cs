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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create or update a new Azure Sql Database backup archival policy
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseBackupLongTermRetentionPolicy",
        DefaultParameterSetName = WeeklyRetentionRequiredSet,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low),
        OutputType(typeof(AzureSqlDatabaseBackupLongTermRetentionPolicyModel))]
    [Alias("Set-AzureRmSqlDatabaseLongTermRetentionPolicy")]
    public class SetAzureSqlDatabaseBackupLongTermRetentionPolicy : AzureSqlDatabaseBackupLongTermRetentionPolicyCmdletBase
    {
        /// <summary>
        /// Parameter set name for Weekly Retention.
        /// </summary>
        private const string WeeklyRetentionRequiredSet = "WeeklyRetentionRequired";

        /// <summary>
        /// Parameter set name for Monthly Retention.
        /// </summary>
        private const string MonthlyRetentionRequiredSet = "MonthlyRetentionRequired";

        /// <summary>
        /// Parameter set name for Yearly Retention.
        /// </summary>
        private const string YearlyRetentionRequiredSet = "YearlyRetentionRequired";

        /// <summary>
        /// Parameter set for clearing the long term retention V2 policy.
        /// </summary>
        private const string RemovePolicySet = "RemovePolicy";

        /// <summary>
        /// Parameter set for setting the legacy long term retention policy.
        /// </summary>
        private const string LegacySet = "Legacy";

        /// <summary>
        /// Gets or sets the backup long term retention state
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = LegacySet,
            HelpMessage = "The state of the long term retention backup policy, 'Enabled' or 'Disabled'")]
        [ValidateNotNullOrEmpty]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the name of the backup long term retention policy
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = LegacySet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource ID of the backup long term retention policy.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to clear the Long Term Retention V2 policy.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = RemovePolicySet,
            HelpMessage = "If provided, the policy for the database will be cleared.")]
        public SwitchParameter RemovePolicy { get; set; }

        /// <summary>
        /// Gets or sets the Weekly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = WeeklyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Weekly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minumum of 7 days and a maximum of 10 years.")]
        [Parameter(Mandatory = false,
            ParameterSetName = MonthlyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Weekly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minumum of 7 days and a maximum of 10 years.")]
        [Parameter(Mandatory = false,
            ParameterSetName = YearlyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Weekly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minumum of 7 days and a maximum of 10 years.")]
        [ValidateNotNullOrEmpty]
        public string WeeklyRetention { get; set; }

        /// <summary>
        /// Gets or sets the Monthly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = MonthlyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Monthly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minumum of 7 days and a maximum of 10 years.")]
        [Parameter(Mandatory = false,
            ParameterSetName = YearlyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Monthly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minumum of 7 days and a maximum of 10 years.")]
        [ValidateNotNullOrEmpty]
        public string MonthlyRetention { get; set; }

        /// <summary>
        /// Gets or sets the Yearly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = YearlyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Yearly Retention. If just a number is passed instead of an ISO 8601 string, days will be assumed as the units. There is a minumum of 7 days and a maximum of 10 years.")]
        [ValidateNotNullOrEmpty]
        public string YearlyRetention { get; set; }

        /// <summary>
        /// Gets or sets the Week of Year for the Yearly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = YearlyRetentionRequiredSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Week of Year, 1 to 52, to save for the Yearly Retention.")]
        [ValidateNotNullOrEmpty]
        public int WeekOfYear { get; set; }

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
                    !ParameterSetName.Equals(LegacySet))
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> model)
        {
            int temp;
            string retentionFormat = "P{0}D";
            if (int.TryParse(WeeklyRetention, out temp))
            {
                WeeklyRetention = string.Format(retentionFormat, WeeklyRetention);
            }

            if (int.TryParse(MonthlyRetention, out temp))
            {
                MonthlyRetention = string.Format(retentionFormat, MonthlyRetention);
            }

            if (int.TryParse(YearlyRetention, out temp))
            {
                YearlyRetention = string.Format(retentionFormat, YearlyRetention);
            }

            if (RemovePolicy.IsPresent)
            {
                WeeklyRetention = "P0D";
                MonthlyRetention = "P0D";
                YearlyRetention = "P0D";
                WeekOfYear = 1;
            }

            return new List<AzureSqlDatabaseBackupLongTermRetentionPolicyModel>()
            {
                new AzureSqlDatabaseBackupLongTermRetentionPolicyModel()
                {
                    ResourceGroupName = ResourceGroupName,
                    ServerName = ServerName,
                    DatabaseName = DatabaseName,
                    State = State,
                    RecoveryServicesBackupPolicyResourceId = ResourceId,
                    Location = model.FirstOrDefault().Location,
                    WeeklyRetention = WeeklyRetention,
                    MonthlyRetention = MonthlyRetention,
                    YearlyRetention = YearlyRetention,
                    WeekOfYear = WeekOfYear
                }
            };
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> PersistChanges(IEnumerable<AzureSqlDatabaseBackupLongTermRetentionPolicyModel> entity)
        {
            if (ShouldProcess(DatabaseName))
            {
                return new List<AzureSqlDatabaseBackupLongTermRetentionPolicyModel>() {
                    ModelAdapter.SetDatabaseBackupLongTermRetentionPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, entity.First())
                };
            }
            else
            {
                return null;
            }
        }
    }
}
