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

namespace Commands.Automation.Test
{
    public class VariableTests : AutomationTestRunner
    {
        public VariableTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestStringVariable()
        {
            TestRunner.RunTestScript("Test-StringVariable");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestIntVariable()
        {
            TestRunner.RunTestScript("Test-IntVariable");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestFloatVariable()
        {
            TestRunner.RunTestScript("Test-FloatVariable");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestArrayVariable()
        {
            TestRunner.RunTestScript("Test-ArrayVariable");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestNormalHashTableVariable()
        {
            TestRunner.RunTestScript("Test-NormalHashTableVariable");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestMultiLevelDictVariable()
        {
            TestRunner.RunTestScript("Test-MultiLevelDictVariable");
        }

        [Fact]
        [Trait(Category.Service, Category.Automation)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.AcceptanceType, Category.BVT)]
        public void TestJsonInDictValueVariable()
        {
            TestRunner.RunTestScript("Test-JsonInDictValueVariable");
        }
    }
}
