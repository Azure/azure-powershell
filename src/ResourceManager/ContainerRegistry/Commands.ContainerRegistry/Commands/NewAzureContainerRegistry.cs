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
using Microsoft.Azure.Management.ContainerRegistry.Models;
using Microsoft.Azure.Management.Internal.Resources.Models;
using System;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.New, ContainerRegistryNoun, SupportsShouldProcess = true)]
    [OutputType(typeof(PSContainerRegistry))]
    public class NewAzureContainerRegistry : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "Container Registry SKU.")]
        [Alias(ContainerRegistrySkuAlias, RegistrySkuAlias)]
        [ValidateSet(SkuTier.Classic, SkuTier.Basic, SkuTier.Premium, SkuTier.Standard, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Registry Location. Default to the location of the resource group.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.ContainerRegistry/registries")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable admin user for the container registry.")]
        [ValidateNotNull]
        [Alias(EnableAdminAlias)]
        public SwitchParameter EnableAdminUser { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Registry Tags.")]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of an existing storage account. This only applies to Classic sku.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(Name, "Create Container Registry"))
            {
                var registryNameStatus = RegistryClient.CheckRegistryNameAvailability(Name);

                if (registryNameStatus?.NameAvailable != null && !registryNameStatus.NameAvailable.Value)
                {
                    throw new InvalidOperationException(registryNameStatus.Message);
                }

                var tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

                if (Location == null)
                {
                    Location = ResourceManagerClient.GetResourceGroupLocation(ResourceGroupName);
                }

                if (string.Equals(Sku, SkuName.Classic) && StorageAccountName == null)
                {
                    DeploymentExtended result = ResourceManagerClient.CreateClassicRegistry(
                        ResourceGroupName, Name, Location, EnableAdminUser, tags);

                    if (result.Properties.ProvisioningState == "Succeeded")
                    {
                        var registry = RegistryClient.GetRegistry(ResourceGroupName, Name);
                        WriteObject(new PSContainerRegistry(registry));
                    }
                }
                else
                {
                    var registry = new Registry
                    {
                        Sku = new Microsoft.Azure.Management.ContainerRegistry.Models.Sku(Sku),
                        AdminUserEnabled = EnableAdminUser,
                        Tags = tags,
                        Location = Location
                    };

                    if (StorageAccountName != null)
                    {
                        var storageAccountId = ResourceManagerClient.GetStorageAccountId(StorageAccountName);
                        registry.StorageAccount = new StorageAccountProperties(storageAccountId);
                    }

                    var createdRegistry = RegistryClient.CreateRegistry(ResourceGroupName, Name, registry);
                    WriteObject(new PSContainerRegistry(createdRegistry));
                }
            }
        }
    }
}
