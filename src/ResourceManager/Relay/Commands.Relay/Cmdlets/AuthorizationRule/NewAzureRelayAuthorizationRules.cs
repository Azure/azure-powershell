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
using Microsoft.Azure.Commands.Relay.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Relay.Commands
{
    /// <summary>
    /// 'New-AzureRmRelayAuthorizationRule' Cmdlet creates a new AuthorizationRule
    /// </summary>
    [Cmdlet(VerbsCommon.New, RelayAuthorizationRuleVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleAttributes))]
    public class NewAzureRelayAuthorizationRule : AzureRelayCmdletBase
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
            HelpMessage = "Namespace Name.")][Parameter(ParameterSetName = WcfRelayAuthoRuleParameterSet)]
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

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Rights, e.g.  \"Listen\",\"Send\",\"Manage\"")]
        [ValidateNotNullOrEmpty]
        public string[] Rights { get; set; }

        public override void ExecuteCmdlet()
        {            
            AuthorizationRuleAttributes sasRule = new AuthorizationRuleAttributes();
            sasRule.Rights = new List<string>();

            foreach (string test in Rights)
            {
                sasRule.Rights.Add(test);
            }

            //Create a new Namespace Authorization Rule
            if (Namespace != null && WcfRelay == null && HybridConnection == null)
                if (ShouldProcess(target: sasRule.Name, action: string.Format("Creating new AuthorizationRule named:{0} for Namespace: {1}", Name, Namespace)))
                {
                    WriteObject(Client.CreateOrUpdateNamespaceAuthorizationRules(ResourceGroup, Namespace, Name, sasRule));
                }


            // Create a new WcfRelay authorizationRule
            if (Namespace != null && WcfRelay != null && HybridConnection == null)
                if (ShouldProcess(target: sasRule.Name, action: string.Format("Creating new AuthorizationRule named:{0} for WcfRelay: {1}", Name, WcfRelay)))
            {
                WriteObject(Client.CreateOrUpdateWcfRelayAuthorizationRules(ResourceGroup, Namespace, WcfRelay, Name, sasRule));
            }

            // Create a new HybridConnection authorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection != null)
                if (ShouldProcess(target: sasRule.Name, action: string.Format("Creating new AuthorizationRule named:{0} for HybridConnection: {1}", Name, HybridConnection)))
                {
                    WriteObject(Client.CreateOrUpdateHybridConnectionsAuthorizationRules(ResourceGroup, Namespace, HybridConnection, Name, sasRule));
                }

        }
    }
}
