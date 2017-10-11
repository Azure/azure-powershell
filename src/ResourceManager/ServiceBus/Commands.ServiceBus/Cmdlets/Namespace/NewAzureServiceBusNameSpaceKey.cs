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

using Microsoft.Azure.Management.ServiceBus.Models;
using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'New-AzureRmServicebusNamespaceKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given ServiceBus Namespace Authorization Rule
    /// </summary>
    [ObsoleteAttribute("'New-AzureRmServicebusNamespaceKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'New-AzureRmServicebusKey'", false)]
    [Cmdlet(VerbsCommon.New, ServiceBusNamespaceKeyVerb, SupportsShouldProcess = true), OutputType(typeof(ListKeysAttributes))]
    public class NewAzureRmServiceBusNamespaceKeys : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroupname)]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }
                
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Authorization Rule Name.")]        
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }        

        [Parameter(Mandatory = true,
            Position = 4,
            ParameterSetName = RegenerateKeysSetName,
            HelpMessage = "Regenerate Keys - PrimaryKey/SecondaryKey.")]
        [ValidateSet(RegeneKeys.PrimaryKey,
            RegeneKeys.SecondaryKey,
            IgnoreCase = true)]       
        public string RegenerateKeys { get; set; }

        public override void ExecuteCmdlet()
        {
            // Get a ServiceBus List Keys for the specified AuthorizationRule

            if (ShouldProcess(target: RegenerateKeys, action: string.Format("Generate new Key:{0} for the AuthorizationRule:{1} of Namespace:{2}", RegenerateKeys, Name, Namespace)))
            {
                WriteObject(Client.SetRegenerateKeys(ResourceGroup, Namespace, Name, RegenerateKeys));
            }
        }
    }
}
