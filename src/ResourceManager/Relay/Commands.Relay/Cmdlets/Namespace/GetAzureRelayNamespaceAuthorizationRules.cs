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

using Microsoft.Azure.Commands.Relay.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands.Namespace
{
    /// <summary>
    /// 'Get-AzureRmRelayNamespaceAuthorizationRule' Cmdlet gives the details of a / List of Relay Namespace AuthorizationRule(s)
    /// <para> If AuthorizationRule name provided, a single AuthorizationRule detials will be returned</para>
    /// <para> If AuthorizationRule name not provided, list of AuthorizationRules will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, RelayNamespaceAuthorizationRuleVerb), OutputType(typeof(List<AuthorizationRuleAttributes>))]
    public class GetAzureRelayNamespaceAuthorizationRule : AzureRelayCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Relay Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Relay Namespace AuthorizationRule Name.")]
        public string AuthorizationRuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(AuthorizationRuleName))
            {
                // Get a Relay namespace AuthorizationRule
                AuthorizationRuleAttributes authRule = Client.GetNamespaceAuthorizationRule(ResourceGroupName, NamespaceName, AuthorizationRuleName);
                WriteObject(authRule);
            }
            else
            {
                // Get all Relay namespace AuthorizationRules
                IEnumerable<AuthorizationRuleAttributes> authRuleList = Client.ListNamespaceAuthorizationRules(ResourceGroupName, NamespaceName);
                WriteObject(authRuleList.ToList(), true);
            }
        }
    }
}
