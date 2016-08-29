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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Database.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Database.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Database
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabase", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabase : AzureSqlDatabaseCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the maximum size of the Azure SQL Database in bytes
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The maximum size of the Azure SQL Database in bytes.")]
        [ValidateNotNullOrEmpty]
        public long MaxSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the edition to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The edition to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public DatabaseEdition Edition { get; set; }

        /// <summary>
        /// Gets or sets the name of the service objective to assign to the Azure SQL Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the service objective to assign to the Azure SQL Database.")]
        [ValidateNotNullOrEmpty]
        public string RequestedServiceObjectiveName { get; set; }

        /// <summary>
        /// Gets or sets the name of the Elastic Pool to put the database in
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The name of the Elastic Pool to put the database in.")]
        [ValidateNotNullOrEmpty]
        public string ElasticPoolName { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Database
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Database")]
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
        protected override IEnumerable<AzureSqlDatabaseModel> GetEntity()
        {
            return new List<AzureSqlDatabaseModel>() {
                ModelAdapter.GetDatabase(this.ResourceGroupName, this.ServerName, this.DatabaseName)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseModel> model)
        {
            List<Model.AzureSqlDatabaseModel> newEntity = new List<AzureSqlDatabaseModel>();
            newEntity.Add(new AzureSqlDatabaseModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                Edition = Edition,
                MaxSizeBytes = MaxSizeBytes,
                RequestedServiceObjectiveName = RequestedServiceObjectiveName,
                Tags = TagsConversionHelper.CreateTagDictionary(Tags, validate: true),
                ElasticPoolName = ElasticPoolName,
                Location = model.FirstOrDefault().Location,
            });
            return newEntity;
        }

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseModel> PersistChanges(IEnumerable<AzureSqlDatabaseModel> entity)
        {
            return new List<AzureSqlDatabaseModel>() {
                ModelAdapter.UpsertDatabase(this.ResourceGroupName, this.ServerName, entity.First())
            };
        }
    }
}
