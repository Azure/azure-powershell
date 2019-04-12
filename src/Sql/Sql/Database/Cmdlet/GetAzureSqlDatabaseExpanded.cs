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
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.Database.Services;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseExpanded", SupportsShouldProcess = true,ConfirmImpact = ConfirmImpact.None)]
    [OutputType(typeof(AzureSqlDatabaseModelExpanded))]
    public class GetAzureSqlDatabaseExpanded : AzureSqlCmdletBase<IEnumerable<AzureSqlDatabaseModelExpanded>, AzureSqlDatabaseAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the Azure SQL Database Server the database is in.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database to use.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database to retrieve.")]
        [ResourceNameCompleter("Microsoft.Sql/servers/databases", "ResourceGroupName", "ServerName")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Initializes the adapter
        /// </summary>
        /// <returns></returns>
        protected override AzureSqlDatabaseAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseModelExpanded> GetEntity()
        {
            ICollection<AzureSqlDatabaseModelExpanded> results;

            if (MyInvocation.BoundParameters.ContainsKey("DatabaseName") && !WildcardPattern.ContainsWildcardCharacters(DatabaseName))
            {
                results = new List<AzureSqlDatabaseModelExpanded>();
                results.Add(ModelAdapter.GetDatabaseExpanded(this.ResourceGroupName, this.ServerName, this.DatabaseName));
            }
            else
            {
                results = ModelAdapter.ListDatabasesExpanded(this.ResourceGroupName, this.ServerName);
            }

            return SubResourceWildcardFilter(DatabaseName, results);
        }
    }
}
