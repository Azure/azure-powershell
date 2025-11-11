using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewaySiteFailoverTest", SupportsShouldProcess = true, DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteFailoverTestDetails>))]
    public class StartAzureVirtualNetworkGatewaySiteFailoverTest : NetworkBaseCmdlet
    {
        private const string ByName = "ByName";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name of the virtual network gateway.",
            ParameterSetName = ByName)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the virtual network gateway.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkGatewayName { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Peering location to run the test for.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string PeeringLocation { get; set; }  // Change to a single string

        [Parameter(
            Mandatory = false,  // Make it optional
            HelpMessage = "Test type: SingleSiteFailover or MultiSiteFailover.",
            ParameterSetName = ByName)]
        [ValidateSet("SingleSiteFailover", "MultiSiteFailover", IgnoreCase = true)]
        public string Type { get; set; }  // Make Type optional

        public override void Execute()
        {
            base.Execute();

            // Since PeeringLocation is now a string, no need to loop
            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways
                .StartExpressRouteSiteFailoverSimulationWithHttpMessagesAsync(
                    ResourceGroupName,
                    VirtualNetworkGatewayName,
                    PeeringLocation
                ).GetAwaiter().GetResult();

            WriteObject(response.Body);
        }
    }
}
