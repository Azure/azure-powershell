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

using System.Collections.Generic;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    public class StartAzureAutomationDscCompilationJobTest : RMTestBase
    {
        private Mock<IAutomationPSClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private StartAzureAutomationDscCompilationJob cmdlet;

        public StartAzureAutomationDscCompilationJobTest()
        {
            this.mockAutomationClient = new Mock<IAutomationPSClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new StartAzureAutomationDscCompilationJob
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void StartAzureAutomationDscCompilationJobTestSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string configurationName = "runbook";
            bool incrementNodeConfigurationBuild = true;
            var parameters = new Dictionary<string, string>()
            {
                {"Key1", "Value1"},
                {"Key2", "Value2"},
            };
            

            this.mockAutomationClient.Setup(
                f =>
                    f.StartCompilationJob(resourceGroupName, accountName, configurationName, parameters, null, incrementNodeConfigurationBuild)
                );

            //CompilationJob StartCompilationJob(string resourceGroupName, 
            // string automationAccountName, string configurationName, 
            // IDictionary parameters, IDictionary configurationData, bool incrementNodeConfigurationBuild = false);

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ConfigurationName = configurationName;
            this.cmdlet.Parameters = parameters;
            this.cmdlet.IncrementNodeConfigurationBuild = incrementNodeConfigurationBuild;
            this.cmdlet.ConfigurationData = null;

            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.StartCompilationJob(resourceGroupName, accountName, configurationName, parameters, null, incrementNodeConfigurationBuild),
                Times.Once());
        }
    }
}
