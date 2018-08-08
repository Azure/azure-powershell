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

using Microsoft.Azure.Commands.Management.BotService.Test.ScenarioTests;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Management.BotService.Test
{
    public class BotServiceTests : RMTestBase
    {
        XunitTracingInterceptor traceInterceptor;

        public BotServiceTests(ITestOutputHelper output)
        {
            this.traceInterceptor = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.traceInterceptor);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewBot()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-NewAzureRmBot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetBot()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmBot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmBotNonExistingBotExistingResourceGroup()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-GetAzureRmBotNonExistingBotExistingResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveAzureRmBot()
        {
            TestController.NewInstance.RunPsTest(traceInterceptor, "Test-RemoveAzureRmBot");
        }
    }
}
