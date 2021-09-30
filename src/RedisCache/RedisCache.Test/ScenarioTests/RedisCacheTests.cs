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
    using ServiceManagement.Common.Models;
    using Xunit;
    using Xunit.Abstractions;

    public class RedisCacheTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public RedisCacheTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCache()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-RedisCache");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetNonExistingRedisCacheTest()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-SetNonExistingRedisCacheTest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCachePipeline()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-RedisCachePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCacheClustering()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-RedisCacheClustering");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRedisCachePatchSchedules()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-RedisCachePatchSchedules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestImportExportReboot()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-ImportExportReboot");
        }

#if NETSTANDARD
        [Fact(Skip = "Needs investigation: Storage Id cannot be null")]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDiagnosticOperations()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-DiagnosticOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGeoReplication()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-GeoReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFirewallRule()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-FirewallRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestZones()
        {
            RedisCacheController.NewInstance.RunPowerShellTest(_logger, "Test-Zones");
        }
    }
}
