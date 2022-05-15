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

namespace Microsoft.Azure.Commands.Blueprint.Test.ScenarioTests
{
    public class BlueprintAssignmentTests : BlueprintTestRunner
    {
        public BlueprintAssignmentTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBlueprintAssignment()
        {
            TestRunner.RunTestScript("Test-GetBlueprintAssignment");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBlueprintAssignmentWithSystemAssignedIdentity()
        {
            TestRunner.RunTestScript("Test-NewBlueprintAssignmentWithSystemAssignedIdentity");
        }

        [Fact(Skip="Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBlueprintAssignment()
        {
            TestRunner.RunTestScript("Test-NewBlueprintAssignment");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetBlueprintAssignment()
        {
            TestRunner.RunTestScript("Test-SetBlueprintAssignment");
        }

        [Fact(Skip = "Investigate auto-registration for RP")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveBlueprintAssignment()
        {
            TestRunner.RunTestScript("Test-RemoveBlueprintAssignment");
        }

    }
}
