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

using Microsoft.Azure.Commands.Cdn.Test.ScenarioTests.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Cdn.Test.ScenarioTests.ScenarioTest
{
    public class ProfileTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public ProfileTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrud()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSkuCreate()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-SkuCreate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileCrudWithPiping()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileDeleteAndSsoWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfilePipeline()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfilePipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileDeleteWithEndpoints()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileDeleteWithEndpoints");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestProfileGetResourceUsage()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileGetResourceUsages");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ProfileGetSupportedOptimizationType()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ProfileGetSupportedOptimizationType");
        }
    }
}
