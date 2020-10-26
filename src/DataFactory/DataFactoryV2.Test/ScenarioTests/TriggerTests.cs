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

using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.DataFactoryV2.Test
{
    public class TriggerTests : DataFactoriesScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public TriggerTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTrigger()
        {
            RunPowerShellTest(_logger, "Test-Trigger");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartTriggerThrowsWithoutPipeline()
        {
            RunPowerShellTest(_logger, "Test-StartTriggerThrowsWithoutPipeline");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInvokeAndStopTriggerRun()
        {
            RunPowerShellTest(_logger, "Test-TriggerInvokeAndStop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTriggerRun()
        {
            RunPowerShellTest(_logger, "Test-TriggerRun");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTriggerWithResourceId()
        {
            RunPowerShellTest(_logger, "Test-TriggerWithResourceId");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEventTriggerSubscriptions()
        {
            RunPowerShellTest(_logger, "Test-BlobEventTriggerSubscriptions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEventTriggerSubscriptionsByInputObject()
        {
            RunPowerShellTest(_logger, "Test-BlobEventTriggerSubscriptionsByInputObject");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBlobEventTriggerSubscriptionsByResourceId()
        {
            RunPowerShellTest(_logger, "Test-BlobEventTriggerSubscriptionsByResourceId");
        }
    }
}
