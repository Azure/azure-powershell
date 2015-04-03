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
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ElasticPool.Model;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database ElasticPool
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseElasticPool",
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabaseElasticPool : AzureSqlDatabaseElasticPoolCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure SQL Database ElasticPool
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the Azure SQL Database ElasticPool.")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the edition to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The edition to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the total shared DTU for the Sql Azure Database Elastic Pool.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The total shared DTU for the Sql Azure Database Elastic Pool.")]
        [ValidateNotNullOrEmpty]
        public int Dtu { get; set; }

        /// <summary>
        /// Gets or sets the storage limit for the Sql Azure Database Elastic Pool in MB.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The storage limit for the Sql Azure Database Elastic Pool in MB.")]
        [ValidateNotNullOrEmpty]
        public long StorageMB { get; set; }

        /// <summary>
        /// Gets or sets the minimum DTU all Sql Azure Databases are guaranteed.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The minimum DTU all Sql Azure Databases are guaranteed.")]
        [ValidateNotNullOrEmpty]
        public int DatabaseDtuMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum DTU any one Sql Azure Database can consume.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The maximum DTU any one Sql Azure Database can consume.")]
        [ValidateNotNullOrEmpty]
        public int DatabaseDtuMax { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The tags to associate with the Azure Sql Database Server")]
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseElasticPoolModel> GetEntity()
        {
            return new List<AzureSqlDatabaseElasticPoolModel>() { 
                ModelAdapter.GetElasticPool(this.ResourceGroupName, this.ServerName, this.ElasticPoolName) 
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseElasticPoolModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseElasticPoolModel> model)
        {
            List<AzureSqlDatabaseElasticPoolModel> newEntity = new List<AzureSqlDatabaseElasticPoolModel>();
            newEntity.Add(new AzureSqlDatabaseElasticPoolModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                Tags = Tags,
                DatabaseDtuMax = DatabaseDtuMax,
                DatabaseDtuMin = DatabaseDtuMin,
                Dtu = Dtu,
                Edition = Edition,
                ElasticPoolName = ElasticPoolName,
                StorageMB = StorageMB,
            });
            return newEntity;
        }

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseElasticPoolModel> PersistChanges(IEnumerable<AzureSqlDatabaseElasticPoolModel> entity)
        {
            return new List<AzureSqlDatabaseElasticPoolModel>() {
                ModelAdapter.UpsertElasticPool(this.ResourceGroupName, this.ServerName, entity.First())
            };
        }
    }
}
