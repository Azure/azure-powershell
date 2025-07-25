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
using Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Model;
using Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Services;
using Microsoft.Azure.Commands.Sql.Services;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Adapter
{
    /// <summary>
    /// Adapter for ipv6 firewall operations
    /// </summary>
    public class AzureSqlServerIpv6FirewallRuleAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerIpv6FirewallRuleCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs an ipv6 firewall rule adapter
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerIpv6FirewallRuleAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerIpv6FirewallRuleCommunicator(Context);
        }

        /// <summary>
        /// Gets an ipv6 firewall rule in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="ipv6FirewallRuleName">The ipv6 firewall rule name</param>
        /// <returns>The ipv6 firewall rule</returns>
        public AzureSqlServerIpv6FirewallRuleModel GetIpv6FirewallRule(string resourceGroupName, string serverName, string ipv6FirewallRuleName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, ipv6FirewallRuleName);
            return CreateIpv6FirewallRuleModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of all the ipv6 firewall rules in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the ipv6 firewall rules</returns>
        public List<AzureSqlServerIpv6FirewallRuleModel> ListIpv6FirewallRules(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName);
            return resp.Select((s) =>
            {
                return CreateIpv6FirewallRuleModelFromResponse(resourceGroupName, serverName, s);
            }).ToList();
        }

        /// <summary>
        /// Upserts an Ipv6 Firewall Rule
        /// </summary>
        /// <param name="model">The ipv6 firewall rule to create</param>
        /// <returns>The updated server model</returns>
        public AzureSqlServerIpv6FirewallRuleModel UpsertIpv6FirewallRule(AzureSqlServerIpv6FirewallRuleModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.Ipv6FirewallRuleName, new Management.Sql.Models.IPv6FirewallRule()
            {
                StartIPv6Address = model.StartIpv6Address,
                EndIPv6Address = model.EndIpv6Address

            });

            return CreateIpv6FirewallRuleModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Deletes an IPv6 Firewall Rule
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server from which the ipv6 firewall rule should be removed</param>
        /// <param name="ipv6FirewallRuleName">The name of the ipv6 firewall rule to remove</param>
        public void RemoveIpv6FirewallRule(string resourceGroupName, string serverName, string ipv6FirewallRuleName)
        {
            Communicator.Remove(resourceGroupName, serverName, ipv6FirewallRuleName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.IPv6FirewallRule to AzureSqlServerIpv6FirewallRuleModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlServerIpv6FirewallRuleModel CreateIpv6FirewallRuleModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.IPv6FirewallRule resp)
        {
            AzureSqlServerIpv6FirewallRuleModel ipv6FirewallRule = new AzureSqlServerIpv6FirewallRuleModel();

            ipv6FirewallRule.StartIpv6Address = resp.StartIPv6Address;
            ipv6FirewallRule.EndIpv6Address = resp.EndIPv6Address;
            ipv6FirewallRule.Ipv6FirewallRuleName = resp.Name;
            ipv6FirewallRule.ResourceGroupName = resourceGroup;
            ipv6FirewallRule.ServerName = serverName;

            return ipv6FirewallRule;
        }
    }
}
