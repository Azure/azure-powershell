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

using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class EcmpRouteTableTests : NetworkTestRunner
    {
        public EcmpRouteTableTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableCreateBasic()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableCreateBasic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableCreateMax16()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableCreateMax16");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableCreate3Ips()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableCreate3Ips");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableAddRemoveRoute()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableAddRemoveRoute");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableUpdateRoute()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableUpdateRoute");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableDeleteTable()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableDeleteTable");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableGetVerifyFields()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableGetVerifyFields");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableMixed()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableMixed");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableConvertTypes()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableConvertTypes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableDenseIpRange()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableDenseIpRange");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableDefaultAndNarrowPrefix()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableDefaultAndNarrowPrefix");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableBgpOverride()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableBgpOverride");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableConvertAllToStandard()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableConvertAllToStandard");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableIdempotentPut()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableIdempotentPut");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableIpv6()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableIpv6");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectBelow2Ips()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectBelow2Ips");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectAbove64Ips()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectAbove64Ips");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectDuplicateIps()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectDuplicateIps");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectForbiddenIps()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectForbiddenIps");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectMutualExclusivity()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectMutualExclusivity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectNextHopOnNonVaTypes()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectNextHopOnNonVaTypes");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectAddressFamilyMismatch()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectAddressFamilyMismatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableSubnetAssociation()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableSubnetAssociation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectOlderApiVersion()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectOlderApiVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void EcmpRouteTableRejectUnauthorizedSubscription()
        {
            TestRunner.RunTestScript("Test-EcmpRouteTableRejectUnauthorizedSubscription");
        }
    }
}
