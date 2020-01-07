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

    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubMessageEnrichment", DefaultParameterSetName = ResourceParameterSet, SupportsShouldProcess = true), OutputType(typeof(PSEnrichmentMetadata))]
    [Alias("Add-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubMsgEnrich")]
    public class AddAzureRmIotHubMessageEnrichment : IotHubBaseCmdlet
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

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "The enrichment's key.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The enrichment's key.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "The enrichment's key.")]
        [ValidateNotNullOrEmpty]
        public string Key { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "The enrichment's value.")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "The enrichment's value.")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "The enrichment's value.")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = InputObjectParameterSet, HelpMessage = "Endpoint(s) to apply enrichments to.")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, HelpMessage = "Endpoint(s) to apply enrichments to.")]
        [Parameter(Mandatory = true, ParameterSetName = ResourceParameterSet, HelpMessage = "Endpoint(s) to apply enrichments to.")]
        [ValidateNotNullOrEmpty]
        public string[] Endpoint { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.Key, Properties.Resources.AddIotHubMessageEnrichment))
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

                if(iotHubDescription.Properties.Routing.Enrichments == null)
                {
                    iotHubDescription.Properties.Routing.Enrichments = new List<EnrichmentProperties>();
                }

                if(!iotHubDescription.Properties.Routing.Enrichments.Any(x => x.Key.Equals(this.Key.Trim(), StringComparison.OrdinalIgnoreCase)))
                {
                    IList<string> endpointNames = new List<string>();
                    foreach (string endpoint in this.Endpoint)
                    {
                        endpointNames.Add(endpoint.Trim());
                    }

                    iotHubDescription.Properties.Routing.Enrichments.Add(
                        new EnrichmentProperties(
                            this.Key.Trim(),
                            this.Value.Trim(),
                            endpointNames
                        ));

                    this.IotHubClient.IotHubResource.CreateOrUpdate(this.ResourceGroupName, this.Name, iotHubDescription);
                    IotHubDescription updatedIotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
                    this.WriteObject(IotHubUtils.ToPSEnrichmentMetadata(updatedIotHubDescription.Properties.Routing.Enrichments.FirstOrDefault(x => x.Key.Equals(this.Key, StringComparison.OrdinalIgnoreCase))), false);
                }
                else
                {
                    throw new ArgumentException(string.Format(Properties.Resources.MessageEnrichmentKeyExist, this.Key));
                }
            }
        }
    }
}