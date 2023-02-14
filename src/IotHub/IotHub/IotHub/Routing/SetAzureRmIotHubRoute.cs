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

    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubRoute", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSRouteMetadata))]
    public class SetAzureRmIotHubRoute : IotHubBaseCmdlet
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

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Name of the Route")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Name of the Route")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Route")]
        [ValidateNotNullOrEmpty]
        public string RouteName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Source of the route")]
        public PSRoutingSource? Source { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Name of the routing endpoint")]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Condition that is evaluated to apply the routing rule")]
        public string Condition { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable route")]
        public SwitchParameter Enabled { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.RouteName, Properties.Resources.UpdateIotHubRoute))
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

                if (iotHubDescription.Properties.Routing.Routes.Any(x => x.Name.Equals(this.RouteName, StringComparison.OrdinalIgnoreCase)))
                {
                    RouteProperties routeProperties = iotHubDescription.Properties.Routing.Routes.FirstOrDefault(x => x.Name.Equals(this.RouteName, StringComparison.OrdinalIgnoreCase));
                    if (this.Source.HasValue)
                    {
                        routeProperties.Source = this.Source.Value.ToString();
                    }
                    if (!string.IsNullOrEmpty(this.EndpointName))
                    {
                        routeProperties.EndpointNames = new List<string>() { this.EndpointName };
                    }
                    if (!string.IsNullOrEmpty(this.Condition))
                    {
                        routeProperties.Condition = this.Condition;
                    }
                    if (this.Enabled.IsPresent)
                    {
                        routeProperties.IsEnabled = this.Enabled.IsPresent;
                    }

                    this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);
                    IotHubDescription updatedIotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
                    this.WriteObject(IotHubUtils.ToPSRouteMetadata(updatedIotHubDescription.Properties.Routing.Routes.FirstOrDefault(x => x.Name.Equals(this.RouteName, StringComparison.OrdinalIgnoreCase))), false);
                }
                else
                {
                    throw new ArgumentException("Entered route doesn't exist.");
                }
            }
        }
    }
}