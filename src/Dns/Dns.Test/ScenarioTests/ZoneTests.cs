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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ScenarioTest.DnsTests
{
    public class ZoneTests : DnsTestsBase
    {
        public XunitTracingInterceptor _logger;

        public ZoneTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrud()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneWithDelegation()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneWithDelegation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrud()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-PrivateZoneCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudRegistrationVirtualNetwork()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-PrivateZoneCrudRegistrationVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudResolutionVirtualNetwork()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-PrivateZoneCrudResolutionVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudByVirtualNetworkIds()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-PrivateZoneCrudByVirtualNetworkIds");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudByVirtualNetworkObjects()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-PrivateZoneCrudByVirtualNetworkObjects");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudTrimsDot()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneCrudTrimsDot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudWithPiping()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudWithPipingTrimsDot()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneCrudWithPipingTrimsDot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneList()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneListSubscription()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneListSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneNewAlreadyExists()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneNewAlreadyExists");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneSetEtagMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneSetEtagMismatch");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneSetNotFound()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneSetNotFound");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveEtagMismatch()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneRemoveEtagMismatch");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveNotFound()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-ZoneRemoveNonExisting");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneAddRemoveRecordSet()
        {
            DnsTestsBase.NewInstance.RunPowerShellTest(_logger, "Test-AddRemoveRecordSet");
        }
    }
}
