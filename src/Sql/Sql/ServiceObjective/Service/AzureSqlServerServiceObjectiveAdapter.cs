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
using System.Management.Automation;
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
        /// <param name="context">The current azure context</param>
        public AzureSqlServerServiceObjectiveAdapter(IAzureContext context)
        {
            Context = context;
            ServerCommunicator = new AzureSqlServerCommunicator(Context);
            CapabilitiesCommunicator = new AzureSqlCapabilitiesCommunicator(Context);
        }

        /// <summary>
        /// Gets a list of all the ServiceObjective for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="serviceObjectiveNamePattern">The name of the serviceObjective, or null to get all.</param>
        /// <returns>A list of all the ServiceObjectives</returns>
        public List<AzureSqlServerServiceObjectiveModel> ListServiceObjectivesByServer(
            string resourceGroupName,
            string serverName,
            WildcardPattern serviceObjectiveNamePattern)
        {
            var server = ServerCommunicator.Get(resourceGroupName, serverName);
            var capabilities = CapabilitiesCommunicator.Get(server.Location);

            return (
                from serverVersion in FilterByName(capabilities.SupportedServerVersions, server.Version)
                from edition in serverVersion.SupportedEditions
                from serviceObjective in FilterByName(edition.SupportedServiceLevelObjectives, serviceObjectiveNamePattern)
                select CreateServiceObjectiveModelFromResponse(edition, serviceObjective, resourceGroupName, serverName)).ToList();
        }

        /// <summary>
        /// Gets a list of all the ServiceObjective for a location
        /// </summary>
        /// <param name="locationName">The name of the location</param>
        /// <param name="serviceObjectiveNamePattern">The name of the serviceObjective, or null to get all.</param>
        /// <returns>A list of all the ServiceObjectives</returns>
        public List<AzureSqlServerServiceObjectiveModel> ListServiceObjectivesByLocation(
            string locationName,
            WildcardPattern serviceObjectiveNamePattern)
        {
            var capabilities = CapabilitiesCommunicator.Get(locationName);

            return (
                from serverVersion in capabilities.SupportedServerVersions
                from edition in serverVersion.SupportedEditions
                from serviceObjective in FilterByName(edition.SupportedServiceLevelObjectives, serviceObjectiveNamePattern)
                select CreateServiceObjectiveModelFromResponse(edition, serviceObjective)).ToList();
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

        private static IEnumerable<ServiceObjectiveCapability> FilterByName(IEnumerable<ServiceObjectiveCapability> capabilities, WildcardPattern nameFilter)
        {
            return capabilities.Where(c => nameFilter.IsMatch(c.Name));
        }

        #endregion

        private static bool IsEnabled(CapabilityStatus? status)
        {
            return status == CapabilityStatus.Default || status == CapabilityStatus.Available;
        }
    }
}
