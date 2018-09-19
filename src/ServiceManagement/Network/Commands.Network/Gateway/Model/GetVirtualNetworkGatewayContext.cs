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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network
{
    public class GetVirtualNetworkGatewayContext : ManagementOperationContext
    {
        public string GatewayId { get; set; }

        public string GatewayName { get; set; }

        public string LastEventData { get; set; }
        
        public string GatewayType { get; set; }

        public DateTime? LastEventTimeStamp { get; set; }

        public string LastEventMessage { get; set; }

        public int LastEventID { get; set; }

        public ProvisioningState State { get; set; }

        public string VIPAddress { get; set; }

        public string DefaultSite { get; set; }

        public string GatewaySKU { get; set; }

        public string Location { get; set; }

        public string VnetId { get; set; }

        public string SubnetId { get; set; }
        
        public string EnableBgp { get; set; }

        public uint Asn { get; set; }

        public string BgpPeeringAddress { get; set; }

        public int PeerWeight { get; set; }
    }
}