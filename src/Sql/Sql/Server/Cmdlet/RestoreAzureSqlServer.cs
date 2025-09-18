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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Restore-AzSqlServer cmdlet
    /// </summary>
    [Cmdlet("Restore", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServer", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true), OutputType(typeof(Model.AzureSqlServerModel))]
    public class RestoreAzureSqlServer : AzureSqlServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the database server to use.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "SQL Database server name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// The location in which to create the server
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The location in which to create the server")]
        [LocationCompleter("Microsoft.Sql/servers")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.ServerName == "")
            {
                throw new PSArgumentException("Missing ServerName");
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the server already exists as a live server or if there's a deleted server to restore.
        /// </summary>
        /// <returns>Null if ready to restore. Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> GetEntity()
        {
            // First check if a live server already exists
            try
            {
                bool serverExists = ModelAdapter.ListServers().Any(s =>
                    string.Equals(s.ResourceGroupName, this.ResourceGroupName, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(s.ServerName, this.ServerName, StringComparison.OrdinalIgnoreCase));

                if (serverExists)
                {
                    // If we get here, a live server exists - cannot restore
                    throw new PSArgumentException(
                        string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.ServerName),
                        "ServerName");
                }
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    // Unexpected exception encountered
                    throw;
                }
                //Continue - no live server exists, which is what we want
            }

            // Now check if there's a deleted server to restore
            try
            {
                var deletedServer = ModelAdapter.GetDeletedServer(this.ResourceGroupName, this.ServerName);
                if (deletedServer == null)
                {
                    throw new PSArgumentException(
                        string.Format("No deleted server named '{0}' found in resource group '{1}' that can be restored.",
                        this.ServerName, this.ResourceGroupName),
                        "ServerName");
                }

                // Deleted server exists and can be restored
                return null;
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new PSArgumentException(
                        string.Format("No deleted server named '{0}' found in resource group '{1}' that can be restored.", 
                        this.ServerName, this.ResourceGroupName),
                        "ServerName");
                }
                
                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerModel> model)
        {
            if (!Sql.Services.Util.ValidateServerName(this.ServerName))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ServerNameInvalid, this.ServerName), "ServerName");
            }

            List<Model.AzureSqlServerModel> newEntity = new List<Model.AzureSqlServerModel>();
            newEntity.Add(new Model.AzureSqlServerModel()
            {
                Location = this.Location,
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                CreateMode = "Restore"
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the server
        /// </summary>
        /// <param name="entity">The server to create</param>
        /// <returns>The created server</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> PersistChanges(IEnumerable<Model.AzureSqlServerModel> entity)
        {
            return new List<Model.AzureSqlServerModel>() {
                ModelAdapter.UpsertServer(entity.First())
            };
        }
    }
}
