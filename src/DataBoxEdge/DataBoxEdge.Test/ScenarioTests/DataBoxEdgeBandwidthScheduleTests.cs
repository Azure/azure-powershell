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

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Test.ScenarioTests
{
    public class DataBoxEdgeBandwidthScheduleTests : DataBoxEdgeTestRunner
    {
        public DataBoxEdgeBandwidthScheduleTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingBandwidthSchedule()
        {
            TestRunner.RunTestScript("Test-GetNonExistingBandwidthSchedule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateBandwidthSchedule()
        {
            TestRunner.RunTestScript("Test-CreateBandwidthSchedule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateBandwidthSchedule()
        {
            TestRunner.RunTestScript("Test-UpdateBandwidthSchedule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUnlimitedBandwidthSchedule()
        {
            TestRunner.RunTestScript("Test-CreateUnlimitedBandwidthSchedule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBandwidthSchedule()
        {
            TestRunner.RunTestScript("Test-RemoveBandwidthSchedule");
        }
    }
}