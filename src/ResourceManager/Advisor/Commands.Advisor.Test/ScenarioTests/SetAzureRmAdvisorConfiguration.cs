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
    public class SetAzureRmAdvisorConfiguration
    {
        private readonly XunitTracingInterceptor _logger;

        public SetAzureRmAdvisorConfiguration(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        // No user input for paratmeters
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationNoParameterSet()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationNoParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationBadUserInputLowCpu()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationBadUserInputLowCpu-Negative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationByLowCpu()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationWithLowCpu");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationByLowCpuExclude()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationByLowCpuExclude");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationPipelineByLowCpuExclude()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationPipelineByLowCpuExclude");
        }

        // ResourceGroupParameterSets
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationByRg()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationWithRg");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzureRmAdvisorConfigurationByRgExclude()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Set-AzureRmAdvisorConfigurationByRgExclude");
        }

    }
}
