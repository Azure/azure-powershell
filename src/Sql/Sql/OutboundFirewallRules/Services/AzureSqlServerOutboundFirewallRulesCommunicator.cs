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
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Sql;

namespace Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Services
{
    /// <summary>
    /// This class is responsible for all the REST communication with the audit REST endpoints
    /// </summary>
    public class AzureSqlServerOutboundFirewallRulesCommunicator
    {
        /// <summary>
        /// The Sql client to be used by this end points communicator
        /// </summary>
        private static SqlManagementClient SqlClient { get; set; }
        private static ResourceManagementClient ResourcesClient { get; set; }

        /// <summary>
        /// Gets or set the Azure subscription
        /// </summary>
        private static IAzureSubscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Creates a communicator for Azure Sql Databases OutboundFirewallRules
        /// </summary>
        /// <param name="context">The current azure context</param>
        public AzureSqlServerOutboundFirewallRulesCommunicator(IAzureContext context)
        {
            Context = context;
            if (context?.Subscription != Subscription)
            {
                Subscription = context?.Subscription;
                SqlClient = null;
            }
        }

        /// <summary>
        /// Gets the Azure Sql Server OutboundFirewallRules
        /// </summary>
        public Management.Sql.Models.OutboundFirewallRule Get(string resourceGroupName, string serverName, string outboundFirewallRuleFQDN)
        {
            return GetCurrentSqlClient().OutboundFirewallRules.Get(resourceGroupName, serverName, outboundFirewallRuleFQDN);
        }

        /// <summary>
        /// Lists Azure Sql Server OutboundFirewallRules
        /// </summary>
        public Microsoft.Rest.Azure.IPage<Management.Sql.Models.OutboundFirewallRule> List(string resourceGroupName, string serverName)
        {
            return GetCurrentSqlClient().OutboundFirewallRules.ListByServer(resourceGroupName, serverName);
        }

        public Management.Sql.Models.OutboundFirewallRule CreateOrUpdate(string resourceGroupName, string serverName, string outboundFirewallRuleFQDN)
        {
            return GetCurrentSqlClient().OutboundFirewallRules.CreateOrUpdate(resourceGroupName, serverName, outboundFirewallRuleFQDN);
        }

        /// <summary>
        /// Deletes an Azure Sql Database Server OutboundFirewallRule
        /// </summary>
        public void Remove(string resourceGroupName, string serverName, string outboundFirewallRuleFQDN)
        {
            GetCurrentSqlClient().OutboundFirewallRules.Delete(resourceGroupName, serverName, outboundFirewallRuleFQDN);
        }

        /// <summary>
        /// Retrieve the SQL Management client for the currently selected subscription, adding the session and request
        /// id tracing headers for the current cmdlet invocation.
        /// </summary>
        /// <returns>The SQL Management client for the currently selected subscription.</returns>
        private Management.Sql.SqlManagementClient GetCurrentSqlClient()
        {
            // Get the SQL management client for the current subscription
            // Note: client is not cached in static field because that causes ObjectDisposedException in functional tests.
            return AzureSession.Instance.ClientFactory.CreateArmClient<Management.Sql.SqlManagementClient>(Context, AzureEnvironment.Endpoint.ResourceManager);
        }
    }
}
