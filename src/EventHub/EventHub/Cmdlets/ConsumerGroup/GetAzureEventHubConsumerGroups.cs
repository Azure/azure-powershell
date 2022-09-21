﻿// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.EventHub.Commands.ConsumerGroup
{
    /// <summary>
    /// 'Get-AzEventHubConsumerGroup' Cmdlet gives the details of a / List of Consumer Group
    /// <para> If consumerGroup name provided, a single Consumergroup detials will be returned</para>
    /// <para> If consumerGroup name not provided, list of Consumergroups will be returned</para>
    /// </summary>
    [GenericBreakingChange(message: BreakingChangeNotification + "\n- Output type of the cmdlet would change to 'Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.Api202201Preview.IConsumerGroup'", deprecateByVersion: DeprecateByVersion, changeInEfectByDate: ChangeInEffectByDate)]
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventHubConsumerGroup"), OutputType(typeof(PSConsumerGroupAttributes))]
    public class GetAzureRmEventHubConsumerGroup : AzureEventHubsCmdletBase
    {

        /// <summary>
        /// Resource Group Name
        /// </summary>
        /// <remarks>Paramaeter value is required</remarks>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 0, HelpMessage = "Resource Group Name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        /// <summary>
        /// Name Space Name. 
        /// </summary>
        /// <remarks>Paramaeter value is required</remarks>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "Namespace Name")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        /// <summary>
        /// EventHub Name. 
        /// </summary>
        /// <remarks>Paramaeter value is required</remarks>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "EventHub Name")]
        [Alias(AliasEventHubName)]
        public string EventHub { get; set; }

        /// <summary>
        /// Consumer Group Name.
        /// <para> If consumerGroup name provided, a single Consumergroup detials will be returned</para>
        /// <para> If consumerGroup name not provided, list of Consumergroups will be returned</para>
        /// </summary>
        /// <remarks>Paramaeter value is not required to see the List</remarks>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, Position =3, HelpMessage = "ConsumerGroup Name")]
        [Alias(AliasConsumerGroupName)]
        public string Name { get; set; }

        [CmdletParameterBreakingChange("MaxCount", ChangeDescription = "'-MaxCount' is being removed. '-Skip' and '-Top' would be added to support pagination.")]
        [Parameter(Mandatory = false, HelpMessage = "Determine the maximum number of ConsumerGroups  to return.")]
        [ValidateNotNull]
        public int? MaxCount { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                {
                    // Get a ConsumnerGroup
                    PSConsumerGroupAttributes consumergroupAttributesList = UtilityClient.GetConsumerGroup(ResourceGroupName, Namespace, EventHub, Name);
                    WriteObject(consumergroupAttributesList);
                }
                else
                {
                    if (MaxCount.HasValue)
                    {
                        // Get all ConsumnerGroups
                        IEnumerable<PSConsumerGroupAttributes> consumergroupAttributesList = UtilityClient.ListAllConsumerGroup(ResourceGroupName, Namespace, EventHub, MaxCount);
                        WriteObject(consumergroupAttributesList.ToList(), true);
                    }
                    else
                    {
                        // Get all ConsumnerGroups
                        IEnumerable<PSConsumerGroupAttributes> consumergroupAttributesList = UtilityClient.ListAllConsumerGroup(ResourceGroupName, Namespace, EventHub);
                        WriteObject(consumergroupAttributesList.ToList(), true);
                    }
                }
            }
            catch (Management.EventHub.Models.ErrorResponseException ex)
            {
                WriteError(Eventhub.EventHubsClient.WriteErrorforBadrequest(ex));
            }
        }
    }
}
