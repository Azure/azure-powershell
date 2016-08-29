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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.RecommendedElasticPools.Services;
using Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Model;
using Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Services;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerUpgradeHint", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlServerUpgradeHint : AzureSqlCmdletBase<UpgradeServerHint, AzureSqlServiceTierAdvisorAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating that we want to exclude elastic pool recommendations.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Exclude elastic pool recommendations")]
        [ValidateNotNullOrEmpty]
        public bool ExcludeElasticPools { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override UpgradeServerHint GetEntity()
        {
            if (ExcludeElasticPools)
            {
                // Return hints for all database ignoring elastic pool recommendations
                return new UpgradeServerHint
                {
                    Databases = ModelAdapter.ListUpgradeDatabaseHints(ResourceGroupName, ServerName, false),
                    ElasticPools = null
                };
            }
            else
            {
                // Return elastic pool hints and exclude databases contained in pools
                var elasticPoolAdapter = new AzureSqlElasticPoolRecommendationAdapter(DefaultProfile.Context);
                return new UpgradeServerHint
                {
                    Databases = ModelAdapter.ListUpgradeDatabaseHints(ResourceGroupName, ServerName, true),
                    ElasticPools = elasticPoolAdapter.ListRecommendedElasticPoolProperties(ResourceGroupName, ServerName)
                };
            }
        }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <param name="subscription">Subscription</param>
        /// <returns>Returns new AzureSqlServiceTierAdvisorAdapter</returns>
        protected override AzureSqlServiceTierAdvisorAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlServiceTierAdvisorAdapter(DefaultProfile.Context);
        }
    }
}
