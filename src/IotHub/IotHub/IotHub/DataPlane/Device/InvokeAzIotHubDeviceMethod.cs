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
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubDeviceMethod", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSCloudToDeviceMethodResult))]
    public class InvokeAzIotHubDeviceMethod : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Devices/IotHubs")]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Target Device Id.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Target Device Id.")]
        [ValidateNotNullOrEmpty]
        public string DeviceId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the method to invoke on this device.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The payload for the method to invoke on this device.")]
        public string Payload { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Number of seconds to wait until a result is received from the direct method. Default is 10.")]
        public int ResponseTimeOut { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Number of seconds to wait until a connection is successfully made. Default is 10.")]
        [ValidateRange(10, 300)]
        public int ConnectionTimeOut { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.IotHubName, Properties.Resources.InvokeIotHubDeviceMethod))
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
                SharedAccessSignatureAuthorizationRule policy = IotHubUtils.GetPolicy(authPolicies, PSAccessRights.ServiceConnect);
                PSIotHubConnectionString psIotHubConnectionString = IotHubUtils.ToPSIotHubConnectionString(policy, iotHubDescription.Properties.HostName);
                ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(psIotHubConnectionString.PrimaryConnectionString);

                if (!this.IsParameterBound(c => c.ResponseTimeOut))
                {
                    this.ResponseTimeOut = 10;
                }

                if (!this.IsParameterBound(c => c.ConnectionTimeOut))
                {
                    this.ConnectionTimeOut = 10;
                }

                CloudToDeviceMethod method = new CloudToDeviceMethod(this.Name, new TimeSpan(0, 0, this.ResponseTimeOut), new TimeSpan(0, 0, this.ConnectionTimeOut));
                if (this.IsParameterBound(c => c.Payload))
                {
                    method = method.SetPayloadJson(this.Payload);
                }

                CloudToDeviceMethodResult result = serviceClient.InvokeDeviceMethodAsync(this.DeviceId, method).GetAwaiter().GetResult();
                PSCloudToDeviceMethodResult psCloudToDeviceMethodResult = new PSCloudToDeviceMethodResult()
                {
                    Status = result.Status,
                    Payload = result.GetPayloadAsJson()
                };
                this.WriteObject(psCloudToDeviceMethodResult);
            }
        }
    }
}
