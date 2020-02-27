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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Devices;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Newtonsoft.Json;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeviceChildren", DefaultParameterSetName = ResourceParameterSet)]
    [Alias("Get-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDCL")]
    [OutputType(typeof(PSDeviceChildren), typeof(PSDevicesChildren[]))]
    public class GetAzIotHubDeviceChildren : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Devices/IotHubs")]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Id of edge device.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Id of edge device.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Id of edge device.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription;
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.Resourcegroup;
                this.IotHubName = this.InputObject.Name;
                iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
            }
            else
            {
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                    this.IotHubName = IotHubUtils.GetIotHubName(this.ResourceId);
                }

                iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.IotHubName);
            }

            IEnumerable<SharedAccessSignatureAuthorizationRule> authPolicies = this.IotHubClient.IotHubResource.ListKeys(this.ResourceGroupName, this.IotHubName);
            SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryRead);
            PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
            RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);

            IList<Device> parentDevices = new List<Device>();
            if (this.DeviceId != null)
            {
                Device parentDevice = registryManager.GetDeviceAsync(this.DeviceId).GetAwaiter().GetResult();

                if (parentDevice == null)
                {
                    throw new ArgumentException($"The entered parent device \"{this.DeviceId}\" doesn't exist.");
                }

                if (!parentDevice.Capabilities.IotEdge)
                {
                    throw new ArgumentException($"The entered device \"{this.DeviceId}\" should be an edge device.");
                }

                parentDevices.Add(parentDevice);
            }
            else
            {
                IEnumerable<string> deviceResults = registryManager.CreateQuery(IotHubDataPlaneUtils.GetEdgeDevices()).GetNextAsJsonAsync().GetAwaiter().GetResult();
                foreach (string deviceResult in deviceResults)
                {
                    Device d = JsonConvert.DeserializeObject<Device>(deviceResult);
                    parentDevices.Add(registryManager.GetDeviceAsync(d.Id).GetAwaiter().GetResult());
                }
            }

            IList<PSDevicesChildren> psDevicesChildren = new List<PSDevicesChildren>();

            foreach (Device parentDevice in parentDevices)
            {
                PSDevicesChildren psDeviceChildren = new PSDevicesChildren
                {
                    DeviceId = parentDevice.Id,
                    ChildrenDeviceId = new List<string>()
                };

                IList<Device> childDevices = new List<Device>();
                IEnumerable<string> deviceResults = registryManager.CreateQuery(IotHubDataPlaneUtils.GetNonEdgeDevices(parentDevice.Scope)).GetNextAsJsonAsync().GetAwaiter().GetResult();

                foreach (string deviceResult in deviceResults)
                {
                    Device d = JsonConvert.DeserializeObject<Device>(deviceResult);
                    psDeviceChildren.ChildrenDeviceId.Add(d.Id);
                }

                psDevicesChildren.Add(psDeviceChildren);
            }

            this.WriteObject(psDevicesChildren, true);
        }
    }
}
