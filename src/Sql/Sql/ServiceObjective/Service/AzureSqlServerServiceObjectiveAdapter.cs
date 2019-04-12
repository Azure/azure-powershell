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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ServiceObjective.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.Sql.Location_Capabilities.Services;
using Microsoft.Azure.Commands.Sql.Server.Services;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ServiceObjective.Adapter
{
    /// <summary>
    /// Adapter for ServiceObjective operations
    /// </summary>
    public class AzureSqlServerServiceObjectiveAdapter
    {
        /// <summary>
        /// Gets or sets the server communicator.
        /// </summary>
        public AzureSqlServerCommunicator ServerCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the capabilities communicator.
        /// </summary>
        public AzureSqlCapabilitiesCommunicator CapabilitiesCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a ServiceObjective adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerServiceObjectiveAdapter(IAzureContext context)
        {
            Context = context;
            ServerCommunicator = new AzureSqlServerCommunicator(Context);
            CapabilitiesCommunicator = new AzureSqlCapabilitiesCommunicator(Context);
        }

        /// <summary>
        /// Gets a ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="serviceObjectiveName">The name of the service objective</param>
        /// <returns>The ServiceObjective</returns>
        public List<AzureSqlServerServiceObjectiveModel> GetServiceObjective(string resourceGroupName, string serverName, string serviceObjectiveName)
        {
            var server = ServerCommunicator.Get(resourceGroupName, serverName);
            var capabilities = CapabilitiesCommunicator.Get(server.Location);

            return (
                from serverVersion in FilterByName(capabilities.SupportedServerVersions, server.Version)
                from edition in serverVersion.SupportedEditions
                from serviceObjective in FilterByName(edition.SupportedServiceLevelObjectives, serviceObjectiveName)
                select CreateServiceObjectiveModelFromResponse(edition, serviceObjective, resourceGroupName, serverName)).ToList();
        }

        /// <summary>
        /// Gets a list of all the ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the ServiceObjectives</returns>
        public List<AzureSqlServerServiceObjectiveModel> ListServiceObjectives(string resourceGroupName, string serverName)
        {
            var server = ServerCommunicator.Get(resourceGroupName, serverName);
            var capabilities = CapabilitiesCommunicator.Get(server.Location);

            return (
                from serverVersion in FilterByName(capabilities.SupportedServerVersions, server.Version)
                from edition in serverVersion.SupportedEditions
                from serviceObjective in edition.SupportedServiceLevelObjectives
                select CreateServiceObjectiveModelFromResponse(edition, serviceObjective, resourceGroupName, serverName)).ToList();
        }

        /// <summary>
        /// Convert a SLO capability to AzureSqlDatabaseServerServiceObjectiveModel
        /// </summary>
        /// <param name="edition">The edition</param>
        /// <param name="slo">The service objective</param>
        /// <param name="resourceGroupName">The resource group name</param>
        /// /// <param name="serverName">The server name</param>
        /// <returns>The converted ServiceObjective model</returns>
        private static AzureSqlServerServiceObjectiveModel CreateServiceObjectiveModelFromResponse(
            EditionCapability edition,
            ServiceObjectiveCapability slo,
            string resourceGroupName = null,
            string serverName = null)
        {
            return new AzureSqlServerServiceObjectiveModel()
            {
                ResourceGroupName = resourceGroupName,
                ServerName = serverName,
                ServiceObjectiveName = slo.Name,
                IsDefault = slo.Status == CapabilityStatus.Default,
                IsSystem = string.Equals(edition.Name, "System", StringComparison.OrdinalIgnoreCase),
                Description = string.Empty,
                Enabled = IsEnabled(slo.Status),
                Edition = edition.Name,
                SkuName = slo.Sku.Name,
                Family = slo.Sku.Family,
                Capacity = slo.Sku.Capacity,
                CapacityUnit = slo.PerformanceLevel.Unit
            };
        }

        #region Filter by name

        private static IEnumerable<ServerVersionCapability> FilterByName(IEnumerable<ServerVersionCapability> capabilities, string name)
        {
            return capabilities.Where(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<EditionCapability> FilterByName(IEnumerable<EditionCapability> capabilities, string name)
        {
            return capabilities.Where(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        private static IEnumerable<ServiceObjectiveCapability> FilterByName(IEnumerable<ServiceObjectiveCapability> capabilities, string name)
        {
            return capabilities.Where(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        #endregion

        private static bool IsEnabled(CapabilityStatus? status)
        {
            return status == CapabilityStatus.Default || status == CapabilityStatus.Available;
        }
    }
}
