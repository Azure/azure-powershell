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
    public class ElasticPoolCrudTests : SqlTestRunner
    {
        public ElasticPoolCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        // Currently the test runs too long to be marked as a check-in test.
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCreate()
        {
            TestRunner.RunTestScript("Test-CreateElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreElasticPoolCreate()
        {
            TestRunner.RunTestScript("Test-CreateVcoreElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.RunType, Category.DesktopOnly)]
        public void TestVcoreElasticPoolCreateWithLicenseType()
        {
            TestRunner.RunTestScript("Test-CreateVcoreElasticPoolWithLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCreateWithZoneRedundancy()
        {
            TestRunner.RunTestScript("Test-CreateElasticPoolWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCreateWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-CreateElasticPoolWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHyperscaleElasticPoolCreate()
        {
            TestRunner.RunTestScript("Test-CreateHyperscaleElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHyperscaleElasticPoolCreateWithReplica()
        {
            TestRunner.RunTestScript("Test-CreateHyperscaleElasticPoolWithReplica");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreElasticPoolUpdate()
        {
            TestRunner.RunTestScript("Test-UpdateVcoreElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVcoreElasticPoolUpdateWithLicenseType()
        {
            TestRunner.RunTestScript("Test-UpdateVcoreElasticPoolWithLicenseType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolUpdateWithZoneRedundancy()
        {
            TestRunner.RunTestScript("Test-UpdateElasticPoolWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolUpdateWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-UpdateElasticPoolWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHyperscaleElasticPoolUpdateReplicaCount()
        {
            TestRunner.RunTestScript("Test-UpdateHyperscaleElasticPoolReplicaCount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMoveDatabaseOutHyperscaleElasticPool()
        {
            TestRunner.RunTestScript("Test-MoveDatabaseOutHyperscaleElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolGet()
        {
            TestRunner.RunTestScript("Test-GetElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolGetWithZoneRedundancy()
        {
            TestRunner.RunTestScript("Test-GetElasticPoolWithZoneRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolGetWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-GetElasticPoolWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHyperscaleElasticPoolGet()
        {
            TestRunner.RunTestScript("Test-GetHyperscaleElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolRemove()
        {
            TestRunner.RunTestScript("Test-RemoveElasticPool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestElasticPoolCancelOperation()
        {
            TestRunner.RunTestScript("Test-ListAndCancelElasticPoolOperation");
        }
    }
}
