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

using Microsoft.Azure.Commands.ResourceGraph.Test.ScenarioTests;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Advisor.Test.ScenarioTests
{
    public class DisableAzureRMAdvisorRecommendation
    {
        private readonly XunitTracingInterceptor _logger;

        public DisableAzureRMAdvisorRecommendation(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureRmAdvisorRecommendationByNameParameter()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Disable-AzureRmAdvisorRecommendationByNameParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureRmAdvisorRecommendationByIdParameter()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Disable-AzureRmAdvisorRecommendationByIdParameter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureRmAdvisorRecommendationByIdParameterAndSName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Disable-AzureRmAdvisorRecommendationByIdParameterAndSName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableAzureRmAdvisorRecommendationPipelineScenario()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Disable-AzureRmAdvisorRecommendationPipelineScenario");
        }
    }
}
