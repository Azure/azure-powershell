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
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.FirewallRule.Model;

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureSqlDatabaseServerFirewallRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureSqlDatabaseServerFirewallRule", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseServerFirewallRule : AzureSqlDatabaseServerFirewallRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Server Firewall Rule
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure Sql Database Server Firewall Rule name.")]
        [ValidateNotNullOrEmpty]
        public string FirewallRuleName { get; set; }

        /// <summary>
        /// Gets a Firewall Rule from the service.
        /// </summary>
        /// <returns>A single Firewall Rule</returns>
        protected override IEnumerable<AzureSqlDatabaseServerFirewallRuleModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseServerFirewallRuleModel> results = null;

            if (this.MyInvocation.BoundParameters.ContainsKey("FirewallRuleName"))
            {
                results = new List<AzureSqlDatabaseServerFirewallRuleModel>();
                results.Add(ModelAdapter.GetFirewallRule(this.ResourceGroupName, this.ServerName, this.FirewallRuleName));
            }
            else
            {
                results = ModelAdapter.ListFirewallRules(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlDatabaseServerFirewallRuleModel> PersistChanges(IEnumerable<AzureSqlDatabaseServerFirewallRuleModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlDatabaseServerFirewallRuleModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseServerFirewallRuleModel> model)
        {
            return model;
        }
    }
}
