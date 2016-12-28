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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'New-AzureRmServiceBusQueueKey' Cmdlet creates a new specified (PrimaryKey / SecondaryKey) key for the given Queue Authorization Rule
    /// </summary>
    [Cmdlet(VerbsCommon.New, ServiceBusQueueKeyVerb, SupportsShouldProcess = true), OutputType(typeof(ResourceListKeys))]
    public class NewAzureRmServiceBusQueueKey : AzureServiceBusCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroup { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "ServiceBus Name.")]
        [ValidateNotNullOrEmpty]
        public string QueueName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Authorization Rule Name.")]        
        [ValidateNotNullOrEmpty]
        public string AuthorizationRuleName { get; set; }        

        [Parameter(Mandatory = true,
            Position = 4,
            HelpMessage = "Regenerate Keys - PrimaryKey/SecondaryKey.")]
        [ValidateSet(RegeneKeys.PrimaryKey,
            RegeneKeys.SecondaryKey,
            IgnoreCase = true)]       
        public string RegenerateKeys { get; set; }

        public override void ExecuteCmdlet()
        {
            var regenKey = new RegenerateKeysParameters(ParsePolicyKey(RegenerateKeys));

            // Get a ServiceBus List Keys for the specified AuthorizationRule            

            if (ShouldProcess(target: RegenerateKeys, action: string.Format("Generate New Keys:{0} for AuthorizationRule:{1} of Queue:{2}", RegenerateKeys, AuthorizationRuleName, QueueName)))
            {
                WriteObject(Client.NewQueueKey(ResourceGroup, NamespaceName, QueueName, AuthorizationRuleName, RegenerateKeys));
            }
        }
    }
}
