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

namespace Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlServerVirtualNetworkRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerVirtualNetworkRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium),
        OutputType(typeof(Model.AzureSqlServerVirtualNetworkRuleModel))]
    public class SetAzureSqlServerVirtualNetworkRule : AzureSqlServerVirtualNetworkRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Server Virtual Network Rule
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the Azure Sql Server Virtual Network Rule.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkRuleName { get; set; }

        /// <summary>
        /// The Virtual Network Subnet Id
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The Virtual Network Subnet Id for the rule.")]
        [ValidateNotNull]
        public string VirtualNetworkSubnetId { get; set; }

        /// <summary>
        /// Create firewall rule before the virtual network has vnet service endpoint enabled.
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
        /// Get the Virtual Network Rule to update
        /// </summary>
        /// <returns>The Virtual Network Rule being updated</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> GetEntity()
        {
            return new List<Model.AzureSqlServerVirtualNetworkRuleModel>() { ModelAdapter.GetVirtualNetworkRule(this.ResourceGroupName, this.ServerName, this.VirtualNetworkRuleName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlServerVirtualNetworkRuleModel> updateData = new List<Model.AzureSqlServerVirtualNetworkRuleModel>();
            updateData.Add(new Model.AzureSqlServerVirtualNetworkRuleModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                VirtualNetworkRuleName = this.VirtualNetworkRuleName,
                VirtualNetworkSubnetId = this.VirtualNetworkSubnetId,
                IgnoreMissingVnetServiceEndpoint = this.IgnoreMissingVnetServiceEndpoint
            });
            return updateData;
        }

        /// <summary>
        /// Sends the VirtualNetwork Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> entity)
        {
            return new List<Model.AzureSqlServerVirtualNetworkRuleModel>() {
                ModelAdapter.UpsertVirtualNetworkRule(entity.First())
            };
        }
    }
}
