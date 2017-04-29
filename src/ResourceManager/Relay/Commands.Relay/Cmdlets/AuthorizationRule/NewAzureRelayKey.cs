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
    /// 'New-AzureRmRelayKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given WcfRelay Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.New, RelayKeyVerb, DefaultParameterSetName = NamespaceAuthoRuleParameterSet, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleKeysAttributes))]
    public class NewAzureRmRelayKey : AzureRelayCmdletBase
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

        [Parameter(Mandatory = true,
            HelpMessage = "Regenerate Keys - 'PrimaryKey'/'SecondaryKey'.")]
        [ValidateSet(RegeneKeys.PrimaryKey,
            RegeneKeys.SecondaryKey,
            IgnoreCase = true)]      
        public string RegenerateKey { get; set; }

        public override void ExecuteCmdlet()
        {
            var regenKey = new RegenerateKeysParameters(RegenerateKey);


            // Generate new Namespace List Keys for the specified AuthorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection == null)
            {
                if (ShouldProcess(target: RegenerateKey, action: string.Format("Generating PrimaryKey/SecondaryKey for AuthorizationRule: {0} of Namespace:{1}", Name, Namespace)))
                {
                    WriteObject(Client.NamespaceRegenerateKeys(ResourceGroup, Namespace, Name, RegenerateKey));
                }
            }

            // Generate new WcfRelay List Keys for the specified AuthorizationRule
            if (Namespace != null && WcfRelay != null && HybridConnection == null)
            {
                if (ShouldProcess(target: RegenerateKey, action: string.Format("Generating PrimaryKey/SecondaryKey for AuthorizationRule: {0} of WcfRelay:{1}", Name, WcfRelay)))
                {
                    WriteObject(Client.WcfRelayRegenerateKeys(ResourceGroup, Namespace, WcfRelay, Name, RegenerateKey));
                }
            }

            // Generate new WcfRelayHybridConnection List Keys for the specified AuthorizationRule
            if (Namespace != null && WcfRelay == null && HybridConnection != null)
            {
                if (ShouldProcess(target: RegenerateKey, action: string.Format("Generating PrimaryKey/SecondaryKey for AuthorizationRule: {0} of HybirdConnection:{1}", Name, HybridConnection)))
                {
                    WriteObject(Client.HybridConnectionsRegenerateKeys(ResourceGroup, Namespace, HybridConnection, Name, RegenerateKey));
                }
            }
        }
    }
}
