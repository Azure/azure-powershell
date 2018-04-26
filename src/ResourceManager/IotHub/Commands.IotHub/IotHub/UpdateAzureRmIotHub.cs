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
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System.Collections;
    using System.Linq;

    [Cmdlet(VerbsData.Update, "AzureRmIotHub", DefaultParameterSetName = ResourceUpdateParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSIotHub))]
    public class UpdateAzureRmIotHub : IotHubBaseCmdlet
    {
        private const string ResourceUpdateParameterSet = "ResourceUpdateSet";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceUpdateParameterSet,
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
            ParameterSetName = ResourceUpdateParameterSet,
            HelpMessage = "IoTHub Tag collection")]
        [ValidateNotNullOrEmpty]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = ResourceUpdateParameterSet,
            HelpMessage = "Reset IoTHub Tags")]
        public SwitchParameter Reset { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, Properties.Resources.UpdateIotHub))
            {
                IotHubDescription iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);

                if (!this.Reset.IsPresent)
                {
                    foreach (var tag in iotHubDescription.Tags)
                    {
                        if (!this.Tag.ContainsKey(tag.Key))
                        {
                            this.Tag.Add(tag.Key, tag.Value);
                        }
                    }
                }

                iotHubDescription = this.IotHubClient.IotHubResource.Update(this.ResourceGroupName, this.Name, IotHubUtils.ToTagsResource(this.Tag.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value)));
                this.WriteObject(IotHubUtils.ToPSIotHub(iotHubDescription), false);
            }
        }
    }
}
