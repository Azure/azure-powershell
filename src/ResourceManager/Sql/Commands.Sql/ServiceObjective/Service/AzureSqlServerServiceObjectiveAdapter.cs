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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.ServiceObjective.Model;
using Microsoft.Azure.Commands.Sql.ServiceObjective.Services;
using Microsoft.Azure.Commands.Sql.Services;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServiceObjective.Adapter
{
    /// <summary>
    /// Adapter for ServiceObjective operations
    /// </summary>
    public class AzureSqlServerServiceObjectiveAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlDatabaseServerServiceObjectiveCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerServiceObjectiveCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a ServiceObjective adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerServiceObjectiveAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerServiceObjectiveCommunicator(Context);
        }

        /// <summary>
        /// Gets a ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="serviceObjectiveName">The name of the service objective</param>
        /// <returns>The ServiceObjective</returns>
        public AzureSqlServerServiceObjectiveModel GetServiceObjective(string resourceGroupName, string serverName, string serviceObjectiveName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, serviceObjectiveName, Util.GenerateTracingId());
            return CreateServiceObjectiveModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of all the ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the ServiceObjectives</returns>
        public List<AzureSqlServerServiceObjectiveModel> ListServiceObjectives(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((s) =>
            {
                return CreateServiceObjectiveModelFromResponse(resourceGroupName, serverName, s);
            }).ToList();
        }

        /// <summary>
        /// Convert a Management.Sql.Models.ServiceObjective to AzureSqlDatabaseServerServiceObjectiveModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client ServiceObjective response to convert</param>
        /// <returns>The converted ServiceObjective model</returns>
        private static AzureSqlServerServiceObjectiveModel CreateServiceObjectiveModelFromResponse(string resourceGroupName, string serverName, Management.Sql.Models.ServiceObjective resp)
        {
            AzureSqlServerServiceObjectiveModel slo = new AzureSqlServerServiceObjectiveModel();

            slo.ResourceGroupName = resourceGroupName;
            slo.ServerName = serverName;
            slo.ServiceObjectiveName = resp.Properties.ServiceObjectiveName;
            slo.IsDefault = resp.Properties.IsDefault;
            slo.IsSystem = resp.Properties.IsSystem;
            slo.Description = resp.Properties.Description;
            slo.Enabled = resp.Properties.Enabled;

            return slo;
        }
    }
}
