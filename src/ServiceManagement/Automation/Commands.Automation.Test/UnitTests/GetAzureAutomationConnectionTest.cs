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
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationConnectionTest : SMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationConnection cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationConnection
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void GetAzureAutomationConnectionByNameSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string connectionName = "connection";

            this.mockAutomationClient.Setup(f => f.GetConnection(accountName, connectionName));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = connectionName;
            this.cmdlet.SetParameterSet("ByConnectionName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.GetConnection(accountName, connectionName), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationConnectionByAllSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string nextLink = string.Empty;

            this.mockAutomationClient.Setup(f => f.ListConnections(accountName, ref nextLink)).Returns((string a, string b) => new List<Connection>());

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListConnections(accountName, ref nextLink), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationConnectionByTypeSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string connectionTypeName = "connectionType";

            this.mockAutomationClient.Setup(f => f.ListConnectionsByType(accountName, connectionTypeName)).Returns((string a, string b) => new List<Connection>());

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.ConnectionTypeName = connectionTypeName;
            this.cmdlet.SetParameterSet("ByConnectionTypeName");
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListConnectionsByType(accountName, connectionTypeName), Times.Once());
        }
    }
}
