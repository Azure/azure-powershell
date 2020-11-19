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

using Microsoft.Azure.Commands.Billing.Test.ScenarioTests.ScenarioTest;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Billing.Test.ScenarioTests
{
    public class InvoiceSectionsTests
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public InvoiceSectionsTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListInvoiceSections()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListInvoiceSections");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInvoiceSectionWithName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetInvoiceSectionWithName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetInvoiceSectionWithNames()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetInvoiceSectionWithNames");
        }
    }
}
