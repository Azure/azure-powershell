﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Cdn.Test.ScenarioTests.ScenarioTest
{
    public class AfdCustomDomainTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public AfdCustomDomainTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact(Skip = "Test is flaky due to creation of custom domain issue which prolongs response time. Will enable once RP issue is resolved.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateAfdCustomDomain()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateAfdCustomDomain");
        }

        [Fact(Skip = "Test is flaky due to RP issue which prolongs response time. Will enable once RP issue is resolved.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAfdCustomDomain()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetAfdCustomDomain");
        }
    }
}
