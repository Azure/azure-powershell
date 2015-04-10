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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;

namespace Microsoft.Azure.Commands.ScenarioTest.DnsTests
{
    public class ZoneTests : DnsTestsBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrud()
        {
            RunPowerShellTest("Test-ZoneCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneCrudWithPiping()
        {
            RunPowerShellTest("Test-ZoneCrudWithPiping");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneList()
        {
            RunPowerShellTest("Test-ZoneList");
        }
        
        [Fact(Skip = "Service does not yet support this")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneNewAlreadyExists()
        {
            RunPowerShellTest("Test-ZoneNewAlreadyExists");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneSetEtagMismatch()
        {
            RunPowerShellTest("Test-ZoneSetEtagMismatch");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneSetNotFound()
        {
            RunPowerShellTest("Test-ZoneSetNotFound");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveEtagMismatch()
        {
            RunPowerShellTest("Test-ZoneRemoveEtagMismatch");
        }

        [Fact()]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZoneRemoveNotFound()
        {
            RunPowerShellTest("Test-ZoneRemoveNonExisting");
        }
    }
}
