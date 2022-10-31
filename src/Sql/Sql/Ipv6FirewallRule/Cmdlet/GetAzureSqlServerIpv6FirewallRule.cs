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

using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServerIpv6FirewallRule cmdlet
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerIpv6FirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.None)]
    [OutputType(typeof(AzureSqlServerIpv6FirewallRuleModel))]
    public class GetAzureSqlServerIpv6FirewallRule : AzureSqlServerIpv6FirewallRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Server IPv6 Firewall Rule
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Sql Database Server IPv6 Firewall Rule name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Ipv6FirewallRuleName { get; set; }

        /// <summary>
        /// Gets an IPv6 Firewall Rule from the service.
        /// </summary>
        /// <returns>A single IPv6 Firewall Rule</returns>
        protected override IEnumerable<AzureSqlServerIpv6FirewallRuleModel> GetEntity()
        {
            ICollection<AzureSqlServerIpv6FirewallRuleModel> results = null;
            ResourceWildcardFilterHelper filterHelper = new ResourceWildcardFilterHelper();

            if (this.MyInvocation.BoundParameters.ContainsKey("Ipv6FirewallRuleName") && !WildcardPattern.ContainsWildcardCharacters(Ipv6FirewallRuleName))
            {
                results = new List<AzureSqlServerIpv6FirewallRuleModel>();
                results.Add(ModelAdapter.GetIpv6FirewallRule(this.ResourceGroupName, this.ServerName, this.Ipv6FirewallRuleName));
            }
            else
            {
                results = ModelAdapter.ListIpv6FirewallRules(this.ResourceGroupName, this.ServerName);
            }

            return filterHelper.SqlSubResourceWildcardFilter(Ipv6FirewallRuleName, results, nameof(AzureSqlServerIpv6FirewallRuleModel.Ipv6FirewallRuleName));
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerIpv6FirewallRuleModel> PersistChanges(IEnumerable<AzureSqlServerIpv6FirewallRuleModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlServerIpv6FirewallRuleModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerIpv6FirewallRuleModel> model)
        {
            return model;
        }
    }
}
