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
using Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Model;
using Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Services;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Adapter
{
    /// <summary>
    /// Adapter for virtual network rule operations
    /// </summary>
    public class AzureSqlServerVirtualNetworkRuleAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerVirtualNetworkRuleCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a virtual network rule adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerVirtualNetworkRuleAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerVirtualNetworkRuleCommunicator(Context);
        }

        /// <summary>
        /// Gets a virtual network rule in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="vnetFirewallRuleName">The virtual network rule name</param>
        /// <returns>The virtual network rule</returns>
        public AzureSqlServerVirtualNetworkRuleModel GetVirtualNetworkRule(string resourceGroupName, string serverName, string vnetFirewallRuleName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, vnetFirewallRuleName);
            return CreateVirtualNetworkRuleModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of all the virtual network rules in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the virtual network rules</returns>
        public List<AzureSqlServerVirtualNetworkRuleModel> ListVirtualNetworkRules(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);
            return resp.Select((s) =>
            {
                return CreateVirtualNetworkRuleModelFromResponse(resourceGroupName, serverName, s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a virtual network rule
        /// </summary>
        /// <param name="model">The virtual network rule to create</param>
        /// <returns>The updated virtual network rule model</returns>
        public AzureSqlServerVirtualNetworkRuleModel UpsertVirtualNetworkRule(AzureSqlServerVirtualNetworkRuleModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.VirtualNetworkRuleName, new Management.Sql.Models.VirtualNetworkRule()
            {
                VirtualNetworkSubnetId = model.VirtualNetworkSubnetId,
                IgnoreMissingVnetServiceEndpoint = model.IgnoreMissingVnetServiceEndpoint
            });
            return CreateVirtualNetworkRuleModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Deletes a virtual network rule
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server from which the virtual network rule should be removed</param>
        /// <param name="vnetFirewallRuleName">The name of the virtual network rule to remove</param>
        public void RemoveVirtualNetworkRule(string resourceGroupName, string serverName, string vnetFirewallRuleName)
        {
            Communicator.Remove(resourceGroupName, serverName, vnetFirewallRuleName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.VnetFirewallRule to AzureSqlServerVirtualNetworkRuleModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted virtual network rule model</returns>
        private static AzureSqlServerVirtualNetworkRuleModel CreateVirtualNetworkRuleModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.VirtualNetworkRule resp)
        {
            AzureSqlServerVirtualNetworkRuleModel vnetFirewallRuleName = new AzureSqlServerVirtualNetworkRuleModel();

            vnetFirewallRuleName.ResourceGroupName = resourceGroup;
            vnetFirewallRuleName.ServerName = serverName;
            vnetFirewallRuleName.VirtualNetworkRuleName = resp.Name;
            vnetFirewallRuleName.VirtualNetworkSubnetId = resp.VirtualNetworkSubnetId;
            vnetFirewallRuleName.IgnoreMissingVnetServiceEndpoint = resp.IgnoreMissingVnetServiceEndpoint;
            vnetFirewallRuleName.State = resp.State;

            return vnetFirewallRuleName;
        }
    }
}
