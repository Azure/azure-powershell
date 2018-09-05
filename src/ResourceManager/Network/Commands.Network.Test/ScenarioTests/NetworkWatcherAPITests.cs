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

using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Network.Test.ScenarioTests
{
    public class NetworkWatcherAPITests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public NetworkWatcherAPITests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestGetTopology()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-GetTopology");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestGetSecurityGroupView()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-GetSecurityGroupView");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestGetNextHop()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-GetNextHop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestVerifyIPFlow()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-VerifyIPFlow");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestPacketCapture()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-PacketCapture");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestTroubleshoot()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-Troubleshoot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestFlowLog()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-FlowLog");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestConnectivityCheck()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ConnectivityCheck");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestReachabilityReport()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ReachabilityReport");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestProvidersList()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ProvidersList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.netanalyticsdev)]
        public void TestConnectionMonitor()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-ConnectionMonitor");
        }
    }
}
