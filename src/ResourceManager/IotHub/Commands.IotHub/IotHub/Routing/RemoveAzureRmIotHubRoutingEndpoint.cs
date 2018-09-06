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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using WindowsAzure.Commands.Utilities.Common;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubRoutingEndpoint", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRmIotHubRoutingEndpoint : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub Object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the Routing Endpoint")]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Type of the Routing Endpoint")]
        public PSEndpointType EndpointType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows to return the boolean object. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription;
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.Resourcegroup;
                this.Name = this.InputObject.Name;
                iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
            }
            else
            {
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                    this.Name = IotHubUtils.GetIotHubName(this.ResourceId);
                }

                iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
            }

            if (ShouldProcess(EndpointName, Properties.Resources.RemoveIotHubRoutingEndpoint))
            {
                if (string.IsNullOrEmpty(this.EndpointName))
                {
                    if (this.IsParameterBound(c => c.EndpointType))
                    {
                        switch (this.EndpointType)
                        {
                            case PSEndpointType.EventHub:
                                iotHubDescription.Properties.Routing.Endpoints.EventHubs = new List<RoutingEventHubProperties>();
                                break;
                            case PSEndpointType.ServiceBusQueue:
                                iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues = new List<RoutingServiceBusQueueEndpointProperties>();
                                break;
                            case PSEndpointType.ServiceBusTopic:
                                iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics = new List<RoutingServiceBusTopicEndpointProperties>();
                                break;
                            case PSEndpointType.AzureStorageContainer:
                                iotHubDescription.Properties.Routing.Endpoints.StorageContainers = new List<RoutingStorageContainerProperties>();
                                break;
                        }
                    }
                    else
                    {
                        iotHubDescription.Properties.Routing.Endpoints.EventHubs = new List<RoutingEventHubProperties>();
                        iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues = new List<RoutingServiceBusQueueEndpointProperties>();
                        iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics = new List<RoutingServiceBusTopicEndpointProperties>();
                        iotHubDescription.Properties.Routing.Endpoints.StorageContainers = new List<RoutingStorageContainerProperties>();
                    }
                }
                else
                {
                    iotHubDescription.Properties.Routing.Endpoints.EventHubs = iotHubDescription.Properties.Routing.Endpoints.EventHubs.Where(x => x.Name.ToLowerInvariant() != this.EndpointName.ToLowerInvariant()).ToList();
                    iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues = iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues.Where(x => x.Name.ToLowerInvariant() != this.EndpointName.ToLowerInvariant()).ToList();
                    iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics = iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics.Where(x => x.Name.ToLowerInvariant() != this.EndpointName.ToLowerInvariant()).ToList();
                    iotHubDescription.Properties.Routing.Endpoints.StorageContainers = iotHubDescription.Properties.Routing.Endpoints.StorageContainers.Where(x => x.Name.ToLowerInvariant() != this.EndpointName.ToLowerInvariant()).ToList();
                }

                try
                {
                    this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);

                    if (PassThru.IsPresent)
                    {
                        this.WriteObject(true);
                    }
                }
                catch
                {
                    if (PassThru.IsPresent)
                    {
                        this.WriteObject(false);
                    }
                }
            }
        }
    }
}