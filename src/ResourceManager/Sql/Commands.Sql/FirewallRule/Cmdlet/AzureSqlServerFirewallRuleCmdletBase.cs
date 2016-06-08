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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.FirewallRule.Adapter;
using Microsoft.Azure.Commands.Sql.FirewallRule.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.FirewallRule.Cmdlet
{
    public abstract class AzureSqlServerFirewallRuleCmdletBase : AzureSqlCmdletBase<IEnumerable<AzureSqlServerFirewallRuleModel>, AzureSqlServerFirewallRuleAdapter>
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database server to use
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "The Azure Sql Server name.")]
        [ValidateNotNullOrEmpty]
        public string ServerName { get; set; }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <param name="subscription">The subscription the cmdlets are operation under</param>
        /// <returns>The server adapter</returns>
        protected override AzureSqlServerFirewallRuleAdapter InitModelAdapter(AzureSubscription subscription)
        {
            return new AzureSqlServerFirewallRuleAdapter(DefaultProfile.Context);
        }
    }
}
