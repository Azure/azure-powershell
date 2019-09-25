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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubRoutingEndpoint", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true), OutputType(
        typeof(PSRoutingEventHubEndpoint), typeof(PSRoutingServiceBusQueueEndpoint),
        typeof(PSRoutingServiceBusTopicEndpoint), typeof(PSRoutingStorageContainerEndpoint))]
    public class AddAzureRmIotHubRoutingEndpoint : IotHubBaseCmdlet, IDynamicParameters
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

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Name of the Routing Endpoint")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Name of the Routing Endpoint")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Routing Endpoint")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Type of the Routing Endpoint")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Type of the Routing Endpoint")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Type of the Routing Endpoint")]
        [ValidateNotNullOrEmpty]
        public PSEndpointType EndpointType { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Resource group of the Endpoint resource")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Resource group of the Endpoint resource")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Resource group of the Endpoint resource")]
        [ValidateNotNullOrEmpty]
        public string EndpointResourceGroup { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "SubscriptionId of the Endpoint resource")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "SubscriptionId of the Endpoint resource")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "SubscriptionId of the Endpoint resource")]
        [ValidateNotNullOrEmpty]
        public string EndpointSubscriptionId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Connection string of the Routing Endpoint")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Connection string of the Routing Endpoint")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Connection string of the Routing Endpoint")]
        [ValidateNotNullOrEmpty]
        public string ConnectionString { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(EndpointName, Properties.Resources.AddIotHubRoutingEndpoint))
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

                switch (this.EndpointType)
                {
                    case PSEndpointType.EventHub:
                        iotHubDescription.Properties.Routing.Endpoints.EventHubs.Add(
                            new RoutingEventHubProperties()
                            {
                                Name = this.EndpointName,
                                ConnectionString = this.ConnectionString,
                                ResourceGroup = this.EndpointResourceGroup,
                                SubscriptionId = this.EndpointSubscriptionId
                            });
                        break;
                    case PSEndpointType.ServiceBusQueue:
                        iotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues.Add(
                            new RoutingServiceBusQueueEndpointProperties()
                            {
                                Name = this.EndpointName,
                                ConnectionString = this.ConnectionString,
                                ResourceGroup = this.EndpointResourceGroup,
                                SubscriptionId = this.EndpointSubscriptionId
                            });
                        break;
                    case PSEndpointType.ServiceBusTopic:
                        iotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics.Add(
                            new RoutingServiceBusTopicEndpointProperties()
                            {
                                Name = this.EndpointName,
                                ConnectionString = this.ConnectionString,
                                ResourceGroup = this.EndpointResourceGroup,
                                SubscriptionId = this.EndpointSubscriptionId
                            });
                        break;
                    case PSEndpointType.AzureStorageContainer:
                        iotHubDescription.Properties.Routing.Endpoints.StorageContainers.Add(
                            new RoutingStorageContainerProperties()
                            {
                                Name = this.EndpointName,
                                ConnectionString = this.ConnectionString,
                                ResourceGroup = this.EndpointResourceGroup,
                                SubscriptionId = this.EndpointSubscriptionId,
                                ContainerName = this.routingEndpointDynamicParameter.ContainerName,
                                Encoding = this.routingEndpointDynamicParameter.Encoding
                            });
                        break;
                }

                this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);
                IotHubDescription updatedIotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);

                switch (this.EndpointType)
                {
                    case PSEndpointType.EventHub:
                        this.WriteObject(IotHubUtils.ToPSRoutingEventHubEndpoint(updatedIotHubDescription.Properties.Routing.Endpoints.EventHubs.FirstOrDefault(x => x.Name.Equals(this.EndpointName, StringComparison.OrdinalIgnoreCase))), false);
                        break;
                    case PSEndpointType.ServiceBusQueue:
                        this.WriteObject(IotHubUtils.ToPSRoutingServiceBusQueueEndpoint(updatedIotHubDescription.Properties.Routing.Endpoints.ServiceBusQueues.FirstOrDefault(x => x.Name.Equals(this.EndpointName, StringComparison.OrdinalIgnoreCase))), false);
                        break;
                    case PSEndpointType.ServiceBusTopic:
                        this.WriteObject(IotHubUtils.ToPSRoutingServiceBusTopicEndpoint(updatedIotHubDescription.Properties.Routing.Endpoints.ServiceBusTopics.FirstOrDefault(x => x.Name.Equals(this.EndpointName, StringComparison.OrdinalIgnoreCase))), false);
                        break;
                    case PSEndpointType.AzureStorageContainer:
                        this.WriteObject(IotHubUtils.ToPSRoutingStorageContainerEndpoint(updatedIotHubDescription.Properties.Routing.Endpoints.StorageContainers.FirstOrDefault(x => x.Name.Equals(this.EndpointName, StringComparison.OrdinalIgnoreCase))), false);
                        break;
                }
            }
        }

        public object GetDynamicParameters()
        {
            if (this.EndpointType.Equals(PSEndpointType.AzureStorageContainer))
            {
                routingEndpointDynamicParameter = new RoutingEndpointDynamicParameter();
                return routingEndpointDynamicParameter;
            }

            return null;
        }

        private RoutingEndpointDynamicParameter routingEndpointDynamicParameter;

        public class RoutingEndpointDynamicParameter
        {
            [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Name of the storage container")]
            [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Name of the storage container")]
            [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the storage container")]
            [ValidateNotNullOrEmpty]
            public string ContainerName { get; set; }

            [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Select the format in which you want to route your data in. You can select JSON or AVRO. The default is set to AVRO.")]
            [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Select the format in which you want to route your data in. You can select JSON or AVRO. The default is set to AVRO.")]
            [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Select the format in which you want to route your data in. You can select JSON or AVRO. The default is set to AVRO.")]
            [ValidateNotNullOrEmpty]
            [ValidateSet(new string[] { "json", "avro" }, IgnoreCase = true)]
            public string Encoding { get; set; }
        }
    }
}



