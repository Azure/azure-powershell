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

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to add Azure Sql Databases into a Failover Group
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmSqlDatabaseToFailoverGroup", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class AddAzureSqlDatabaseToFailoverGroup : AzureSqlFailoverGroupCmdletBase
    {
        /// <summary>
        /// The name of the Azure SQL Database FailoverGroup
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 2,
            HelpMessage = "The name of the Azure SQL Failover Group.")]
        [ValidateNotNullOrEmpty]
        public string FailoverGroupName { get; set; }

        /// <summary>
        /// The Azure SQL Databases to be added to the secondary server
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Azure SQL Databases to be added to the secondary server.")]
        [ValidateNotNullOrEmpty]
        public List<AzureSqlDatabaseModel> Databases { get; set; }

        /// <summary>
        /// Gets or sets the tags associated with the Azure Sql Failover Group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Elastic Pool")]
        [Alias("Tag")]
        public Hashtable Tag { get; set; }

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
            string location = ModelAdapter.GetServerLocation(ResourceGroupName, ServerName);
            List<AzureSqlFailoverGroupModel> newEntity = new List<AzureSqlFailoverGroupModel>();
            List<string> dbs = new List<string>();

           if (MyInvocation.BoundParameters.ContainsKey("Databases") || Databases != null)
            {
                dbs.AddRange(ConvertDatabaseModelToDatabaseHelper(Databases));
            }
            else
            {
                throw new PSArgumentException(
                    string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverGroupAddDatabaseNoArguments, this.FailoverGroupName, this.ServerName),
                    "FailoverGroupName");
            }

            newEntity.Add(new AzureSqlFailoverGroupModel()
            {
                Databases = GetUpdatedDatabaseList(dbs)
            });

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
                ModelAdapter.AddOrRemoveDatabaseToFailoverGroup(this.ResourceGroupName, this.ServerName, this.FailoverGroupName,entity.First())
            };
        }

        /// <summary>
        /// Helper to Convert DatabaseModels to a list of database ids the Failover Group
        /// </summary>
        /// <param name="models">The input as a list of database modelsl</param>
        /// <returns>The list of database ids</returns>
        public List<string> ConvertDatabaseModelToDatabaseHelper(ICollection<AzureSqlDatabaseModel> models)
        {
            List<string> result = new List<string>();

            foreach (var model in models.ToList()) {
                if (String.Compare(model.DatabaseName, "master", StringComparison.Ordinal) == 0)
                {
                    WriteWarning("Can not add master database into the failover group. This operation request will be ignored");
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
        /// <param name="addedDbs">dbs to be removed from Failover Group</param>
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
                    throw new PSArgumentException(
                        string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverGroupAddDatabaseAlreadyExists, db, this.FailoverGroupName, this.ServerName),
                        "FailoverGroupName");
                }
            }

            return result.ToList();
        }
    }
}
