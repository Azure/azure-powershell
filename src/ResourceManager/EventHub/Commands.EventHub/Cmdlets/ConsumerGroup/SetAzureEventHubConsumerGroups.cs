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
using Microsoft.Azure.Management.EventHub.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'Set-AzureRmEventHubConsumerGroup' Cmdlet updates the specified of Consumer Group
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ConsumerGroupVerb, SupportsShouldProcess = true), OutputType(typeof(ConsumerGroupAttributes))]
    public class SetAzureEventHubConsumerGroup : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
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
             HelpMessage = "EventHub Name.")]
        [ValidateNotNullOrEmpty]
        public string EventHubName { get; set; }

        [Parameter(Mandatory = true,
             ValueFromPipelineByPropertyName = true,
             Position = 3,
             HelpMessage = "ConsumerGroup Name.")]
        [ValidateNotNullOrEmpty]
        public string ConsumerGroupName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = InputFileParameterSetName,
            Position = 4,
            HelpMessage = "Name of file containing a single ConsumerGroup definition.")]
        [ValidateNotNullOrEmpty]
        public string InputFile { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = ConsumerGroupParameterSetName,
            Position = 4,
            HelpMessage = "ConsumerGroup definition.")]
        [ValidateNotNullOrEmpty]
        public ConsumerGroupAttributes ConsumerGroupObj { get; set; }


        public override void ExecuteCmdlet()
        {
            ConsumerGroupAttributes consumerGroup = null;
            if (!string.IsNullOrEmpty(InputFile))
            {
                consumerGroup = ParseInputFile<ConsumerGroupAttributes>(InputFile);
            }
            else
            {
                consumerGroup = ConsumerGroupObj;
            }

            ConsumerGroupAttributes consumergrpAttributes = Client.CreateOrUpdateConsumerGroup(ResourceGroupName, NamespaceName, EventHubName, consumerGroup.Name, consumerGroup);
            WriteObject(consumergrpAttributes);
        }
    }
}
