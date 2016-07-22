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
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using ServiceManagemenet.Common.Models;
    using Xunit;
    using Xunit.Abstractions;

    public class RedisCacheTests : RMTestBase
    {
        public RedisCacheTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCache()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-RedisCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNonExistingRedisCacheTest()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-SetNonExistingRedisCacheTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCachePipeline()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-RedisCachePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetRedisCacheBugFixTest()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-SetRedisCacheBugFixTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMaxMemoryPolicyErrorCheck()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-MaxMemoryPolicyErrorCheck");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCacheClustering()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-RedisCacheClustering");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzureRedisCacheDiagnostics()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-SetAzureRedisCacheDiagnostics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRedisCacheDiagnostics()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-RemoveAzureRedisCacheDiagnostics");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResetAzureRmRedisCache()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-ResetAzureRmRedisCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestExportAzureRmRedisCache()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-ExportAzureRmRedisCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportAzureRmRedisCache()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-ImportAzureRmRedisCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCachePatchSchedules()
        {
            RedisCacheController.NewInstance.RunPowerShellTest("Test-RedisCachePatchSchedules");
        }
    }
}
