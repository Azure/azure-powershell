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

using Microsoft.Azure.Commands.ServiceBus.Models;
using System.Management.Automation;
using System;

namespace Microsoft.Azure.Commands.ServiceBus.Commands.Queue
{
    /// <summary>
    /// 'Get-AzureRmServiceBusQueueKey' Cmdlet gives key detials for the given Queue Authorization Rule
    /// </summary>
    [ObsoleteAttribute("'Get-AzureRmServiceBusQueueKey' cmdlet is mark as obsolete and will be depricated in upcoming breaking changes build. Please use the New cmdlet 'Get-AzureRmServiceBusKey'", false)]
    [Cmdlet(VerbsCommon.Get, ServiceBusQueueKeyVerb), OutputType(typeof(ListKeysAttributes))]
    public class GetAzureRmServiceBusQueueKey : AzureServiceBusCmdletBase
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
            HelpMessage = "ServiceBus Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "ServiceBus Queue Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasQueueName)]
        public string Queue { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ServiceBus Queue AuthorizationRule Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAuthorizationRuleName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            // Get a ServiceBus namespace List Keys for the specified AuthorizationRule
            ListKeysAttributes keys = Client.GetQueueKey(ResourceGroup, Namespace, Queue, Name);
            WriteObject(keys);
        }
    }
}
