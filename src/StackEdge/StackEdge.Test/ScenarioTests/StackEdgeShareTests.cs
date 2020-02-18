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

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Test.ScenarioTests
{
    public class StackEdgeShareTests : StackEdgeScenarioTestBase
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public StackEdgeShareTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingShare()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-GetShareNonExistent");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestCreateShare()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-CreateShare");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestCreateLocalShare()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-CreateLocalShare");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestRemoveShare()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-RemoveShare");
        }
    }
}