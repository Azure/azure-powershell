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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Services;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ServiceTierAdvisor.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseUpgradeHint", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    [OutputType(typeof(RecommendedDatabaseProperties))]
    public class GetAzureSqlDatabaseUpgradeHint : AzureSqlCmdletBase<IEnumerable<RecommendedDatabaseProperties>, AzureSqlServiceTierAdvisorAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Server.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure SQL Database.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating that we want to exclude databases already in elastic pool recommendations.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Exclude databases that are included in elastic pool recommendations")]
        [ValidateNotNullOrEmpty]
        public bool ExcludeElasticPoolCandidates { get; set; }


        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<RecommendedDatabaseProperties> GetEntity()
        {
            ICollection<RecommendedDatabaseProperties> results;

            if (MyInvocation.BoundParameters.ContainsKey("DatabaseName") && !WildcardPattern.ContainsWildcardCharacters(DatabaseName))
            {
                results = new List<RecommendedDatabaseProperties>();
                results.Add(ModelAdapter.GetUpgradeDatabaseHints(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.ExcludeElasticPoolCandidates));
            }
            else
            {
                results = ModelAdapter.ListUpgradeDatabaseHints(this.ResourceGroupName, this.ServerName, this.ExcludeElasticPoolCandidates);
            }

            return SubResourceWildcardFilter(DatabaseName, results);
        }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns>Returns new AzureSqlServiceTierAdvisorAdapter</returns>
        protected override AzureSqlServiceTierAdvisorAdapter InitModelAdapter()
        {
            return new AzureSqlServiceTierAdvisorAdapter(DefaultProfile.DefaultContext);
        }
    }
}
