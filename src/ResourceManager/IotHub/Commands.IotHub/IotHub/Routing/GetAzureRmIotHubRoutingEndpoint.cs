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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using WindowsAzure.Commands.Utilities.Common;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubRoutingEndpoint", DefaultParameterSetName = ResourceParameterSet), OutputType(
        typeof(PSRoutingEventHubEndpoint), typeof(List<PSRoutingEventHubProperties>),
        typeof(PSRoutingServiceBusQueueEndpoint), typeof(PSRoutingServiceBusQueueEndpointProperties[]),
        typeof(PSRoutingServiceBusTopicEndpoint), typeof(PSRoutingServiceBusTopicEndpointProperties[]),
        typeof(PSRoutingStorageContainerEndpoint), typeof(PSRoutingStorageContainerProperties[]),
        typeof(PSRoutingCustomEndpoint[]))]
    public class GetAzureRmIotHubRoutingEndpoint : IotHubBaseCmdlet
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

        [Parameter(Mandatory = false, HelpMessage = "Type of the Routing Endpoint")]
        public PSEndpointType EndpointType { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the Routing Endpoint")]
        public string EndpointName { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription;
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
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

            if (!this.IsParameterBound(c => c.EndpointType))
            {
                List<PSRoutingCustomEndpoint> psRoutingCustomEndpointCollection = new List<PSRoutingCustomEndpoint>();

                foreach (RoutingEventHubProperties routingEventHubProperties in iotHubDescription.Properties.Routing.Endpoints.EventHubs)
                {
                    psRoutingCustomEndpointCollection.Add(new PSRoutingCustomEndpoint()
                    {
                        Name = routingEventHubProperties.Name,
                        ConnectionString = routingEventHubProperties.ConnectionString,
                        EndpointType = PSEndpointType.EventHub
                    });
                }

                foreach (RoutingServiceBusQueueEndpointProperties routingServiceBusQueueEndpointProperties in iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues)
                {
                    psRoutingCustomEndpointCollection.Add(new PSRoutingCustomEndpoint()
                    {
                        Name = routingServiceBusQueueEndpointProperties.Name,
                        ConnectionString = routingServiceBusQueueEndpointProperties.ConnectionString,
                        EndpointType = PSEndpointType.ServiceBusQueue
                    });
                }

                foreach (RoutingServiceBusTopicEndpointProperties routingServiceBusTopicEndpointProperties in iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics)
                {
                    psRoutingCustomEndpointCollection.Add(new PSRoutingCustomEndpoint()
                    {
                        Name = routingServiceBusTopicEndpointProperties.Name,
                        ConnectionString = routingServiceBusTopicEndpointProperties.ConnectionString,
                        EndpointType = PSEndpointType.ServiceBusTopic
                    });
                }

                foreach (RoutingStorageContainerProperties routingStorageContainerProperties in iotHubDescription.Properties.Routing.Endpoints.StorageContainers)
                {
                    psRoutingCustomEndpointCollection.Add(new PSRoutingCustomEndpoint()
                    {
                        Name = routingStorageContainerProperties.Name,
                        ConnectionString = routingStorageContainerProperties.ConnectionString,
                        ContainerName = routingStorageContainerProperties.ContainerName,
                        EndpointType = PSEndpointType.AzureStorageContainer
                    });
                }

                if (string.IsNullOrEmpty(this.EndpointName))
                {
                    if (psRoutingCustomEndpointCollection.Count == 1)
                    {
                        this.WriteEndpointObject(iotHubDescription, psRoutingCustomEndpointCollection[0].EndpointType, string.Empty);
                    }
                    else
                    {
                        this.WriteObject(psRoutingCustomEndpointCollection, true);
                    }
                }
                else
                {
                    PSRoutingCustomEndpoint psRoutingCustomEndpoint = psRoutingCustomEndpointCollection.FirstOrDefault(x => x.Name.Equals(this.EndpointName, StringComparison.OrdinalIgnoreCase));
                    this.WriteEndpointObject(iotHubDescription, psRoutingCustomEndpoint.EndpointType, this.EndpointName);
                }
            }
            else
            {
                this.WriteEndpointObject(iotHubDescription, this.EndpointType, this.EndpointName);
            }
        }

        private void WriteEndpointObject(IotHubDescription iotHubDescription, PSEndpointType psEndpointType, string endpointName)
        {
            switch (psEndpointType)
            {
                case PSEndpointType.EventHub:
                    if (string.IsNullOrEmpty(endpointName))
                    {
                        if (iotHubDescription.Properties.Routing.Endpoints.EventHubs.Count == 1)
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingEventHubEndpoint(iotHubDescription.Properties.Routing.Endpoints.EventHubs[0]), false);
                        }
                        else
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingEventHubProperties(iotHubDescription.Properties.Routing.Endpoints.EventHubs), true);
                        }
                    }
                    else
                    {
                        this.WriteObject(IotHubUtils.ToPSRoutingEventHubEndpoint(iotHubDescription.Properties.Routing.Endpoints.EventHubs.FirstOrDefault(x => x.Name.Equals(endpointName, StringComparison.OrdinalIgnoreCase))), false);
                    }
                    break;
                case PSEndpointType.ServiceBusQueue:
                    if (string.IsNullOrEmpty(endpointName))
                    {
                        if (iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues.Count == 1)
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingServiceBusQueueEndpoint(iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues[0]), false);
                        }
                        else
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingServiceBusQueueEndpointProperties(iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues), true);
                        }
                    }
                    else
                    {
                        this.WriteObject(IotHubUtils.ToPSRoutingServiceBusQueueEndpoint(iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues.FirstOrDefault(x => x.Name.Equals(endpointName, StringComparison.OrdinalIgnoreCase))), false);
                    }
                    break;
                case PSEndpointType.ServiceBusTopic:
                    if (string.IsNullOrEmpty(endpointName))
                    {
                        if (iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics.Count == 1)
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingServiceBusTopicEndpoint(iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics[0]), false);
                        }
                        else
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingServiceBusTopicEndpointProperties(iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics), true);
                        }
                    }
                    else
                    {
                        this.WriteObject(IotHubUtils.ToPSRoutingServiceBusTopicEndpoint(iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics.FirstOrDefault(x => x.Name.Equals(endpointName, StringComparison.OrdinalIgnoreCase))), false);
                    }
                    break;
                case PSEndpointType.AzureStorageContainer:
                    if (string.IsNullOrEmpty(endpointName))
                    {
                        if (iotHubDescription.Properties.Routing.Endpoints.StorageContainers.Count == 1)
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingStorageContainerEndpoint(iotHubDescription.Properties.Routing.Endpoints.StorageContainers[0]), false);
                        }
                        else
                        {
                            this.WriteObject(IotHubUtils.ToPSRoutingStorageContainerProperties(iotHubDescription.Properties.Routing.Endpoints.StorageContainers), true);
                        }
                    }
                    else
                    {
                        this.WriteObject(IotHubUtils.ToPSRoutingStorageContainerEndpoint(iotHubDescription.Properties.Routing.Endpoints.StorageContainers.FirstOrDefault(x => x.Name.Equals(endpointName, StringComparison.OrdinalIgnoreCase))), false);
                    }
                    break;
            }
        }
    }
}