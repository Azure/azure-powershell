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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.LegacySdk;
using Microsoft.Azure.Management.Sql.LegacySdk.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerFirewallRuleCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Databases FirewallRules
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerFirewallRuleCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Database Server FirewallRules
        /// </summary>
        public Management.Sql.LegacySdk.Models.FirewallRule Get(string resourceGroupName, string serverName, string firewallRuleName)
        {
            return GetCurrentSqlClient().FirewallRules.Get(resourceGroupName, serverName, firewallRuleName).FirewallRule;
        }

        /// <summary>
        /// Lists Azure Sql Databases Server FirewallRules
        /// </summary>
        public IList<Management.Sql.LegacySdk.Models.FirewallRule> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().FirewallRules.List(resourceGroupName, serverName).FirewallRules;
        }

        /// <summary>
        /// Creates or updates an Azure Sql Database Server FirewallRule
        /// </summary>
        public Management.Sql.LegacySdk.Models.FirewallRule CreateOrUpdate(string resourceGroupName, string serverName, string firewallRuleName, FirewallRuleCreateOrUpdateParameters parameters)
        {
            return GetCurrentSqlClient().FirewallRules.CreateOrUpdate(resourceGroupName, serverName, firewallRuleName, parameters).FirewallRule;
        }

        /// <summary>
        /// Deletes an Azure Sql Database Server FirewallRule
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string firewallRuleName)
        {
            GetCurrentSqlClient().FirewallRules.Delete(resourceGroupName, serverName, firewallRuleName);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            if (SqlClient == null)
            {
                SqlClient = AzureSession.Instance.ClientFactory.CreateClient<SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
            }
            return SqlClient;
        }
    }
}
