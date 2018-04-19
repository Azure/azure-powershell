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

namespace Microsoft.Azure.Commands.Management.DeviceProvisioningServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Azure.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using DPSResources = Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Properties.Resources;

    [Cmdlet(VerbsCommon.Remove, "AzureRmIoTDeviceProvisioningServiceLinkedHub", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Remove-AzureRmIoTDpsHub")]
    [OutputType(typeof(bool))]
    public class RemoveAzureRmIoTDeviceProvisioningServiceLinkedHub : IotDpsBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Linked Hub Object")]
        [ValidateNotNullOrEmpty]
        public PSIotHubDefinitionDescription InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Device Provisioning Service Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "Host name of linked IoT Hub")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            HelpMessage = "Host name of linked IoT Hub")]
        [ValidateNotNullOrEmpty]
        public string LinkedHubName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.RemoveLinkedHub))
            {
                if (ParameterSetName.Equals(InputObjectParameterSet))
                {
                    this.ResourceGroupName = this.InputObject.ResourceGroupName;
                    this.Name = this.InputObject.Name;
                    this.LinkedHubName = this.InputObject.LinkedHubName;
                }

                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                    this.Name = IotDpsUtils.GetIotDpsName(this.ResourceId);
                }

                ProvisioningServiceDescription provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.Name);
                IList<IotHubDefinitionDescription> linkedHubs = GetIotDpsHubs(this.ResourceGroupName, this.Name);
                IotHubDefinitionDescription linkedHub = linkedHubs.FirstOrDefault(hubs => hubs.Name.Equals(this.LinkedHubName));
                provisioningServiceDescription.Properties.IotHubs = linkedHubs.Where(x => x.ConnectionString != linkedHub.ConnectionString).ToList();
                IotDpsCreateOrUpdate(this.ResourceGroupName, this.Name, provisioningServiceDescription);

                if (PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}


