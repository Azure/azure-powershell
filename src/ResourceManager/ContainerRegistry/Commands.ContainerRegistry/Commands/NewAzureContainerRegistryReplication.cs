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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.New, ContainerRegistryReplicationNoun, DefaultParameterSetName = NameResourceGroupParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSContainerRegistryReplication))]
    public class NewAzureContainerRegistryReplication : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias)]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegistryObjectParameterSet, HelpMessage = "Container Registry Object.")]
        [ValidateNotNull]
        public PSContainerRegistry Registry { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Container Registry Location. Default to the location of the resource group.")]
        [ValidateNotNullOrEmpty]
        [Alias(ReplicationLocationAlias)]
        [LocationCompleter("Microsoft.ContainerRegistry/registries/replications")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Registry Replication Name. Default to the location name.")]
        [ValidateNotNullOrEmpty]
        [Alias(ReplicationNameAlias, ResourceNameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Registry Tags.")]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, RegistryObjectParameterSet))
            {
                ResourceGroupName = Registry.ResourceGroupName;
                RegistryName = Registry.Name;
            }
            else if (MyInvocation.BoundParameters.ContainsKey("ResourceId") || !string.IsNullOrWhiteSpace(ResourceId))
            {
                string resourceGroup, registryName, childResourceName;
                if (!ConversionUtilities.TryParseRegistryRelatedResourceId(ResourceId, out resourceGroup, out registryName, out childResourceName))
                {
                    WriteInvalidResourceIdError(InvalidRegistryResourceIdErrorMessage);
                    return;
                }

                ResourceGroupName = resourceGroup;
                RegistryName = registryName;
            }

            var tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            if (string.IsNullOrEmpty(Name))
            {
                Name = Location.Replace(" ", string.Empty).ToLower();
            }

            if (ShouldProcess(Name, "Create a replication for the container registry"))
            {
                var replication = RegistryClient.CreateReplication(ResourceGroupName, RegistryName, Name, Location, tags);
                WriteObject(new PSContainerRegistryReplication(replication));
            }
        }
    }
}
