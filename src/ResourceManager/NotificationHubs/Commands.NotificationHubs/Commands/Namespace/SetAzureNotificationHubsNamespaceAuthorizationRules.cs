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

using Microsoft.Azure.Commands.NotificationHubs.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.NotificationHubs.Commands.Namespace
{

    [Cmdlet(VerbsCommon.Set, "AzureRmNotificationHubsNamespaceAuthorizationRules"), OutputType(typeof(SharedAccessAuthorizationRuleAttributes))]
    public class SetAzureNotificationHubsNamespaceAuthorizationRules : AzureNotificationHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = InputFileParameterSetName,
            HelpMessage = "File name containing a single AuthorizationRule definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = SASRuleParameterSetName,
            HelpMessage = "Namespace AuthorizationRule Object.")]
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

            // Update namespace authorizationRule
            var updateNSAuthRule = Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroup, Namespace, sasRule.Name, sasRule.Rights,
                sasRule.PrimaryKey, sasRule.SecondaryKey == null ? null : sasRule.SecondaryKey);
            WriteObject(updateNSAuthRule);
        }
    }
}
