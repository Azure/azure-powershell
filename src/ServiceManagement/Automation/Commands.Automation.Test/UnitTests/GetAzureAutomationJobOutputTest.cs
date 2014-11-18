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
using Microsoft.Azure.Commands.Automation.Cmdlet;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;

namespace Microsoft.Azure.Commands.Automation.Test.UnitTests
{
    [TestClass]
    public class GetAzureAutomationJobOutputTest : TestBase
    {
        private Mock<IAutomationClient> mockAutomationClient;

        private MockCommandRuntime mockCommandRuntime;

        private GetAzureAutomationJobOutput cmdlet;

        [TestInitialize]
        public void SetupTest()
        {
            this.mockAutomationClient = new Mock<IAutomationClient>();
            this.mockCommandRuntime = new MockCommandRuntime();
            this.cmdlet = new GetAzureAutomationJobOutput
                              {
                                  AutomationClient = this.mockAutomationClient.Object,
                                  CommandRuntime = this.mockCommandRuntime
                              };
        }

        [TestMethod]
        public void GetAzureAutomationJobOutputStreamAnySuccessfull()
        {
            // Setup
            string accountName = "automation";
            string stream = Constants.JobOutputParameter.Any;
            DateTime startTime = default(DateTime);
            var jobId = new Guid();

            this.mockAutomationClient.Setup(f => f.ListJobStreamItems(accountName, jobId, startTime, null));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = jobId;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.Stream = stream;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobStreamItems(accountName, jobId, startTime, null), Times.Once());
        }

        [TestMethod]
        public void GetAzureAutomationJobOutputStreamDebugSuccessfull()
        {
            // Setup
            string accountName = "automation";
            DateTime startTime = default(DateTime);
            string stream = Constants.JobOutputParameter.Debug;
            var jobId = new Guid();

            this.mockAutomationClient.Setup(f => f.ListJobStreamItems(accountName, jobId, startTime, stream));

            // Test
            this.cmdlet.AutomationAccountName = accountName;
            this.cmdlet.Id = jobId;
            this.cmdlet.StartTime = startTime;
            this.cmdlet.Stream = stream;
            this.cmdlet.ExecuteCmdlet();

            // Assert
            this.mockAutomationClient.Verify(f => f.ListJobStreamItems(accountName, jobId, startTime, stream), Times.Once());
        }
    }
}
