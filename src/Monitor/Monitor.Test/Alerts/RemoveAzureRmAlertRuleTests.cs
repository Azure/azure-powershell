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

using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Monitor;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class RemoveAzureRmAlertRuleTests
    {
        private readonly RemoveAzureRmAlertRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IAlertRulesOperations> insightsAlertRuleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Rest.Azure.AzureOperationResponse response;
        private string resourceGroup;
        private string ruleNameOrTargetUri;

        public RemoveAzureRmAlertRuleTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsAlertRuleOperationsMock = new Mock<IAlertRulesOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureRmAlertRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            response = new Rest.Azure.AzureOperationResponse()
            {
                RequestId = Guid.NewGuid().ToString(),
                Response = new System.Net.Http.HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK
                }                
            };

            insightsAlertRuleOperationsMock.Setup(f => f.DeleteWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse>(response))
                .Callback((string resourceGrp, string ruleName, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    ruleNameOrTargetUri = ruleName;
                });

            insightsManagementClientMock.SetupGet(f => f.AlertRules).Returns(this.insightsAlertRuleOperationsMock.Object);

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAlertRuleCommandParametersProcessing()
        {
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.Name = Utilities.Name;

            cmdlet.ExecuteCmdlet();
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.ruleNameOrTargetUri);
        }
    }
}
