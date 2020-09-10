﻿// ----------------------------------------------------------------------------------
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
    public class NetworkWatcherAPITests : NetworkTestRunner
    {
        public NetworkWatcherAPITests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestGetTopology()
        {
            TestRunner.RunTestScript("Test-GetTopology");
        }

        [Fact(Skip = "Skipped due to backend issues")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestGetSecurityGroupView()
        {
            TestRunner.RunTestScript("Test-GetSecurityGroupView");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestGetNextHop()
        {
            TestRunner.RunTestScript("Test-GetNextHop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestVerifyIPFlow()
        {
            TestRunner.RunTestScript("Test-VerifyIPFlow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestPacketCapture()
        {
            TestRunner.RunTestScript("Test-PacketCapture");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestTroubleshoot()
        {
            TestRunner.RunTestScript("Test-Troubleshoot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestFlowLog()
        {
            TestRunner.RunTestScript("Test-FlowLog");
        }

        [Fact(Skip = "This test only applies to desktop")]
        [Trait(Category.RunType, Category.DesktopOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestConnectivityCheck()
        {
            TestRunner.RunTestScript("Test-ConnectivityCheck");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestReachabilityReport()
        {
            TestRunner.RunTestScript("Test-ReachabilityReport");
        }

        [Fact(Skip = "API is no longer available to customers")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestProvidersList()
        {
            TestRunner.RunTestScript("Test-ProvidersList");
        }

        [Fact(Skip = "Need to rewrite test after introduction of ConnectionMonitor V2")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestConnectionMonitor()
        {
            TestRunner.RunTestScript("Test-ConnectionMonitor");
        }

        [Fact(Skip = "Server returns empty array")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestNetworkConfigurationDiagnostic()
        {
            TestRunner.RunTestScript("Test-NetworkConfigurationDiagnostic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        [Trait(Category.Owner, NrpTeamAlias.netanalyticsdev)]
        public void TestCRUDFlowLog()
        {
            TestRunner.RunTestScript("Test-CRUDFlowLog");
        }
    }
}
