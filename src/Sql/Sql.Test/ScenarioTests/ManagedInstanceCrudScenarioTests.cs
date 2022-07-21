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
    /// <summary>
    /// These tests depends on the existing resources. Please contact MDCSSQLCustomerExp@microsoft.com for instructions.
    /// </summary>
    public class ManagedInstanceCrudScenarioTests : SqlTestRunner
    {
        public ManagedInstanceCrudScenarioTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstance()
        {
            TestRunner.RunTestScript("Test-CreateManagedInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetManagedInstance()
        {
            TestRunner.RunTestScript("Test-SetManagedInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetBackupStorageRedundancy()
        {
            TestRunner.RunTestScript("Test-SetRedundancy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveManagedInstance()
        {
            TestRunner.RunTestScript("Test-RemoveManagedInstance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstanceWithIdentity()
        {
            TestRunner.RunTestScript("Test-CreateManagedInstanceWithIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUpdateManagedInstanceWithMinimalTlsVersion()
        {
            TestRunner.RunTestScript("Test-CreateUpdateManagedInstanceWithMinimalTlsVersion");
        }

        [Fact(Skip = "It is unknow for now how to fix this.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstanceWithMaintenanceConfigurationId()
        {
            TestRunner.RunTestScript("Test-CreateManagedInstanceWithMaintenanceConfigurationId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstanceWithMultiAzEnabled()
        {
            TestRunner.RunTestScript("Test-CreateManagedInstanceWithMultiAzEnabled");
        }
    }
}
