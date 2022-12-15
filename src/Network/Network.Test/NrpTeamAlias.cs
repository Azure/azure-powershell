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

namespace Commands.Network.Test
{
    class NrpTeamAlias
    {
        // Below is the list of aliases to contact on test behavior

        // Azure PowerShell Team
        public const string azdevxps = "azdevxps";

        // Virtual Appliance dev team
        // First part of ApplicationGateway tests
        public const string nvadev = "nvadev";

        // Second part of ApplicationGateway tests
        public const string nvadev_subset1 = "nvadev_subset1";

        //Azure Firewall dev team
        public const string azurefirewall = "azurefirewall";

        // Azure Network Billing and Telemetry team
        public const string billingandtelemetry = "azurenetworkbilling";

        // Azure Bastion dev team
        public const string bastion = "bastion";

        // Brooklyn FTEs
        // Split into subsets due to tests' long running time
        // Cortex and LocalNetworkGateway tests
        public const string brooklynft = "brooklynft";
        // First part of VirtualNetworkGatewayConnection tests
        public const string brooklynft_subset1 = "brooklynft_subset1";
        // First half of VirtualNetworkGateway tests
        public const string brooklynft_subset2 = "brooklynft_subset2";
        // Second half of VirtualNetworkGateway tests
        public const string brooklynft_subset3 = "brooklynft_subset3";
        // Second part of VirtualNetworkGatewayConnection tests
        public const string brooklynft_subset4 = "brooklynft_subset4";
        // Third part of VirtualNetworkGatewayConnection tests
        public const string brooklynft_subset5 = "brooklynft_subset5";

        // Ddos team
        public const string ddos = "ddosdev";

        // Express Route Team
        public const string exrdev = "exrdev";

        // Azure Network IPAM dev team
        public const string ipam = "ipamdev";

        // Azure Network Analytics Dev Team
        public const string netanalyticsdev = "netanalyticsdev";

        // Azure NSM Dev Team
        public const string nsmdev = "nsmdev";

        // Azure Private Endpoint and Private Link Dev Team
        public const string plcpdev = "plcpdev";

        // RNM Dev Team
        public const string rnmdev = "rnmdev";

        // Windows Azure SLB Dev Team
        public const string slbdev = "slbdev";

        // Windows Azure NRP dev team
        public const string wanrpdev = "wanrpdev";

        // Virtual WAN team
        public const string virtualwan = "routeservicedev";
    }
}
