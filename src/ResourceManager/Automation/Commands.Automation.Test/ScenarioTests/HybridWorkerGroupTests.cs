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

    public class HybridWorkerGroupTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public HybridWorkerGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void E2EHybridWorkerGroup()
        {
            RunPowerShellTest(_logger, "Test-E2EHybridWorkerGroup");
        }
    }
}