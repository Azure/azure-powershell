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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class AddAzureRmWebtestAlertRuleTests
    {
        private readonly AddAzureRmWebtestAlertRuleCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IAlertRulesOperations> insightsAlertRuleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Rest.Azure.AzureOperationResponse<AlertRuleResource> response;
        private string resourceGroup;
        private AlertRuleResource createOrUpdatePrms;

        public AddAzureRmWebtestAlertRuleTests(ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            TestExecutionHelpers.SetUpSessionAndProfile();
            insightsAlertRuleOperationsMock = new Mock<IAlertRulesOperations>();
            insightsManagementClientMock = new Mock<MonitorManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new AddAzureRmWebtestAlertRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            AlertRuleResource alertRuleResourceInput = new AlertRuleResource()
            {
                Location = null, 
                IsEnabled = true, 
                AlertRuleResourceName = "a name"
            };

            response = new Rest.Azure.AzureOperationResponse<AlertRuleResource>()
            {
                Body = alertRuleResourceInput
            };

            insightsAlertRuleOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AlertRuleResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse<AlertRuleResource>>(response))
                .Callback((string resourceGrp, string name, AlertRuleResource createOrUpdateParams, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    createOrUpdatePrms = createOrUpdateParams;
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
        public void AddAzureRmWebtestAlertRuleCommandParametersProcessing()
        {
            // Test null actions
            cmdlet.Name = Utilities.Name;
            cmdlet.Location = "East US";
            cmdlet.ResourceGroupName = Utilities.ResourceGroup;
            cmdlet.FailedLocationCount = 10;
            cmdlet.Action = null;
            cmdlet.WindowSize = TimeSpan.FromMinutes(15);

            cmdlet.ExecuteCmdlet();

            this.AssertResults(
                location: "East US",
                tagsKey: "hidden-link:",
                isEnabled: true,
                actionsNull: true,
                actionsCount: 0,
                failedLocationCount: 10,
                totalMinutes: 15);

            // Test null actions and disabled
            cmdlet.DisableRule = true;

            cmdlet.ExecuteCmdlet();

            this.AssertResults(
                location: "East US",
                tagsKey: "hidden-link:",
                isEnabled: false,
                actionsNull: true,
                actionsCount: 0,
                failedLocationCount: 10,
                totalMinutes: 15);

            // Test empty actions
            cmdlet.DisableRule = false;
            cmdlet.Action = new List<RuleAction>();

            cmdlet.ExecuteCmdlet();

            this.AssertResults(
                location: "East US",
                tagsKey: "hidden-link:",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 0,
                failedLocationCount: 10,
                totalMinutes: 15);

            // Test non-empty actions (one action)
            List<string> eMails = new List<string>();
            eMails.Add("le@hypersoft.com");
            RuleAction ruleAction = new RuleEmailAction
            {
                SendToServiceOwners = true,
                CustomEmails = eMails
            };

            cmdlet.Action.Add(ruleAction);

            cmdlet.ExecuteCmdlet();

            this.AssertResults(
                location: "East US",
                tagsKey: "hidden-link:",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 1,
                failedLocationCount: 10,
                totalMinutes: 15);

            // Test non-empty actions (two actions)
            var properties = new Dictionary<string, string>();
            properties.Add("hello", "goodbye");
            ruleAction = new RuleWebhookAction
            {
                ServiceUri = "http://bueno.net",
                Properties = properties
            };

            cmdlet.Action.Add(ruleAction);

            cmdlet.ExecuteCmdlet();

            this.AssertResults(
                location: "East US",
                tagsKey: "hidden-link:",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 2,
                failedLocationCount: 10,
                totalMinutes: 15);

            // Test non-empty actions (two actions) and non-default window size
            cmdlet.WindowSize = TimeSpan.FromMinutes(300);

            cmdlet.ExecuteCmdlet();

            this.AssertResults(
                location: "East US",
                tagsKey: "hidden-link:",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 2,
                failedLocationCount: 10,
                totalMinutes: 300);
        }

        private void AssertResults(string location, string tagsKey, bool isEnabled, bool actionsNull, int actionsCount, int failedLocationCount, double totalMinutes)
        {
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(location, this.createOrUpdatePrms.Location);
            Assert.True(this.createOrUpdatePrms.Tags.ContainsKey(tagsKey));

            Assert.NotNull(this.createOrUpdatePrms);
            if (actionsNull)
            {
                Assert.Null(this.createOrUpdatePrms.Actions);
            }
            else
            {
                Assert.NotNull(this.createOrUpdatePrms.Actions);
                Assert.Equal(actionsCount, this.createOrUpdatePrms.Actions.Count);
            }

            Assert.Equal(Utilities.Name, this.createOrUpdatePrms.AlertRuleResourceName);
            Assert.Equal(isEnabled, this.createOrUpdatePrms.IsEnabled);
            Assert.True(this.createOrUpdatePrms.Condition is LocationThresholdRuleCondition);

            var condition = this.createOrUpdatePrms.Condition as LocationThresholdRuleCondition;
            Assert.Equal(failedLocationCount, condition.FailedLocationCount);
            Assert.Equal(totalMinutes, ((TimeSpan)condition.WindowSize).TotalMinutes);

            // This is probably unnecessary
            Assert.True(condition.DataSource is RuleMetricDataSource);
            var dataSource = condition.DataSource as RuleMetricDataSource;
            Assert.Null(dataSource.MetricName);
            Assert.Null(dataSource.ResourceUri);
        }
    }
}
