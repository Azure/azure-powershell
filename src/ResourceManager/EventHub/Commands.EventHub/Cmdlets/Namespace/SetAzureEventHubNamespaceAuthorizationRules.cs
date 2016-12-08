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

using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Set-AzureRmEventHubNamespaceAuthorizationRule' Cmdlet updates specified Eventhub Namespace AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventHubNamespaceAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    public class SetAzureEventHubNamespaceAuthorizationRule : AzureEventHubsCmdletBase
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
            HelpMessage = "EventHub Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            HelpMessage = "EventHub NameSpace AuthorizationRule Object.")]
        [ValidateNotNullOrEmpty]
        public SharedAccessAuthorizationRuleAttributes AuthRuleObj { get; set; }

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

            SharedAccessAuthorizationRuleAttributes sasRule = new SharedAccessAuthorizationRuleAttributes();

            if (AuthRuleObj != null)
            {
                sasRule = AuthRuleObj;
            }
            else
            {
                NamespaceAttributes getNameSpace = Client.GetNamespace(ResourceGroupName, NamespaceName);

                IList<Management.EventHub.Models.AccessRights?> newListAry = new List<Management.EventHub.Models.AccessRights?>();

                foreach (string test in Rights)
                {
                    newListAry.Add(ParseAccessRights(test));
                }

                sasRule.Name = AuthorizationRuleName;
                sasRule.Rights = newListAry;
                sasRule.Location = getNameSpace.Location;
            }

            // Update a eventHub authorizationRule
            
            if (ShouldProcess(target: AuthorizationRuleName, action: string.Format("Update AuthoriationRule:{0} of NameSpace:{1}", AuthorizationRuleName, NamespaceName)))
            {
                WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, NamespaceName, sasRule.Name, sasRule));
            }
        }
    }
}
