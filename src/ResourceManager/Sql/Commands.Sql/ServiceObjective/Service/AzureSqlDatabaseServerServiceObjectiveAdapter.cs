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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ServiceObjective.Model;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ServiceObjective.Adapter
{
    /// <summary>
    /// Adapter for ServiceObjective operations
    /// </summary>
    public class AzureSqlDatabaseServerServiceObjectiveAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Constructs a ServiceObjective adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseServerServiceObjectiveAdapter(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            AzureCommunicator = new AzureEndpointsCommunicator(Profile, subscription);
        }

        /// <summary>
        /// Gets a ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="serviceObjectiveName">The name of the service objective</param>
        /// <returns>The ServiceObjective</returns>
        public AzureSqlDatabaseServerServiceObjectiveModel GetServiceObjective(string resourceGroupName, string serverName, string serviceObjectiveName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());
            
            ServiceObjectiveGetResponse resp = client.ServiceObjectives.Get(resourceGroupName, serverName, serviceObjectiveName);
            return CreateServiceObjectiveModelFromResponse(resourceGroupName, serverName, resp.ServiceObjective);
        }

        /// <summary>
        /// Gets a list of all the ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the ServiceObjectives</returns>
        public List<AzureSqlDatabaseServerServiceObjectiveModel> ListServiceObjectives(string resourceGroupName, string serverName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            ServiceObjectiveListResponse resp = client.ServiceObjectives.List(resourceGroupName, serverName);

            return resp.ServiceObjectives.Select((s) =>
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
        private static AzureSqlDatabaseServerServiceObjectiveModel CreateServiceObjectiveModelFromResponse(string resourceGroupName, string serverName, Management.Sql.Models.ServiceObjective resp)
        {
            AzureSqlDatabaseServerServiceObjectiveModel slo = new AzureSqlDatabaseServerServiceObjectiveModel();

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
