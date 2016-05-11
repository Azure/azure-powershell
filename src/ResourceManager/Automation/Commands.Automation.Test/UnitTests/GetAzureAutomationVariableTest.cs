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

using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationVariableTest : RMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationVariable cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationVariable
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void GetAzureAutomationVariableByNameSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string variableName = "variable";

            this.mockAutomationClient.Setup(f => f.GetVariable(resourceGroupName, accountName, variableName));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = variableName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByName);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetVariable(resourceGroupName, accountName, variableName), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationVariableByAllSuccessfull()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListVariables(resourceGroupName, accountName, ref nextLink)).Returns((string a, string b, string c) => new List<Variable>());

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.SetParameterSet(AutomationCmdletParameterSets.ByAll);
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListVariables(resourceGroupName, accountName, ref nextLink), Times.Once());
        }
    }
}
