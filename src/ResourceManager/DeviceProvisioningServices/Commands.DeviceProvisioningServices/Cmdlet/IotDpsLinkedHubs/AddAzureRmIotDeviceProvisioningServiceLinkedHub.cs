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
    using Azure.Management.IotHub;
    using Azure.Management.IotHub.Models;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using DPSResources = Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Properties.Resources;

    [Cmdlet(VerbsCommon.Add, "AzureRmIoTDeviceProvisioningServiceLinkedHub", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("Add-AzureRmIoTDpsHub")]
    [OutputType(typeof(PSIotHubDefinitionDescription), typeof(List<PSIotHubDefinitions>))]
    public class AddAzureRmIotDeviceProvisioningServiceLinkedHub : IotDpsBaseCmdlet
    {
        private const string ResourceParameterSet = "ResourceSet";
        private const string InputObjectParameterSet = "InputObjectSet";
        private const string ResourceIdParameterSet = "ResourceIdSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Object")]
        [ValidateNotNullOrEmpty]
        public PSProvisioningServiceDescription InputObject { get; set; }

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
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub resource group name")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub resource group name")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub resource group name")]
        [ValidateNotNullOrEmpty]
        public string IotHubResourceGroupName { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [Parameter(
            Position = 3,
            Mandatory = true,
            ParameterSetName = ResourceParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string IotHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Allocation weight of the IoT Hub")]
        [ValidateNotNullOrEmpty]
        public int? AllocationWeight { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A boolean indicating whether to apply allocation policy to the IoT Hub")]
        [ValidateNotNullOrEmpty]
        public bool? ApplyAllocationPolicy { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.AddLinkedHub))
            {
                switch (ParameterSetName)
                {
                    case InputObjectParameterSet:
                        this.ResourceGroupName = this.InputObject.ResourceGroupName;
                        this.Name = this.InputObject.Name;
                        this.AddIotDpsLinkedHub();
                        break;

                    case ResourceIdParameterSet:
                        this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                        this.Name = IotDpsUtils.GetIotDpsName(this.ResourceId);
                        this.AddIotDpsLinkedHub();
                        break;

                    case ResourceParameterSet:
                        this.AddIotDpsLinkedHub();
                        break;

                    default:
                        throw new ArgumentException("BadParameterSetName");
                }
            }
        }

        private void WritePSObject(IotHubDefinitionDescription iotDpsHub)
        {
            this.WriteObject(IotDpsUtils.ToPSIotHubDefinitionDescription(iotDpsHub, this.ResourceGroupName, this.Name), false);
        }

        private void WritePSObjects(IList<IotHubDefinitionDescription> iotDpsHubs)
        {
            this.WriteObject(IotDpsUtils.ToPSIotHubDefinitionDescription(iotDpsHubs), true);
        }

        private void AddIotDpsLinkedHub()
        {
            try
            {
                const string IotHubConnectionStringTemplate = "HostName={0};SharedAccessKeyName={1};SharedAccessKey={2}";
                string connectionString = string.Empty;

                IotHubDescription iotHubDescription = this.IotHubClient.IotHubResource.Get(this.IotHubResourceGroupName, this.IotHubName);
                var hostName = iotHubDescription.Properties.HostName;
                var location = iotHubDescription.Location;

                IList<SharedAccessSignatureAuthorizationRule> keys = new List<SharedAccessSignatureAuthorizationRule>(this.IotHubClient.IotHubResource.ListKeys(this.IotHubResourceGroupName, this.IotHubName));
                SharedAccessSignatureAuthorizationRule key = keys.FirstOrDefault(x => x.Rights.HasFlag(AccessRights.ServiceConnect));
                if (key != null)
                {
                    connectionString = String.Format(IotHubConnectionStringTemplate, hostName, key.KeyName, key.PrimaryKey);
                }
                else
                {
                    throw new ArgumentNullException("Iot Hub doesn't have required access policy");
                }

                IotHubDefinitionDescription iotDpsHub = new IotHubDefinitionDescription()
                {
                    ConnectionString = connectionString,
                    Location = location,
                    AllocationWeight = this.AllocationWeight,
                    ApplyAllocationPolicy = this.ApplyAllocationPolicy
                };

                ProvisioningServiceDescription provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.Name);
                provisioningServiceDescription.Properties.IotHubs.Add(iotDpsHub);
                IotDpsCreateOrUpdate(this.ResourceGroupName, this.Name, provisioningServiceDescription);

                IList<IotHubDefinitionDescription> iotDpsHubs = GetIotDpsHubs(this.ResourceGroupName, this.Name);
                if (iotDpsHubs.Count == 1)
                {
                    this.WritePSObject(iotDpsHubs[0]);
                }
                else
                {
                    this.WritePSObjects(iotDpsHubs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

