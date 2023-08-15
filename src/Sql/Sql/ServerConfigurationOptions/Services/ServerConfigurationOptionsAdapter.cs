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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Model;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.ServerConfigurationOptions.Services
{
    /// <summary>
    /// Adapter for ServerConfigurationOptions operations
    /// </summary>
    public class ServerConfigurationOptionsAdapter
    {
        /// <summary>
        /// Gets or sets the ServerConfigurationOptionsCommunicator which has all the needed management clients
        /// </summary>
        private ServerConfigurationOptionsCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a ServerConfigurationOptions adapter
        /// </summary>
        /// <param name="context"></param>
        public ServerConfigurationOptionsAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new ServerConfigurationOptionsCommunicator(Context);
        }

        /// <summary>
        /// Gets a server configuration option in a managed instance
        /// </summary>
        /// <param name="resourceGroupName">Name of the resource group</param>
        /// <param name="instanceName">Name of the managed instance</param>
        /// <returns>Server configuration option</returns>
        public ServerConfigurationOptionsModel GetServerConfigurationOption(string resourceGroupName, string instanceName)
        {
            var resp = Communicator.Get(resourceGroupName, instanceName);
            return CreateServerConfigurationOptionsFromResponse(resourceGroupName, instanceName, resp);
        }

        /// <summary>
        /// Gets a list of all server configuration options in a managed instance
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="instanceName"></param>
        /// <returns>A list of all the server configuration options</returns>
        public List<ServerConfigurationOptionsModel> ListServerConfigurationOptions(string resourceGroupName, string instanceName)
        {
            var resp = Communicator.List(resourceGroupName, instanceName);

            return resp.Select((opt) => CreateServerConfigurationOptionsFromResponse(resourceGroupName, instanceName, opt)).ToList();
        }

        /// <summary>
        /// Sets the value of the server configuration options
        /// </summary>
        /// <param name="model">The input parameters for the create/update operation</param>
        /// <returns>Server configuration options</returns>
        internal ServerConfigurationOptionsModel SetConfigurationOption(ServerConfigurationOptionsModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.InstanceName, new ServerConfigurationOption
            {
                ServerConfigurationOptionValue = model.Value
            });

            return CreateServerConfigurationOptionsFromResponse(model.ResourceGroupName, model.InstanceName, resp);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.ServerConfigurationOption to ServerConfigurationOptionsModel
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="instanceName">Managed instance name</param>
        /// <param name="serverConfigurationOption">The management client server configuration option response to convert</param>
        /// <returns>The converted server configuration option model</returns>
        private static ServerConfigurationOptionsModel CreateServerConfigurationOptionsFromResponse(string resourceGroupName, string instanceName, ServerConfigurationOption serverConfigurationOption)
        {
            ServerConfigurationOptionsModel serverConfigurationOptionsModel = new ServerConfigurationOptionsModel()
            {
                ResourceGroupName = resourceGroupName,
                InstanceName = instanceName,
                Id = serverConfigurationOption.Id,
                Type = serverConfigurationOption.Type,
                Name = serverConfigurationOption.Name,
                Value = serverConfigurationOption.ServerConfigurationOptionValue
            };
            return serverConfigurationOptionsModel;
        }
    }
}

