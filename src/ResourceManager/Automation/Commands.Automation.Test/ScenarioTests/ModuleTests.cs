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

namespace Commands.Automation.Test
{
    using Microsoft.Azure.Commands.Automation.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Xunit;

    public class ModuleTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor logger;

        public ModuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetAllModules()
        {
            RunPowerShellTest(logger, "Test-GetAllModules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void GetModuleByName()
        {
            RunPowerShellTest(logger, "Test-GetModuleByName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void NewModule()
        {
            RunPowerShellTest(logger, "Test-NewModule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.DesktopOnly)]
        [Trait(Category.Service, Category.Automation)]
        public void ImportModule()
        {
            RunPowerShellTest(logger, "Test-ImportModule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void SetModule()
        {
            RunPowerShellTest(logger, "Test-SetModule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void RemoveModule()
        {
            RunPowerShellTest(logger, "Test-RemoveModule");
        }
    }
}