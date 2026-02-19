using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.ExpressRouteCircuit
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteCircuitLinkFailoverTest", SupportsShouldProcess = true, DefaultParameterSetName = "ByName"), OutputType(typeof(PSExpressRouteLinkFailoverAllTestsDetails))]
    public class ExpressRouteCircuitStopLinkFailoverSimulation : NetworkBaseCmdlet
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
            HelpMessage = "Circuit Test Category: BgpDisconnect or ASPathPrepend.",
            ParameterSetName = ByName)]
        [ValidateSet("BgpDisconnect", "ASPathPrepend", IgnoreCase = true)]
        public string CircuitTestCategory { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Link type: Primary or Secondary.",
            ParameterSetName = ByName)]
        [ValidateSet("Primary", "Secondary", IgnoreCase = true)]
        public string LinkType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Whether the simulation was successful.",
            ParameterSetName = ByName)]
        public bool WasSimulationSuccessful { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Whether the simulation is verified.",
            ParameterSetName = ByName)]
        public bool IsVerified { get; set; }

        // To Do: change API once swagger checked in
        public override void Execute()
        {
            base.Execute();

            //var parameters = new ExpressRouteLinkFailoverStopApiParameters
            //{
            //    CircuitTestCategory = this.CircuitTestCategory,
            //    LinkType = this.LinkType,
            //    WasSimulationSuccessful = this.WasSimulationSuccessful,
            //    IsVerified = this.IsVerified
            //};

            //// To Do: Change to correctly call the API to stop link failover simulation and return the result
            //var response = NetworkClient.NetworkManagementClient.ExpressRouteCircuits
            //    .StopExpressRouteCircuitLinkFailoverSimulationWithHttpMessagesAsync(
            //        ResourceGroupName,
            //        ExpressRouteCircuitName,
            //        parameters
            //    ).GetAwaiter().GetResult();

            var parameters = new ExpressRouteFailoverStopApiParameters
            {
                PeeringLocation = this.ResourceGroupName,
                WasSimulationSuccessful = this.WasSimulationSuccessful,
                Details = new List<FailoverConnectionDetails> ()
            };

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .StopExpressRouteSiteFailoverSimulationWithHttpMessagesAsync(
                    ResourceGroupName,
                    ExpressRouteCircuitName,
                    parameters
                ).GetAwaiter().GetResult();

            WriteObject(response.Body);
        }
    }
}