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

using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Insights.ActionGroups;

namespace Microsoft.Azure.Commands.Insights.Test.ActionGroups
{
    public class GetAzureRmActionGroupTests
    {
        private readonly GetAzureRmActionGroupCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IActionGroupsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<ActionGroupResource> responseSimple;
        private AzureOperationResponse<IEnumerable<ActionGroupResource>> responsePage;
        private string resourceGroup;
        private string name;

        public GetAzureRmActionGroupTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActionGroupsOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmActionGroupCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            ActionGroupResource responseObject = ActionGroupsUtilities.CreateActionGroupResource(name: "actiongroup1", shortName: "ag1");

            responseSimple = new AzureOperationResponse<ActionGroupResource>()
            {
                Body = responseObject
            };

            responsePage = new AzureOperationResponse<IEnumerable<ActionGroupResource>>()
            {
                Body = new List<ActionGroupResource> { responseObject }
            };

            insightsOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<ActionGroupResource>>(responseSimple))
                .Callback((string resourceGrp, string name, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.name = name;
                });

            insightsOperationsMock.Setup(f => f.ListByResourceGroupWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<ActionGroupResource>>>(responsePage))
                .Callback((string resourceGrp, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                });

            insightsOperationsMock.Setup(f => f.ListBySubscriptionIdWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<ActionGroupResource>>>(responsePage))
                .Callback((Dictionary<string, List<string>> headers, CancellationToken t) =>
                { });

            insightsManagementClientMock.SetupGet(f => f.ActionGroups).Returns(this.insightsOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetActionGroupCommandParametersProcessing()
        {
            // Get by subId
            cmdlet.ExecuteCmdlet();

            // Get by resource group
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Null(this.name);

            // Get by name
            cmdlet.Name = Utilities.Name;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.name);

            // Error
            cmdlet.ResourceGroupName = "   ";
            cmdlet.Name = Utilities.Name;
            Assert.Throws<PSArgumentException>(() => cmdlet.ExecuteCmdlet());
        }
    }
}