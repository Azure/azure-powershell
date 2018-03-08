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

namespace Microsoft.Azure.Commands.Sql.Database_Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseLongTermRetentionPolicy",
        DefaultParameterSetName = WeeklyRetentionRequiredSet,
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    [Alias("Set-AzureRmSqlDatabaseBackupLongTermRetentionPolicy")]
    public class SetAzureRmSqlDatabaseLongTermRetentionPolicy : AzureSqlDatabaseLongTermRetentionPolicyCmdletBase
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
        /// Gets or sets the Weekly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = WeeklyRetentionRequiredSet,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Weekly Retention of the long term retention policy.")]
        [Parameter(Mandatory = false,
            ParameterSetName = MonthlyRetentionRequiredSet,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Weekly Retention of the long term retention policy.")]
        [Parameter(Mandatory = false,
            ParameterSetName = YearlyRetentionRequiredSet,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Weekly Retention of the long term retention policy.")]
        [ValidateNotNullOrEmpty]
        public string WeeklyRetention { get; set; }

        /// <summary>
        /// Gets or sets the Monthly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = MonthlyRetentionRequiredSet,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Monthly Retention of the long term retention policy.")]
        [Parameter(Mandatory = false,
            ParameterSetName = YearlyRetentionRequiredSet,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Monthly Retention of the long term retention policy.")]
        [ValidateNotNullOrEmpty]
        public string MonthlyRetention { get; set; }

        /// <summary>
        /// Gets or sets the Yearly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = YearlyRetentionRequiredSet,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Yearly Retention of the long term retention policy.")]
        [ValidateNotNullOrEmpty]
        public string YearlyRetention { get; set; }

        /// <summary>
        /// Gets or sets the Week of Year for the Yearly Retention.
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = YearlyRetentionRequiredSet,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Week of Year to save for the Yearly Retention.")]
        [ValidateNotNullOrEmpty]
        public int WeekOfYear { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionPolicyModel> GetEntity()
        {
            return new List<AzureSqlDatabaseLongTermRetentionPolicyModel>() {
                ModelAdapter.GetDatabaseLongTermRetentionPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseLongTermRetentionPolicyModel> model)
        {
            List<AzureSqlDatabaseLongTermRetentionPolicyModel> newEntity =
                new List<AzureSqlDatabaseLongTermRetentionPolicyModel>();
            newEntity.Add(new AzureSqlDatabaseLongTermRetentionPolicyModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                Policy = new Management.Sql.Models.LongTermRetentionPolicy()
                {
                    WeeklyRetention = WeeklyRetention,
                    MonthlyRetention = MonthlyRetention,
                    YearlyRetention = YearlyRetention,
                    WeekOfYear = WeekOfYear
                }
            });
            return newEntity;
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseLongTermRetentionPolicyModel> PersistChanges(IEnumerable<AzureSqlDatabaseLongTermRetentionPolicyModel> entity)
        {
            if (ShouldProcess(DatabaseName))
            {
                return new List<AzureSqlDatabaseLongTermRetentionPolicyModel>() {
                    ModelAdapter.SetDatabaseLongTermRetentionPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, entity.First())
                };
            }
            else
            {
                return null;
            }
        }
    }
}
