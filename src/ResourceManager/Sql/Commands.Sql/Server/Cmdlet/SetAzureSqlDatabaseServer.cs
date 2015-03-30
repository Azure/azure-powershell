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
using System.Security;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureSqlDatabaseServer cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseServer", 
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabaseServer : AzureSqlDatabaseServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "SQL Database server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The new SQL administrator password for the server.")]
        [ValidateNotNull]
        public SecureString SqlAdminPassword { get; set; }
        
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The tags to associate with the server.")]
        [ValidateNotNull]
        public Dictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the server version
        /// </summary>
        [Parameter(Mandatory = false, 
            ValueFromPipelineByPropertyName = true, 
            HelpMessage = "Which server version to change to.")]
        [ValidateNotNullOrEmpty]
        public string ServerVersion { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the server to update
        /// </summary>
        /// <returns>The server being updated</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseServerModel> GetEntity()
        {
            return new List<Model.AzureSqlDatabaseServerModel>() { ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseServerModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlDatabaseServerModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlDatabaseServerModel> updateData = new List<Model.AzureSqlDatabaseServerModel>();
            updateData.Add(new Model.AzureSqlDatabaseServerModel()
                {
                    SqlAdminPassword = this.SqlAdminPassword,
                    Tags = this.Tags,
                    ServerVersion = this.ServerVersion
                });
            return updateData;
        }

        /// <summary>
        /// Sends the server update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseServerModel> PersistChanges(IEnumerable<Model.AzureSqlDatabaseServerModel> entity)
        {
            return new List<Model.AzureSqlDatabaseServerModel>() { ModelAdapter.UpsertServer(entity.First()) };
        }
    }
}
