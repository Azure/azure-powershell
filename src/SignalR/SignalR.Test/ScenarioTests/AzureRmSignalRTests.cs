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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.SignalR.Test.ScenarioTests
{
    public class AzureRmSignalRTests : RMTestBase
    {
        private readonly ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public AzureRmSignalRTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmSignalR() =>
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmSignalR");

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmSignalRWithDefaultArgs() =>
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmSignalRWithDefaultArgs");

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmSignalRUpdateNetworkAcl() =>
    TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmSignalRUpdateNetworkAcl");

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureRmSignalRSetUpstream() =>
TestController.NewInstance.RunPowerShellTest(_logger, "Test-AzureRmSignalRSetUpstream");

    }
}
