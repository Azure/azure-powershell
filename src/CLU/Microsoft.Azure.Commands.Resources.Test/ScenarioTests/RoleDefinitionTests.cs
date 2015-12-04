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


using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    public class RoleDefinitionTests : RMTestBase
    {
        private const string CallingClass = "Microsoft.Azure.Commands.Resources.Test.ScenarioTests.RoleDefinitionTests";

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RoleDefinitionCreateTests()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RoleDefinitionCreateTests",
                "Test-RoleDefinitionCreateTests");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdNegativeScenarios()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RdNegativeScenarios",
                "Test-RdNegativeScenarios");
        }

        [Fact(Skip = "TODO, [#108248038]: Enable scenario tests")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RdPositiveScenarios()
        {
            ResourcesController.NewInstance.RunPsTest(
                CallingClass,
                "RdPositiveScenarios",
                "Test-RDPositiveScenarios");
        }
    }
}
