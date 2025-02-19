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

namespace Microsoft.Azure.Commands.RedisCache.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Xunit.Abstractions;

    public class RedisCacheTests : RedisCacheTestRunner
    {
        public RedisCacheTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCache()
        {
            TestRunner.RunTestScript("Test-RedisCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNonExistingRedisCacheTest()
        {
            TestRunner.RunTestScript("Test-SetNonExistingRedisCacheTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCachePipeline()
        {
            TestRunner.RunTestScript("Test-RedisCachePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCacheClustering()
        {
            TestRunner.RunTestScript("Test-RedisCacheClustering");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCachePatchSchedules()
        {
            TestRunner.RunTestScript("Test-RedisCachePatchSchedules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportExportRebootClear()
        {
            TestRunner.RunTestScript("Test-ImportExportRebootClear");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticOperations()
        {
            TestRunner.RunTestScript("Test-DiagnosticOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGeoReplication()
        {
            TestRunner.RunTestScript("Test-GeoReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFirewallRule()
        {
            TestRunner.RunTestScript("Test-FirewallRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZones()
        {
            TestRunner.RunTestScript("Test-Zones");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedIdentity()
        {
            TestRunner.RunTestScript("Test-ManagedIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateChannel()
        {
            TestRunner.RunTestScript("Test-UpdateChannel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAuthenticationCache()
        {
            TestRunner.RunTestScript("Test-AuthenticationCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateToAutomaticZonalAllocationPolicyForPremiumCache()
        {
            TestRunner.RunTestScript("Test-UpdateToAutomaticZonalAllocationPolicyForPremiumCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAutomaticZonalAllocationPolicyForStandardCache()
        {
            TestRunner.RunTestScript("Test-AutomaticZonalAllocationPolicyForStandardCache");
        }
    }
}
