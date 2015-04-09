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

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureSqlDatabaseServerFirewallRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureSqlDatabaseServerFirewallRule", ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabaseServerFirewallRule : AzureSqlDatabaseServerFirewallRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Server Firewall Rule
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The name of the Azure Sql Database Server Firewall Rule.")]
        [ValidateNotNullOrEmpty]
        public string FirewallRuleName { get; set; }

        /// <summary>
        /// The new start IP address for the rule.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The new start IP address for the rule.")]
        [ValidateNotNull]
        public string StartIpAddress { get; set; }

        /// <summary>
        /// The new end IP address for the rule.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The new end IP address for the rule.")]
        [ValidateNotNull]
        public string EndIpAddress { get; set; }

        /// <summary>
        /// Get the Firewall Rule to update
        /// </summary>
        /// <returns>The Firewall Rule being updated</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseServerFirewallRuleModel> GetEntity()
        {
            return new List<Model.AzureSqlDatabaseServerFirewallRuleModel>() { ModelAdapter.GetFirewallRule(this.ResourceGroupName, this.ServerName, this.FirewallRuleName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseServerFirewallRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlDatabaseServerFirewallRuleModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlDatabaseServerFirewallRuleModel> updateData = new List<Model.AzureSqlDatabaseServerFirewallRuleModel>();
            updateData.Add(new Model.AzureSqlDatabaseServerFirewallRuleModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                FirewallRuleName = this.FirewallRuleName,
                StartIpAddress = this.StartIpAddress,
                EndIpAddress = this.EndIpAddress,
            });
            return updateData;
        }

        /// <summary>
        /// Sends the Firewall Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseServerFirewallRuleModel> PersistChanges(IEnumerable<Model.AzureSqlDatabaseServerFirewallRuleModel> entity)
        {
            return new List<Model.AzureSqlDatabaseServerFirewallRuleModel>() { 
                ModelAdapter.UpsertFirewallRule(entity.First()) 
            };
        }
    }
}
