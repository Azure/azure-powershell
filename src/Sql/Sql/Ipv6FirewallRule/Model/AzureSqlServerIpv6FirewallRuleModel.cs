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

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Model
{
    /// <summary>
    /// Represents the core properties of an Azure Sql Database IPv6 Server Firewall Rule
    /// </summary>
    public class AzureSqlServerIpv6FirewallRuleModel
    {
        /// <summary>
        /// Gets or sets the name of the resource group
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the server
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the start IPv6 address of the rule
        /// </summary>
        public string StartIpv6Address { get; set; }

        /// <summary>
        /// Gets or sets the end IPv6 address of the rule
        /// </summary>
        public string EndIpv6Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the IPv6 firewall rule
        /// </summary>
        public string Ipv6FirewallRuleName { get; set; }
    }
}
