﻿// ----------------------------------------------------------------------------------
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
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using ResourceManager.Common.ArgumentCompleters;
    using ResourceProperties = Microsoft.Azure.Commands.Management.IotHub.Properties;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHub", SupportsShouldProcess = true)]
    [OutputType(typeof(PSIotHub))]
    public class NewAzureRmIotHub : IotHubBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the Sku")]
        [ValidateNotNullOrEmpty]
        public PSIotHubSku SkuName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Number of Units")]
        [ValidateNotNullOrEmpty]
        public long Units { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Location")]
        [LocationCompleter("Microsoft.Devices/IotHubs")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Properties")]
        [ValidateNotNullOrEmpty]
        public PSIotHubInputProperties Properties { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "IoT hub instance tags. Property bag in key-value pairs in the form of a hash table.")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, ResourceProperties.Resources.AddIotHub))
            {
                var iotHubDescription = new IotHubDescription()
                {
                    Location = this.Location,
                    Sku = new IotHubSkuInfo()
                    {
                        Name = this.SkuName.ToString(),
                        Capacity = this.Units
                    }
                };

                if (this.IsParameterBound(c => c.Tag))
                {
                    iotHubDescription.Tags = this.Tag.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
                }

                if (this.Properties != null)
                {
                    iotHubDescription.Properties = IotHubUtils.ToIotHubProperties(this.Properties);
                }

                this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);
                IotHubDescription updatedIotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
                this.WriteObject(IotHubUtils.ToPSIotHub(updatedIotHubDescription), false);
            }
        }
    }
}
