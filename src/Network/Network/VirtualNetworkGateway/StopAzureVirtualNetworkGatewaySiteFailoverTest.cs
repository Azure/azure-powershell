// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0
//
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network.VirtualNetworkGateway
{
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewaySiteFailoverTest", DefaultParameterSetName = "ByName"), OutputType(typeof(PSExpressRouteFailoverTestDetails))]
    public class StopAzureVirtualNetworkGatewaySiteFailoverTest : NetworkBaseCmdlet
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
            HelpMessage = "The GUID that identifies the failover test to stop.",
            ParameterSetName = ByName)]
        [ValidateNotNullOrEmpty]
        public string TestGuid { get; set; }

        public override void Execute()
        {
            base.Execute();

            var response = NetworkClient.NetworkManagementClient.VirtualNetworkGateways.StopSiteFailoverTest(
                ResourceGroupName,
                VirtualNetworkGatewayName,
                TestGuid
            );

            var psResult = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteFailoverTestDetails>(response);
            WriteObject(psResult);
        }
    }
}
