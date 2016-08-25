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
using Microsoft.Azure.Commands.Sql.FirewallRule.Model;
using Microsoft.Azure.Commands.Sql.FirewallRule.Services;
using Microsoft.Azure.Commands.Sql.Services;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Adapter
{
    /// <summary>
    /// Adapter for firewall operations
    /// </summary>
    public class AzureSqlServerFirewallRuleAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerFirewallRuleCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureContext Context { get; set; }

        /// <summary>
        /// Constructs a firewall rule adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerFirewallRuleAdapter(AzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerFirewallRuleCommunicator(Context);
        }

        /// <summary>
        /// Gets a firewall rule in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="firewallRuleName">The firewall rule name</param>
        /// <returns>The firewall rule</returns>
        public AzureSqlServerFirewallRuleModel GetFirewallRule(string resourceGroupName, string serverName, string firewallRuleName)
        {
            var resp = Communicator.Get(resourceGroupName, serverName, firewallRuleName, Util.GenerateTracingId());
            return CreateFirewallRuleModelFromResponse(resourceGroupName, serverName, resp);
        }

        /// <summary>
        /// Gets a list of all the firewall rules in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the firewall rules</returns>
        public List<AzureSqlServerFirewallRuleModel> ListFirewallRules(string resourceGroupName, string serverName)
        {
            var resp = Communicator.List(resourceGroupName, serverName, Util.GenerateTracingId());
            return resp.Select((s) =>
            {
                return CreateFirewallRuleModelFromResponse(resourceGroupName, serverName, s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a Firewall Rule
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of ther server</param>
        /// <param name="model">The firewall rule to create</param>
        /// <returns>The updated server model</returns>
        public AzureSqlServerFirewallRuleModel UpsertFirewallRule(AzureSqlServerFirewallRuleModel model)
        {
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.FirewallRuleName, Util.GenerateTracingId(), new FirewallRuleCreateOrUpdateParameters()
            {
                Properties = new FirewallRuleCreateOrUpdateProperties()
                {
                    EndIpAddress = model.EndIpAddress,
                    StartIpAddress = model.StartIpAddress
                }
            });

            return CreateFirewallRuleModelFromResponse(model.ResourceGroupName, model.ServerName, resp);
        }

        /// <summary>
        /// Deletes a Firewall Rule
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server from which the firewall rule should be removed</param>
        /// <param name="firewallRuleName">The name of the firewall rule to remove</param>
        public void RemoveFirewallRule(string resourceGroupName, string serverName, string firewallRuleName)
        {
            Communicator.Remove(resourceGroupName, serverName, firewallRuleName, Util.GenerateTracingId());
        }

        /// <summary>
        /// Convert a Management.Sql.Models.FirewallRule to AzureSqlServerFirewallRuleModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlServerFirewallRuleModel CreateFirewallRuleModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.FirewallRule resp)
        {
            AzureSqlServerFirewallRuleModel firewallRule = new AzureSqlServerFirewallRuleModel();

            firewallRule.StartIpAddress = resp.Properties.StartIpAddress;
            firewallRule.EndIpAddress = resp.Properties.EndIpAddress;
            firewallRule.FirewallRuleName = resp.Name;
            firewallRule.ResourceGroupName = resourceGroup;
            firewallRule.ServerName = serverName;

            return firewallRule;
        }
    }
}
