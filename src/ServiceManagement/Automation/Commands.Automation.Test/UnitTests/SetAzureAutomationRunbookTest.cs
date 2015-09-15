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
using System.Collections.Generic;
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class SetAzureAutomationRunbookTest : SMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private SetAzureAutomationRunbook cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new SetAzureAutomationRunbook
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void SetAzureAutomationRunbookByNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";

            this.mockAutomationClient.Setup(f => f.UpdateRunbook(accountName, runbookName, null, null, null, null));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runbookName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UpdateRunbook(accountName, runbookName, null, null, null, null), Times.Once());
        }

        [TestMethod]
        public void SetAzureAutomationRunbookByNameWithParametersSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string runbookName = "runbook";
            bool? logProgress = false;
            string[] tags = { "tag1", "tags2" };

            this.mockAutomationClient.Setup(f => f.UpdateRunbook(accountName, runbookName, null, tags, logProgress, null));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = runbookName;
            this.cmdlet.Tags = tags;
            this.cmdlet.LogProgress = logProgress;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.UpdateRunbook(accountName, runbookName, null, tags, logProgress, null), Times.Once());
        }
    }
}
