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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'Remove-AzureRmRelayAuthorizationRule' Cmdlet removes/deletes AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, EventHubAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureEventhubAuthorizationRules : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // Delete Namespace authorizationRule
            if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingNamespaceAuthorizationRule, Name, Namespace),
                string.Format(Resources.RemoveNamespaceAuthorizationRule, Name, Namespace),
                Name,
                () =>
                {
                    Client.DeleteNamespaceAuthorizationRules(ResourceGroupName, Namespace, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });

            // Delete Eventhub authorizationRule
            if (ParameterSetName.Equals(EventhubAuthoRuleParameterSet))
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingEventHubAuthorizationRule, Namespace, EventHub, Name),
                string.Format(Resources.RemoveEventHubAuthorizationRule, Namespace, EventHub, Name),
                Name,
                () =>
                {
                    Client.DeleteEventHubAuthorizationRules(ResourceGroupName, Namespace, EventHub, Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
