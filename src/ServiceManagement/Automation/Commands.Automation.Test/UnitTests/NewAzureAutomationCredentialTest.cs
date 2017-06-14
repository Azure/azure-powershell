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
using System.Management.Automation;
using System.Security;
using System;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class NewAzureAutomationCredentialTest : SMTestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private NewAzureAutomationCredential cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new NewAzureAutomationCredential
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void NewAzureAutomationCredentialByPathSuccessfull()
        {
            // Setup
            string accountName = "automation";
            string credentialName = "credential";
            string username = "testUser";
            string password = "password";
            string description = "desc";

            var secureString = new SecureString();
            Array.ForEach(password.ToCharArray(), secureString.AppendChar);
            secureString.MakeReadOnly();

            var value = new PSCredential(username, secureString);

            this.mockAutomationClient.Setup(
                f => f.CreateCredential(accountName, credentialName, username, password, description));

            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Name = credentialName;
            this.cmdlet.Description = description;
            this.cmdlet.Value = value;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.CreateCredential(accountName, credentialName, username, password, description), Times.Once());
        }
    }
}
