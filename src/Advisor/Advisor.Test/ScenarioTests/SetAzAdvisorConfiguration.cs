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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;


namespace Microsoft.Azure.Commands.Advisor.Test.ScenarioTests
{
    public class SetAzAdvisorConfiguration
    {
        private readonly XunitTracingInterceptor _logger;

        public SetAzAdvisorConfiguration(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationBadUserInputLowCpu()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzAdvisorConfigurationBadUserInputLowCpu-Negative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByLowCpu()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzAdvisorConfigurationWithLowCpu");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByLowCpuExclude()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzAdvisorConfigurationByLowCpuExclude");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationPipelineByLowCpuExclude()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzAdvisorConfigurationPipelineByLowCpuExclude");
        }

        // ResourceGroupParameterSets
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByRg()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzAdvisorConfigurationWithRg");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByRgExclude()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzAdvisorConfigurationByRgExclude");
        }

    }
}
