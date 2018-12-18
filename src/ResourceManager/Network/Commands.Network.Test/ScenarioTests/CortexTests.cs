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

namespace Commands.Network.Test.ScenarioTests
{
    using System;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Xunit.Abstractions;

    public class CortexTests : Microsoft.WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public CortexTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestCortexCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CortexCRUD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, Category.pgtm)]
        public void TestCortexExpressRouteCRUD()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CortexExpressRouteCRUD");
        }

        [Fact]
        [Trait(Category.RunType, Category.LiveOnly)]
        [Trait(Category.Owner, Category.brooklynft)]
        public void TestCortexDownloadConfig()
        {
            NetworkResourcesController.NewInstance.RunPsTest(_logger, "Test-CortexDownloadConfig");
        }
    }
}
