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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventHub.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'Get-AzureRmEventHubConsumerGroup' Cmdlet gives the details of a / List of Consumer Group
    /// <para> If consumerGroup name provided, a single Consumergroup detials will be returned</para>
    /// <para> If consumerGroup name not provided, list of Consumergroups will be returned</para>
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ConsumerGroupVerb), OutputType(typeof(List<ConsumerGroupAttributes>))]
    public class GetAzureRmEventHubConsumerGroup : AzureEventHubsCmdletBase
    {

        /// <summary>
        /// Resource Group Name
        /// </summary>
        /// <remarks>Paramaeter value is required</remarks>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name Space Name. 
        /// </summary>
        /// <remarks>Paramaeter value is required</remarks>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        /// <summary>
        /// EventHub Name. 
        /// </summary>
        /// <remarks>Paramaeter value is required</remarks>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "EventHub Name.")]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        /// <summary>
        /// Consumer Group Name.
        /// <para> If consumerGroup name provided, a single Consumergroup detials will be returned</para>
        /// <para> If consumerGroup name not provided, list of Consumergroups will be returned</para>
        /// </summary>
        /// <remarks>Paramaeter value is not required to see the List</remarks>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "ConsumerGroup Name.")]
        [Alias(AliasConsumerGroupName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                // Get a ConsumnerGroup
                ConsumerGroupAttributes consumergroupAttributesList = Client.GetConsumerGroup(ResourceGroupName, Namespace, EventHub, Name);
                WriteObject(consumergroupAttributesList);
            }
            else
            {
                // Get all ConsumnerGroups
                IEnumerable<ConsumerGroupAttributes> consumergroupAttributesList = Client.ListAllConsumerGroup(ResourceGroupName, Namespace, EventHub);
                WriteObject(consumergroupAttributesList.ToList(), true);
            }
        }
    }
}
