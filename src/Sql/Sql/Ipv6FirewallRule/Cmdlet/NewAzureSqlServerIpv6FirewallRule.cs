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

using Hyak.Common;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Ipv6FirewallRule.Cmdlet
{
    /// <summary>
    /// Defines the New-AzSqlServerIpv6FirewallRule cmdlet
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlServerIpv6FirewallRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low), OutputType(typeof(Model.AzureSqlServerIpv6FirewallRuleModel))]
    public class NewAzureSqlServerIpv6FirewallRule : AzureSqlServerIpv6FirewallRuleCmdletBase
    {
        #region Private

        /// <summary> Parameter Set name for specifying rule name and start/end IPv6s </summary>
        private const string UserSpecifiedRuleSet = "UserSpecifiedRuleSet";

        #endregion Private

        /// <summary>
        /// Azure Sql Database Server IPv6 Firewall Rule Name.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Azure Sql Database Server IPv6 Firewall Rule Name.",
            ParameterSetName = UserSpecifiedRuleSet)]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string Ipv6FirewallRuleName { get; set; }

        /// <summary>
        /// The start IPv6 address for the ipv6 firewall rule
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The start IPv6 address for the ipv6 firewall rule",
            ParameterSetName = UserSpecifiedRuleSet)]
        [ValidateNotNull]
        public string StartIpv6Address { get; set; }

        /// <summary>
        /// The end IPv6 address for the ipv6 firewall rule
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The end IPv6 address for the ipv6 firewall rule",
            ParameterSetName = UserSpecifiedRuleSet)]
        [ValidateNotNullOrEmpty]
        public string EndIpv6Address { get; set; }

        /// <summary>
        /// Check to see if the IPv6 FirewallRule already exists for this server
        /// </summary>
        /// <returns>Null if the IPv6 FirewallRule doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> GetEntity()
        {
            try
            {
                if (ParameterSetName == UserSpecifiedRuleSet)
                {

                    ModelAdapter.GetIpv6FirewallRule(this.ResourceGroupName, this.ServerName, this.Ipv6FirewallRuleName);
                }
            }
            catch (Microsoft.Rest.Azure.CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no server with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The server already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerFirewallRuleNameExists, this.Ipv6FirewallRuleName, this.ServerName),
                "Ipv6FirewallRule");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the IPv6 FirewallRule doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> model)
        {
            List<Model.AzureSqlServerIpv6FirewallRuleModel> newEntity = new List<Model.AzureSqlServerIpv6FirewallRuleModel>();

            if (ParameterSetName == UserSpecifiedRuleSet)
            {
                newEntity.Add(new Model.AzureSqlServerIpv6FirewallRuleModel()
                {
                    ResourceGroupName = this.ResourceGroupName,
                    ServerName = this.ServerName,
                    Ipv6FirewallRuleName = this.Ipv6FirewallRuleName,
                    StartIpv6Address = this.StartIpv6Address,
                    EndIpv6Address = this.EndIpv6Address,
                });
            }

            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the IPv6 Firewall Rule
        /// </summary>
        /// <param name="entity">The IPv6 FirewallRule to create</param>
        /// <returns>The created IPv6 FirewallRule</returns>
        protected override IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerIpv6FirewallRuleModel> entity)
        {
            return new List<Model.AzureSqlServerIpv6FirewallRuleModel>() {
                ModelAdapter.UpsertIpv6FirewallRule(entity.First())
            };
        }
    }
}
