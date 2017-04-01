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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.Get, ContainerRegistryNoun), OutputType(typeof(PSContainerRegistry))]
    public class GetAzureContainerRegistry : ContainerRegistryCmdletBase
    {
        internal const string ResourceGroupParameterSet = "ResourceGroupParameterSet";
        internal const string RegistryNameParameterSet = "RegistryNameParameterSet";

        [Parameter(
            Position = 0,
            Mandatory = false,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = RegistryNameParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = RegistryNameParameterSet,
            HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(ResourceGroupName) && !string.IsNullOrEmpty(Name))
            {
                var registry = RegistryClient.GetRegistry(ResourceGroupName, Name);
                WriteObject(new PSContainerRegistry(registry));
            }
            else
            {
                List<PSContainerRegistry> list = new List<PSContainerRegistry>();

                var registries = RegistryClient.ListRegistries(ResourceGroupName);
                foreach (Registry registry in registries)
                {
                    list.Add(new PSContainerRegistry(registry));
                }

                while (!string.IsNullOrEmpty(registries.NextPageLink))
                {
                    registries = RegistryClient.ListRegistriesUsingNextLink(ResourceGroupName, registries.NextPageLink);
                    foreach (Registry registry in registries)
                    {
                        list.Add(new PSContainerRegistry(registry));
                    }
                }

                WriteObject(list, true);
            }
        }
    }
}
