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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubEventHubConsumerGroup", SupportsShouldProcess = true), OutputType(typeof(string))]
    [Alias("Remove-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubEHCG")]
    public class RemoveAzureRmIotHubEventHubConsumerGroup : IotHubBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Position = 2,
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the EventHub ConsumerGroupName")]
        [ValidateNotNullOrEmpty]
        public string EventHubConsumerGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            string eventsEndpointName = "events";
            if (ShouldProcess(EventHubConsumerGroupName, Properties.Resources.RemoveEventHubConsumerGroup))
            {
                this.IotHubClient.IotHubResource.DeleteEventHubConsumerGroup(this.ResourceGroupName, this.Name, eventsEndpointName, this.EventHubConsumerGroupName);
                IEnumerable<EventHubConsumerGroupInfo> iotHubEHConsumerGroups = this.IotHubClient.IotHubResource.ListEventHubConsumerGroups(this.ResourceGroupName, this.Name, eventsEndpointName);
                this.WriteObject(IotHubUtils.ToPSEventHubConsumerGroupInfo(iotHubEHConsumerGroups), true);
            }
        }
    }
}
