using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using AutoMapper;

    public enum DevicePathEnum
    {
       primary, 
       secondary
    }

    [Cmdlet(VerbsCommon.Get, "AzureRmExpressRouteCircuitARPTable"),OutputType(typeof(PSExpressRouteCircuitArpTable))]
    public class GetAzureExpressRouteCircuitARPTableCommand : NetworkBaseCmdlet
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
                var arpTables = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.ListArpTable(ResourceGroupName,ExpressRouteCircuitName,PeeringType,DevicePath);

                var psARPs = new List<PSExpressRouteCircuitArpTable>();

                foreach (var arpTable in arpTables)
                {
                    var psARP = Mapper.Map<PSExpressRouteCircuitArpTable>(arpTable);
                    psARPs.Add(psARP);
                }

                WriteObject(psARPs, true);
            }
        }
    }

}
