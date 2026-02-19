using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.ExpressRouteCircuit
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitLinkFailoverTest", SupportsShouldProcess = true, DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteLinkFailoverAllTestsDetails>))]
    public class ExpressRouteCircuitStartLinkFailoverSimulation : NetworkBaseCmdlet
    {
        private const string ByName = "ByName";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the ExpressRoute circuit.",
            ParameterSetName = ByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the ExpressRoute circuit.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteCircuitName { get; set; }

        [Parameter(
            Mandatory = true, 
            HelpMessage = "Link type: Primary or Secondary.",
            ParameterSetName = ByName)]
        [ValidateSet("Primary", "Secondary", IgnoreCase = true)]
        public string LinkType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Circuit Test Category: BgpDisconnect or ASPathPrepend.",
            ParameterSetName = ByName)]
        [ValidateSet("BgpDisconnect", "ASPathPrepend", IgnoreCase = true)]
        public string CircuitMaintenanceCategory { get; set; }

        // ************ To Do: Change to correctly call the API to start link failover simulation and return the result ************
        public override void Execute()
        {
            base.Execute();

            //var response = NetworkClient.NetworkManagementClient.ExpressRouteCircuits
            //    .StartExpressRouteCircuitLinkFailoverSimulationWithHttpMessagesAsync(
            //        ResourceGroupName,
            //        ExpressRouteCircuitName,
            //        LinkType,
            //        CircuitMaintenanceCategory
            //    ).GetAwaiter().GetResult();

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .StartExpressRouteSiteFailoverSimulationWithHttpMessagesAsync(
                    ResourceGroupName,
                    ExpressRouteCircuitName,
                    LinkType
                ).GetAwaiter().GetResult();

            WriteObject(response.Body);
        }
    }
}