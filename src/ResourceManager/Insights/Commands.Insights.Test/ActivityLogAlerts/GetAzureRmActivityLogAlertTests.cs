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
using Microsoft.Azure.Commands.Insights.ActivityLogAlert;

namespace Microsoft.Azure.Commands.Insights.Test.ActivityLogAlerts
{
    public class GetAzureRmActivityLogAlertTests
    {
        private readonly GetAzureRmActivityLogAlertCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IActivityLogAlertsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<ActivityLogAlertResource> responseSimple;
        private AzureOperationResponse<IEnumerable<ActivityLogAlertResource>> responsePage;
        private string resourceGroup;
        private string name;

        public GetAzureRmActivityLogAlertTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActivityLogAlertsOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmActivityLogAlertCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            ActivityLogAlertResource responseObject = ActivityLogAlertsUtilities.CreateActivityLogAlertResource(location: "westus", name: "alert1");

            responseSimple = new AzureOperationResponse<ActivityLogAlertResource>()
            {
                Body = responseObject
            };

            responsePage = new AzureOperationResponse<IEnumerable<ActivityLogAlertResource>>()
            {
                Body = new List<ActivityLogAlertResource> { responseObject }
            };

            insightsOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<ActivityLogAlertResource>>(responseSimple))
                .Callback((string resourceGrp, string name, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.name = name;
                });

            insightsOperationsMock.Setup(f => f.ListByResourceGroupWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<ActivityLogAlertResource>>>(responsePage))
                .Callback((string resourceGrp, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    this.resourceGroup = resourceGrp;
                });

            insightsOperationsMock.Setup(f => f.ListBySubscriptionIdWithHttpMessagesAsync(It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<ActivityLogAlertResource>>>(responsePage))
                .Callback((Dictionary<string, List<string>> headers, CancellationToken t) =>
                {});

            insightsManagementClientMock.SetupGet(f => f.ActivityLogAlerts).Returns(this.insightsOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAutoscaleSettingCommandParametersProcessing()
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
        }
    }
}
