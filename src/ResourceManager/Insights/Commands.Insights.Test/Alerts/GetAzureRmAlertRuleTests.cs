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
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
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
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAlertOperations> insightsAlertRuleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private RuleGetResponse singleResponse;
        private RuleListResponse listResponse;
        private string resourceGroup;
        private string ruleNameOrTargetUri;

        public GetAzureRmAlertRuleTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            insightsAlertRuleOperationsMock = new Mock<IAlertOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmAlertRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            listResponse = Utilities.InitializeRuleListResponse();
            singleResponse = Utilities.InitializeRuleGetResponse();

            insightsAlertRuleOperationsMock.Setup(f => f.ListRulesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<RuleListResponse>(listResponse))
                .Callback((string resourceGrp, string nameOrTargetUri, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    ruleNameOrTargetUri = nameOrTargetUri;
                });

            insightsAlertRuleOperationsMock.Setup(f => f.GetRuleAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<RuleGetResponse>(singleResponse))
                .Callback((string resourceGrp, string nameOrTargetUri, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    ruleNameOrTargetUri = nameOrTargetUri;
                });

            insightsManagementClientMock.SetupGet(f => f.AlertOperations).Returns(this.insightsAlertRuleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAlertRuleCommandParametersProcessing()
        {
            // Setting required parameter
            cmdlet.ResourceGroup = Utilities.ResourceGroup;

            Utilities.ExecuteVerifications(
                cmdlet: cmdlet,
                expectedResourceGroup: Utilities.ResourceGroup,
                resourceGroup: ref this.resourceGroup,
                nameOrTargetUri: ref this.ruleNameOrTargetUri);
        }
    }
}
