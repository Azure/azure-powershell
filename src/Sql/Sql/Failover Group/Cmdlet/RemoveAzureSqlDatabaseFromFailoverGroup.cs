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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Commands.Sql.FailoverGroup.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.FailoverGroup.Cmdlet
{
    /// <summary>
    /// Cmdlet to remove Azure Sql Databases from a Failover Group
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseFromFailoverGroup",ConfirmImpact = ConfirmImpact.Medium,SupportsShouldProcess = true), OutputType(typeof(AzureSqlFailoverGroupModel))]
    public class RemoveAzureSqlDatabaseFromFailoverGroup : AzureSqlFailoverGroupCmdletBase
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
        /// The Azure SQL Database to be removed to the secondary server
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "One or more Azure SQL Databases on the Failover Group's primary server to be removed from the Failover Group.")]
        [ValidateNotNullOrEmpty]
        public List<AzureSqlDatabaseModel> Database { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseFromAzureSqlDatabaseFailoverGroupDescription, this.FailoverGroupName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlDatabaseeFromAzureSqlDatabaseFailoverGroupWarning, this.FailoverGroupName, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

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
            AzureSqlFailoverGroupModel newModel = model.First();
            List<string> dbs = new List<string>();

            dbs.AddRange(ConvertDatabaseModelToDatabaseHelper(Database));
            newModel.Databases = GetUpdatedDatabaseList(dbs);

            newEntity.Add(newModel);

            return newEntity;
        }

        /// <summary>
        /// Update the databases of the failover group
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
        /// Helper method to get the updated database list to be passed into API call for removing dbs from failover group.
        /// </summary>
        /// <param name="removedDbs">dbs to be removed from Failover Group</param>
        /// <returns>The new list of databases after removing the user inputed dbs</returns>
        protected List<string> GetUpdatedDatabaseList(ICollection<string> removedDbs)
        {
            HashSet<string> result = new HashSet<string>(GetEntity().First().Databases.ToList());

            foreach (var db in removedDbs.ToList())
            {
                if (result.Contains(db))
                {
                    result.Remove(db);
                }
                else
                {
                    WriteWarning(
                        string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.FailoverGroupRemoveDatabaseNotExists, db, this.FailoverGroupName, this.ServerName)
                    );
                }
            }

            return result.ToList();
        }

        /// <summary>
        /// Helper method to get the updated database list to be passed into API call for removing dbs from failover group.
        /// </summary>
        /// <param name="models">dbs to be removed from Failover Group</param>
        /// <returns>The new list of databases after adding the user inputed dbs</returns>
        public List<string> ConvertDatabaseModelToDatabaseHelper(ICollection<AzureSqlDatabaseModel> models)
        {
            List<string> result = new List<string>();

            foreach (var model in models.ToList())
            {
                if (String.Compare(model.DatabaseName, "master", StringComparison.Ordinal) == 0)
                {
                    WriteWarning("Can not remove master database from the failover group. This operation request for removing master database will be ignored");
                }
                else
                {
                    result.Add(model.ResourceId);
                }
            }

            return result;
        }
    }
}
