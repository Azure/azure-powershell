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

using System.Management.Automation;
using Microsoft.Azure.Management.ContainerRegistry.Models;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsData.Update, ContainerRegistryCredentialNoun,
        DefaultParameterSetName = NameResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(PSContainerRegistryCredential))]
    public class UpdateAzureContainerRegistryCredential : ContainerRegistryCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = NameResourceGroupParameterSet,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = NameResourceGroupParameterSet,
            HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = RegistryObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Container Registry Object.")]
        [ValidateNotNullOrEmpty]
        public PSContainerRegistry Registry { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of password to regenerate. " + AllowedPasswordNames)]
        [ValidateNotNullOrEmpty]
        public PasswordName PasswordName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, RegistryObjectParameterSet))
            {
                ResourceGroupName = Registry.ResourceGroupName;
                Name = Registry.Name;
            }

            if (ShouldProcess(Name, string.Format("Update Container Registry Credential '{0}'", PasswordName)))
            {
                var credentials = RegistryClient.RegenerateRegistryCredential(ResourceGroupName, Name, PasswordName);
                WriteObject(new PSContainerRegistryCredential(credentials));
            }
        }
    }
}
