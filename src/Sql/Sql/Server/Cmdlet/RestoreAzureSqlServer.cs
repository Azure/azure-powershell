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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
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
                return _deletedServerAdapter ?? (_deletedServerAdapter = new AzureSqlDeletedServerAdapter(DefaultContext));
            }
        }

        private AzureSqlDeletedServerAdapter _deletedServerAdapter;
        
        /// <summary>
        /// Stores the deleted server information to use in ApplyUserInputToModel
        /// </summary>
        private AzureSqlDeletedServerModel _deletedServerModel;

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// This is not a parameter for Restore-AzSqlServer - it's retrieved from deleted server metadata.
        /// Hiding the base class parameter by not applying [Parameter] attribute.
        /// </summary>
        public override string ResourceGroupName { get; set; }

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
            // First retrieve the deleted server to get metadata (including ResourceGroupName)
            try
            {
                DeletedServer deletedServer = DeletedServerAdapter.GetDeletedServer(this.Location, this.ServerName);
                _deletedServerModel = DeletedServerAdapter.CreateDeletedServerModelFromResponse(deletedServer);

                if (_deletedServerModel == null)
                {
                    // No deleted server found
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.DeletedServerNotFound,
                        this.ServerName, this.Location),
                        "ServerName");
                }

                // Set ResourceGroupName from deleted server metadata (not user input)
                this.ResourceGroupName = _deletedServerModel.ResourceGroupName;
            }
            catch (PSArgumentException)
            {
                // Re-throw PSArgumentException as-is
                throw;
            }
            catch (ErrorResponseException errEx) when (errEx.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle NotFound exceptions (DeletedServerNotFound)
                HandleNotFoundException(errEx, throwDeletedServerNotFound: true);
                
                // If HandleNotFoundException didn't throw, it's an unexpected scenario
                throw;
            }

            // Now check if a live server already exists with this name
            try
            {
                // If GetServer succeeds, a live server exists - cannot restore
                ModelAdapter.GetServer(this.ResourceGroupName, this.ServerName);
                
                throw new PSArgumentException(
                    string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.ServerName),
                    "ServerName");
            }
            catch (PSArgumentException)
            {
                // Re-throw PSArgumentException as-is
                throw;
            }
            catch (ErrorResponseException errEx) when (errEx.Response?.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle NotFound exceptions (ResourceGroupNotFound will throw, server NotFound is expected)
                HandleNotFoundException(errEx, throwDeletedServerNotFound: false);
            }

            // Deleted server exists and can be restored
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
                // Handle NotFound exceptions (ResourceGroupNotFound will throw)
                HandleNotFoundException(errEx, throwDeletedServerNotFound: false);
                
                // If HandleNotFoundException didn't throw, it's an unexpected scenario
                throw;
            }
        }
        
        /// <summary>
        /// Helper method to handle NotFound exceptions and throw appropriate user-friendly errors
        /// </summary>
        /// <param name="errEx">The ErrorResponseException with NotFound status to handle</param>
        /// <param name="throwDeletedServerNotFound">If true, throws DeletedServerNotFound error for ResourceNotFound. If false, ignores it.</param>
        private void HandleNotFoundException(ErrorResponseException errEx, bool throwDeletedServerNotFound = false)
        {
            string errorCode = errEx.Body?.Error?.Code;
            string errorMessage = errEx.Body?.Error?.Message ?? errEx.Message;
            
            // Check error type and throw appropriate exception
            if (errorCode == "ResourceGroupNotFound" || 
                (errorMessage.Contains("Resource group") && errorMessage.Contains("could not be found")))
            {
                // Resource group not found
                throw new PSArgumentException(
                    string.Format(Properties.Resources.ResourceGroupNotFoundForRestore,
                        this.ServerName, this.ResourceGroupName, this.Location),
                    "ResourceGroupName");
            }
            else if (throwDeletedServerNotFound && 
                     (errorCode == "ResourceNotFound" || 
                      (errorMessage.Contains("Resource") && errorMessage.Contains("was not found"))))
            {
                // Deleted server not found
                throw new PSArgumentException(
                    string.Format(Properties.Resources.DeletedServerNotFound, 
                        this.ServerName, this.Location),
                    "ServerName");
            }
        }
    }
}
