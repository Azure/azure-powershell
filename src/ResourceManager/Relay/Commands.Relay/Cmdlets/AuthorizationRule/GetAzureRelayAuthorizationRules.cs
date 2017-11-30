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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands
{
    /// <summary>
    /// 'Get-AzureRmWcfRelayAuthorizationRule' Cmdlet gives the details of a / List of AuthorizationRule(s)
    /// <para> If AuthorizationRule name provided, a single AuthorizationRule detials will be returned</para>
    /// <para> If AuthorizationRule name not provided, list of AuthorizationRules will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, RelayAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet), OutputType(typeof(List<AuthorizationRuleAttributes>))]
    public class GetAzureRelayAuthorizationRule : AzureRelayCmdletBase
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
        [Parameter(ParameterSetName = WcfRelayAuthoRuleParameterSet)]
        [Parameter(ParameterSetName = HybridConnectionAuthoRuleParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = WcfRelayAuthoRuleParameterSet,
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string WcfRelay { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2, ParameterSetName = HybridConnectionAuthoRuleParameterSet,
            HelpMessage = "HybridConnection Name.")]
        [ValidateNotNullOrEmpty]
        public string HybridConnection { get; set; }

        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {

            //Get Namespace Authorization Rule
            if (ParameterSetName == NamespaceAuthoRuleParameterSet)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a Namespace AuthorizationRule
                    AuthorizationRuleAttributes authRule = Client.GetNamespaceAuthorizationRule(ResourceGroupName, Namespace, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all Namespace AuthorizationRules
                    IEnumerable<AuthorizationRuleAttributes> authRuleList = Client.ListNamespaceAuthorizationRules(ResourceGroupName, Namespace);
                    WriteObject(authRuleList, true);
                }
            }


            // Get WcfRelay authorizationRule
            if (ParameterSetName == WcfRelayAuthoRuleParameterSet)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a WcfRelay AuthorizationRule
                    AuthorizationRuleAttributes authRule = Client.GetWcfRelayAuthorizationRules(ResourceGroupName, Namespace, WcfRelay, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all WcfRelay AuthorizationRules
                    IEnumerable<AuthorizationRuleAttributes> authRuleList = Client.ListWcfRelayAuthorizationRules(ResourceGroupName, Namespace, WcfRelay);
                    WriteObject(authRuleList, true);
                }
            }

            // Get HybridConnection authorizationRule
            if (ParameterSetName == HybridConnectionAuthoRuleParameterSet)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a HybridConnection AuthorizationRule
                    AuthorizationRuleAttributes authRule = Client.GetHybridConnectionsAuthorizationRules(ResourceGroupName, Namespace, HybridConnection, Name);
                    WriteObject(authRule);
                }
                else
                {
                    // Get all HybridConnection AuthorizationRules
                    IEnumerable<AuthorizationRuleAttributes> authRuleList = Client.ListHybridConnectionsAuthorizationRules(ResourceGroupName, Namespace, HybridConnection);
                    WriteObject(authRuleList, true);
                }
            }
            
        }
    }
}
