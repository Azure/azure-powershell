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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ScenarioTest.SqlTests
{
    public class DataMaskingTests : SqlTestsBase
    {

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestDatabaseDataMaskingPolicyEnablementToggling()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingPolicyEnablementToggling");
        }

        [Fact(Skip = "Test executes for long time period")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingLevelChanges()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingLevelChanges");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestDatabaseDataMaskingPrivilegedLoginsChanges()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingPrivilegedLoginsChanges");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestDatabaseDataMaskingBasicRuleLifecycle()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingBasicRuleLifecycle");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestDatabaseDataMaskingNumberRuleLifecycle()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingNumberRuleLifecycle");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void TestDatabaseDataMaskingTextRuleLifecycle()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingTextRuleLifecycle");
        }
        
        [Fact(Skip = "Test executes for long time period")]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingRuleCreationFailures()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingRuleCreationFailures");
        }
    }
}
