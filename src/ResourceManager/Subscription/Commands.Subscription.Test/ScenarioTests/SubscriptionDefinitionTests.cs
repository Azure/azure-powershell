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
using Microsoft.Azure.Commands.Subscription.Test.ScenarioTests.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Subscription.Test.ScenarioTests
{
    /// <summary>
    /// The following tests require four subscription definitions to be created manually at this time. This can 
    /// be done by calling New-AzureRmSubscriptionDefinition. At this time, this can only be done when your tenant is 
    /// whitelisted by Microsoft.
    /// </summary>
    public class SubscriptionDefinitionTests
    {
        private XunitTracingInterceptor _logger;

        public SubscriptionDefinitionTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestListSubscriptionDefinitions()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ListSubscriptionDefinitions");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSubscriptionDefinitionByName()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-GetSubscriptionDefinitionByName");
        }
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewSubscriptionDefinition()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewSubscriptionDefinition");
        }
    }
}
