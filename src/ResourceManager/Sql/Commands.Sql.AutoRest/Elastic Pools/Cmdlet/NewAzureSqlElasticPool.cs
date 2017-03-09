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

using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.ElasticPool.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ElasticPool.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql ElasticPool
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlElasticPool", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    public class NewAzureSqlElasticPool : AzureSqlElasticPoolCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Elastic Pool to create.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure SQL ElasticPool to create.")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the edition to assign to the Azure SQL Elastic Pool
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The edition to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the total shared DTU for the Sql Azure Elastic Pool.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The total shared DTU for the Sql Azure Elastic Pool.")]
        [ValidateNotNullOrEmpty]
        public int Dtu { get; set; }

        /// <summary>
        /// Gets or sets the storage limit for the Sql Azure Elastic Pool in MB.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The storage limit for the Sql Azure Elastic Pool in MB.")]
        [ValidateNotNullOrEmpty]
        public int StorageMB { get; set; }

        /// <summary>
        /// Gets or sets the minimum DTU all Sql Azure Databases are guaranteed.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The minimum DTU all Sql Azure Databases are guaranteed.")]
        [ValidateNotNullOrEmpty]
        public int DatabaseDtuMin { get; set; }

        /// <summary>
        /// Gets or sets the maximum DTU any one Sql Azure Database can consume.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The maximum DTU any one Sql Azure Database can consume.")]
        [ValidateNotNullOrEmpty]
        public int DatabaseDtuMax { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Elastic Pool
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Elastic Pool")]
        [Alias("Tag")]
        public Hashtable Tags { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> GetEntity()
        {
            // We try to get the database.  Since this is a create, we don't want the database to exist
            try
            {
                ModelAdapter.GetElasticPool(this.ResourceGroupName, this.ServerName, this.ElasticPoolName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no database with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The database already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ElasticPoolNameExists, this.ElasticPoolName, this.ServerName),
                "ElasticPoolName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> ApplyUserInputToModel(IEnumerable<AzureSqlElasticPoolModel> model)
        {
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            List<AzureSqlElasticPoolModel> newEntity = new List<AzureSqlElasticPoolModel>();
            newEntity.Add(new AzureSqlElasticPoolModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                Location = location,
                ElasticPoolName = ElasticPoolName,
                DatabaseDtuMax = MyInvocation.BoundParameters.ContainsKey("DatabaseDtuMax") ? (int?)DatabaseDtuMax : null,
                DatabaseDtuMin = MyInvocation.BoundParameters.ContainsKey("DatabaseDtuMin") ? (int?)DatabaseDtuMin : null,
                Dtu = MyInvocation.BoundParameters.ContainsKey("Dtu") ? (int?)Dtu : null,
                Edition = MyInvocation.BoundParameters.ContainsKey("Edition") ? (DatabaseEdition?)Edition : null,
                StorageMB = MyInvocation.BoundParameters.ContainsKey("StorageMB") ? (int?)StorageMB : null,
            });
            return newEntity;
        }

        /// <summary>
        /// Create the new database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlElasticPoolModel> PersistChanges(IEnumerable<AzureSqlElasticPoolModel> entity)
        {
            return new List<AzureSqlElasticPoolModel>() {
                ModelAdapter.UpsertElasticPool(entity.First())
            };
        }
    }
}
