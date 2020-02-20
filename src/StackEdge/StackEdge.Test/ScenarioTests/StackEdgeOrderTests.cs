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


using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Test.ScenarioTests
{
    public class StackEdgeOrderTests : StackEdgeScenarioTestBase
    {
        private ServiceManagement.Common.Models.XunitTracingInterceptor _logger;

        public StackEdgeOrderTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new ServiceManagement.Common.Models.XunitTracingInterceptor(output);
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetNonExistingOrder()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-GetOrderNonExistent");
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateOrder()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-CreateNewOrder");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveOrder()
        {
            StackEdgeScenarioTestBase.NewInstance.RunPowerShellTest(_logger, "Test-RemoveOrder");
        }
    }
}