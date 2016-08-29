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

using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ElasticPool.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlElasticPoolDatabase", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlElasticPoolDatabase : AzureSqlElasticPoolCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the ElasticPool to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Elastic Pool to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Database to get.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure SQL Database to retrieve.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected IEnumerable<AzureSqlDatabaseModel> GetDatabase()
        {
            ICollection<AzureSqlDatabaseModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                results = new List<AzureSqlDatabaseModel>();
                results.Add(ModelAdapter.GetElasticPoolDatabase(this.ResourceGroupName, this.ServerName, this.ElasticPoolName, this.DatabaseName));
            }
            else
            {
                results = ModelAdapter.ListElasticPoolDatabases(this.ResourceGroupName, this.ServerName, this.ElasticPoolName);
            }

            return results;
        }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ModelAdapter = InitModelAdapter(DefaultProfile.Context.Subscription);

            WriteObject(GetDatabase());
        }

        /// <summary>
        /// Not Used.
        /// </summary>
        /// <returns>Not Used</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> GetEntity()
        {
            return null;
        }
    }
}
