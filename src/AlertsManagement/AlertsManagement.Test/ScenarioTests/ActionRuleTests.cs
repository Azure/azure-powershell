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

using System;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.AlertsManagement.Test.ScenarioTests
{
    public class ActionRuleTests : RMTestBase
    {
        public XunitTracingInterceptor _logger;

        public ActionRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetActionRulesFilteredByParameters()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetActionRulesFilteredByParameters");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUpdateAndDeleteSuppressionRule()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateUpdateAndDeleteSuppressionRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUpdateAndDeleteActionGroupRule()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateUpdateAndDeleteActionGroupRule");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateUpdateAndDeleteDiagnosticsRule()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-CreateUpdateAndDeleteDiagnosticsRule");
        }
    }
}