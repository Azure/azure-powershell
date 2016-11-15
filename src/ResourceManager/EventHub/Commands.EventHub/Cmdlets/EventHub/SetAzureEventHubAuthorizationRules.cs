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

namespace Microsoft.Azure.Commands.EventHub.Commands.EventHub
{
    /// <summary>
    /// 'Set-AzureRmEventHubAuthorizationRule' Cmdlet updates the specified AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventHubAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    public class SetAzureEventHubAuthorizationRule : AzureEventHubsCmdletBase
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
            HelpMessage = "EventHub Name.")]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ParameterSetName = InputFileParameterSetName,
            HelpMessage = "Name of file containing a single AuthorizationRule definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ParameterSetName = SASRuleParameterSetName,
            HelpMessage = "EventHub AuthorizationRule Object.")]
        [ValidateNotNullOrEmpty]
        public SharedAccessAuthorizationRuleAttributes SASRule { get; set; }

        public override void ExecuteCmdlet()
        {
            SharedAccessAuthorizationRuleAttributes sasRule = null;
            if (!string.IsNullOrEmpty(InputFile))
            {
                sasRule = ParseInputFile<SharedAccessAuthorizationRuleAttributes>(InputFile);
            }
            else
            {
                sasRule = SASRule;
            }

            // Update a eventHub authorizationRule
            SharedAccessAuthorizationRuleAttributes authRule = Client.CreateOrUpdateEventHubAuthorizationRules(ResourceGroupName, NamespaceName, EventHubName,
                                                    sasRule.Name, sasRule);
            WriteObject(authRule);
        }
    }
}
