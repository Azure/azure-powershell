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
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Management.Sql.Models;
using Hyak.Common;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to update a existing sync group
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlSyncGroup", SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlSyncGroup : AzureSqlSyncGroupCmdletBase
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The sync group name.")]
        [ValidateNotNullOrEmpty]
        public string SyncGroupName { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in seconds) of doing data synchronization
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The frequency (in seconds) of doing data synchronization. Default is -1, which means the auto synchronization is not enabled.")]
        public int? IntervalInSeconds { get; set; }

        /// <summary>
        /// Gets or sets the hub database credential of the sync group
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The SQL authentication credetial of hub database.")]
        [ValidateNotNull]
        public PSCredential HubDatabaseCredential { get; set; }

        /// <summary>
        /// Gets or sets the path of the schema file
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The path of the schema file.")]
        public string SchemaFile { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> GetEntity()
        {
            return new List<AzureSqlSyncGroupModel>() { 
                ModelAdapter.GetSyncGroup(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName) 
            };
        }

        /// <summary>
        /// create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> ApplyUserInputToModel(IEnumerable<AzureSqlSyncGroupModel> model)
        {
            AzureSqlSyncGroupModel newModel = model.First();

            if (MyInvocation.BoundParameters.ContainsKey("IntervalInSeconds"))
            {
                newModel.IntervalInSeconds = this.IntervalInSeconds;
            }

            if (MyInvocation.BoundParameters.ContainsKey("HubDatabaseCredential"))
            {
                newModel.HubDatabaseUserName = this.HubDatabaseCredential.UserName;
                newModel.HubDatabasePassword = this.HubDatabaseCredential.Password;
            }
            else
            {
                newModel.HubDatabaseUserName = null;
                newModel.HubDatabasePassword = null;
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

            return model;
        }

        /// <summary>
        /// Update the sync group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncGroupModel> PersistChanges(IEnumerable<AzureSqlSyncGroupModel> entity)
        {
            return new List<AzureSqlSyncGroupModel>() {
                ModelAdapter.UpdateSyncGroup(entity.First())
            };
        }
    }
}
