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
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using DPSResources = Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Properties.Resources;

    [Cmdlet(VerbsData.Update, "AzureRmIoTDeviceProvisioningService", DefaultParameterSetName = ResourceUpdateParameterSet, SupportsShouldProcess = true)]
    [Alias("Update-AzureRmIoTDps")]
    [OutputType(typeof(PSProvisioningServiceDescription))]
    public class UpdateAzureRmIoTDeviceProvisioningService : IotDpsBaseCmdlet
    {
        private const string InputObjectUpdateParameterSet = "InputObjectUpdateSet";
        private const string InputObjectCreateUpdateParameterSet = "InputObjectCreateUpdateSet";
        private const string ResourceIdUpdateParameterSet = "ResourceIdUpdateSet";
        private const string ResourceIdCreateUpdateParameterSet = "ResourceIdCreateUpdateSet";
        private const string ResourceUpdateParameterSet = "ResourceUpdateSet";
        private const string ResourceCreateUpdateParameterSet = "ResourceCreateUpdateSet";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectUpdateParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Object")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = InputObjectCreateUpdateParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "IoT Device Provisioning Service Object")]
        [ValidateNotNullOrEmpty]
        public PSProvisioningServiceDescription InputObject { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdUpdateParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Device Provisioning Service Resource Id")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceIdCreateUpdateParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IoT Device Provisioning Service Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceUpdateParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceCreateUpdateParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceUpdateParameterSet,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceCreateUpdateParameterSet,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = InputObjectUpdateParameterSet,
            HelpMessage = "IoT Device Provisioning Service Tag collection")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdUpdateParameterSet,
            HelpMessage = "IoT Device Provisioning Service Tag collection")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceUpdateParameterSet,
            HelpMessage = "IoT Device Provisioning Service Tag collection")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = InputObjectCreateUpdateParameterSet,
            HelpMessage = "IoT Device Provisioning Service Allocation policy")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ResourceIdCreateUpdateParameterSet,
            HelpMessage = "IoT Device Provisioning Service Allocation policy")]
        [Parameter(
            Position = 2,
            Mandatory = true,
            ParameterSetName = ResourceCreateUpdateParameterSet,
            HelpMessage = "IoT Device Provisioning Service Allocation policy")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(new string[] { "Hashed", "GeoLatency", "Static" }, IgnoreCase = true)]
        public string AllocationPolicy { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = InputObjectUpdateParameterSet,
            HelpMessage = "Reset IoT Device Provisioning Service Tags")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceIdUpdateParameterSet,
            HelpMessage = "Reset IoT Device Provisioning Service Tags")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceUpdateParameterSet,
            HelpMessage = "Reset IoT Device Provisioning Service Tags")]
        public SwitchParameter Reset { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.UpdateDeviceProvisioningService))
            {
                if (ParameterSetName.Equals(InputObjectCreateUpdateParameterSet) || ParameterSetName.Equals(InputObjectUpdateParameterSet))
                {
                    this.ResourceGroupName = this.InputObject.ResourceGroupName;
                    this.Name = this.InputObject.Name;
                }

                if (ParameterSetName.Equals(ResourceIdCreateUpdateParameterSet) || ParameterSetName.Equals(ResourceIdUpdateParameterSet))
                {
                    this.ResourceGroupName = IotDpsUtils.GetResourceGroupName(this.ResourceId);
                    this.Name = IotDpsUtils.GetIotDpsName(this.ResourceId);
                }
                
                switch(ParameterSetName)
                {
                    case InputObjectCreateUpdateParameterSet:
                    case ResourceIdCreateUpdateParameterSet:
                    case ResourceCreateUpdateParameterSet:
                        this.CreateUpdateIotDps();
                        break;

                    case InputObjectUpdateParameterSet:
                    case ResourceIdUpdateParameterSet:
                    case ResourceUpdateParameterSet:
                        this.UpdateIotDps();
                        break;
                }
            }
        }

        private void WritePSObject(ProvisioningServiceDescription provisioningServiceDescription)
        {
            this.WriteObject(IotDpsUtils.ToPSProvisioningServiceDescription(provisioningServiceDescription), false);
        }

        private void CreateUpdateIotDps()
        {
            PSAllocationPolicy psAllocationPolicy;
            if (Enum.TryParse<PSAllocationPolicy>(this.AllocationPolicy, true, out psAllocationPolicy))
            {
                ProvisioningServiceDescription provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.Name);
                provisioningServiceDescription.Properties.AllocationPolicy = psAllocationPolicy.ToString();
                this.WritePSObject(IotDpsCreateOrUpdate(this.ResourceGroupName, this.Name, provisioningServiceDescription));
            }
            else
            {
                throw new ArgumentException("Invalid Allocation Policy");
            }
        }

        private void UpdateIotDps()
        {
            ProvisioningServiceDescription updatedProvisioningServiceDescription = new ProvisioningServiceDescription();
            if (this.Reset.IsPresent)
            {
                updatedProvisioningServiceDescription = this.IotDpsClient.IotDpsResource.Update(this.ResourceGroupName, this.Name, IotDpsUtils.ToTagsResource(this.Tag.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value)));
            }
            else
            {
                ProvisioningServiceDescription provisioningServiceDescription = GetIotDpsResource(this.ResourceGroupName, this.Name);
                foreach (var tag in provisioningServiceDescription.Tags)
                {
                    if (!this.Tag.ContainsKey(tag.Key))
                    {
                        this.Tag.Add(tag.Key, tag.Value);
                    }
                }
                updatedProvisioningServiceDescription = this.IotDpsClient.IotDpsResource.Update(this.ResourceGroupName, this.Name, IotDpsUtils.ToTagsResource(this.Tag.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value)));
            }

            this.WritePSObject(updatedProvisioningServiceDescription);
        }
    }
}
