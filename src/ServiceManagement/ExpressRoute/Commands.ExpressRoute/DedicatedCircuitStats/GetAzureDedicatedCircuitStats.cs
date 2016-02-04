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


using System.ComponentModel;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.ExpressRoute
{
    [Cmdlet(VerbsCommon.Get, "AzureDedicatedCircuitStats"), OutputType(typeof(AzureDedicatedCircuitPeeringStats), typeof(IEnumerable<AzureDedicatedCircuitPeeringStats>))]
    public class GetAzureDedicatedCircuitPeeringStatsCommand : ExpressRouteBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Service Key representing the Dedicated Circuit")]
        public Guid ServiceKey { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Bgp Peering Access Type: Public or Private or Microsoft")]
        public string AccessType { get; set; }

        
        public override void ExecuteCmdlet()
        {
            if(string.IsNullOrEmpty(AccessType))
            {
                AzureDedicatedCircuitStats stats = new AzureDedicatedCircuitStats
                                                       {
                                                           PrimaryBytesIn = (ulong)0,
                                                           PrimaryBytesOut = (ulong)0,
                                                           SecondaryBytesIn = (ulong)0,
                                                           SecondaryBytesOut = (ulong)0
                                                       };
                stats = compute(stats, ServiceKey, BgpPeeringAccessType.Private);
                stats = compute(stats, ServiceKey, BgpPeeringAccessType.Public);
                stats = compute(stats, ServiceKey, BgpPeeringAccessType.Microsoft);

                WriteObject(stats);
                
            }
            BgpPeeringAccessType type; 
            if (BgpPeeringAccessType.TryParse(AccessType, true, out type))
            {
                var stats = ExpressRouteClient.GetAzureDedicatedCircuitStatsInfo(ServiceKey, type);
                WriteObject(stats);
            }      
        }

        private AzureDedicatedCircuitStats compute(AzureDedicatedCircuitStats stats, Guid key, BgpPeeringAccessType type)
        {
            try
            {
                AzureBgpPeering peering = ExpressRouteClient.GetAzureBGPPeering(ServiceKey, type);
                if (peering != null)
                {
                    var tempstats = ExpressRouteClient.GetAzureDedicatedCircuitStatsInfo(key, type);
                    stats.PrimaryBytesIn += tempstats.PrimaryBytesIn;
                    stats.PrimaryBytesOut += tempstats.PrimaryBytesOut;
                    stats.SecondaryBytesIn += tempstats.SecondaryBytesIn;
                    stats.SecondaryBytesOut += tempstats.SecondaryBytesOut;
                }
                return stats;
            }
            catch
            {
                // The cirucit might not have corresponding peering
                return stats;
            }
        }
    }
}
