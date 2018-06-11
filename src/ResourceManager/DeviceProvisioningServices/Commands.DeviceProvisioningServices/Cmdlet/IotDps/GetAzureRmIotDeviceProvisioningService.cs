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
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.DeviceProvisioningServices.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.DeviceProvisioningServices;
    using Microsoft.Azure.Management.DeviceProvisioningServices.Models;

    [Cmdlet(VerbsCommon.Get, "AzureRmIoTDeviceProvisioningService", DefaultParameterSetName = ListIotDpsByRGParameterSet)]
    [Alias("Get-AzureRmIoTDps")]
    [OutputType(typeof(PSProvisioningServiceDescription), typeof(List<PSProvisioningServicesDescription>))]
    public class GetAzureRmIoTDeviceProvisioningService : IotDpsBaseCmdlet
    {
        private const string GetIotDpsParameterSet = "GetIotDpsByName";
        private const string ListIotDpsByRGParameterSet = "ListIotDpsByResourceGroup";

        [Parameter(
            Mandatory = false,
            ParameterSetName = ListIotDpsByRGParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = GetIotDpsParameterSet,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = GetIotDpsParameterSet,
            HelpMessage = "Name of the IoT Device Provisioning Service")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            switch(ParameterSetName)
            {
                case GetIotDpsParameterSet:
                    this.GetIotDps();
                    break;

                case ListIotDpsByRGParameterSet:
                    if (string.IsNullOrEmpty(this.ResourceGroupName))
                    {
                        IEnumerable<ProvisioningServiceDescription> iotprovisioningServiceDescriptionsBySubscription = this.IotDpsClient.IotDpsResource.ListBySubscription();
                        this.GetIotDpsCollection(iotprovisioningServiceDescriptionsBySubscription);
                    }
                    else
                    {
                        IEnumerable<ProvisioningServiceDescription> provisioningServiceDescriptions = this.IotDpsClient.IotDpsResource.ListByResourceGroup(this.ResourceGroupName);
                        this.GetIotDpsCollection(provisioningServiceDescriptions);
                    }
                    break;
                
                default:
                    throw new ArgumentException("BadParameterSetName");
            }
        }

        private void WritePSObject(ProvisioningServiceDescription provisioningServiceDescription)
        {
            this.WriteObject(IotDpsUtils.ToPSProvisioningServiceDescription(provisioningServiceDescription), false);
        }

        private void WritePSObjects(IEnumerable<ProvisioningServiceDescription> provisioningServicesDescription)
        {
            this.WriteObject(IotDpsUtils.ToPSProvisioningServicesDescription(provisioningServicesDescription), true);
        }

        private void GetIotDps()
        {
            this.WritePSObject(GetIotDpsResource(this.ResourceGroupName, this.Name));
        }

        private void GetIotDpsCollection(IEnumerable<ProvisioningServiceDescription> provisioningServicesDescription)
        {
            List<ProvisioningServiceDescription> iotDpsList = new List<ProvisioningServiceDescription>(provisioningServicesDescription);
            if (iotDpsList.Count == 1)
            {
                this.WritePSObject(iotDpsList[0]);
            }
            else
            {
                this.WritePSObjects(provisioningServicesDescription);
            }
        }
    }
}
