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
    public class InstancePoolCrudTests : SqlTestRunner
    {
        public InstancePoolCrudTests(ITestOutputHelper output) : base(output)
        {
        }

        #region Instance pool

        /// <summary>
        /// Tests creation of an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateInstancePool()
        {
            TestRunner.RunTestScript("Test-CreateInstancePool");
        }

        /// <summary>
        /// Tests updating an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateInstancePool()
        {
            TestRunner.RunTestScript("Test-UpdateInstancePool");
        }

        /// <summary>
        /// Tests getting an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInstancePool()
        {
            TestRunner.RunTestScript("Test-GetInstancePool");
        }

        [Fact(Skip = "Skip due to long setup time for managed instance pool")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveInstancePool()
        {
            TestRunner.RunTestScript("Test-RemoveInstancePool");
        }

        #endregion

        #region Managed Instance

        /// <summary>
        /// Tests creation of a managed instance in an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateManagedInstanceInInstancePool()
        {
            TestRunner.RunTestScript("Test-CreateManagedInstanceInInstancePool");
        }

        /// <summary>
        /// Tests getting all managed instances in an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetManagedInstanceInInstancePool()
        {
            TestRunner.RunTestScript("Test-GetManagedInstanceInInstancePool");
        }

        /// <summary>
        /// Tests updating a managed instance in an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpdateManagedInstanceInInstancePool()
        {
            TestRunner.RunTestScript("Test-UpdateManagedInstanceInInstancePool");
        }

        /// <summary>
        /// Tests updating a managed instance in an instance pool
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDeleteManagedInstanceInInstancePool()
        {
            TestRunner.RunTestScript("Test-DeleteManagedInstanceInInstancePool");
        }

        #endregion

        #region Instance Pool Usages

        /// <summary>
        /// Tests getting the instance pool usage
        /// </summary>
        [Fact(Skip = "Cannot re-record.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInstancePoolUsage()
        {
            TestRunner.RunTestScript("Test-GetInstancePoolUsage");
        }

        #endregion
    }
}