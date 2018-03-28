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
using Microsoft.Azure.Management.ContainerRegistry.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsData.Update, ContainerRegistryCredentialNoun, DefaultParameterSetName = NameResourceGroupParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSContainerRegistryCredential))]
    public class UpdateAzureContainerRegistryCredential : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = RegistryObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [ValidateNotNull]
        public PSContainerRegistry Registry { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of password to regenerate.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(PasswordNameStrings.Password, PasswordNameStrings.Password2)]
        public PasswordName PasswordName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, RegistryObjectParameterSet))
            {
                ResourceGroupName = Registry.ResourceGroupName;
                Name = Registry.Name;
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
                Name = registryName;
            }

            if (ShouldProcess(Name, string.Format("Update Container Registry Credential '{0}'", PasswordName)))
            {
                var credentials = RegistryClient.RegenerateRegistryCredential(ResourceGroupName, Name, PasswordName);
                WriteObject(new PSContainerRegistryCredential(credentials));
            }
        }
    }
}
