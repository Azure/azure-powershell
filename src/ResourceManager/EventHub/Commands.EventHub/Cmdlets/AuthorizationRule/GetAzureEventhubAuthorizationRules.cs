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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands
{
    /// <summary>
    /// 'Get-AzureRmWcfRelayAuthorizationRule' Cmdlet gives the details of a / List of AuthorizationRule(s)
    /// <para> If AuthorizationRule name provided, a single AuthorizationRule detials will be returned</para>
    /// <para> If AuthorizationRule name not provided, list of AuthorizationRules will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, EventHubAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet), OutputType(typeof(List<SharedAccessAuthorizationRuleAttributes>))]
    public class GetAzureEventHubAuthorizationRule : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1, ParameterSetName = NamespaceAuthoRuleParameterSet,
            HelpMessage = "Namespace Name.")]
        [Parameter(Mandatory = true, Position = 1,ValueFromPipelineByPropertyName = true, ParameterSetName = EventhubAuthoRuleParameterSet)]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = AliasAuthoRuleParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = EventhubAuthoRuleParameterSet,
            HelpMessage = "Eventhub Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasEventHubName)]
        public string Eventhub { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = AliasAuthoRuleParameterSet,
            HelpMessage = "Alias Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        public string AliasName { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            //Get Namespace Authorization Rule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Namespace AuthorizationRule
                    SharedAccessAuthorizationRuleAttributes authRule = Client.GetNamespaceAuthorizationRule(ResourceGroupName, Namespace, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Namespace AuthorizationRules
                    IEnumerable<SharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListNamespaceAuthorizationRules(ResourceGroupName, Namespace);
                    WriteObject(authRuleList, true);
                }

            // Get Eventhub authorizationRule
            if (ParameterSetName == EventhubAuthoRuleParameterSet)
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Eventhub AuthorizationRule
                    SharedAccessAuthorizationRuleAttributes authRule = Client.GetEventHubAuthorizationRules(ResourceGroupName, Namespace, Eventhub, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Eventhub AuthorizationRules
                    IEnumerable<SharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListEventHubAuthorizationRules(ResourceGroupName, Namespace, Eventhub);
                    WriteObject(authRuleList, true);
                }

            // Get Alias authorizationRule
            if (ParameterSetName == AliasAuthoRuleParameterSet)
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Alias AuthorizationRule
                    SharedAccessAuthorizationRuleAttributes authRule = Client.GetAliasAuthorizationRules(ResourceGroupName, Namespace, AliasName, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Alias AuthorizationRules
                    IEnumerable<SharedAccessAuthorizationRuleAttributes> authRuleList = Client.ListAliasAuthorizationRules(ResourceGroupName, Namespace, AliasName);
                    WriteObject(authRuleList, true);
                }

        }
    }
}
