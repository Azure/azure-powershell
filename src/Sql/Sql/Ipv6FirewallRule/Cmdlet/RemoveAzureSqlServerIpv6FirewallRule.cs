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
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzSqlServerIpv6FirewallRule cmdlet
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerIpv6FirewallRule", SupportsShouldProcess = true), OutputType(typeof(Model.AzureSqlServerIpv6FirewallRuleModel))]
    public class RemoveAzureSqlServerIpv6FirewallRule : AzureSqlServerIpv6FirewallRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the ipv6 firewall rule to remove
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Azure Sql Database Server IPv6 Firewall Rule name")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string Ipv6FirewallRuleName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> GetEntity()
        {
            return new List<Model.AzureSqlServerIpv6FirewallRuleModel>() {
                ModelAdapter.GetIpv6FirewallRule(this.ResourceGroupName, this.ServerName, this.Ipv6FirewallRuleName)
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the ipv6 server firewall rule.
        /// </summary>
        /// <param name="entity">The ipv6 firewall rule being deleted</param>
        /// <returns>The ipv6 firewall rule that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> entity)
        {
            ModelAdapter.RemoveIpv6FirewallRule(this.ResourceGroupName, this.ServerName, this.Ipv6FirewallRuleName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerFirewallRuleDescription, this.Ipv6FirewallRuleName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerFirewallRuleWarning, this.Ipv6FirewallRuleName, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
