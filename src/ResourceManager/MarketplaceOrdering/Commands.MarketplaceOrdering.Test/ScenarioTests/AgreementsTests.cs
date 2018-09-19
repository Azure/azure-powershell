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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.MarketplaceOrdering.Test.ScenarioTests
{
    public class AgreementsTests
    {
        private ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public AgreementsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAgreement()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetAgreementTerms");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAgreementNotAccepted()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SetAgreementTermsNotAccepted");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAgreementAccepted()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SetAgreementTermsAccepted");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAgreementAcceptedPipeline()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SetAgreementTermsAcceptedPipelineGet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAgreementRejectPipeline()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SetAgreementTermsRejectedPipelineGet");
        }
    }
}
