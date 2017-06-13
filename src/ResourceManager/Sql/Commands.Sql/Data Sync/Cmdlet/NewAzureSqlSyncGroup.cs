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
using System.Management.Automation;
using System.Linq;
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Management.Sql.Models;
using Hyak.Common;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new sync group
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlSyncGroup", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    public class NewAzureSqlSyncGroup : AzureSqlSyncGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            Position = 3, 
            HelpMessage = "The sync group name.")]
        [Alias("SyncGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the database used to store sync related metadata
        /// </summary>
        [Parameter(Mandatory = true,
           HelpMessage = "The database used to store sync related metadata.")]
        [ValidateNotNullOrEmpty]
        public string SyncDatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server on which sync metadata database is hosted
        /// </summary>
        [Parameter(Mandatory = true,
           HelpMessage = "The server on which the sync metadata database is hosted.")]
        [ValidateNotNullOrEmpty]
        public string SyncDatabaseServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group the sync metadata database belongs to
        /// </summary>
        [Parameter(Mandatory = true,
           HelpMessage = "The resource group the sync metadata database belongs to.")]
        [ValidateNotNullOrEmpty]
        public string SyncDatabaseResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in seconds) of doing data synchronization.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The frequency (in seconds) of doing data synchronization. Default is -1, which means the auto synchronization is not enabled.")]
        public int IntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the hub database credential of the sync group
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The SQL authentication credential of the hub database.")]
        [ValidateNotNull]
        public PSCredential DatabaseCredential { get; set; }

        /// <summary>
        /// Gets or sets the policy of resolving confliction between hub and member database in the sync group
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = "The policy of resolving confliction between hub and member database in the sync group.")]
        [ValidateSet("HubWin", "MemberWin", IgnoreCase = true)]
        public string ConflictResolutionPolicy { get; set; }

        /// <summary>
        /// Gets or sets the path of the schema file
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The path of the schema file.")]
        [ValidateNotNullOrEmpty]
        public string SchemaFile { get; set; }

        /// <summary>
        /// The id of database used to store sync related metadata
        /// </summary>
        private string syncDatabaseId = null;

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> GetEntity()
        {
            // We try to get the sync group. Since this is a create, we don't want the sync group to exist
            try
            {
                ModelAdapter.GetSyncGroup(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want. We looked and there is no sync group with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The sync group already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.SyncGroupNameExists, this.Name, this.DatabaseName),
                "SyncGroupName");
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlSyncGroupModel> model)
        {
            List<Model.AzureSqlSyncGroupModel> newEntity = new List<AzureSqlSyncGroupModel>();
            AzureSqlSyncGroupModel newModel = new AzureSqlSyncGroupModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                DatabaseName = this.DatabaseName,
                SyncGroupName = this.Name,
                ConflictResolutionPolicy = this.ConflictResolutionPolicy != null ? this.ConflictResolutionPolicy.ToString() : null,
                HubDatabaseUserName = this.DatabaseCredential != null ? this.DatabaseCredential.UserName : null,
                HubDatabasePassword = this.DatabaseCredential != null ? this.DatabaseCredential.Password : null
            };

            if (MyInvocation.BoundParameters.ContainsKey("IntervalInSeconds"))
            {
                newModel.IntervalInSeconds = this.IntervalInSeconds;
            }

            if (MyInvocation.BoundParameters.ContainsKey("SyncDatabaseResourceGroupName") 
                && MyInvocation.BoundParameters.ContainsKey("SyncDatabaseServerName") 
                && MyInvocation.BoundParameters.ContainsKey("SyncDatabaseName"))
            {
                this.syncDatabaseId = string.Format("resourceGroups/{0}/providers/Microsoft.Sql/servers/{1}/databases/{2}",
                    this.SyncDatabaseResourceGroupName, this.SyncDatabaseServerName, this.SyncDatabaseName);
            }

            // if schema file is specified
            if (MyInvocation.BoundParameters.ContainsKey("SchemaFile"))
            {
                try
                {
                    newModel.Schema = ConstructSchemaFromFile(this.SchemaFile);
                }
                catch (CloudException ex)
                {
                    // There are problems with schema file
                    throw new PSArgumentException(ex.Response.ToString(), "SchemaFile");
                }
            }
            newEntity.Add(newModel);
            return newEntity;
        }

        /// <summary>
        /// Create the new sync group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> PersistChanges(IEnumerable<AzureSqlSyncGroupModel> entity)
        {
            return new List<AzureSqlSyncGroupModel>() {
                ModelAdapter.CreateSyncGroup(entity.First(), this.syncDatabaseId)
            };
        }
    }
}
