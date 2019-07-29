using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class InstancePoolCrudTests : SqlTestsBase
    {
        public InstancePoolCrudTests(ITestOutputHelper output) : base(output)
        {
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