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
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Management.Sql.Models;
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
        /// Gets the deleted server adapter for accessing deleted server information
        /// </summary>
        private AzureSqlDeletedServerAdapter DeletedServerAdapter
        {
            get
            {
                if (_deletedServerAdapter == null)
                {
                    _deletedServerAdapter = new AzureSqlDeletedServerAdapter(DefaultContext);
                }
                return _deletedServerAdapter;
            }
        }

        private AzureSqlDeletedServerAdapter _deletedServerAdapter;

        /// <summary>
        /// Stores the deleted server information to use in ApplyUserInputToModel
        /// </summary>
        private AzureSqlDeletedServerModel _deletedServerModel;
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
        /// Check to see if the server already exists as a live server or if there's a deleted server to restore.
        /// </summary>
        /// <returns>Null - the deleted server info is stored in _deletedServerModel field</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> GetEntity()
        {
            // Retrieve and validate the deleted server exists in the specified resource group
            _deletedServerModel = GetDeletedServerInResourceGroup();

            // Check if a live server already exists with this name
            VerifyServerDoesNotExist();

            return null;
        }

        /// <summary>
        /// Generates the model from the user input and deleted server metadata
        /// </summary>
        /// <param name="model">This is null since the server doesn't exist yet</param>
        /// <returns>The server model configured for restore operation with properties from deleted server and user input</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerModel> model)
        {
            return new List<Model.AzureSqlServerModel>
            {
                new Model.AzureSqlServerModel
                {
                    Location = this.Location,
                    ResourceGroupName = this.ResourceGroupName,
                    ServerName = this.ServerName,
                    CreateMode = "Restore"
                }
            };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the server
        /// </summary>
        /// <param name="entity">The server to create</param>
        /// <returns>The created server</returns>
        protected override IEnumerable<Model.AzureSqlServerModel> PersistChanges(IEnumerable<Model.AzureSqlServerModel> entity)
        {
            try
            {
                return new List<Model.AzureSqlServerModel>() {
                    ModelAdapter.UpsertServer(entity.First())
                };
            }
            catch (ErrorResponseException errEx) when (errEx.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Check if it's a resource group not found error
                string errorCode = errEx.Body?.Error?.Code;

                if (errorCode == "ResourceGroupNotFound")
                {
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.ResourceGroupNotFoundForRestore,
                            this.ServerName, this.ResourceGroupName),
                        "ResourceGroupName");
                }
                // Re-throw if it's not a resource group issue
                throw;
            }
        }

        /// <summary>
        /// Retrieves the deleted server and validates it exists in the user-provided resource group
        /// </summary>
        /// <returns>The deleted server model</returns>
        private AzureSqlDeletedServerModel GetDeletedServerInResourceGroup()
        {
            DeletedServer deletedServer;
            try
            {
                deletedServer = DeletedServerAdapter.GetDeletedServer(this.Location, this.ServerName);
            }
            catch (ErrorResponseException errEx) when (errEx.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new PSArgumentException(
                    string.Format(Properties.Resources.DeletedServerNotFound, this.ServerName, this.Location),
                    "ServerName");
            }

            AzureSqlDeletedServerModel deletedServerModel = DeletedServerAdapter.CreateDeletedServerModelFromResponse(deletedServer);

            if (deletedServerModel == null)
            {
                throw new PSArgumentException(
                    string.Format(Properties.Resources.DeletedServerNotFound, this.ServerName, this.Location),
                    "ServerName");
            }

            // Validate that the user-provided ResourceGroupName matches the deleted server's ResourceGroupName
            if (!string.Equals(this.ResourceGroupName, deletedServerModel.ResourceGroupName, StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException(
                    string.Format(Properties.Resources.ResourceGroupMismatchForRestore,
                        this.ResourceGroupName, deletedServerModel.ResourceGroupName, this.ServerName),
                    "ResourceGroupName");
            }

            return deletedServerModel;
        }

        /// <summary>
        /// Verifies that a live server does not already exist with the given name
        /// </summary>
        private void VerifyServerDoesNotExist()
        {
            try
            {
                ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName);

                // If we reach here, server exists - cannot restore
                throw new PSArgumentException(
                    string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.ServerName),
                    "ServerName");
            }
            catch (ErrorResponseException errEx) when (errEx.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Server not found is expected - check if it's a resource group issue
                string errorCode = errEx.Body?.Error?.Code;

                if (errorCode == "ResourceGroupNotFound")
                {
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.ResourceGroupNotFoundForRestore,
                            this.ServerName, this.ResourceGroupName),
                        "ResourceGroupName");
                }
                // Otherwise, NotFound is expected (no live server exists) - continue
            }
        }
    }
}
