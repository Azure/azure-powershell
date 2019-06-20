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

namespace Microsoft.Azure.Commands.AzureStack.Tests
{
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;

    public class TestCases : RMTestBase
    {
        private readonly XunitTracingInterceptor logger;

        public TestCases(ITestOutputHelper output)
        {
            this.logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(this.logger);
        }

        [Fact]
        public void TestListRegistrations() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestListRegistrations));

        [Fact]
        public void TestGetRegistration() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestGetRegistration));

        [Fact]
        public void TestGetActivationKey() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestGetActivationKey));

        [Fact]
        public void TestCreateUpdateAndDeleteRegistration() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestCreateUpdateAndDeleteRegistration));

        [Fact]
        public void TestListProducts() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestListProducts));

        [Fact]
        public void TestGetProduct() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestGetProduct));

        [Fact]
        public void TestGetProductDetails() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestGetProductDetails));

        [Fact]
        public void TestListCustomerSubscriptions() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestListCustomerSubscriptions));

        [Fact]
        public void TestGetCustomerSubscription() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestGetCustomerSubscription));

        [Fact]
        public void TestCreateAndDeleteCustomerSubscription() => TestController.Instance.RunPowerShellTest(this.logger, nameof(TestCreateAndDeleteCustomerSubscription));
    }
}
