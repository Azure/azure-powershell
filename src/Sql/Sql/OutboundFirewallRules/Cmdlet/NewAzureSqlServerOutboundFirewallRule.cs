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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Cmdlet
{
    /// <summary>
    /// Defines the New-AzSqlServerOutboundFirewallRule cmdlet
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerOutboundFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low), OutputType(typeof(Model.AzureSqlServerOutboundFirewallRulesModel))]
    public class NewAzureSqlServerOutboundFirewallRule : AzureSqlServerOutboundFirewallRulesCmdletBase
    {
        /// <summary>
        /// Gets or sets the allowed FQDN of the Azure Sql Database Server Outbound Firewall Rule
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Sql Database Server Outbound Firewall Rule Allowed FQDN.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string AllowedFQDN { get; set; }

        /// <summary>
        /// Check to see if the allowed FQDN already exists in the list of outbound firewall rules for this server
        /// </summary>
        /// <returns>Null if the FirewallRule doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetOutboundFirewallRule(this.ResourceGroupName, this.ServerName, this.AllowedFQDN);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want. We looked and there is no allowed FQDN in the list of outbound firewall rules with this name.
                    return null;
                }

                //Unexpected status code was returned in the response.
                throw;
            }

            // The server already has an Outbound Firewall Rule with the provided allowed FQDN.
            throw new AzPSArgumentException(
                string.Format(Properties.Resources.ServerOutboundFirewallRuleFQDNExists, this.AllowedFQDN, this.ServerName), "AllowedFQDN");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the outbound firewall rule doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> model)
        {
            List<Model.AzureSqlServerOutboundFirewallRulesModel> newEntity = new List<Model.AzureSqlServerOutboundFirewallRulesModel>();

            if (this.MyInvocation.BoundParameters.ContainsKey("AllowedFQDN") && !WildcardPattern.ContainsWildcardCharacters(AllowedFQDN))
            {
                newEntity.Add(new Model.AzureSqlServerOutboundFirewallRulesModel()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    ServerName = this.ServerName,
                    AllowedFQDN = this.AllowedFQDN,
                });
            }

            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the new Outbound Firewall Rule
        /// </summary>
        /// <param name="entity">The OutboundFirewallRule to create</param>
        /// <returns>The created OutboundFirewallRule</returns>
        protected override IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> PersistChanges(IEnumerable<Model.AzureSqlServerOutboundFirewallRulesModel> entity)
        {
            return new List<Model.AzureSqlServerOutboundFirewallRulesModel>() {
                ModelAdapter.UpsertFirewallRule(entity.First())
            };
        }
    }
}
