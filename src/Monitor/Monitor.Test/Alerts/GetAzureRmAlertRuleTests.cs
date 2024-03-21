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
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class GetAzureRmAlertRuleTests
    {
        private readonly GetAzureRmAlertRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IAlertRulesOperations> insightsAlertRuleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Rest.Azure.AzureOperationResponse<AlertRuleResource> singleResponse;
        private Rest.Azure.AzureOperationResponse<IEnumerable<AlertRuleResource>> listResponse;
        private string resourceGroup;
        private string ruleNameOrTargetUri;

        public GetAzureRmAlertRuleTests(ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsAlertRuleOperationsMock = new Mock<IAlertRulesOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmAlertRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            listResponse = new Rest.Azure.AzureOperationResponse<IEnumerable<AlertRuleResource>>
            {
                Body = Utilities.InitializeRuleListResponse(),
            };

            singleResponse = new Rest.Azure.AzureOperationResponse<AlertRuleResource>
            {
                Body = Utilities.InitializeRuleGetResponse()
            };

            insightsAlertRuleOperationsMock.Setup(f => f.ListByResourceGroupWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse<IEnumerable<AlertRuleResource>>>(listResponse))
                .Callback((string resourceGrp, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                });

            insightsAlertRuleOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse<AlertRuleResource>>(singleResponse))
                .Callback((string resourceGrp, string nameOrTargetUri, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    ruleNameOrTargetUri = nameOrTargetUri;
                });

            insightsManagementClientMock.SetupGet(f => f.AlertRules).Returns(this.insightsAlertRuleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAlertRuleCommandParametersProcessing()
        {
            // Setting required parameter
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                expectedResourceGroup: Utilities.ResourceGroup,
                resourceGroup: ref this.resourceGroup,
                nameOrTargetUri: ref this.ruleNameOrTargetUri);
        }
    }
}
