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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class NetworkWatcherAPITests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public NetworkWatcherAPITests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestGetTopology()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-GetTopology");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestGetSecurityGroupView()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-GetSecurityGroupView");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestGetNextHop()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-GetNextHop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestVerifyIPFlow()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-VerifyIPFlow");
        }

        [Fact(Skip = "There was a bug in API. After fix is deployed, we need to rerecord test.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestPacketCapture()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-PacketCapture");
        }

        [Fact(Skip = "Rerecord tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestTroubleshoot()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-Troubleshoot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestFlowLog()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-FlowLog");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestConnectivityCheck()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-ConnectivityCheck");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestReachabilityReport()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-ReachabilityReport");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestProvidersList()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-ProvidersList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestConnectionMonitor()
        {
            NetworkResourcesController.NewInstance.RunPsTest("Test-ConnectionMonitor");
        }
    }
}
