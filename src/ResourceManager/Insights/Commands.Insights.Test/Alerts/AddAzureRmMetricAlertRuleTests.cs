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
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
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
    public class AddAzureRmMetricAlertRuleTests
    {
        private readonly AddAzureRmMetricAlertRuleCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAlertRulesOperations> insightsAlertRuleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Rest.Azure.AzureOperationResponse<AlertRuleResource> response;
        private string resourceGroup;
        private AlertRuleResource alertRuleResource;

        public AddAzureRmMetricAlertRuleTests(ITestOutputHelper output)
        {
            AzureSessionInitializer.InitializeAzureSession();
            ResourceManagerProfileProvider.InitializeResourceManagerProfile();
            //XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            insightsAlertRuleOperationsMock = new Mock<IAlertRulesOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new AddAzureRmMetricAlertRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            AlertRuleResource alertRuleResourceInput = new AlertRuleResource(alertRuleResourceName: "a name", location: null, isEnabled: true);
            response = new Rest.Azure.AzureOperationResponse<AlertRuleResource>()
            {
                Body = alertRuleResourceInput
            };

            insightsAlertRuleOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AlertRuleResource>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Rest.Azure.AzureOperationResponse<AlertRuleResource>>(response))
                .Callback((string resourceGrp, string name, AlertRuleResource alertRuleResourceIn, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    alertRuleResource = alertRuleResourceIn;
                });

            insightsManagementClientMock.SetupGet(f => f.AlertRules).Returns(this.insightsAlertRuleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureRmMetricAlertRuleCommandParametersProcessing()
        {
            // Test null actions
            cmdlet.Name = Utilities.Name;
            cmdlet.Location = "East US";
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.Operator = ConditionOperator.GreaterThan;
            cmdlet.Threshold = 1;
            cmdlet.TargetResourceId = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo";
            cmdlet.MetricName = "Requests";
            cmdlet.TimeAggregationOperator = TimeAggregationOperator.Total;
            cmdlet.Actions = null;
            cmdlet.WindowSize = TimeSpan.FromMinutes(10);

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: true,
                actionsCount: 0,
                threshold: 1,
                conditionOperator: ConditionOperator.GreaterThan,
                totalMinutes: 10,
                timeAggregationOperator: TimeAggregationOperator.Total,
                metricName: "Requests",
                resourceUri: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo");

            // Test null actions and disabled
            cmdlet.DisableRule = true;

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: false,
                actionsNull: true,
                actionsCount: 0,
                threshold: 1,
                conditionOperator: ConditionOperator.GreaterThan,
                totalMinutes: 10,
                timeAggregationOperator: TimeAggregationOperator.Total,
                metricName: "Requests",
                resourceUri: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo");

            // Test empty actions
            cmdlet.DisableRule = false;
            cmdlet.Actions = new List<RuleAction>();

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 0,
                threshold: 1,
                conditionOperator: ConditionOperator.GreaterThan,
                totalMinutes: 10,
                timeAggregationOperator: TimeAggregationOperator.Total,
                metricName: "Requests",
                resourceUri: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo");

            // Test non-empty actions (one action)
            List<string> eMails = new List<string>();
            eMails.Add("le@hypersoft.com");
            RuleAction ruleAction = new RuleEmailAction
            {
                SendToServiceOwners = true,
                CustomEmails = eMails
            };

            cmdlet.Actions.Add(ruleAction);

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 1,
                threshold: 1,
                conditionOperator: ConditionOperator.GreaterThan,
                totalMinutes: 10,
                timeAggregationOperator: TimeAggregationOperator.Total,
                metricName: "Requests",
                resourceUri: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo");

            // Test non-empty actions (two actions)
            var properties = new Dictionary<string, string>();
            properties.Add("hello", "goodbye");
            ruleAction = new RuleWebhookAction
            {
                ServiceUri = "http://bueno.net",
                Properties = properties
            };

            cmdlet.Actions.Add(ruleAction);

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 2,
                threshold: 1,
                conditionOperator: ConditionOperator.GreaterThan,
                totalMinutes: 10,
                timeAggregationOperator: TimeAggregationOperator.Total,
                metricName: "Requests",
                resourceUri: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo");

            // Test non-empty actions (two actions) and non-default window size
            cmdlet.WindowSize = TimeSpan.FromMinutes(300);

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 2,
                threshold: 1,
                conditionOperator: ConditionOperator.GreaterThan,
                totalMinutes: 300,
                timeAggregationOperator: TimeAggregationOperator.Total,
                metricName: "Requests",
                resourceUri: "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo");
        }

        private void AssertResult(
            string location,
            string tagsKey,
            bool isEnabled,
            bool actionsNull,
            int actionsCount,
            double threshold,
            ConditionOperator conditionOperator,
            double totalMinutes,
            TimeAggregationOperator timeAggregationOperator,
            string metricName,
            string resourceUri)
        {
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(location, this.alertRuleResource.Location);
            Assert.True(this.alertRuleResource.Tags.ContainsKey(tagsKey));

            Assert.NotNull(this.alertRuleResource);

            if (actionsNull)
            {
                Assert.Null(this.alertRuleResource.Actions);
            }
            else
            {
                Assert.NotNull(this.alertRuleResource.Actions);
                Assert.Equal(actionsCount, this.alertRuleResource.Actions.Count);
            }

            Assert.Equal(Utilities.Name, this.alertRuleResource.AlertRuleResourceName);
            Assert.Equal(isEnabled, this.alertRuleResource.IsEnabled);

            Assert.True(this.alertRuleResource.Condition is ThresholdRuleCondition);

            var condition = this.alertRuleResource.Condition as ThresholdRuleCondition;
            Assert.Equal(threshold, condition.Threshold);
            Assert.Equal(conditionOperator, condition.OperatorProperty);
            Assert.Equal(totalMinutes, ((TimeSpan)condition.WindowSize).TotalMinutes);
            Assert.Equal(timeAggregationOperator, condition.TimeAggregation);

            Assert.True(condition.DataSource is RuleMetricDataSource);

            var dataSource = condition.DataSource as RuleMetricDataSource;
            Assert.Equal(metricName, dataSource.MetricName);
            Assert.Equal(resourceUri, dataSource.ResourceUri);
        }
    }
}
