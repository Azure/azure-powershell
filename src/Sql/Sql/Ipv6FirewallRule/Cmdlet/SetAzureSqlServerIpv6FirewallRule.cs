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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzSqlServerIpv6FirewallRule cmdlet
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerIpv6FirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low), OutputType(typeof(Model.AzureSqlServerIpv6FirewallRuleModel))]
    public class SetAzureSqlServerIpv6FirewallRule : AzureSqlServerIpv6FirewallRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Server IPv6 Firewall Rule
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure Sql Database Server IPv67 Firewall Rule.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string Ipv6FirewallRuleName { get; set; }

        /// <summary>
        /// The new start IPv6 address for the rule.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The new start IPv6 address for the rule.")]
        [ValidateNotNull]
        public string StartIpv6Address { get; set; }

        /// <summary>
        /// The new end IPv6 address for the rule.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The new end IPv6 address for the rule.")]
        [ValidateNotNull]
        public string EndIpv6Address { get; set; }

        /// <summary>
        /// Get the IPv6 Firewall Rule to update
        /// </summary>
        /// <returns>The IPv6 Firewall Rule being updated</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> GetEntity()
        {
            return new List<Model.AzureSqlServerIpv6FirewallRuleModel>() { ModelAdapter.GetIpv6FirewallRule(this.ResourceGroupName, this.ServerName, this.Ipv6FirewallRuleName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlServerIpv6FirewallRuleModel> updateData = new List<Model.AzureSqlServerIpv6FirewallRuleModel>();
            updateData.Add(new Model.AzureSqlServerIpv6FirewallRuleModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                Ipv6FirewallRuleName = this.Ipv6FirewallRuleName,
                StartIpv6Address = this.StartIpv6Address,
                EndIpv6Address = this.EndIpv6Address,
            });
            return updateData;
        }

        /// <summary>
        /// Sends the IPv6 Firewall Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> entity)
        {
            return new List<Model.AzureSqlServerIpv6FirewallRuleModel>() {
                ModelAdapter.UpsertIpv6FirewallRule(entity.First())
            };
        }
    }
}
