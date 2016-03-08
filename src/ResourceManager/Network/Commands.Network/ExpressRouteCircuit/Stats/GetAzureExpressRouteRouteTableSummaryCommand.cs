using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Collections;
    using System.Linq;

    using AutoMapper;

    [Cmdlet(VerbsCommon.Get, "AzureRmExpressRouteCircuitARPTable"), OutputType(typeof(PSExpressRouteCircuitRoutesTableSummary))]
    public class GetAzureExpressRouteRouteTableSummaryCommand : NetworkBaseCmdlet
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

        [Parameter(
            Mandatory = true,
            HelpMessage = "The DevicePath, can be either Primary or Secondary")]
        [ValidateNotNullOrEmpty]
        public string DevicePath { get; set; }
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            DevicePathEnum path;
            if (Enum.TryParse(DevicePath, true, out path))
            {
                var routeTables = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.BeginListRoutesTableSummary(ResourceGroupName, ExpressRouteCircuitName, PeeringType, DevicePath).Value.Cast<object>().ToList();
                var psRouteTables = new List<PSExpressRouteCircuitRoutesTableSummary>();
                foreach (var arpTable in routeTables)
                {
                    var psARP = Mapper.Map<PSExpressRouteCircuitRoutesTableSummary>(arpTable);
                    psRouteTables.Add(psARP);
                }
                WriteObject(psRouteTables, true);
            }
        }
    }
}
