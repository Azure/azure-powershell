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

using Microsoft.Azure.Management.Relay.Models;
using Microsoft.Azure.Commands.Relay.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Relay.Commands
{
    /// <summary>
    /// 'Get-AzureRmRelayKey' Cmdlet gives key detials for the given Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.Get, RelayKeyVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet), OutputType(typeof(AuthorizationRuleKeysAttributes))]
    public class GetAzureRelayKey : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

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

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {

            // Get a Namespace List Keys for the specified AuthorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection == null)
            {
                AuthorizationRuleKeysAttributes keys = Client.GetNamespaceListKeys(ResourceGroup, Namespace, Name);
                WriteObject(keys);
            }

            // Get a WcfRelay List Keys for the specified AuthorizationRule
            if (Namespace != null && WcfRelay != null && HybridConnection == null)              
            {
                AuthorizationRuleKeysAttributes keys = Client.GetWcfRelayListKeys(ResourceGroup, Namespace, WcfRelay, Name);
                WriteObject(keys);
            }

            // Get a HybridConnection List Keys for the specified AuthorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection != null)                
            {
                AuthorizationRuleKeysAttributes keys = Client.GethybridConnectionsListKeys(ResourceGroup, Namespace, HybridConnection, Name);
                WriteObject(keys);
            }           
            
        }
    }
}
