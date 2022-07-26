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

namespace Microsoft.Azure.Commands.PrivateDns.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class ZoneTests : PrivateDnsTestRunner
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
        public void TestZoneSetUsingResourceId()
        {
            TestRunner.RunTestScript("Test-ZoneSetUsingResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveUsingResourceId()
        {
            TestRunner.RunTestScript("Test-ZoneRemoveUsingResourceId");
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneNewWithLocalSuffix()
        {
            TestRunner.RunTestScript("Test-ZoneNewWithLocalSuffix");
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
    }
}
