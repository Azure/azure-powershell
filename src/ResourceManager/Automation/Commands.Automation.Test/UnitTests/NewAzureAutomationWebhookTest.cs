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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System;
namespace Microsoft.Azure.Commands.ResourceManager.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationWebhookTest : RMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationWebhook cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationWebhook
            {
                AutomationClient = this.mockAutomationClient.Object,
                CommandRuntime = this.mockCommandRuntime
            };
        }

        [TestMethod]
        public void NewAzureAutomationWebhookByNameSuccessful()
        {
            // Setup
            string resourceGroupName = "resourceGroup";
            string accountName = "account";
            string name = "webhookName";
            string runbookName = "runbookName";
            DateTimeOffset expiryTime = DateTimeOffset.Now.AddDays(1);

            this.mockAutomationClient.Setup(
                f => f.CreateWebhook(resourceGroupName, accountName, name, runbookName, true, expiryTime, null));

            // Test
            this.cmdlet.ResourceGroupName = resourceGroupName;
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = name;
            this.cmdlet.RunbookName = runbookName;
            this.cmdlet.ExpiryTime = expiryTime;
            this.cmdlet.IsEnabled = true;
            this.cmdlet.Parameters = null;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(
                f => f.CreateWebhook(resourceGroupName, accountName, name, runbookName, true, expiryTime, null),
                Times.Once());
        }
    }
}