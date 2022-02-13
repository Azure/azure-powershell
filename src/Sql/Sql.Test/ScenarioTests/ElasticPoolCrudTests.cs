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
using RestTestFramework = Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class ElasticPoolCrudTests : SqlTestsBase
    {
        public ElasticPoolCrudTests(ITestOutputHelper output) : base(output)
        {
            base.resourceTypesToIgnoreApiVersion = new string[] {
                "Microsoft.Sql/servers"
            };
        }

        // Currently the test runs too long to be marked as a check-in test.
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCreate()
        {
            RunPowerShellTest("Test-CreateElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreElasticPoolCreate()
        {
            RunPowerShellTest("Test-CreateVcoreElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.DesktopOnly)]
        public void TestVcoreElasticPoolCreateWithLicenseType()
        {
            RunPowerShellTest("Test-CreateVcoreElasticPoolWithLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCreateWithZoneRedundancy()
        {
            RunPowerShellTest("Test-CreateElasticPoolWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCreateWithMaintenanceConfigurationId()
        {
            RunPowerShellTest("Test-CreateElasticPoolWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolUpdate()
        {
            RunPowerShellTest("Test-UpdateElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreElasticPoolUpdate()
        {
            RunPowerShellTest("Test-UpdateVcoreElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreElasticPoolUpdateWithLicenseType()
        {
            RunPowerShellTest("Test-UpdateVcoreElasticPoolWithLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolUpdateWithZoneRedundancy()
        {
            RunPowerShellTest("Test-UpdateElasticPoolWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolUpdateWithMaintenanceConfigurationId()
        {
            RunPowerShellTest("Test-UpdateElasticPoolWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolGet()
        {
            RunPowerShellTest("Test-GetElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolGetWithZoneRedundancy()
        {
            RunPowerShellTest("Test-GetElasticPoolWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolGetWithMaintenanceConfigurationId()
        {
            RunPowerShellTest("Test-GetElasticPoolWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolRemove()
        {
            RunPowerShellTest("Test-RemoveElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCancelOperation()
        {
            RunPowerShellTest("Test-ListAndCancelElasticPoolOperation");
        }
    }
}
