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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubMessageEnrichment", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubMsgEnrich")]
    public class RemoveAzureRmIotHubMessageEnrichment : IotHubBaseCmdlet
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
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectParameterSet, HelpMessage = "The enrichment's key.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The enrichment's key.")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceParameterSet, HelpMessage = "The enrichment's key.")]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Allows to return the boolean object. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription;
            if (ParameterSetName.Equals(InputObjectParameterSet))
            {
                this.ResourceGroupName = this.InputObject.Resourcegroup;
                this.Name = this.InputObject.Name;
                iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
            }
            else
            {
                if (ParameterSetName.Equals(ResourceIdParameterSet))
                {
                    this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                    this.Name = IotHubUtils.GetIotHubName(this.ResourceId);
                }

                iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
            }

            if (ShouldProcess(this.Key, Properties.Resources.RemoveIotHubMessageEnrichment))
            {

                if (string.IsNullOrEmpty(this.Key))
                {
                    iotHubDescription.Properties.Routing.Enrichments = new List<EnrichmentProperties>();
                }
                else
                {
                    if (!iotHubDescription.Properties.Routing.Enrichments.Any(x => x.Key.Equals(this.Key.Trim(), StringComparison.OrdinalIgnoreCase)))
                    {
                        throw new ArgumentException(string.Format(Properties.Resources.MessageEnrichmentKeyMissing, this.Key));
                    }

                    iotHubDescription.Properties.Routing.Enrichments = iotHubDescription.Properties.Routing.Enrichments.Where(x => x.Key.ToLowerInvariant() != this.Key.ToLowerInvariant()).ToList();
                }

                try
                {
                    this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);

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