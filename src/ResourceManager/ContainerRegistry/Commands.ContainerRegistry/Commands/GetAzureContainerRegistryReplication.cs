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
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.Get, ContainerRegistryReplicationNoun, DefaultParameterSetName = ListReplicationByNameResourceGroupParameterSet)]
    [OutputType(typeof(PSContainerRegistryReplication), typeof(IList<PSContainerRegistryReplication>))]
    public class GetAzureContainerRegistryReplication : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ShowReplicationByNameResourceGroupParameterSet, HelpMessage = "Container Registry Replication Name.")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ShowReplicationByRegistryObjectParameterSet, HelpMessage = "Container Registry Replication Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(ReplicationNameAlias, ResourceNameAlias)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ShowReplicationByNameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ListReplicationByNameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ShowReplicationByNameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = ListReplicationByNameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias)]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ShowReplicationByRegistryObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [Parameter(Mandatory = true, ParameterSetName = ListReplicationByRegistryObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [ValidateNotNull]
        public PSContainerRegistry Registry { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry replication resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if(string.Equals(ParameterSetName, ShowReplicationByRegistryObjectParameterSet) || 
                string.Equals(ParameterSetName, ListReplicationByRegistryObjectParameterSet))
            {
                ResourceGroupName = Registry.ResourceGroupName;
                RegistryName = Registry.Name;
            }

            switch (ParameterSetName)
            {
                case ShowReplicationByRegistryObjectParameterSet:
                case ShowReplicationByNameResourceGroupParameterSet:
                    ShowReplication();
                    break;
                case ListReplicationByNameResourceGroupParameterSet:
                case ListReplicationByRegistryObjectParameterSet:
                    ListReplication();
                    break;
                case ResourceIdParameterSet:
                    ShowReplicationByResourceId();
                    break;
            }
        }

        private void ShowReplicationByResourceId()
        {
            string resourceGroup, registryName, childResourceName;
            if(!ConversionUtilities.TryParseRegistryRelatedResourceId(ResourceId, out resourceGroup, out registryName, out childResourceName))
            {
                WriteInvalidResourceIdError(InvalidRegistryOrReplicationResourceIdErrorMessage);
                return;
            }

            ResourceGroupName = resourceGroup;
            Name = childResourceName;
            RegistryName = registryName;

            if(string.IsNullOrEmpty(Name))
            {
                ListReplication();
            }
            else
            {
                ShowReplication();
            }
        }

        private void ListReplication()
        {
            var replications = RegistryClient.ListAllReplications(ResourceGroupName, RegistryName);
            WriteObject(replications, true);
        }

        private void ShowReplication()
        {
            var replication = RegistryClient.GetReplication(ResourceGroupName, RegistryName, Name);
            WriteObject(new PSContainerRegistryReplication(replication));
        }
    }
}
