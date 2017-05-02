﻿// ----------------------------------------------------------------------------------
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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsData.Update, ContainerRegistryNoun,
        DefaultParameterSetName = "Empty",
        SupportsShouldProcess = true),
        OutputType(typeof(PSContainerRegistry))]
    public class UpdateAzureContainerRegistry : ContainerRegistryCmdletBase
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
            Mandatory = true,
            ParameterSetName = EnableAdminUserParameterSet,
            HelpMessage = "Enable admin user for the container registry.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DisableAdminUserParameterSet,
            HelpMessage = "Disable admin user for the container registry.")]
        [ValidateNotNull]
        [Alias(EnableAdminAlias)]
        public SwitchParameter EnableAdminUser { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = EnableAdminUserParameterSet,
            HelpMessage = "Enable admin user for the container registry.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DisableAdminUserParameterSet,
            HelpMessage = "Disable admin user for the container registry.")]
        [ValidateNotNull]
        [Alias(DisableAdminAlias)]
        public SwitchParameter DisableAdminUser { get; set; }

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
            if (ShouldProcess(Name, "Update Container Registry"))
            {
                var tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);

                bool? adminUserEnabled = null;

                if (EnableAdminUser || DisableAdminUser)
                {
                    adminUserEnabled = EnableAdminUser || !DisableAdminUser;
                }

                string storageAccountResourceGroup = null;

                if (StorageAccountName != null)
                {
                    storageAccountResourceGroup = ResourceManagerClient.GetStorageAccountResourceGroup(StorageAccountName);
                }

                var registry = RegistryClient.UpdateRegistry(
                    ResourceGroupName, Name, adminUserEnabled, StorageAccountName, storageAccountResourceGroup, tags);
                WriteObject(new PSContainerRegistry(registry));
            }
        }
    }
}
