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

using Microsoft.Azure.Management.EventHub.Models;
using Microsoft.Azure.Commands.EventHub.Models;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'Get-AzureRmRelayKey' Cmdlet gives key detials for the given Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.Get, EventHubKeyVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet), OutputType(typeof(PSListKeysAttributes))]
    public class GetAzureEventhubKey : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = NamespaceAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [Parameter(Mandatory = true, ParameterSetName = AliasAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EventhubAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AliasAuthoRuleParameterSet, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "Alias Name")]
        [ValidateNotNullOrEmpty]
        public string AliasName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "AuthorizationRule Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {

            // Get a Namespace List Keys for the specified AuthorizationRule
            if (ParameterSetName.Equals(NamespaceAuthoRuleParameterSet))
            {
                PSListKeysAttributes keys = Client.GetNamespaceListKeys(ResourceGroupName, Namespace, Name);
                WriteObject(keys,true);
            }

            // Get a EventHub List Keys for the specified AuthorizationRule
            if (ParameterSetName.Equals(EventhubAuthoRuleParameterSet))
            {
                PSListKeysAttributes keys = Client.GetEventHubListKeys(ResourceGroupName, Namespace, EventHub, Name);
                WriteObject(keys,true);
            }

            // Get Alias List Keys for the specified AuthorizationRule
            if (ParameterSetName.Equals(AliasAuthoRuleParameterSet))
            {
                PSListKeysAttributes keys = Client.GetAliasListKeys(ResourceGroupName, Namespace, AliasName, Name);
                WriteObject(keys, true);
            }

        }
    }
}
