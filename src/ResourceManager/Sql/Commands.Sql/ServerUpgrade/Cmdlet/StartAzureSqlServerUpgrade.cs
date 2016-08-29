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

using Microsoft.Azure.Commands.Sql.ServerUpgrade.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServerUpgrade.Cmdlet
{
    /// <summary>
    /// Defines the Start-AzureRmSqlServerUpgrade cmdlet
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSqlServerUpgrade",
        ConfirmImpact = ConfirmImpact.Low)]
    public class StartAzureSqlServerUpgrade : AzureSqlServerUpgradeCmdletBase<AzureSqlServerUpgradeStartModel>
    {
        /// <summary>
        /// Gets or sets the server version
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines to which version the Sql Azure Server is being upgraded")]
        [ValidateNotNullOrEmpty]
        public string ServerVersion { get; set; }

        /// <summary>
        /// Gets or sets the earliest time to upgrade the server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines the earliest time the Sql Azure Server can be upgraded")]
        [ValidateNotNullOrEmpty]
        public DateTime? ScheduleUpgradeAfterUtcDateTime { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Determines the collection of recommended database properties for server upgrade")]
        public RecommendedDatabaseProperties[] DatabaseCollection { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Determines the collection of recommended elastic pool properties for server upgrade")]
        public UpgradeRecommendedElasticPoolProperties[] ElasticPoolCollection { get; set; }

        private const int StorageMbPerDtuBasic = 100;
        private const int StorageMbPerDtuStandard = 1024;
        private const int StorageMbPerDtuPremium = 512;

        /// <summary>
        /// Check to see if the server already exists in this resource group.
        /// </summary>
        /// <returns>Null if the server doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerUpgradeStartModel> GetEntity()
        {
            var upgrade = ModelAdapter.GetUpgrade(this.ResourceGroupName, this.ServerName);

            if (upgrade.Status == ServerUpgradeStatus.Queued ||
                upgrade.Status == ServerUpgradeStatus.InProgress ||
                upgrade.Status == ServerUpgradeStatus.Cancelling)
            {
                // The server upgrade is already pending
                throw new PSArgumentException(
                    string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerUpgradeExists, this.ServerName),
                    "ServerName");
            }

            // This is what we want. Returning null so that the upgrade can be started in the next method 
            return null;
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="models">This is null since the server upgrade doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlServerUpgradeStartModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerUpgradeStartModel> models)
        {
            if (ElasticPoolCollection != null)
            {
                // Ignore user input and recalculate StorageMb based on Dtu and coefficient of the edition
                foreach (var elasticPoolProperties in ElasticPoolCollection)
                {
                    switch (elasticPoolProperties.Edition.ToLower())
                    {
                        case "basic":
                            elasticPoolProperties.StorageMb = elasticPoolProperties.Dtu * StorageMbPerDtuBasic;
                            break;
                        case "standard":
                            elasticPoolProperties.StorageMb = elasticPoolProperties.Dtu * StorageMbPerDtuStandard;
                            break;
                        case "premium":
                            elasticPoolProperties.StorageMb = elasticPoolProperties.Dtu * StorageMbPerDtuPremium;
                            break;
                        default:
                            throw new PSArgumentException(string.Format("Edition {0} is invalid", elasticPoolProperties.Edition));
                    }

                }
            }

            var newEntity = new List<AzureSqlServerUpgradeStartModel>();
            newEntity.Add(new AzureSqlServerUpgradeStartModel
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                ServerVersion = this.ServerVersion,
                ScheduleUpgradeAfterUtcDateTime = this.ScheduleUpgradeAfterUtcDateTime,
                DatabaseCollection = this.DatabaseCollection,
                ElasticPoolCollection = this.ElasticPoolCollection
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Start the server upgrade
        /// </summary>
        /// <param name="entity">The server upgrade model to start</param>
        /// <returns>The same server upgrade start model</returns>
        protected override IEnumerable<AzureSqlServerUpgradeStartModel> PersistChanges(IEnumerable<AzureSqlServerUpgradeStartModel> entity)
        {
            var model = entity.First();
            ModelAdapter.Start(model);

            // Get the upgrade object again from cluster to output
            return new List<AzureSqlServerUpgradeStartModel>
            {
                model
            };
        }
    }
}
