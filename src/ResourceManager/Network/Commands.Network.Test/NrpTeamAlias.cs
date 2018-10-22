using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public const string brooklynft = "brooklynft";
        public const string brooklynft_subset1 = "brooklynft_subset1";
        public const string brooklynft_subset2 = "brooklynft_subset2";
        public const string brooklynft_subset3 = "brooklynft_subset3";

        // Azure Network Analytics Dev Team
        public const string netanalyticsdev = "netanalyticsdev";

        // Windows Azure NRP dev team
        public const string wanrpdev = "wanrpdev";

        //Azure NRP Firewall dev team
        public const string azurefirewall = "azurefirewall";
    }
}
