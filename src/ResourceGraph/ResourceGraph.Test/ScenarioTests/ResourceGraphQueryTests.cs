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
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceGraph.Test.ScenarioTests
{
    public class ResourceGraphQueryTests
    {
        private readonly XunitTracingInterceptor _logger;

        public ResourceGraphQueryTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Query()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Search-AzureRmGraph-Query");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PagedQuery()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Search-AzureRmGraph-PagedQuery");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void Subscriptions()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Search-AzureRmGraph-Subscriptions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InlcudeSubscriptionNames()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Search-AzureRmGraph-IncludeSubscriptionNames");
        }

        [Fact(Skip = "Fails on Linux. Equality assertion fails. Investigation needed.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void QueryError()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Search-AzureRmGraph-QueryError");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SubscriptionQueryError()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Search-AzureRmGraph-SubscriptionQueryError");
        }
    }
}
