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

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubRouteTable",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
        SupportsShouldProcess = true),
        OutputType(typeof(Boolean))]
    public class RemoveVirtualHubRouteTableCommand : VirtualHubRouteTableBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName", "ParentResourceName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        public string HubName { get; set; }

        [Alias("ResourceName", "VirtualHubRouteTableName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableName,
            HelpMessage = "The resource name.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs/routeTables", "ResourceGroupName", "ParentResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ParentVirtualHub", "ParentObject")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject)]
        [ValidateNotNull]
        public PSVirtualHub VirtualHub { get; set; }

        [Alias("VirtualHubRouteTable")]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableObject,
            HelpMessage = "The virtual hub route table resource to remove.")]
        public PSVirtualHubRouteTable InputObject { get; set; }

        [Alias("VirtualHubRouteTableId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubRouteTableResourceId,
            HelpMessage = "The resource id of the virtual hub route table resource to remove.")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
            // Resolve the parameters
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHub.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.HubName = parsedResourceId.ResourceName;
            }
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubRouteTableObject, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.InputObject.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.HubName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubRouteTableResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.HubName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = parsedResourceId.ResourceName;
            }

            //// Get the virtual hub - this will throw not found if the resource is invalid
            PSVirtualHub parentVirtualHub = this.GetVirtualHub(this.ResourceGroupName, this.HubName);

            if (parentVirtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentVirtualHubNotFound);
            }

            var routeTableToRemove = parentVirtualHub.RouteTables.FirstOrDefault(routeTable => routeTable.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
            if (routeTableToRemove != null)
            {
                base.Execute();

                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Properties.Resources.RemovingResource, Name),
                    Properties.Resources.RemoveResourceMessage,
                    this.Name,
                    () =>
                    {
                        parentVirtualHub.RouteTables.Remove(routeTableToRemove);
                        this.CreateOrUpdateVirtualHub(this.ResourceGroupName, this.HubName, parentVirtualHub, parentVirtualHub.Tag);

                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
        }
    }
}
