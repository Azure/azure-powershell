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

namespace Microsoft.Azure.Commands.MixedReality.Test
{
    public class RemoteRenderingAccountTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public RemoteRenderingAccountTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoteRenderingAccountOperations()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RemoteRenderingAccountOperations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoteRenderingAccountOperationsWithPiping()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-RemoteRenderingAccountOperationsWithPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListRemoteRenderingAccounts()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListRemoteRenderingAccounts");
        }
    }
}
