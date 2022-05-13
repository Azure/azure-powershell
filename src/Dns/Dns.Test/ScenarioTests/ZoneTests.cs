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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ScenarioTest.DnsTests
{
    public class ZoneTests : DnsTestRunner
    {
        public ZoneTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrud()
        {
            TestRunner.RunTestScript("Test-ZoneCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneWithDelegation()
        {
            TestRunner.RunTestScript("Test-ZoneWithDelegation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrud()
        {
            TestRunner.RunTestScript("Test-PrivateZoneCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudRegistrationVirtualNetwork()
        {
            TestRunner.RunTestScript("Test-PrivateZoneCrudRegistrationVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudResolutionVirtualNetwork()
        {
            TestRunner.RunTestScript("Test-PrivateZoneCrudResolutionVnet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudByVirtualNetworkIds()
        {
            TestRunner.RunTestScript("Test-PrivateZoneCrudByVirtualNetworkIds");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPrivateZoneCrudByVirtualNetworkObjects()
        {
            TestRunner.RunTestScript("Test-PrivateZoneCrudByVirtualNetworkObjects");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudTrimsDot()
        {
            TestRunner.RunTestScript("Test-ZoneCrudTrimsDot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudWithPiping()
        {
            TestRunner.RunTestScript("Test-ZoneCrudWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudWithPipingTrimsDot()
        {
            TestRunner.RunTestScript("Test-ZoneCrudWithPipingTrimsDot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneList()
        {
            TestRunner.RunTestScript("Test-ZoneList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneListSubscription()
        {
            TestRunner.RunTestScript("Test-ZoneListSubscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneNewAlreadyExists()
        {
            TestRunner.RunTestScript("Test-ZoneNewAlreadyExists");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneSetEtagMismatch()
        {
            TestRunner.RunTestScript("Test-ZoneSetEtagMismatch");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneSetNotFound()
        {
            TestRunner.RunTestScript("Test-ZoneSetNotFound");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveEtagMismatch()
        {
            TestRunner.RunTestScript("Test-ZoneRemoveEtagMismatch");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveNotFound()
        {
            TestRunner.RunTestScript("Test-ZoneRemoveNonExisting");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneAddRemoveRecordSet()
        {
            TestRunner.RunTestScript("Test-AddRemoveRecordSet");
        }
    }
}
