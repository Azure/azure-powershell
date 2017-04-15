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
using Microsoft.Azure.Management.Relay.Models;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Relay.Commands.Namespace
{
    /// <summary>
    /// 'Set-AzureRmRelayNamespaceAuthorizationRule' Cmdlet updates specified Relay Namespace AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, RelayNamespaceAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleAttributes))]
    public class SetAzureRelayNamespaceAuthorizationRule : AzureRelayCmdletBase
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
            HelpMessage = "Relay Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            HelpMessage = "Relay NameSpace AuthorizationRule Object.")]
        [ValidateNotNullOrEmpty]
        public AuthorizationRuleAttributes AuthRuleObj { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name - Required if 'AuthruleObj' not specified.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Required if 'AuthruleObj' not specified. Rights - e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {

            AuthorizationRuleAttributes sasRule = new AuthorizationRuleAttributes();

            if (AuthRuleObj != null)
            {
                sasRule = AuthRuleObj;
            }
            else
            {
                sasRule.Rights = new List<string>();
                if (Rights != null && Rights.Length > 0)
                foreach (string test in Rights)
                {
                    sasRule.Rights.Add(test);
                }
            }

            // Update a Relay authorizationRule
            
            if (ShouldProcess(target: AuthorizationRuleName, action: string.Format("Update AuthoriationRule:{0} of NameSpace:{1}", AuthorizationRuleName, NamespaceName)))
            {
                WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, NamespaceName, sasRule.Name, sasRule));
            }
        }
    }
}
