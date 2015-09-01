﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class DataMaskingTests : SqlTestsBase
    {

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingPolicyEnablementToggling()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingPolicyEnablementToggling");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingPrivilegedLoginsChanges()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingPrivilegedLoginsChanges");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingBasicRuleLifecycle()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingBasicRuleLifecycle");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingNumberRuleLifecycle()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingNumberRuleLifecycle");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingTextRuleLifecycle()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingTextRuleLifecycle");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingRuleCreationFailures()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingRuleCreationFailures");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestDatabaseDataMaskingRuleCreationWithoutPolicy()
        {
            RunPowerShellTest("Test-DatabaseDataMaskingRuleCreationWithoutPolicy");
        }
    }
}
