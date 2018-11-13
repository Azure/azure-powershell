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

namespace Microsoft.Azure.Commands.ServiceBus.Test.ScenarioTests
{
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using ServiceManagemenet.Common.Models;
    using Xunit;
    using Xunit.Abstractions;
    public class ServiceBusServiceTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ServiceBusServiceTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceBusNameSpace_CURD_Tests()
        {
            ServiceBusController.NewInstance.RunPsTest(_logger, "ServiceBusTests");
        }

#if NETSTANDARD
        [Fact(Skip = "Failed assertion: $namespaceListKeys.PrimaryConnectionString.Contains($updatedAuthRule.PrimaryKey)")]
        [Trait(Category.RunType, Category.DesktopOnly)]
#else
        [Fact]
#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ServiceBusNameSpaceAuth_CURD_Tests()
        {
            ServiceBusController.NewInstance.RunPsTest(_logger, "ServiceBusNameSpaceAuthTests");
        }
    }
}
