﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Insights.ActionGroups;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    public class RemoveAzureRmActionGroupTests
    {
        private readonly RemoveAzureRmActionGroupCommand cmdlet;
        private readonly Mock<MonitorManagementClient> monitorClientMock;
        private readonly Mock<IActionGroupsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private string resourceGroup;
        private string name;

        public RemoveAzureRmActionGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActionGroupsOperations>();
            monitorClientMock = new Mock<MonitorManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureRmActionGroupCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = monitorClientMock.Object
            };

            insightsOperationsMock.Setup(f => f.DeleteWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse>(new Microsoft.Rest.Azure.AzureOperationResponse()))
                .Callback((string r, string n, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = r;
                    this.name = n;
                });

            monitorClientMock.SetupGet(f => f.ActionGroups).Returns(this.insightsOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveActionGroupCommandParametersProcessing()
        {
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Name = "group1";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("group1", this.name);
        }
    }
}