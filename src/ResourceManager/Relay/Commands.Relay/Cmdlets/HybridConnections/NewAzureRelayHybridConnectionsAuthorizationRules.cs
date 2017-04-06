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

using System.Management.Automation;
using Microsoft.Azure.Commands.Relay.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Relay.Commands.HybridConnections
{
    /// <summary>
    /// 'New-AzureRmRelayHybridConnectionsAuthorizationRule' Cmdlet creates a new AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.New, RelayHybridConnectionsAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleAttributes))]
    public class NewAzureRelayHybridConnectionsAuthorizationRule : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "HybridConnections Name.")]
        [ValidateNotNullOrEmpty]
        public string HybridConnectionsName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Rights, e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {            
            AuthorizationRuleAttributes sasRule = new AuthorizationRuleAttributes();
            
            foreach (string test in Rights)
            {
                sasRule.Rights.Add(test);
            }

            // Create a new HybridConnections authorizationRule

            if (ShouldProcess(target: sasRule.Name, action: string.Format("Creating new AuthorizationRule named:{0} for HybridConnections: {1}", AuthorizationRuleName, HybridConnectionsName)))
            {
                WriteObject(Client.CreateOrUpdateHybridConnectionsAuthorizationRules(ResourceGroupName, NamespaceName, HybridConnectionsName, AuthorizationRuleName, sasRule));
            }
        }
    }
}
