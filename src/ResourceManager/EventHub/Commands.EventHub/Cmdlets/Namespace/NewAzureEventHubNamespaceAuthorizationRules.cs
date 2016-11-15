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

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'New-AzureRmEventHubNamespaceAuthorizationRule' Cmdlet creates a new Eventhub Namespace AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.New, EventHubNamespaceAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    public class NewAzureEventHubNamespaceAuthorizationRule : AzureEventHubsCmdletBase
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
            ParameterSetName = InputFileParameterSetName,
            HelpMessage = "Name of file containing a single EventHub NameSpace AuthorizationRule definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = SASRuleParameterSetName,
            HelpMessage = "EventHub Namespace AuthorizationRule Object.")]
        [ValidateNotNullOrEmpty]
        public SharedAccessAuthorizationRuleAttributes SharedAccessAuthorizationRule { get; set; }

        public override void ExecuteCmdlet()
        {
            SharedAccessAuthorizationRuleAttributes sasRule = null;
            if (!string.IsNullOrEmpty(InputFile))
            {
                sasRule = ParseInputFile<SharedAccessAuthorizationRuleAttributes>(InputFile);
            }
            else
            {
                sasRule = SharedAccessAuthorizationRule;
            }

            // Create a new EventHub namespace authorizationRule
            SharedAccessAuthorizationRuleAttributes authRule = Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroupName, NamespaceName, sasRule.Name, sasRule);
            WriteObject(authRule);
        }
    }
}
