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
using Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Model;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Services
{
    /// <summary>
    /// Adapter for outbound firewall rule operations
    /// </summary>
    public class AzureSqlServerOutboundFirewallRulesAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlServerOutboundFirewallRulesCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a outbound firewall rules adapter
        /// </summary>
        /// <param name="context">Context for Azure</param>
        public AzureSqlServerOutboundFirewallRulesAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerOutboundFirewallRulesCommunicator(Context);
        }

        /// <summary>
        /// Gets an allowed FQDN from the list of outbound firewall rules for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="allowedFQDN">The allowed fully qualified domain name (FQDN) in the list of the outbound firewall rules.</param>
        /// <returns>The firewall rule</returns>
        public AzureSqlServerOutboundFirewallRulesModel GetOutboundFirewallRule(string resourceGroupName, string serverName, string allowedFQDN)
        {
            Microsoft.Azure.Management.Sql.Models.OutboundFirewallRule response = Communicator.Get(resourceGroupName, serverName, allowedFQDN);
            return CreateOutboundFirewallRuleModelFromResponse(resourceGroupName, serverName, response);
        }

        /// <summary>
        /// Gets a list of all the allowed FQDNs in the list of outbound firewall rules for a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the firewall rules</returns>
        public List<AzureSqlServerOutboundFirewallRulesModel> ListOutboundFirewallRules(string resourceGroupName, string serverName)
        {
            Microsoft.Rest.Azure.IPage<Microsoft.Azure.Management.Sql.Models.OutboundFirewallRule> response = Communicator.List(resourceGroupName, serverName);

            return response.Select((s) =>
            {
                return CreateOutboundFirewallRuleModelFromResponse(resourceGroupName, serverName, s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a new allowed FQDN to the list of outbound firewall rules for a server
        /// </summary>
        /// <param name="model">The firewall rule to create</param>
        /// <returns>The updated server model</returns>
        public AzureSqlServerOutboundFirewallRulesModel UpsertFirewallRule(AzureSqlServerOutboundFirewallRulesModel model)
        {
            Microsoft.Azure.Management.Sql.Models.OutboundFirewallRule reponse = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ServerName, model.AllowedFQDN);
            return CreateOutboundFirewallRuleModelFromResponse(model.ResourceGroupName, model.ServerName, reponse);
        }

        /// <summary>
        /// Deletes an allowed FQDN from the list of outbound firewall rules for a server
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server from which the firewall rule should be removed</param>
        /// <param name="allowedFQDN">The allowed fully qualified domain name (FQDN) in the list of the outbound firewall rules.</param>
        public void RemoveFirewallRule(string resourceGroupName, string serverName, string allowedFQDN)
        {
            Communicator.Remove(resourceGroupName, serverName, allowedFQDN);
        }

        /// <summary>
        /// Convert a management service client response to AzureSqlServerOutboundFirewallRulesModel
        /// </summary>
        /// <param name="resourceGroup">The resource group the server is in</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="resp">The management service client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlServerOutboundFirewallRulesModel CreateOutboundFirewallRuleModelFromResponse(string resourceGroup, string serverName, Management.Sql.Models.OutboundFirewallRule resp)
        {
            AzureSqlServerOutboundFirewallRulesModel outboundFirewallRule = new AzureSqlServerOutboundFirewallRulesModel();

            outboundFirewallRule.AllowedFQDN = resp.Name;
            outboundFirewallRule.ResourceGroupName = resourceGroup;
            outboundFirewallRule.ServerName = serverName;

            return outboundFirewallRule;
        }
    }
}
