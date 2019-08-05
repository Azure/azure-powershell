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
    public class InstancePoolCrudTests : SqlTestsBase
    {
        public InstancePoolCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        protected override void SetupManagementClients(RestTestFramework.MockContext context)
        {
            var sqlClient = GetSqlClient(context);
            var newResourcesClient = GetResourcesClient(context);
            var networkClient = GetNetworkClient(context);
            Helper.SetupSomeOfManagementClients(sqlClient, newResourcesClient, networkClient);
        }

        #region Instance pool

        /// <summary>
        /// Tests creation of an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstancePool()
        {
            RunPowerShellTest("Test-CreateInstancePool");
        }

        /// <summary>
        /// Tests updating an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateInstancePool()
        {
            RunPowerShellTest("Test-UpdateInstancePool");
        }

        /// <summary>
        /// Tests getting an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInstancePool()
        {
            RunPowerShellTest("Test-GetInstancePool");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveInstancePool()
        {
            RunPowerShellTest("Test-RemoveInstancePool");
        }

        #endregion

        #region Managed Instance

        /// <summary>
        /// Tests creation of a managed instance in an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstanceInInstancePool()
        {
            RunPowerShellTest("Test-CreateManagedInstanceInInstancePool");
        }

        /// <summary>
        /// Tests getting all managed instances in an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagedInstanceInInstancePool()
        {
            RunPowerShellTest("Test-GetManagedInstanceInInstancePool");
        }

        /// <summary>
        /// Tests updating a managed instance in an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagedInstanceInInstancePool()
        {
            RunPowerShellTest("Test-UpdateManagedInstanceInInstancePool");
        }

        /// <summary>
        /// Tests updating a managed instance in an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteManagedInstanceInInstancePool()
        {
            RunPowerShellTest("Test-DeleteManagedInstanceInInstancePool");
        }

        #endregion

        #region Instance Pool Usages

        /// <summary>
        /// Tests getting the instance pool usage
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInstancePoolUsage()
        {
            RunPowerShellTest("Test-GetInstancePoolUsage");
        }

        #endregion
    }
}