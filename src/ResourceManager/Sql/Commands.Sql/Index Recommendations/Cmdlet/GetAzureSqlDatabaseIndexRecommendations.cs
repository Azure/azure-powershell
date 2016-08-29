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
using Microsoft.Azure.Commands.Sql.Model;
using Microsoft.Azure.Commands.Sql.Service;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseIndexRecommendations cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseIndexRecommendations", ConfirmImpact = ConfirmImpact.None, SupportsShouldProcess = true)]
    public class GetAzureSqlDatabaseIndexRecommendations : AzureSqlCmdletBase<IEnumerable<IndexRecommendation>, AzureSqlDatabaseIndexRecommendationAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Database name.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Table name.")]
        [ValidateNotNullOrEmpty]
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the name of the index recommendation.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure SQL Index Recommendation name.")]
        [ValidateNotNullOrEmpty]
        public string IndexRecommendationName { get; set; }

        /// <summary>
        /// Gets a server upgrade from the service.
        /// </summary>
        /// <returns>A single server upgrade</returns>
        protected override IEnumerable<IndexRecommendation> GetEntity()
        {
            var results = new List<IndexRecommendation>();

            // If database name property is set load only index recommendations for that database
            // else load for all databases on server
            if (MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                results.AddRange(ModelAdapter.ListRecommendedIndexes(ResourceGroupName, ServerName, DatabaseName));
            }
            else
            {
                results.AddRange(ModelAdapter.ListRecommendedIndexes(ResourceGroupName, ServerName, null));
            }

            // If index name is set keep only index recommendations with corresponding name
            if (MyInvocation.BoundParameters.ContainsKey("IndexRecommendationName"))
            {
                results = results.Where(i => i.Name == IndexRecommendationName).ToList();
            }

            // If table property is set keep only indexes on corresponding table
            if (MyInvocation.BoundParameters.ContainsKey("TableName"))
            {
                results = results.Where(i => i.Table == TableName).ToList();
            }

            return results;
        }

        /// <summary>
        /// Initializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The recommended index adapter</returns>
        protected override AzureSqlDatabaseIndexRecommendationAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlDatabaseIndexRecommendationAdapter(DefaultProfile.Context);
        }
    }
}
