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
using Microsoft.Azure.Commands.Sql.Server.Adapter;
using Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Model;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerDisasterRecoveryConfiguration.Services
{
    /// <summary>
    /// Adapter for Server Disaster Recovery Configuration operations
    /// </summary>
    public class AzureSqlServerDisasterRecoveryConfigurationAdapter
    {
        /// <summary>
        /// Gets or sets the AzureSqlServerDisasterRecoveryConfigurationCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerDisasterRecoveryConfigurationCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Gets or sets the Azure Subscription
        /// </summary>
        private AzureSubscription _subscription { get; set; }

        /// <summary>
        /// Constructs a Server Disaster Recovery Configuration adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerDisasterRecoveryConfigurationAdapter(AzureContext context)
        {
            Context = context;
            _subscription = context.Subscription;
            Communicator = new AzureSqlServerDisasterRecoveryConfigurationCommunicator(Context);
        }

        /// <summary>
        /// Gets an Azure Sql Server Disaster Recovery Configuration by name.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="serverDisasterRecoveryConfigurationName">The name of the Azure Sql Server Disaster Recovery Configuration</param>
        /// <returns>The Azure Sql Server Disaster Recovery Configuration object</returns>
        internal AzureSqlServerDisasterRecoveryConfigurationModel GetServerDisasterRecoveryConfiguration(string resourceGroupName, string serverName, string serverDisasterRecoveryConfigurationName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, serverDisasterRecoveryConfigurationName, Util.GenerateTracingId());
            return CreateServerDisasterRecoveryConfigurationModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of Azure Sql Server DisasterRecoveryConfigurations.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <returns>A list of Server Disaster Recovery Configuration objects</returns>
        internal ICollection<AzureSqlServerDisasterRecoveryConfigurationModel> ListServerDisasterRecoveryConfigurations(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            return resp.Select((serverDisasterRecoveryConfigurationName) => CreateServerDisasterRecoveryConfigurationModelFromResponse(resourceGroupName, serverName, serverDisasterRecoveryConfigurationName)).ToList();
        }

        /// <summary>
        /// Creates an Azure Sql Server Disaster Recovery Configuration.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="partnerServerId">The id (path) of the partner Azure Sql Server</param>
        /// <param name="model">A model containing parameters for the Server Disaster Recovery Configuration</param>
        /// <returns>The created Azure Sql Server Disaster Recovery Configuration</returns>
        internal AzureSqlServerDisasterRecoveryConfigurationModel CreateServerDisasterRecoveryConfiguration(string resourceGroup, string serverName, string partnerServerId, AzureSqlServerDisasterRecoveryConfigurationModel model)
        {
            var resp = Communicator.Create(resourceGroup, serverName, model.ServerDisasterRecoveryConfigurationName, Util.GenerateTracingId(), new ServerDisasterRecoveryConfigurationCreateOrUpdateParameters()
            {
                Location = model.Location,
                Properties = new ServerDisasterRecoveryConfigurationCreateOrUpdateProperties()
                {
                    PartnerServerId = partnerServerId
                }
            });

            return CreateServerDisasterRecoveryConfigurationModelFromResponse(resourceGroup, serverName, resp);
        }

        /// <summary>
        /// Starts failover for an Azure Sql Server Disaster Recovery Configuration.
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <param name="allowDataLoss">Whether or not potential data loss is allowed during the failover</param>
        internal void FailoverServerDisasterRecoveryConfiguration(string resourceGroup, string serverName, AzureSqlServerDisasterRecoveryConfigurationModel model, bool allowDataLoss)
        {
            Communicator.Failover(resourceGroup, serverName, model.ServerDisasterRecoveryConfigurationName, allowDataLoss, Util.GenerateTracingId());
        }

        /// <summary>
        /// Deletes a Server Disaster Recovery Configuration
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="serverDisasterRecoveryConfigurationName">The name of the Azure Sql Server Disaster Recovery Configuration to delete</param>
        public void RemoveServerDisasterRecoveryConfiguration(string resourceGroupName, string serverName, string serverDisasterRecoveryConfigurationName)
        {
            Communicator.Remove(resourceGroupName, serverName, serverDisasterRecoveryConfigurationName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Gets the Location of the server.
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns></returns>
        public string GetServerLocation(string resourceGroupName, string serverName)
        {
            AzureSqlServerAdapter serverAdapter = new AzureSqlServerAdapter(Context);
            var server = serverAdapter.GetServer(resourceGroupName, serverName);
            return server.Location;
        }

        /// <summary>
        /// Converts the response from the service to a powershell Server Disaster Recovery Configuration object
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the Azure Sql Server</param>
        /// <param name="serverDisasterRecoveryConfiguration">The service response</param>
        /// <returns>The converted model</returns>
        public static AzureSqlServerDisasterRecoveryConfigurationModel CreateServerDisasterRecoveryConfigurationModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.ServerDisasterRecoveryConfiguration serverDisasterRecoveryConfiguration)
        {
            return new AzureSqlServerDisasterRecoveryConfigurationModel(resourceGroup, serverName, serverDisasterRecoveryConfiguration);
        }

        internal IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> ListServerDisasterRecoveryConfigurationActivity(string resourceGroupName, string serverName, string serverDisasterRecoveryConfigurationName, Guid? operationId)
        {
            var response = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());

            IEnumerable<AzureSqlServerDisasterRecoveryConfigurationActivityModel> list = response.Select((r) =>
            {
                return new AzureSqlServerDisasterRecoveryConfigurationActivityModel()
                {
                    ServerDisasterRecoveryConfigurationName = r.Name,

                };
            });

            // Check if we have a database name constraint
            if (!string.IsNullOrEmpty(serverDisasterRecoveryConfigurationName))
            {
                list = list.Where(pl => string.Equals(pl.ServerDisasterRecoveryConfigurationName, serverDisasterRecoveryConfigurationName, StringComparison.OrdinalIgnoreCase));
            }

            return list.ToList();
        }
    }
}
