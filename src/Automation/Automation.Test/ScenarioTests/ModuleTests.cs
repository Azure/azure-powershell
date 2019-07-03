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
    public class ModuleTests : AutomationTestRunner
    {
        public ModuleTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllModules()
        {
            TestRunner.RunTestScript("Test-GetAllModules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetModuleByName()
        {
            TestRunner.RunTestScript("Test-GetModuleByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void NewModule()
        {
            TestRunner.RunTestScript("Test-NewModule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.DesktopOnly)]
        [Trait(Category.Service, Category.Automation)]
        public void ImportModule()
        {
            TestRunner.RunTestScript("Test-ImportModule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void SetModule()
        {
            TestRunner.RunTestScript("Test-SetModule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void RemoveModule()
        {
            TestRunner.RunTestScript("Test-RemoveModule");
        }
    }
}