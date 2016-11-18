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

namespace Microsoft.Azure.Commands.EventHub.Commands.Namespace
{
    /// <summary>
    /// 'Remove-AzureRmEventHubNamespaceAuthorizationRule' Cmdlet deletes specified Eventhub Namespace AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubNamespaceAuthorizationRuleVerb, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmEventHubNamespaceAuthorizationRule : AzureEventHubsCmdletBase
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
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Namespace AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new EventHub namespace authorizationRule
            bool deleteAuthRule = Client.DeleteNamespaceAuthorizationRules(ResourceGroupName, NamespaceName, AuthorizationRuleName);
            WriteObject(deleteAuthRule);
        }
    }
}
