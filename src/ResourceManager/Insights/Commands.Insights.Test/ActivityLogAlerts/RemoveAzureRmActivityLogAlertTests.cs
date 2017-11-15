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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Insights.ActivityLogAlert;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;

namespace Microsoft.Azure.Commands.Insights.Test.ActivityLogAlerts
{
    public class RemoveAzureRmActivityLogAlertTests
    {
        private readonly RemoveAzureRmActivityLogAlertCommand cmdlet;
        private readonly Mock<MonitorManagementClient> monitorClientMock;
        private readonly Mock<IActivityLogAlertsOperations> insightsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private string resourceGroup;
        private string name;

        public RemoveAzureRmActivityLogAlertTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsOperationsMock = new Mock<IActivityLogAlertsOperations>();
            monitorClientMock = new Mock<MonitorManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureRmActivityLogAlertCommand()
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

            monitorClientMock.SetupGet(f => f.ActivityLogAlerts).Returns(this.insightsOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveActivityLogAlertCommandParametersProcessing()
        {
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Name = "alert1";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("alert1", this.name);

            cmdlet.Name = null;
            cmdlet.ResourceGroupName = null;
            var resource = new ActivityLogAlertResource(location: "Global", scopes: null, condition: null, name: "andy0307rule", actions: null, id: "subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-ActivityLogAlerts/providers/microsoft.insights/activityLogAlerts/andy0307rule")
            {
                Enabled = false
            };

            cmdlet.InputObject = new OutputClasses.PSActivityLogAlertResource(resource);
            cmdlet.ExecuteCmdlet();

            Assert.Equal("Default-ActivityLogAlerts", this.resourceGroup);
            Assert.Equal("andy0307rule", this.name);

            resource = new ActivityLogAlertResource(location: "Global", scopes: null, condition: null, name: "andy0307rule", actions: null, id: "//subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-ActivityLogAlerts/providers/microsoft.insights/activityLogAlerts/andy0307rule")
            {
                Enabled = false
            };

            cmdlet.InputObject = new OutputClasses.PSActivityLogAlertResource(resource);
            cmdlet.ExecuteCmdlet();

            Assert.Equal("Default-ActivityLogAlerts", this.resourceGroup);
            Assert.Equal("andy0307rule", this.name);

            cmdlet.InputObject = null;
            cmdlet.ResourceId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-ActivityLogAlerts/providers/microsoft.insights/activityLogAlerts/andy0307rule";
            cmdlet.ExecuteCmdlet();

            Assert.Equal("Default-ActivityLogAlerts", this.resourceGroup);
            Assert.Equal("andy0307rule", this.name);
        }
    }
}
