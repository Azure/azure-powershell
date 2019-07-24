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

        #region Create Tests

        /// <summary>
        /// Tests creation of an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInstancePoolCreate()
        {
            RunPowerShellTest("Test-CreateInstancePool");
        }

        /// <summary>
        /// Tests creation of a managed instance in an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInstancePoolCreateManagedInstance()
        {
            RunPowerShellTest("Test-CreateManagedInstanceInInstancePool");
        }

        #endregion

        #region Update Tests

        /// <summary>
        /// Tests updating an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInstancePoolUpdate()
        {
            RunPowerShellTest("Test-UpdateInstancePool");
        }

        /// <summary>
        /// Tests updating a managed instance in an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInstancePoolUpdateManagedInstance()
        {
            RunPowerShellTest("Test-UpdateManagedInstanceInInstancePool");
        }

        #endregion

        #region Get Tests

        /// <summary>
        /// Tests getting an instance pool
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInstancePoolRead()
        {
            RunPowerShellTest("Test-GetInstancePool");
        }

        #endregion

        #region Remove Tests

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInstancePoolRemove()
        {
            RunPowerShellTest("Test-RemoveInstancePool");
        }

        #endregion
    }
}
