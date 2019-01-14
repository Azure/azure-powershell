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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;

namespace Microsoft.Azure.Commands.Kusto.Test.ScenarioTests
{
    public class KustoClusterTests : KustoTestsBase
    {
        private readonly XunitTracingInterceptor _logger;

        public KustoClusterTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestKustoClusterLifecycle()
        {
            NewInstance.RunPsTest(_logger, "Test-KustoClusterLifecycle");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestKustoClusterName()
        {
            NewInstance.RunPsTest(_logger, "Test-KustoClusterName");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestKustoClusterUpdate()
        {
            NewInstance.RunPsTest(_logger, "Test-KustoClusterUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestKustoClusterSuspendResume()
        {
            NewInstance.RunPsTest(_logger, "Test-KustoClusterSuspendResume");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestKustoClusterRemove()
        {
            NewInstance.RunPsTest(_logger, "Test-KustoClusterRemove");
        }

    }
}
