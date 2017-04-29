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

namespace Microsoft.Azure.Commands.Relay.Commands.WcfRelay
{
    /// <summary>
    /// 'New-AzureRmWcfRelayKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given WcfRelay Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.New, RelayWcfRelayKeyVerb, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleKeysAttributes))]
    public class NewAzureRmWcfRelayKey : AzureRelayCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
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
            HelpMessage = "WcfRelay Name.")]
        [ValidateNotNullOrEmpty]
        public string WcfRelayName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Authorization Rule Name.")]        
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }        

        [Parameter(Mandatory = true,
            HelpMessage = "Regenerate Keys - 'PrimaryKey'/'SecondaryKey'.")]
        [ValidateSet(RegeneKeys.PrimaryKey,
            RegeneKeys.SecondaryKey,
            IgnoreCase = true)]      
        public string RegenerateKey { get; set; }

        public override void ExecuteCmdlet()
        {
            var regenKey = new RegenerateKeysParameters(RegenerateKey);

            // Get a WcfRelay List Keys for the specified AuthorizationRule
            if (ShouldProcess(target: RegenerateKey, action: string.Format("Generating PrimaryKey/SecondaryKey for AuthorizationRule: {0} of WcfRelay:{1}", AuthorizationRuleName, WcfRelayName)))
            {
               WriteObject(Client.SetRegenerateKeys(ResourceGroupName, NamespaceName, WcfRelayName, AuthorizationRuleName, RegenerateKey));
            }
        }
    }
}
