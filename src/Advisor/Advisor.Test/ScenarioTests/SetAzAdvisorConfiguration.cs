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


namespace Microsoft.Azure.Commands.Advisor.Test.ScenarioTests
{
    public class SetAzAdvisorConfiguration : AdvisorTestRunner
    {
        public SetAzAdvisorConfiguration(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationBadUserInputLowCpu()
        {
            TestRunner.RunTestScript("Set-AzAdvisorConfigurationBadUserInputLowCpu-Negative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByLowCpu()
        {
            TestRunner.RunTestScript("Set-AzAdvisorConfigurationWithLowCpu");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByLowCpuExclude()
        {
            TestRunner.RunTestScript("Set-AzAdvisorConfigurationByLowCpuExclude");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationPipelineByLowCpuExclude()
        {
            TestRunner.RunTestScript("Set-AzAdvisorConfigurationPipelineByLowCpuExclude");
        }

        // ResourceGroupParameterSets
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByRg()
        {
            TestRunner.RunTestScript("Set-AzAdvisorConfigurationWithRg");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetAzAdvisorConfigurationByRgExclude()
        {
            TestRunner.RunTestScript("Set-AzAdvisorConfigurationByRgExclude");
        }

    }
}
