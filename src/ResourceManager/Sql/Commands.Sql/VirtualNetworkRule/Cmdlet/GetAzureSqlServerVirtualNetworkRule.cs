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

using Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlServerVirtualNetworkRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlServerVirtualNetworkRule"),
        OutputType(typeof(Model.AzureSqlServerVirtualNetworkRuleModel))]
    public class GetAzureSqlServerVirtualNetworkRule : AzureSqlServerVirtualNetworkRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Server Virtual Network Rule
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Azure Sql Server Virtual Network Rule name.")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkRuleName { get; set; }

        /// <summary>
        /// Gets a Virtual Network Rule from the service.
        /// </summary>
        /// <returns>A single Virtual Network Rule</returns>
        protected override IEnumerable<AzureSqlServerVirtualNetworkRuleModel> GetEntity()
        {
            ICollection<AzureSqlServerVirtualNetworkRuleModel> results = null;

            if (this.MyInvocation.BoundParameters.ContainsKey("VirtualNetworkRuleName"))
            {
                results = new List<AzureSqlServerVirtualNetworkRuleModel>();
                results.Add(ModelAdapter.GetVirtualNetworkRule(this.ResourceGroupName, this.ServerName, this.VirtualNetworkRuleName));
            }
            else
            {
                results = ModelAdapter.ListVirtualNetworkRules(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlServerVirtualNetworkRuleModel> PersistChanges(IEnumerable<AzureSqlServerVirtualNetworkRuleModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlServerVirtualNetworkRuleModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerVirtualNetworkRuleModel> model)
        {
            return model;
        }
    }
}
