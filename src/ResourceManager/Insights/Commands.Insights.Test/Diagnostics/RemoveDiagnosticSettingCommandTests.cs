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
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.Diagnostics;
using Microsoft.Azure.Management.Monitor.Management;

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Diagnostics
{
    public class RemoveDiagnosticSettingCommandTests
    {
        private readonly RemoveAzureRmDiagnosticSettingCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IDiagnosticSettingsOperations> insightsDiagnosticsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private const string ResourceId = "/subscriptions/123/resourcegroups/rg/providers/rp/resource/myresource";

        private string resourceIdIn;
        private string settingName;

        public RemoveDiagnosticSettingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            this.insightsDiagnosticsOperationsMock = new Mock<IDiagnosticSettingsOperations>();
            this.insightsManagementClientMock = new Mock<MonitorManagementClient>();
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new RemoveAzureRmDiagnosticSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            insightsDiagnosticsOperationsMock.Setup(f => f.DeleteWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()))
                   .Returns(Task.FromResult(new Rest.Azure.AzureOperationResponse
                   {
                       RequestId = "111-222"
                   }))
                   .Callback((string resourceId, string settingName, Dictionary<string, List<string>> headers, CancellationToken t) =>
                   {
                       resourceIdIn = resourceId;
                       this.settingName = settingName;
                   });

            insightsManagementClientMock.SetupGet(f => f.DiagnosticSettings).Returns(this.insightsDiagnosticsOperationsMock.Object);

            cmdlet.ResourceId = ResourceId;

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveSettingTest()
        {
            cmdlet.Name = "MySetting";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(ResourceId, resourceIdIn);
            Assert.Equal("MySetting", settingName);
        }
    }
}
