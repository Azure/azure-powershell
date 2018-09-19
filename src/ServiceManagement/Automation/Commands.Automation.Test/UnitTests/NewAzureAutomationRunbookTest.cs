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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationRunbookTest : SMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationRunbook cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationRunbook
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void NewAzureAutomationRunbookByPathSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookPath = "runbook.ps1";
            string description = "desc";
            string[] tags = { "tag1", "tags2" };

            this.mockAutomationClient.Setup(
                f => f.CreateRunbookByPath(accountName, runbookPath, description, tags));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Path = runbookPath;
            this.cmdlet.Description = description;
            this.cmdlet.Tags = tags;
            this.cmdlet.SetParameterSet("ByPath");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateRunbookByPath(accountName, runbookPath, description, tags), Times.Once());
        }

        [TestMethod]
        public void NewAzureAutomationRunbookByNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            string description = "desc";
            string[] tags = { "tag1", "tags2" };

            this.mockAutomationClient.Setup(
                f => f.CreateRunbookByName(accountName, runbookName, description, tags));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runbookName;
            this.cmdlet.Description = description;
            this.cmdlet.Tags = tags;
            this.cmdlet.SetParameterSet("ByRunbookName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateRunbookByName(accountName, runbookName, description, tags), Times.Once());
        }
    }
}
