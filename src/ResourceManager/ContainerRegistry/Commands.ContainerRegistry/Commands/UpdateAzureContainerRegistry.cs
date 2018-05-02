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
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsData.Update, ContainerRegistryNoun, DefaultParameterSetName = NameResourceGroupParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSContainerRegistry))]
    public class UpdateAzureContainerRegistry : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = EnableAdminUserByResourceNameParameterSet, HelpMessage = "Resource Group Name.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = DisableAdminUserByResourceNameParameterSet, HelpMessage = "Resource Group Name.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = EnableAdminUserByResourceNameParameterSet, HelpMessage = "Container Registry Name.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = DisableAdminUserByResourceNameParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias, RegistryNameAlias, ResourceNameAlias)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = EnableAdminUserByResourceNameParameterSet, HelpMessage = "Enable admin user for the container registry.")]
        [Parameter(Mandatory = true, ParameterSetName = EnableAdminUserByResourceIdParameterSet, HelpMessage = "Enable admin user for the container registry.")]
        [ValidateNotNull]
        [Alias(EnableAdminAlias)]
        public SwitchParameter EnableAdminUser { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = DisableAdminUserByResourceNameParameterSet, HelpMessage = "Disable admin user for the container registry.")]
        [Parameter(Mandatory = true, ParameterSetName = DisableAdminUserByResourceIdParameterSet, HelpMessage = "Disable admin user for the container registry.")]
        [ValidateNotNull]
        [Alias(DisableAdminAlias)]
        public SwitchParameter DisableAdminUser { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Registry Tags.")]
        [ValidateNotNull]
        [Alias(TagsAlias)]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of an existing storage account.")]
        [ValidateNotNullOrEmpty]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Container Registry SKU.")]
        [Alias(ContainerRegistrySkuAlias, RegistrySkuAlias)]
        [ValidateSet(SkuTier.Classic, SkuTier.Basic, SkuTier.Premium, SkuTier.Standard, IgnoreCase = false)]
        public string Sku { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry resource id")]
        [Parameter(Mandatory = true, ParameterSetName = DisableAdminUserByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry resource id")]
        [Parameter(Mandatory = true, ParameterSetName = EnableAdminUserByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            var tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

            bool? adminUserEnabled = null;

            if (EnableAdminUser || DisableAdminUser)
            {
                adminUserEnabled = EnableAdminUser || !DisableAdminUser;
            }

            string storageAccountId = null;

            if (StorageAccountName != null)
            {
                storageAccountId = ResourceManagerClient.GetStorageAccountId(StorageAccountName);
            }

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

            if (ShouldProcess(Name, "Update Container Registry"))
            {
                var registry = RegistryClient.UpdateRegistry(ResourceGroupName, Name, adminUserEnabled, Sku, storageAccountId, tags);
                WriteObject(new PSContainerRegistry(registry));
            }
        }
    }
}
