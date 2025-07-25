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
using Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Model;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.OutboundFirewallRules.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlServerOutboundFirewallRules cmdlet
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerOutboundFirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.None)]
    [OutputType(typeof(AzureSqlServerOutboundFirewallRulesModel))]
    public class GetAzureSqlServerOutboundFirewallRule : AzureSqlServerOutboundFirewallRulesCmdletBase
    {
        /// <summary>
        /// Gets or sets the allowed FQDN of the Azure Sql Database Server Outbound Firewall Rule
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Sql Database Server Outbound Firewall Rule FQDN.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string AllowedFQDN { get; set; }

        /// <summary>
        /// Gets an allowed FQDN from the list of outbound firewall rules from the service.
        /// </summary>
        /// <returns>A single Firewall Rule</returns>
        protected override IEnumerable<AzureSqlServerOutboundFirewallRulesModel> GetEntity()
        {
            List<AzureSqlServerOutboundFirewallRulesModel> results = null;

            if (this.MyInvocation.BoundParameters.ContainsKey("AllowedFQDN") && !WildcardPattern.ContainsWildcardCharacters(AllowedFQDN))
            {
                Model.AzureSqlServerOutboundFirewallRulesModel model;
                results = new List<AzureSqlServerOutboundFirewallRulesModel>();

                try
                {
                    model = ModelAdapter.GetOutboundFirewallRule(this.ResourceGroupName, this.ServerName, this.AllowedFQDN);
                    results.Add(model);
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
            }
            else
            {
                results = ModelAdapter.ListOutboundFirewallRules(this.ResourceGroupName, this.ServerName);
            }

            return SubResourceWildcardFilter(AllowedFQDN, results);
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerOutboundFirewallRulesModel> PersistChanges(IEnumerable<AzureSqlServerOutboundFirewallRulesModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlServerOutboundFirewallRulesModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerOutboundFirewallRulesModel> model)
        {
            return model;
        }
    }
}
