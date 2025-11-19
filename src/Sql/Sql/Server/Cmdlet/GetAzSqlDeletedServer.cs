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
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Server.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlDeletedServer cmdlet
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDeletedServer", ConfirmImpact = ConfirmImpact.None)]
    [OutputType(typeof(AzureSqlDeletedServerModel))]
    public class GetAzSqlDeletedServer : AzureSqlDeletedServerCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the deleted server to retrieve. If not specified, lists all deleted servers in the location.
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the deleted server to retrieve. If not specified, lists all deleted servers in the location.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the location where the deleted server was located
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The Azure region where the deleted server was located.")]
        [LocationCompleter("Microsoft.Sql/deletedServers")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets deleted servers from the service.
        /// </summary>
        /// <returns>A collection of deleted servers</returns>
        protected override IEnumerable<AzureSqlDeletedServerModel> GetEntity()
        {
            ICollection<AzureSqlDeletedServerModel> results = new List<AzureSqlDeletedServerModel>();

            if (!string.IsNullOrEmpty(this.ServerName))
            {
                // Get a specific deleted server
                var deletedServer = ModelAdapter.GetDeletedServer(this.Location, this.ServerName);
                if (deletedServer != null)
                {
                    var model = ModelAdapter.CreateDeletedServerModelFromResponse(deletedServer);
                    results.Add(model);
                }
            }
            else
            {
                // List all deleted servers in the location
                var deletedServers = ModelAdapter.ListDeletedServers(this.Location);
                foreach (var deletedServer in deletedServers)
                {
                    var model = ModelAdapter.CreateDeletedServerModelFromResponse(deletedServer);
                    results.Add(model);
                }
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlDeletedServerModel> PersistChanges(IEnumerable<AzureSqlDeletedServerModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlDeletedServerModel> ApplyUserInputToModel(IEnumerable<AzureSqlDeletedServerModel> model)
        {
            return model;
        }
    }
}