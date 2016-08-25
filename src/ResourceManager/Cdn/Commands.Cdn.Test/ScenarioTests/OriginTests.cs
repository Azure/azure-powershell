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

namespace Microsoft.Azure.Commands.Cdn.Test.ScenarioTests.ScenarioTest
{
    public class OriginTests
    {
        private ServiceManagemenet.Common.Models.XunitTracingInterceptor _logger;

        public OriginTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output);
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOriginGetSetWithRunningEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-OriginGetSetWithRunningEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOriginGetSetWithStoppedEndpoint()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-OriginGetSetWithStoppedEndpoint");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOriginGetSetWhenEndpointDoesnotExist()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-OriginGetSetWhenEndpointDoesnotExist");
        }
    }
}
