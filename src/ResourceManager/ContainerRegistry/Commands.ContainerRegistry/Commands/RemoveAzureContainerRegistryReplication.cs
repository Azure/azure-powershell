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

namespace Microsoft.Azure.Commands.ContainerRegistry
{
    [Cmdlet(VerbsCommon.Remove, ContainerRegistryReplicationNoun, DefaultParameterSetName = NameResourceGroupParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemoveAzureContainerRegistryReplication : ContainerRegistryCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Container Registry Replication Name. Default to the location name.")]
        [ValidateNotNullOrEmpty]
        [Alias(ReplicationNameAlias, ResourceNameAlias)]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = NameResourceGroupParameterSet, HelpMessage = "Container Registry Name.")]
        [Alias(ContainerRegistryNameAlias)]
        [ValidateNotNullOrEmpty]
        public string RegistryName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ReplicationObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Container Registry Object.")]
        [ValidateNotNull]
        public PSContainerRegistryReplication Replicatoin { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = ResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "The container registry replication resource id")]
        [ValidateNotNullOrEmpty]
        [Alias(ResourceIdAlias)]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, ReplicationObjectParameterSet))
            {
                ResourceId = Replicatoin.Id;
            }
            if (MyInvocation.BoundParameters.ContainsKey("ResourceId") || !string.IsNullOrWhiteSpace(ResourceId))
            {
                string resourceGroup, registryName, childResourceName;
                if (!ConversionUtilities.TryParseRegistryRelatedResourceId(ResourceId, out resourceGroup, out registryName, out childResourceName)
                    || string.IsNullOrEmpty(childResourceName))
                {
                    WriteInvalidResourceIdError(InvalidReplicationResourceIdErrorMessage);
                    return;
                }

                ResourceGroupName = resourceGroup;
                RegistryName = registryName;
                Name = childResourceName;
            }

            if (ShouldProcess(Name, "Delete the replication from the container registry. This will also delete all the webhooks in this replication."))
            {
                RegistryClient.DeleteReplication(ResourceGroupName, RegistryName, Name);
                if (PassThru)
                {
                    WriteObject(true);
                }
            }
        }
    }
}
