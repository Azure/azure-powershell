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

using Microsoft.Azure.Management.Monitor;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Insights.ScheduledQueryRules;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.Insights.Test.ScheduledQueryRules
{
    public class GetScheduledQueryRulesTests
    {
        private readonly GetScheduledQueryRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> monitorManagementClientMock;
        private readonly Mock<IScheduledQueryRulesOperations> sqrOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse<LogSearchRuleResource> responseSingle;
        private AzureOperationResponse<IEnumerable<LogSearchRuleResource>> responseList;
        private string resourceGroup;
        private string ruleName;
        IEnumerable<LogSearchRuleResource> retrieved = null;

        public GetScheduledQueryRulesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            sqrOperationsMock = new Mock<IScheduledQueryRulesOperations>();
            monitorManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetScheduledQueryRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = monitorManagementClientMock.Object
            };

            Source source = new Source();
            Schedule schedule = new Schedule();
            Action action = new Action();

            //ScheduledQueryRuleResource responseObject = new ScheduledQueryRuleResource(new LogSearchRuleResource(name: "alert2", location: "westus", source: source, schedule: schedule, action: action));
            LogSearchRuleResource responseObject = new LogSearchRuleResource(name: "alert2", location: "westus", source: source, schedule: schedule, action: action);

            responseSingle = new AzureOperationResponse<LogSearchRuleResource>()
            {
                Body = responseObject
            };

            responseList = new AzureOperationResponse<IEnumerable<LogSearchRuleResource>>()
            {
                Body = new List<LogSearchRuleResource> { responseObject }
            };

            sqrOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<LogSearchRuleResource>>(responseSingle))
                .Callback((string resourceGrp, string name, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.ruleName = name;
                    this.retrieved = new List<LogSearchRuleResource> {responseSingle.Body};
                });

            sqrOperationsMock.Setup(f => f.ListByResourceGroupWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<ODataQuery<LogSearchRuleResource>>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<LogSearchRuleResource>>>(responseList))
                .Callback((string resourceGrp, ODataQuery<LogSearchRuleResource> odataQuery, Dictionary<string, List<string>> customHeaders, CancellationToken cancellationToken) =>
                {
                    this.resourceGroup = resourceGrp;
                    this.retrieved = responseList.Body;
                });

            sqrOperationsMock.Setup(f => f.ListBySubscriptionWithHttpMessagesAsync(It.IsAny<ODataQuery<LogSearchRuleResource>>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse<IEnumerable<LogSearchRuleResource>>>(responseList))
                .Callback(() =>
                {
                    this.retrieved = responseList.Body;
                });

            monitorManagementClientMock.SetupGet(f => f.ScheduledQueryRules).Returns(this.sqrOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetScheduledQueryRuleCommandParametersProcessing()
        {
            // Get by subId
            cmdlet.ExecuteCmdlet();
            Assert.Single(this.retrieved);
            
            // Get by resource group
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.ExecuteCmdlet();

            Assert.Single(this.retrieved);
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Null(this.ruleName);
            
            // Get by name
            cmdlet.Name = Utilities.Name;
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.ExecuteCmdlet();

            Assert.Single(this.retrieved);
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.ruleName);
        }
    }
}
