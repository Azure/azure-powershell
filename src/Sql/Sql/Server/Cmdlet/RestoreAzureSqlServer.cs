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
using Microsoft.Rest.Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServer cmdlet
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
        /// Soft-delete retention days for the server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the create mode for the server, valid values for this parameter are \"Normal\" and \"Restore\".")]
        public string CreateMode { get; set; } = "Restore";

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
        /// Check to see if the server already exists in this resource group.
        /// </summary>
        /// <returns>Null if the server doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no server with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The server already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.ServerName),
                "ServerName");
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
                CreateMode = this.CreateMode
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
