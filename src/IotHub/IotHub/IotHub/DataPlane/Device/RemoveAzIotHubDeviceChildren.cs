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

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeviceChildren", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Remove-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDCL")]
    [OutputType(typeof(bool))]
    public class RemoveAzIotHubDeviceChildren : IotHubBaseCmdlet
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

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Id of edge device.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Id of edge device.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Id of edge device.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "Child device list (comma separated) includes only non-edge devices.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Child device list (comma separated) includes only non-edge devices.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "Child device list (comma separated) includes only non-edge devices.")]
        [ValidateNotNullOrEmpty]
        public string[] Children { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows to return the boolean object. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.DeviceId, Properties.Resources.RemoveIotHubDeviceChildren))
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
                SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.RegistryWrite);
                PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
                RegistryManager registryManager = RegistryManager.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);

                Device parentDevice = registryManager.GetDeviceAsync(this.DeviceId).GetAwaiter().GetResult();

                if (parentDevice == null)
                {
                    throw new ArgumentException($"The entered parent device \"{this.DeviceId}\" doesn't exist.");
                }

                if (!parentDevice.Capabilities.IotEdge)
                {
                    throw new ArgumentException($"The entered device \"{this.DeviceId}\" should be an edge device.");
                }

                IList<Device> childDevices = new List<Device>();

                if (this.Children != null)
                {
                    foreach (string childDeviceId in this.Children)
                    {
                        Device childDevice = registryManager.GetDeviceAsync(childDeviceId).GetAwaiter().GetResult();
                        
                        if (childDevice == null)
                        {
                            throw new ArgumentException($"The entered children device \"{childDeviceId}\" doesn't exist.");
                        }

                        if (childDevice.Capabilities.IotEdge)
                        {
                            throw new ArgumentException($"The entered children device \"{childDeviceId}\" should be non-edge device.");
                        }

                        if (!string.IsNullOrEmpty(childDevice.Scope) && !childDevice.Scope.Equals(parentDevice.Scope))
                        {
                            throw new ArgumentException($"The entered children device \"{childDeviceId}\" isn\'t assigned as a child of entered device \"{this.DeviceId}\".");
                        }

                        childDevices.Add(childDevice);
                    }
                }
                else
                {
                    IEnumerable<string> deviceResults = registryManager.CreateQuery(IotHubDataPlaneUtils.GetNonEdgeDevices(parentDevice.Scope)).GetNextAsJsonAsync().GetAwaiter().GetResult();
                    foreach (string deviceResult in deviceResults)
                    {
                        Device d = JsonConvert.DeserializeObject<Device>(deviceResult);
                        childDevices.Add(registryManager.GetDeviceAsync(d.Id).GetAwaiter().GetResult());
                    }
                }

                try
                {
                    foreach (Device childDevice in childDevices)
                    {
                        childDevice.Scope = string.Empty;
                        registryManager.UpdateDeviceAsync(childDevice).GetAwaiter().GetResult();
                    }

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
