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

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services
{
    public static partial class SqlDatabaseManagementExtensionMethods
    {
        /// <summary>
        /// Retrieves all firewall rules on the specified server.
        /// </summary>
        /// <param name="proxy">
        /// Channel used for communication with Azure's service management APIs.
        /// </param>
        /// <param name="subscriptionId">
        /// The subscription id which contains the server.
        /// </param>
        /// <param name="serverName">
        /// The name of the server to retrieve firewall rules for.
        /// </param>
        /// <returns>A list of all firewall rules on the server.</returns>
        public static SqlDatabaseFirewallRulesList GetServerFirewallRules(this ISqlDatabaseManagement proxy, string subscriptionId, string serverName)
        {
            return proxy.EndGetServerFirewallRules(proxy.BeginGetServerFirewallRules(subscriptionId, serverName, null, null));
        }

        /// <summary>
        /// Creates a new firewall rule on the specified server.
        /// </summary>
        /// <param name="proxy">
        /// Channel used for communication with Azure's service management APIs.
        /// </param>
        /// <param name="subscriptionId">
        /// The subscription id which contains the server.
        /// </param>
        /// <param name="serverName">
        /// The name of the server in which to create the firewall rule.
        /// </param>
        /// <param name="ruleName">
        /// The name of the new firewall rule.
        /// </param>
        /// <param name="startIpAddress">
        /// The starting IP address for the firewall rule.
        /// </param>
        /// <param name="endIpAddress">
        /// The ending IP address for the firewall rule.
        /// </param>
        public static void NewServerFirewallRule(this ISqlDatabaseManagement proxy, string subscriptionId, string serverName, string ruleName, string startIpAddress, string endIpAddress)
        {
            var input = new SqlDatabaseFirewallRuleInput
            {
                Name = ruleName,
                StartIPAddress = startIpAddress,
                EndIPAddress = endIpAddress
            };

            proxy.EndNewServerFirewallRule(proxy.BeginNewServerFirewallRule(subscriptionId, serverName, input, null, null));
        }

        /// <summary>
        /// Updates a firewall rule on the specified server.
        /// </summary>
        /// <param name="proxy">
        /// Channel used for communication with Azure's service management APIs.
        /// </param>
        /// <param name="subscriptionId">
        /// The subscription id which contains the server.
        /// </param>
        /// <param name="serverName">
        /// The name of the server containing the firewall rule.
        /// </param>
        /// <param name="ruleName">
        /// The name of the firewall rule to update.
        /// </param>
        /// <param name="startIpAddress">
        /// The starting IP address for the firewall rule.
        /// </param>
        /// <param name="endIpAddress">
        /// The ending IP address for the firewall rule.
        /// </param>
        public static void UpdateServerFirewallRule(this ISqlDatabaseManagement proxy, string subscriptionId, string serverName, string ruleName, string startIpAddress, string endIpAddress)
        {
            var input = new SqlDatabaseFirewallRuleInput
            {
                Name = ruleName,
                StartIPAddress = startIpAddress,
                EndIPAddress = endIpAddress
            };

            proxy.EndUpdateServerFirewallRule(proxy.BeginUpdateServerFirewallRule(subscriptionId, serverName, ruleName, input, null, null));
        }

        /// <summary>
        /// Removes a new firewall rule on the specified server.
        /// </summary>
        /// <param name="proxy">
        /// Channel used for communication with Azure's service management APIs.
        /// </param>
        /// <param name="subscriptionId">
        /// The subscription id which contains the server.
        /// </param>
        /// <param name="serverName">
        /// The name of the server containing the firewall rule.
        /// </param>
        /// <param name="ruleName">
        /// The name of the firewall rule to remove.
        /// </param>
        public static void RemoveServerFirewallRule(this ISqlDatabaseManagement proxy, string subscriptionId, string serverName, string ruleName)
        {
            proxy.EndRemoveServerFirewallRule(proxy.BeginRemoveServerFirewallRule(subscriptionId, serverName, ruleName, null, null));
        }
    }
}
