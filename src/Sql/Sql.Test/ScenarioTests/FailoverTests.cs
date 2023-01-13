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

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class FailoverTests : SqlTestRunner
    {
        public FailoverTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverDatabase()
        {
            TestRunner.RunTestScript("Test-FailoverDatabase");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverDatabasePassThru()
        {
            TestRunner.RunTestScript("Test-FailoverDatabasePassThru");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverDatabaseWithDatabasePiping()
        {
            TestRunner.RunTestScript("Test-FailoverDatabaseWithDatabasePiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverDatabaseWithServerPiping()
        {
            TestRunner.RunTestScript("Test-FailoverDatabaseWithServerPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverDatabaseReadableSecondary()
        {
            TestRunner.RunTestScript("Test-FailoverDatabaseReadableSecondary");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverStandardDatabaseReadableSecondary()
        {
            TestRunner.RunTestScript("Test-FailoverStandardDatabaseReadableSecondary");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverElasticPool()
        {
            TestRunner.RunTestScript("Test-FailoverElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverElasticPoolPassThru()
        {
            TestRunner.RunTestScript("Test-FailoverElasticPoolPassThru");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverElasticPoolWithPoolPiping()
        {
            TestRunner.RunTestScript("Test-FailoverElasticPoolWithPoolPiping");
        }
    }
}
