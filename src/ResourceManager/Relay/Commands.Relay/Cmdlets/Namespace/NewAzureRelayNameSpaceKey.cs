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

namespace Microsoft.Azure.Commands.Relay.Commands.Namespace
{
    /// <summary>
    /// 'New-AzureRmRelayNamespaceKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given Relay Namespace Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.New, RelayNamespaceKeyVerb, SupportsShouldProcess = true), OutputType(typeof(AuthorizationRuleKeysAttributes))]
    public class NewAzureRmRelayNamespaceKey : AzureRelayCmdletBase
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
            HelpMessage = "Authorization Rule Name.")]        
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }        

        [Parameter(Mandatory = true,
            Position = 3,
            HelpMessage = "Regenerate Keys - 'PrimaryKey'/'SecondaryKey'.")]
        [ValidateSet(RegeneKeys.PrimaryKey,
            RegeneKeys.SecondaryKey,
            IgnoreCase = true)]      
        public string RegenerateKey { get; set; }

        public override void ExecuteCmdlet()
        {
            var regenKey = new RegenerateKeysParameters(RegenerateKey);

            // Get a Relay List Keys for the specified AuthorizationRule
            if (ShouldProcess(target: RegenerateKey, action: string.Format("Generating Key:{0} for AuthorizationRule:{1} of NameSpace:{2}", RegenerateKey, AuthorizationRuleName, NamespaceName)))
            {
                WriteObject(Client.SetRegenerateKeys(ResourceGroupName, NamespaceName, AuthorizationRuleName, RegenerateKey));
            }
        }
    }
}
