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

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ManagedDatabaseLogReplayScenarioTest : SqlTestRunner
    {
        public ManagedDatabaseLogReplayScenarioTest(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(Skip = "Depends on hardcoded resource to rerecord")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedDatabaseLogReplayService()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseLogReplay");
        }

        [Fact(Skip = "Depends on hardcoded resource to rerecord")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCompleteManagedDatabaseLogReplayService()
        {
            TestRunner.RunTestScript("Test-CompleteManagedDatabaseLogReplay");
        }

        [Fact(Skip = "Depends on hardcoded resource to rerecord")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCancelManagedDatabaseLogReplayService()
        {
            TestRunner.RunTestScript("Test-CancelManagedDatabaseLogReplay");
        }

        [Fact(Skip = "Depends on hardcoded resource to rerecord")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingManagedDatabaseLogReplayService()
        {
            TestRunner.RunTestScript("Test-ManagedDatabaseLogReplayPiping");
        }

        [Fact(Skip = "Depends on hardcoded resource to rerecord")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPipingCompleteCancelManagedDatabaseLogReplayService()
        {
            TestRunner.RunTestScript("Test-PipingCompleteCancelManagedDatabaseLogReplay");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCancelManagedDatabaseLogReplayFailForWrongDatabase()
        {
            TestRunner.RunTestScript("Test-CancelManagedDatabaseLogReplayFailForWrongDatabase");
        }
    }
}
