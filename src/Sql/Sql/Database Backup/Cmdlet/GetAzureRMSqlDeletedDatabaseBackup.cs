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

using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Rest.Azure.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDeletedDatabaseBackup", SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlDeletedDatabaseBackupModel))]
    public class GetAzureRMSqlDeletedDatabaseBackup : AzureSqlDeletedDatabaseBackupCmdletBase
    {
        [Parameter(Mandatory = false,
            HelpMessage = "Flag to be used to view all the AKV keys in a database.")]
        public SwitchParameter ExpandKeyList { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Timestamp filter to get AKV keys")]
        public string KeysFilter { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Id of the database in this format: 'databaseName,133204753572100000' fetched from the list of restorable dropped databases.")]
        public string DatabaseId { get; set; }
         
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDeletedDatabaseBackupModel> GetEntity()
        {
            ICollection<AzureSqlDeletedDatabaseBackupModel> results;

            ODataQuery<Management.Sql.Models.RestorableDroppedDatabase> oDataQuery = new ODataQuery<Management.Sql.Models.RestorableDroppedDatabase>();

            if (ExpandKeyList.IsPresent)
            {
                if (!MyInvocation.BoundParameters.ContainsKey("DatabaseId"))
                {
                    throw new PSArgumentNullException("DatabaseId parameter is required with ExpandKeys parameter. DatabaseId can be fetched from list of restorable dropped databases.");
                }

                if (!String.IsNullOrEmpty(KeysFilter))
                {
                    oDataQuery.Expand = String.Format("keys($filter=pointInTime('{0}'))", KeysFilter);
                }
                else
                {
                    oDataQuery.Expand = "keys";
                }

                results = new List<AzureSqlDeletedDatabaseBackupModel>();
                results.Add(ModelAdapter.GetRestorableDroppedDatabase(ResourceGroupName, ServerName, DatabaseId, oDataQuery));
            }
            else if (MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                if (MyInvocation.BoundParameters.ContainsKey("DeletionDate"))
                {
                    results = new List<AzureSqlDeletedDatabaseBackupModel>();

                    // The server expects a deleted database entity ID that consists of the database name and deletion time as a windows file time separated by a comma.
                    results.Add(ModelAdapter.GetDeletedDatabaseBackup(this.ResourceGroupName, this.ServerName, this.DatabaseName + "," + this.DeletionDate.Value.ToFileTimeUtc().ToString()));
                }
                else
                {
                    results = ModelAdapter.ListDeletedDatabaseBackups(this.ResourceGroupName, this.ServerName).Where(backup => backup.DatabaseName == DatabaseName).ToList();
                }
            }
            else
            {
                results = ModelAdapter.ListDeletedDatabaseBackups(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDeletedDatabaseBackupModel> ApplyUserInputToModel(IEnumerable<AzureSqlDeletedDatabaseBackupModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDeletedDatabaseBackupModel> PersistChanges(IEnumerable<AzureSqlDeletedDatabaseBackupModel> entity)
        {
            return entity;
        }
    }
}
