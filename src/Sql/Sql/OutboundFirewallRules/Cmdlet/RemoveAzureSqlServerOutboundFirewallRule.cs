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

using Microsoft.Azure.Commands.Common.Exceptions;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzSqlServerOutboundFirewallRule cmdlet
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerOutboundFirewallRule", SupportsShouldProcess = true), OutputType(typeof(Model.AzureSqlServerOutboundFirewallRulesModel))]
    public class RemoveAzureSqlServerOutboundFirewallRule : AzureSqlServerOutboundFirewallRulesCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the allowed FQDN in the list of outbound firewall rules to remove
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Sql Database Server Outbound Firewall Rule FQDN")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string AllowedFQDN { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> GetEntity()
        {
            Model.AzureSqlServerOutboundFirewallRulesModel model;

            try
            {
                model = ModelAdapter.GetOutboundFirewallRule(this.ResourceGroupName, this.ServerName, this.AllowedFQDN);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new AzPSArgumentException(
                        string.Format(Properties.Resources.ServerOutboundFirewallRuleFQDNDoesNotExist, this.AllowedFQDN, this.ServerName), "AllowedFQDN");
                }

                //Unexpected status code was returned in the response.
                throw;
            }

            //The outbound firewall rule has been found, so proceed.
            return new List<Model.AzureSqlServerOutboundFirewallRulesModel>() { model };
        }

        /// <summary>
        /// Apply user input. Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the allowed FQDN from the list of outbound firewall rules for a Azure Sql Database Server.
        /// </summary>
        /// <param name="entity">The server being deleted</param>
        /// <returns>The server that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> PersistChanges(IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> entity)
        {
            ModelAdapter.RemoveFirewallRule(this.ResourceGroupName, this.ServerName, this.AllowedFQDN);
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (Force.IsPresent || ShouldProcess(
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlServerOutboundFirewallRuleDescription, this.AllowedFQDN, this.ServerName),
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.RemoveAzureSqlServerOutboundFirewallRuleWarning, this.AllowedFQDN, this.ServerName),
               Microsoft.Azure.Commands.Sql.Properties.Resources.ShouldProcessCaption))
            {
                base.ExecuteCmdlet();
            }
        }
    }
}
