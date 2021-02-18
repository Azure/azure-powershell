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
    public class ManagedInstanceFailoverScenarioTests : SqlTestsBase
    {
        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var networkClient = GetNetworkClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient, networkClient);
        }

        public ManagedInstanceFailoverScenarioTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverManagedInstance()
        {
            RunPowerShellTest("Test-FailoverManagedInstance");
        }

        [Fact(Skip = "Depends on hardcoded resource")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverManagedInstancePassThru()
        {
            RunPowerShellTest("Test-FailoverManagedInstancePassThru");
        }

        [Fact(Skip = "Depends on hardcoded resource")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverManagedInstancePiping()
        {
            RunPowerShellTest("Test-FailoverManagedInstancePiping");
        }

        [Fact(Skip = "Depends on hardcoded resource")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFailoverManagedInstanceReadableSecondary()
        {
            RunPowerShellTest("Test-FailoverManagedInstanceReadableSecondary");
        }
    }
}
