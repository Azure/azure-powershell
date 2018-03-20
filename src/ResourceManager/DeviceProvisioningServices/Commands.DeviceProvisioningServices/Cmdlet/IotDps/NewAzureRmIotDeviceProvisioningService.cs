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
    using System.Management.Automation;
    using Azure.Management.Internal.Resources;
    using Azure.Management.Internal.Resources.Models;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
    using DPSResources = Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Properties.Resources;

    [Cmdlet(VerbsCommon.New, "AzureRmIoTDeviceProvisioningService", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true)]
    [Alias("New-AzureRmIoTDps")]
    [OutputType(typeof(PSProvisioningServiceDescription))]
    public class NewAzureRmIoTDeviceProvisioningService : IotDpsBaseCmdlet
    {
        private const string ResourceParameterSet = "ResourceSet";

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
            Mandatory = false,
            HelpMessage = "Location")]
        [LocationCompleter("Microsoft.Devices/ProvisioningServices")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Properties")]
        [ValidateNotNullOrEmpty]
        public PSIotDpsPropertiesDescription Properties { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sku")]
        [ValidateNotNullOrEmpty]
        public PSIotDpsSku SkuName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, DPSResources.AddDeviceProvisioningService))
            {
                try
                {
                    if (string.IsNullOrEmpty(this.Location))
                    {
                        ResourceGroup resourceGroup = ResourceManagementClient.ResourceGroups.Get(this.ResourceGroupName);
                        this.Location = resourceGroup.Location;
                    }

                    var provisioningServiceDescription = new ProvisioningServiceDescription()
                    {
                        Location = this.Location,
                        Properties = this.Properties != null ? IotDpsUtils.ToIotDpsPropertiesDescription(this.Properties) : new IotDpsPropertiesDescription(),
                        Sku = new IotDpsSkuInfo(this.SkuName.ToString() ?? IotDpsSku.S1)
                    };

                    IotDpsCreateOrUpdate(this.ResourceGroupName, this.Name, provisioningServiceDescription);
                    this.WriteObject(IotDpsUtils.ToPSProvisioningServiceDescription(GetIotDpsResource(this.ResourceGroupName, this.Name)), false);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
