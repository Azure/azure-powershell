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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.Tags.Model;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    using System;
    using System.Linq;

    using AutoMapper;

    [Cmdlet(VerbsCommon.Get, "AzureExpressRouteCircuitRouteTable"), OutputType(typeof(PSExpressRouteCircuitRoutesTable))]
    public class GetAzureExpressRouteCircuitRouteTableCommand : NetworkBaseCmdlet
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
                var routeTables = this.NetworkClient.NetworkManagementClient.ExpressRouteCircuits.ListRoutesTable(ResourceGroupName, ExpressRouteCircuitName, PeeringType, DevicePath).Value.Cast<object>().ToList();
                var psroutes = new List<PSExpressRouteCircuitRoutesTable>();

                foreach (var routeTable in routeTables)
                {
                    var psroute = Mapper.Map<PSExpressRouteCircuitRoutesTable>(routeTable);
                    psroutes.Add(psroute);
                }

                WriteObject(psroutes, true);
            }
        }
    }
}



