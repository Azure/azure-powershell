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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using DPSResources = Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Properties.Resources;

    [Cmdlet(VerbsData.Update, "AzureRmIoTDeviceProvisioningServiceLinkedHub", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Update-AzureRmIoTDpsHub")]
    [OutputType(typeof(PSIotHubDefinitionDescription))]
    public class UpdateAzureRmIoTDeviceProvisioningServiceLinkedHub : IotDpsBaseCmdlet
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

        [Parameter(
           Mandatory = false,
           HelpMessage = "Allocation weight of the IoT Hub")]
        [ValidateNotNullOrEmpty]
        public int? AllocationWeight { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Apply allocation policy to the IoT Hub")]
        public SwitchParameter ApplyAllocationPolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.UpdateLinkedHub))
            {
                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                        this.ResourceGroupName = this.InputObject.ResourceGroupName;
                        this.Name = this.InputObject.Name;
                        this.LinkedHubName = this.InputObject.LinkedHubName;
                        this.UpdateIotDpsLinkedHub();
                        break;

                    case ResourceIdParameterSet:
                        this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                        this.Name = IotDpsUtils.GetIotDpsName(this.ResourceId);
                        this.UpdateIotDpsLinkedHub();
                        break;

                    case ResourceParameterSet:
                        this.UpdateIotDpsLinkedHub();
                        break;

                    default:
                        throw new ArgumentException("BadParameterSetName");
                }
            }
        }

        private void UpdateIotDpsLinkedHub()
        {
            ProvisioningServiceDescription provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.Name);
            IotHubDefinitionDescription iotHub = provisioningServiceDescription.Properties.IotHubs.FirstOrDefault(x => x.Name.Equals(this.LinkedHubName, StringComparison.OrdinalIgnoreCase));
            iotHub.ApplyAllocationPolicy = this.ApplyAllocationPolicy.IsPresent;
            iotHub.AllocationWeight = this.AllocationWeight ?? iotHub.AllocationWeight;
            IotDpsCreateOrUpdate(this.ResourceGroupName, this.Name, provisioningServiceDescription);
            this.WriteObject(IotDpsUtils.ToPSIotHubDefinitionDescription(GetIotDpsHubs(this.ResourceGroupName, this.Name, this.LinkedHubName), this.ResourceGroupName, this.Name), false);
        }
    }
}

