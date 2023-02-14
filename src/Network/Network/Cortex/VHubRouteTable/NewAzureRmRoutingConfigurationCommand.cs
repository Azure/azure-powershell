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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RoutingConfiguration",
        SupportsShouldProcess = false),
        OutputType(typeof(PSRoutingConfiguration))]
    public class NewAzureRmRoutingConfigurationCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The hub route table associated with this routing configuration.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs/hubRouteTables")]
        public string AssociatedRouteTable { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of labels for the PropagatedRouteTables property.")]
        public string[] Label { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The list of resource ids of all the hub route tables to advertise the routes to for the PropagatedRouteTables property.")]
        public string[] Id { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of routes that control routing from VirtualHub into a virtual network connection.")]
        public PSStaticRoute[] StaticRoute { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Should we bypass NVA for destinations in spoke vnet? 'Contains' for no, 'Equal' for yes. Default is 'Contains'.")]
        public string VnetLocalRouteOverrideCriteria { get; set; }

        public override void Execute()
        {
            base.Execute();

            // Resolve the provided Associated RouteTable
            var associatedRouteTable = ResolveRouteTableId(AssociatedRouteTable);
            if (associatedRouteTable == null)
            {
                throw new PSArgumentException(Properties.Resources.VHubRouteTableNotFound);
            }

            // Resolve the Propagated RouteTable property
            var propagatedRouteTable = new PSPropagatedRouteTable
            {
                Labels = Label?.ToList()
            };

            var resolvedIds = new List<PSResourceId>() { };
            foreach (var id in Id)
            {
                var resolvedRouteTable = ResolveRouteTableId(id);
                if (resolvedRouteTable == null)
                {
                    throw new PSArgumentException(Properties.Resources.VHubRouteTableNotFound);
                }

                resolvedIds.Add(
                    new PSResourceId()
                    { 
                        Id = resolvedRouteTable.Id 
                    });
            }

            propagatedRouteTable.Ids = resolvedIds;

            if (!string.IsNullOrEmpty(VnetLocalRouteOverrideCriteria) && VnetLocalRouteOverrideCriteria != "Equal"
                && VnetLocalRouteOverrideCriteria != "Contains")
            {
                throw new PSArgumentException(Properties.Resources.InvalidVnetLocalRouteOverrideCriteriaValue);
            }

            var staticRoutesConfig = new PSStaticRoutesConfig
            {
                VnetLocalRouteOverrideCriteria = string.IsNullOrEmpty(VnetLocalRouteOverrideCriteria) ? "Contains" : VnetLocalRouteOverrideCriteria
            };

            var routingConfig = new PSRoutingConfiguration
            {
                PropagatedRouteTables = propagatedRouteTable,
                AssociatedRouteTable = new PSResourceId() { Id = associatedRouteTable.Id },
                VnetRoutes = new PSVnetRoute
                {
                    StaticRoutes = StaticRoute?.ToList(),
                    StaticRoutesConfig = staticRoutesConfig
                }
            };

            WriteObject(routingConfig);
        }

        private PSVHubRouteTable ResolveRouteTableId(string routeTableId)
        {
            var parsedRouteTableId = new ResourceIdentifier(routeTableId);
            if (!string.Equals(parsedRouteTableId.ResourceType, "Microsoft.Network/virtualHubs/hubRouteTables", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new PSArgumentException(Properties.Resources.VHubRouteTableReferenceNotFound);
            }

            var parsedHubName = parsedRouteTableId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            var resolvedRouteTable = new VHubRouteTableBaseCmdlet()
                .GetVHubRouteTable(parsedRouteTableId.ResourceGroupName, parsedHubName, parsedRouteTableId.ResourceName);
            return resolvedRouteTable;
        }
    }
}
