// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Collections.Generic;
using CNM = Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayFailoverAllTestsDetails", DefaultParameterSetName = "ByName"), OutputType(typeof(List<PSExpressRouteFailoverTestDetails>))]
    public class GetAzureVirtualNetworkGatewayFailoverAllTestsDetails : NetworkBaseCmdlet
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
            HelpMessage = "The type of failover test. Example: SingleSiteFailover, MultiSiteFailover, All",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Fetch only the latest test for each peering location.",
            ParameterSetName = ByName)]
        public bool FetchLatest { get; set; }

        public override void Execute()
        {
            base.Execute();

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways.GetFailoverAllTestDetails(
                ResourceGroupName,
                VirtualNetworkGatewayName,
                Type,
                FetchLatest
            );

            var psResult = NetworkResourceManagerProfile.Mapper.Map<List<PSExpressRouteFailoverTestDetails>>(response);
            WriteObject(psResult, enumerateCollection: true);
        }
    }
}
