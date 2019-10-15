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
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Add,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHubRouteTable",
        DefaultParameterSetName = "SetByResource",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class AddAzureRmVirtualHubRouteTableCommand : VirtualHubRouteTableBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("VirtualHubName", "ParentVirtualHubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The parent resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        public string HubName { get; set; }

        [Alias("VirtualHub", "ParentVirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The parent resource.")]
        public PSVirtualHub VirtualHub { get; set; }


        [Alias("VirtualHubRouteTable")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
           HelpMessage = "The virtualhubroutetable resource.")]
        [Parameter(
           Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
           HelpMessage = "The virtualhubroutetable resource.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualHubRouteTable InputObject { get; set; }

        public override void ExecuteCmdlet()
        {
            // Resolve the parameters
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHub.Id);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.HubName = parsedResourceId.ResourceName;
            }

            base.Execute();

            var routeTable = new PSVirtualHubRouteTable
            {
                Name = this.InputObject.Name,
                Routes = this.InputObject.Routes == null ? new List<PSVirtualHubRoute>() : this.InputObject.Routes,
                AttachedConnections = this.InputObject.AttachedConnections == null ? new List<string>() : this.InputObject.AttachedConnections
            };

            this.VirtualHub.RouteTables.Add(routeTable);

            WriteObject(this.VirtualHub);
        }
    }
}
