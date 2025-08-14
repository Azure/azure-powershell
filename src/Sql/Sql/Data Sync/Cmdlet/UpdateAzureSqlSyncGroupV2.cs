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
using Microsoft.Azure.Commands.Sql.DataSync.Model;
using Microsoft.Azure.Management.Sql.DataSyncV2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    /// <summary>
    /// Cmdlet to update a existing sync group
    /// </summary>
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlSyncGroupV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium), OutputType(typeof(AzureSqlSyncGroupModelV2))]
    public class UpdateAzureSqlSyncGroupV2 : AzureSqlSyncGroupCmdletBaseV2
    {
        /// <summary>
        /// Gets or sets the sync group name
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The sync group name.")]
        [ValidateNotNullOrEmpty]
        [Alias("SyncGroupName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the frequency (in seconds) of doing data synchronization
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
        /// Gets or sets the path of the schema file
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The path of the schema file.")]
        public string SchemaFile { get; set; }

        /// <summary>
        /// Gets or sets if private link should be used
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Whether to use a private link connection when connecting to the hub of this sync group.")]
        public bool UsePrivateLinkConnection { get; set; }

        /// <summary>
        /// Gets or sets the Database Authentication type of the hub database
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The Database Authentication type of the hub database.")]
        [ValidateSet("password", "userAssigned", IgnoreCase = true)]
        public string HubDatabaseAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the identity ID of the hub database in case of user assigned identity authentication
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identity ID of the hub database in case of UAMI Authentication")]
        public string IdentityId { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncGroupModelV2> GetEntity()
        {
            return new List<AzureSqlSyncGroupModelV2>() {
                ModelAdapter.GetSyncGroup(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.Name)
            };
        }

        /// <summary>
        /// create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlSyncGroupModelV2> ApplyUserInputToModel(IEnumerable<AzureSqlSyncGroupModelV2> model)
        {
            AzureSqlSyncGroupModelV2 newModel = model.First();

            if (MyInvocation.BoundParameters.ContainsKey("IntervalInSeconds"))
            {
                newModel.IntervalInSeconds = this.IntervalInSeconds;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(UsePrivateLinkConnection)))
            {
                newModel.UsePrivateLinkConnection = this.UsePrivateLinkConnection;
            }

            // if schema file is specified
            if (MyInvocation.BoundParameters.ContainsKey("SchemaFile"))
            {
                try
                {
                    newModel.Schema = ConstructSchemaFromFileV2(this.SchemaFile);
                }
                catch (CloudException ex)
                {
                    // There are problems with schema file
                    throw new PSArgumentException(ex.Response.ToString(), "SchemaFile");
                }
            }

            if (!MyInvocation.BoundParameters.ContainsKey(nameof(HubDatabaseAuthenticationType)) ||
                this.HubDatabaseAuthenticationType.Equals("password", System.StringComparison.OrdinalIgnoreCase))
            {
                if (MyInvocation.BoundParameters.ContainsKey(nameof(DatabaseCredential)))
                {
                    newModel.HubDatabaseUserName = this.DatabaseCredential.UserName;
                    newModel.HubDatabasePassword = this.DatabaseCredential.Password;
                }
                else
                {
                    newModel.HubDatabaseUserName = null;
                    newModel.HubDatabasePassword = null;
                }

                newModel.Identity = new DataSyncParticipantIdentity
                {
                    Type = "None"
                };
            }
            else if (this.HubDatabaseAuthenticationType.Equals("userAssigned", System.StringComparison.OrdinalIgnoreCase))
            {
                if (!MyInvocation.BoundParameters.ContainsKey(nameof(IdentityId)) ||
                    string.IsNullOrEmpty(this.IdentityId))
                {
                    newModel.Identity = new DataSyncParticipantIdentity
                    {
                        Type = "UserAssigned"
                    };
                }
                else
                {
                    newModel.Identity = AzureSqlSyncIdentityHelper.CreateUserAssignedIdentity(this.IdentityId);
                }
            }
            else
            {
                throw new PSArgumentException(
                        Microsoft.Azure.Commands.Sql.Properties.Resources.InvalidDatabaseAuthenticationType,
                        "HubDatabaseAuthenticationType");
            }

            return model;
        }

        /// <summary>
        /// Update the sync group
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncGroupModelV2> PersistChanges(IEnumerable<AzureSqlSyncGroupModelV2> entity)
        {
            return new List<AzureSqlSyncGroupModelV2>() {
                ModelAdapter.UpdateSyncGroup(entity.First())
            };
        }
    }
}
