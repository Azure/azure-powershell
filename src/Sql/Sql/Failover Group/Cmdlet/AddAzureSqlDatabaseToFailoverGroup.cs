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
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to add Azure Sql Databases into a Failover Group
    /// </summary>
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseToFailoverGroup",ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(AzureSqlFailoverGroupModel))]
    public class AddAzureSqlDatabaseToFailoverGroup : AzureSqlFailoverGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The name of the primary Azure SQL Database Server of the Failover Group.")]
        [ResourceNameCompleter("Microsoft.Sql/servers", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// The name of the Azure SQL Database FailoverGroup
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Database Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// The Azure SQL Database to be added to the secondary server
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "One or more Azure SQL Databases on the Failover Group's primary server to be added to the Failover Group.")]
        [ValidateNotNullOrEmpty]
        public List<AzureSqlDatabaseModel> Database { get; set; }

        /// <summary>
        /// The Azure SQL Databases secondary type on partner server.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Databases secondary type on partner server. Default value is Geo.")]
        [ValidateSet("Geo", "Standby")]
        public string SecondaryType { get; set; }

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
        protected override IEnumerable<AzureSqlFailoverGroupModel> GetEntity()
        {
            return new List<AzureSqlFailoverGroupModel>() {
                ModelAdapter.GetFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName)
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlFailoverGroupModel> model)
        {
            List<AzureSqlFailoverGroupModel> newEntity = new List<AzureSqlFailoverGroupModel>();
            AzureSqlFailoverGroupModel newModel = model.First();
            List<string> dbs = new List<string>();

            dbs.AddRange(ConvertDatabaseModelToDatabaseHelper(Database));
            newModel.Databases = GetUpdatedDatabaseList(dbs);

            if (MyInvocation.BoundParameters.ContainsKey("SecondaryType"))
            {
                newModel.SecondaryType = SecondaryType;
            }
            newEntity.Add(newModel);

            return newEntity;
        }

        /// <summary>
        /// Update the Failover Group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlFailoverGroupModel> PersistChanges(IEnumerable<AzureSqlFailoverGroupModel> entity)
        {
            return new List<AzureSqlFailoverGroupModel>() {
                ModelAdapter.AddOrRemoveDatabaseToFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName, entity.First())
            };
        }

        /// <summary>
        /// Helper method which converts a list of Azure Database Model to a list of Database IDs
        /// </summary>
        /// <param name="models">The input as a list of database models</param>
        /// <returns>The list of database ids</returns>
        public List<string> ConvertDatabaseModelToDatabaseHelper(ICollection<AzureSqlDatabaseModel> models)
        {
            List<string> result = new List<string>();

            foreach (var model in models.ToList())
            {
                if (String.Compare(model.DatabaseName, "master", StringComparison.Ordinal) == 0)
                {
                    WriteWarning("Can not add master database into the failover group. The operation request to add master database will be ignored");
                }
                else
                {
                    result.Add(model.ResourceId);
                }
            }

            return result;
        }

        /// <summary>
        /// Helper method to get the updated database list to be passed into API call for adding dbs to failover group.
        /// </summary>
        /// <param name="addedDbs">dbs to be added into Failover Group</param>
        /// <returns>The new list of databases after removing the user inputed dbs</returns>
        protected List<string> GetUpdatedDatabaseList(ICollection<string> addedDbs)
        {
            HashSet<string> result = new HashSet<string>(GetEntity().First().Databases.ToList());

            foreach (var db in addedDbs.ToList())
            {
                if (!result.Contains(db))
                {
                    result.Add(db);
                }
                else
                {
                    throw new PSArgumentException(string.Format(Properties.Resources.FailoverGroupAddDatabaseAlreadyExists, db, this.FailoverGroupName, this.ServerName), "Database");
                }
            }

            return result.ToList();
        }
    }
}
