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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ThreatDetectionTests : SqlTestRunner
    {
        public ThreatDetectionTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThreatDetectionGetDefaultPolicy()
        {
            TestRunner.RunTestScript("Test-ThreatDetectionGetDefaultPolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThreatDetectionDatabaseUpdatePolicy()
        {
            TestRunner.RunTestScript("Test-ThreatDetectionDatabaseUpdatePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ThreatDetectionServerUpdatePolicy()
        {
            TestRunner.RunTestScript("Test-ThreatDetectionServerUpdatePolicy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisablingThreatDetection()
        {
            TestRunner.RunTestScript("Test-DisablingThreatDetection");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidArgumentsThreatDetection()
        {
            TestRunner.RunTestScript("Test-InvalidArgumentsThreatDetection");
        }
    }
}
