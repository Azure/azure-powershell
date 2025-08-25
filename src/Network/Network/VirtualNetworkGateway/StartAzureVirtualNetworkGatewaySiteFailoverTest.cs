// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsLifecycle.Start, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewaySiteFailoverTest", DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteFailoverTestDetails>))]
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
            HelpMessage = "List of peering locations to run the test for.",
            ParameterSetName = ByName)]
        public List<string> PeeringLocations { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Test type: SingleSiteFailover or MultiSiteFailover.",
            ParameterSetName = ByName)]
        [ValidateSet("SingleSiteFailover", "MultiSiteFailover", IgnoreCase = true)]
        public string Type { get; set; }

        public override void Execute()
        {
            base.Execute();

            var request = new StartSiteFailoverRequest
            {
                PeeringLocations = PeeringLocations,
                Type = Type
            };

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways.StartSiteFailoverTest(
                ResourceGroupName,
                VirtualNetworkGatewayName,
                request
            );

            var psResult = NetworkResourceManagerProfile.Mapper.Map<List<PSExpressRouteFailoverTestDetails>>(response);
            WriteObject(psResult, enumerateCollection: true);
        }
    }
}
