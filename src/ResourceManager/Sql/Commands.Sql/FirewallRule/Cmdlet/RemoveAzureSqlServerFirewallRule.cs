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

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlServerFirewallRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlServerFirewallRule", SupportsShouldProcess = true)]
    public class RemoveAzureSqlServerFirewallRule : AzureSqlServerFirewallRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the firewall rule to remove
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Azure Sql Database Server Firewall Rule name")]
        [ValidateNotNullOrEmpty]
        public string FirewallRuleName { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerFirewallRuleModel> GetEntity()
        {
            return new List<Model.AzureSqlServerFirewallRuleModel>() {
                ModelAdapter.GetFirewallRule(this.ResourceGroupName, this.ServerName, this.FirewallRuleName)
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlServerFirewallRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerFirewallRuleModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the server.
        /// </summary>
        /// <param name="entity">The server being deleted</param>
        /// <returns>The server that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerFirewallRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerFirewallRuleModel> entity)
        {
            ModelAdapter.RemoveFirewallRule(this.ResourceGroupName, this.ServerName, this.FirewallRuleName);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerFirewallRuleDescription, this.FirewallRuleName, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.RemoveAzureSqlServerFirewallRuleWarning, this.FirewallRuleName, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
