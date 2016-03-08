using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System;

    using AutoMapper;

    [Cmdlet(VerbsCommon.Get, "AzureRmExpressRouteCircuitStats"), OutputType(typeof(PSExpressRouteCircuitStats))]
    public class GetAzureExpressRouteCircuitStatsCommand : NetworkBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Name of ExpressRoute Circuit")]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteCircuitName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The PeeringType")]
        [ValidateSet(
           MNM.ExpressRouteCircuitPeeringType.AzurePrivatePeering,
           MNM.ExpressRouteCircuitPeeringType.AzurePublicPeering,
           MNM.ExpressRouteCircuitPeeringType.MicrosoftPeering,
           IgnoreCase = true)]
        public string PeeringType { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(PeeringType))
            {
                var stats = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.ListStats(
                    ResourceGroupName,
                    ExpressRouteCircuitName);
                var psStats = Mapper.Map<PSExpressRouteCircuitStats>(stats);
                WriteObject(psStats, true);
            }
            else
            {
                var stats = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.ListPeeringStats(
                    ResourceGroupName,
                    ExpressRouteCircuitName,
                    PeeringType);
                var psStats = Mapper.Map<PSExpressRouteCircuitStats>(stats);
                WriteObject(psStats, true);
            }
        }
    }
}


