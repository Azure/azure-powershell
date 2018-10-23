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

        // Virtual Appliance dev team
        public const string nvadev = "nvadev";

        // SDN NRP Dev Team
        public const string sdnnrp = "sdnnrp";

        // Pankaj's Team
        public const string pgtm = "pgtm";

        // Windows Azure SLB Dev Team
        public const string slbdev = "slbdev";

        // Brooklyn FTEs
        // Split into subsets due to tests' long running time
        // Cortex and LocalNetworkGateway tests
        public const string brooklynft = "brooklynft";
        // VirtualNetworkGatewayConnection tests
        public const string brooklynft_subset1 = "brooklynft_subset1";
        // First half of VirtualNetworkGateway tests
        public const string brooklynft_subset2 = "brooklynft_subset2";
        // Second half of VirtualNetworkGateway tests
        public const string brooklynft_subset3 = "brooklynft_subset3";

        // Azure Network Analytics Dev Team
        public const string netanalyticsdev = "netanalyticsdev";

        // Windows Azure NRP dev team
        public const string wanrpdev = "wanrpdev";

        //Azure NRP Firewall dev team
        public const string azurefirewall = "azurefirewall";
    }
}
