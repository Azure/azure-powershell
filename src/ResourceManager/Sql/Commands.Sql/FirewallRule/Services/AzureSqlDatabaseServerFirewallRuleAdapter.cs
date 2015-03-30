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
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.FirewallRule.Model;
using Microsoft.Azure.Common.Authentication.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Adapter
{
    /// <summary>
    /// Adapter for firewall operations
    /// </summary>
    public class AzureSqlDatabaseServerFirewallRuleAdapter
    {
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public AzureProfile Profile { get; set; }

        /// <summary>
        /// Constructs a firewall rule adapter
        /// </summary>
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlDatabaseServerFirewallRuleAdapter(AzureProfile profile, AzureSubscription subscription)
        {
            Profile = profile;
            AzureCommunicator = new AzureEndpointsCommunicator(Profile, subscription);
        }

        /// <summary>
        /// Gets a firewall rule in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <param name="firewallRuleName">The firewall rule name</param>
        /// <returns>The firewall rule</returns>
        public AzureSqlDatabaseServerFirewallRuleModel GetFirewallRule(string resourceGroupName, string serverName, string firewallRuleName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());
            
            FirewallRuleGetResponse resp = client.FirewallRules.Get(resourceGroupName, serverName, firewallRuleName);
            return CreateFirewallRuleModelFromResponse(resp.FirewallRule);
        }

        /// <summary>
        /// Gets a list of all the firewall rules in a server
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group</param>
        /// <param name="serverName">The name of the server</param>
        /// <returns>A list of all the firewall rules</returns>
        public List<AzureSqlDatabaseServerFirewallRuleModel> ListFirewallRules(string resourceGroupName, string serverName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            FirewallRuleListResponse resp = client.FirewallRules.List(resourceGroupName, serverName);

            return resp.FirewallRules.Select((s) =>
            {
                return CreateFirewallRuleModelFromResponse(s);
            }).ToList();
        }

        /// <summary>
        /// Upserts a Firewall Rule
        /// </summary>
        /// <param name="resourceGroup">The name of the resource group</param>
        /// <param name="serverName">The name of ther server</param>
        /// <param name="model">The firewall rule to create</param>
        /// <returns>The updated server model</returns>
        public AzureSqlDatabaseServerFirewallRuleModel UpsertFirewallRule(string resourceGroupName, string serverName, AzureSqlDatabaseServerFirewallRuleModel model)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            FirewallRuleGetResponse response = client.FirewallRules.CreateOrUpdate(resourceGroupName, serverName, model.FirewallRuleName, new FirewallRuleCreateOrUpdateParameters()
                {
                    Properties = new FirewallRuleCreateOrUpdateProperties()
                    {
                        EndIpAddress= model.EndIpAddress,
                        StartIpAddress = model.StartIpAddress
                    }
                });

            return CreateFirewallRuleModelFromResponse(response.FirewallRule);
        }

        /// <summary>
        /// Deletes a Firewall Rule
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="serverName">The name of the server from which the firewall rule should be removed</param>
        /// <param name="firewallRuleName">The name of the firewall rule to remove</param>
        public void RemoveFirewallRule(string resourceGroupName, string serverName, string firewallRuleName)
        {
            SqlManagementClient client = AzureCommunicator.GetCurrentSqlClient(Guid.NewGuid().ToString());

            client.FirewallRules.Delete(resourceGroupName, serverName, firewallRuleName);
        }

        /// <summary>
        /// Convert a Management.Sql.Models.FirewallRule to AzureSqlDatabaseServerFirewallRuleModel
        /// </summary>
        /// <param name="resourceGroupName">The resource group the server is in</param>
        /// <param name="resp">The management client server response to convert</param>
        /// <returns>The converted server model</returns>
        private static AzureSqlDatabaseServerFirewallRuleModel CreateFirewallRuleModelFromResponse(Management.Sql.Models.FirewallRule resp)
        {
            AzureSqlDatabaseServerFirewallRuleModel firewallRule = new AzureSqlDatabaseServerFirewallRuleModel();

            firewallRule.StartIpAddress = resp.Properties.StartIpAddress;
            firewallRule.EndIpAddress = resp.Properties.EndIpAddress;
            firewallRule.FirewallRuleName = resp.Name;

            return firewallRule;
        }
    }
}
