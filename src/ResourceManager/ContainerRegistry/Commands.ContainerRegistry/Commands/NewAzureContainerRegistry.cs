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

using System;
using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using DeploymentState = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ProvisioningState;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.New, ContainerRegistryNoun), OutputType(typeof(PSContainerRegistry))]
    public class NewAzureContainerRegistry : ContainerRegistryCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Container Registry Location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Container Registry SKU. " + AllowedSkuNames)]
        [Alias(ContainerRegistrySkuAlias, RegistrySkuAlias)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(SkuTier.Basic, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Indicates whether the admin user is enabled.")]
        [ValidateNotNull]
        [Alias(AdminEnabledAlias)]
        public bool? AdminUserEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Container Registry Tags.")]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of an existing storage account.")]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            var registryNameStatus = RegistryClient.CheckRegistryNameAvailability(Name);

            if (registryNameStatus?.NameAvailable != null && !registryNameStatus.NameAvailable.Value)
            {
                throw new InvalidOperationException(registryNameStatus.Message);
            }

            var tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            DeploymentExtended result = ResourceManagerClient.CreateRegistry(
                ResourceGroupName, Name, Location, Sku, AdminUserEnabled, StorageAccountName, tags);

            if (result.Properties.ProvisioningState == DeploymentState.Succeeded.ToString())
            {
                var registry = RegistryClient.GetRegistry(ResourceGroupName, Name);
                WriteObject(new PSContainerRegistry(registry));
            }
        }
    }
}
