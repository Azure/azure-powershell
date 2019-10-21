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

namespace Microsoft.Azure.Commands.DataShare.Test.ScenarioTests.ScenarioTest
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class SynchronizationTests
    {
        private readonly ServiceManagement.Common.Models.XunitTracingInterceptor logger;

        public SynchronizationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(this.logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestStartSynchronization()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SynchronizationStart");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCancelSynchronization()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-SynchronizationCancel");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSubscriptionSynchronizationCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ListShareSubscriptionSynchronizationCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSubscriptionSynchronizationDetailsCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ListShareSubscriptionSynchronizationDetailsCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSynchronizationCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ListShareSynchronizationCrud");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListShareSynchronizationDetailsCrud()
        {
            TestController.NewInstance.RunPowerShellTest(this.logger, "Test-ListShareSynchronizationDetailsCrud");
        }
    }
}
