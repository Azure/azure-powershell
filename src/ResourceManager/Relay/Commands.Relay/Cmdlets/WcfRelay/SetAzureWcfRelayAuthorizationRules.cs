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

namespace Microsoft.Azure.Commands.Relay.Commands.WcfRelay
{
    /// <summary>
    /// 'Set-AzureRmWcfRelayAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, RelayWcfRelayAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleAttributes))]
    public class SetAzurewcfRelayAuthorizationRule : AzureRelayCmdletBase
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
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string WcfRelayName { get; set; }
        
        [Parameter(Mandatory = true,
            Position = 3,
            HelpMessage = "WcfRelay AuthorizationRule Object.")]
        [ValidateNotNullOrEmpty]
        public AuthorizationRuleAttributes AuthRuleObj { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Required if 'AuthruleObj' not specified. Rights - e.g.  @(\"Listen\",\"Send\",\"Manage\")")]
        [ValidateNotNullOrEmpty]
        public string[] Right { get; set; }        

        public override void ExecuteCmdlet()
        {
            AuthorizationRuleAttributes sasRule = new AuthorizationRuleAttributes();

            if (AuthRuleObj != null)
            {
                sasRule = AuthRuleObj;
            }
            else
            {

                foreach (string test in Right)
                {
                    sasRule.Rights.Add(test);
                }
                
            }

            // Update a WcfRelay authorizationRule
            if (ShouldProcess(target: AuthorizationRuleName, action: string.Format("Update AuthorizationRule:{0} of WcfRelay:{1} of NameSpace:{2}", AuthorizationRuleName, WcfRelayName, NamespaceName)))
            {
                WriteObject(Client.CreateOrUpdateWcfRelayAuthorizationRules(ResourceGroupName, NamespaceName, WcfRelayName, AuthorizationRuleName, sasRule));
            }
        }
    }
}
