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

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class LogAnalyticTests : ComputeTestRunner
    {
        public LogAnalyticTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportLogAnalyticThrottledRequestsNegative()
        {
            TestRunner.RunTestScript("Test-ExportLogAnalyticThrottledRequestsNegative");
        }

		[Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportLogAnalyticRequestRateByIntervalNegative()
        {
            TestRunner.RunTestScript("Test-ExportLogAnalyticRequestRateByIntervalNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportLogAnalyticGroupByParameters()
        {
            TestRunner.RunTestScript("Test-ExportLogAnalyticGroupByParameters");
        }

        [Fact(Skip = "BUG: LogAnalytics does not work.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait("Re-record", "ClientRuntime changes")]
        public void TestExportLogAnalytics()
        {
            TestRunner.RunTestScript("Test-ExportLogAnalytics");
        }
    }
}
