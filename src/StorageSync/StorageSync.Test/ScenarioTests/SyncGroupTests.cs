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


using ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace StorageSyncTests
{
    /// <summary>
    /// Class SyncGroupTests.
    /// </summary>
    public class SyncGroupTests : StorageSyncTestRunner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SyncGroupTests"/> class.
        /// </summary>
        /// <param name="output">The output.</param>
        public SyncGroupTests(ITestOutputHelper output) : base(output)
        {
        }

        /// <summary>
        /// Defines the test method TestSyncGroup.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSyncGroup()
        {
            TestRunner.RunTestScript("Test-SyncGroup");
        }

        /// <summary>
        /// Defines the test method TestNewSyncGroup.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSyncGroup()
        {
            TestRunner.RunTestScript("Test-NewSyncGroup");
        }

        /// <summary>
        /// Defines the test method TestGetSyncGroup.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroup()
        {
            TestRunner.RunTestScript("Test-GetSyncGroup");
        }

        /// <summary>
        /// Defines the test method TestGetSyncGroupParentObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroupParentObject()
        {
            TestRunner.RunTestScript("Test-GetSyncGroupParentObject");
        }

        /// <summary>
        /// Defines the test method TestGetSyncGroupParentResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroupParentResourceId()
        {
            TestRunner.RunTestScript("Test-GetSyncGroupParentResourceId");
        }


        /// <summary>
        /// Defines the test method TestGetSyncGroups.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSyncGroups()
        {
            TestRunner.RunTestScript("Test-GetSyncGroups");
        }

        /// <summary>
        /// Defines the test method TestRemoveSyncGroup.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSyncGroup()
        {
            TestRunner.RunTestScript("Test-RemoveSyncGroup");
        }

        /// <summary>
        /// Defines the test method TestRemoveSyncGroupResourceId.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSyncGroupResourceId()
        {
            TestRunner.RunTestScript("Test-RemoveSyncGroupResourceId");
        }

        /// <summary>
        /// Defines the test method TestRemoveSyncGroupInputObject.
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveSyncGroupInputObject()
        {
            TestRunner.RunTestScript("Test-RemoveSyncGroupInputObject");
        }

    }
}
