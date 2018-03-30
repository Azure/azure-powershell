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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.Get, ContainerRegistryNoun, DefaultParameterSetName = ListRegistriesParameterSet)]
    [OutputType(typeof(PSContainerRegistry), typeof(IList<PSContainerRegistry>))]
    public class GetAzureContainerRegistry : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = ListRegistriesParameterSet, HelpMessage = "Resource Group Name.")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RegistryNameParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RegistryNameParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Show more details about the container registry.")]
        public SwitchParameter IncludeDetail { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, ListRegistriesParameterSet))
            {
                ListRegistry();
            }
            else
            {
                if (MyInvocation.BoundParameters.ContainsKey("ResourceId") || !string.IsNullOrWhiteSpace(ResourceId))
                {
                    string resourceGroup, registryName, childResourceName;
                    if (!ConversionUtilities.TryParseRegistryRelatedResourceId(ResourceId, out resourceGroup, out registryName, out childResourceName))
                    {
                        WriteInvalidResourceIdError(InvalidRegistryResourceIdErrorMessage);
                        return;
                    }

                    ResourceGroupName = resourceGroup;
                    Name = registryName;
                }
                ShowRegistry();
            }
        }

        private void ShowRegistry()
        {
            var registry = RegistryClient.GetRegistry(ResourceGroupName, Name);
            var psRegistry = new PSContainerRegistry(registry);

            if (IncludeDetail)
            {
                SetRegistryDetials(psRegistry);
            }
            WriteObject(psRegistry);
        }

        private void ListRegistry()
        {
            var psRegistries = RegistryClient.ListAllRegistries(ResourceGroupName);

            if (IncludeDetail)
            {
                foreach (var psr in psRegistries)
                {
                    SetRegistryDetials(psr);
                }
            }
            WriteObject(psRegistries, true);
        }

        private void SetRegistryDetials(PSContainerRegistry registry)
        {
            if (!string.IsNullOrEmpty(registry.ResourceGroupName) && !string.IsNullOrEmpty(registry.Name))
            {
                registry.Usages = RegistryClient.ListRegistryUsage(registry.ResourceGroupName, registry.Name)?.Value;
            }
        }
    }
}
