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

using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureRmSqlServerVirtualNetworkRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlServerVirtualNetworkRule", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true),
        OutputType(typeof(Model.AzureSqlServerVirtualNetworkRuleModel))]
    public class NewAzureSqlServerVirtualNetworkRule : AzureSqlServerVirtualNetworkRuleCmdletBase
    {
        /// <summary>
        /// Azure Sql Server Virtual Network Rule Name.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Azure Sql Server Virtual Network Rule Name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkRuleName { get; set; }

        /// <summary>
        /// The Virtual Network Subnet Id
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The Virtual Network Subnet Id that specifies the Microsoft.Network details")]
        [ValidateNotNull]
        public string VirtualNetworkSubnetId { get; set; }

        /// <summary>
        /// Create firewall rule before the virtual network vnet service endpoint enabled.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Create firewall rule before the virtual network has vnet service endpoint enabled.")]
        [ValidateNotNull]
        public SwitchParameter IgnoreMissingVnetServiceEndpoint { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if the Virtual Network Rule already exists for this server
        /// </summary>
        /// <returns>Null if the Virtual Network Rule doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetVirtualNetworkRule(this.ResourceGroupName, this.ServerName, this.VirtualNetworkRuleName);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no virtual network rule with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The server already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerVirtualNetworkRuleNameExists, this.VirtualNetworkRuleName, this.ServerName),
                "VirtualNetworkRule");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the virtual network rule doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> model)
        {
            List<Model.AzureSqlServerVirtualNetworkRuleModel> newEntity = new List<Model.AzureSqlServerVirtualNetworkRuleModel>();
            newEntity.Add(new Model.AzureSqlServerVirtualNetworkRuleModel()
            {
                ResourceGroupName = this.ResourceGroupName.Trim(),
                ServerName = this.ServerName.Trim(),
                VirtualNetworkRuleName = this.VirtualNetworkRuleName.Trim(),
                VirtualNetworkSubnetId = this.VirtualNetworkSubnetId.Trim(),
                IgnoreMissingVnetServiceEndpoint = this.IgnoreMissingVnetServiceEndpoint
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the virtual network rule
        /// </summary>
        /// <param name="entity">The server to create</param>
        /// <returns>The created server</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> entity)
        {
            return new List<Model.AzureSqlServerVirtualNetworkRuleModel>() {
                ModelAdapter.UpsertVirtualNetworkRule(entity.First())
            };
        }
    }
}