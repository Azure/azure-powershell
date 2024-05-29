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
using Microsoft.Azure.Commands.Insights.OutputClasses;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using Xunit;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class AddAzureRmMetricAlertRuleV2Tests : RMTestBase
    {
        private readonly AddAzureRmMetricAlertRuleV2Command _cmdlet;
        private readonly Mock<IMetricAlertsOperations> _insightsMetricAlertsOperationsMock;

        public AddAzureRmMetricAlertRuleV2Tests(ITestOutputHelper output)
        {
            var commandRuntimeMock = new Mock<ICommandRuntime>();
            var insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            _insightsMetricAlertsOperationsMock = new Mock<IMetricAlertsOperations>();
            _cmdlet = new AddAzureRmMetricAlertRuleV2Command()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            PopulateCmdletDefaultParameters();

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);


            _insightsMetricAlertsOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<MetricAlertResource>(),
                    It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string resourceGrp, string name, MetricAlertResource createOrUpdateParams, Dictionary<string, List<string>> u,
                    CancellationToken t) => new AzureOperationResponse<MetricAlertResource>()
                    {
                        Body = createOrUpdateParams
                    });

            insightsManagementClientMock.SetupGet(f => f.MetricAlerts).Returns(this._insightsMetricAlertsOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2ByTargetResourceIdAndActionGroupIdParametersProcessing()
        {
            _cmdlet.TargetResourceId = "resourceId";
            _cmdlet.ActionGroupId = new[] { "actionGroupId1", "actionGroupId2" };

            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Contains(_cmdlet.ActionGroupId[0], metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Contains(_cmdlet.ActionGroupId[1], metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Contains(_cmdlet.TargetResourceId, metricAlert.Scopes);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2ByTargetResourceScopeAndActionGroupParametersProcessing()
        {
            _cmdlet.TargetResourceScope = new[] { "resourceId1", "resourceId2" };
            _cmdlet.ActionGroup = new[] {
                new Microsoft.Azure.Management.Monitor.Management.Models.ActivityLogAlertActionGroup("actionGroupId1", null),
                new Microsoft.Azure.Management.Monitor.Management.Models.ActivityLogAlertActionGroup("actionGroupId2", null)
            };

            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Contains(_cmdlet.ActionGroup[0].ActionGroupId, metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Contains(_cmdlet.ActionGroup[1].ActionGroupId, metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Contains(_cmdlet.TargetResourceScope[0], metricAlert.Scopes);
                Assert.Contains(_cmdlet.TargetResourceScope[1], metricAlert.Scopes);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2ByTargetResourceScopeActionGroupAndActionGroupIdParametersProcessing()
        {
            _cmdlet.TargetResourceScope = new[] { "resourceId1", "resourceId2" };
            _cmdlet.ActionGroup = new[] {
                new Microsoft.Azure.Management.Monitor.Management.Models.ActivityLogAlertActionGroup("actionGroupId1", new Dictionary<string, string> {{"key1", "value1"}}),
                new Microsoft.Azure.Management.Monitor.Management.Models.ActivityLogAlertActionGroup("actionGroupId2", null)
            };

            _cmdlet.ActionGroupId = new[] { "actionGroupId1", "actionGroupId3" };

            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Contains(_cmdlet.ActionGroup[0].ActionGroupId, metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Contains(_cmdlet.ActionGroup[0].WebhookProperties, metricAlert.Actions.Select(action => action.WebHookProperties));
                Assert.Contains(_cmdlet.ActionGroup[1].ActionGroupId, metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Contains(_cmdlet.ActionGroupId[1], metricAlert.Actions.Select(action => action.ActionGroupId));
                Assert.Equal(3, metricAlert.Actions.Count);
                Assert.Contains(_cmdlet.TargetResourceScope[0], metricAlert.Scopes);
                Assert.Contains(_cmdlet.TargetResourceScope[1], metricAlert.Scopes);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2WithFalseAutoMitigateFlag()
        {
            _cmdlet.AutoMitigate = false;
            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Equal(false, metricAlert.AutoMitigate);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2WithTrueAutoMitigateFlag()
        {
            _cmdlet.AutoMitigate = true; ;
            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Equal(true, metricAlert.AutoMitigate);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2WithDefaultAutoMitigateFlag()
        {
            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Equal(true, metricAlert.AutoMitigate);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2WithWebtestConditionProcessing()
        {
            var webtestCriteria = new WebtestLocationAvailabilityCriteria("webTestId", "componentId", 4);
            _cmdlet.TargetResourceId = "webTestId";
            _cmdlet.Condition = new List<IPSMultiMetricCriteria>()
            {
                new PSWebtestLocationAvailabilityCriteria(webtestCriteria)
            };

            _cmdlet.ExecuteCmdlet();

            Func<MetricAlertResource, bool> verify = metricAlert =>
            {
                Assert.Contains($"hidden-link:{webtestCriteria.WebTestId}", metricAlert.Tags.Keys);
                Assert.Contains($"hidden-link:{webtestCriteria.ComponentId}", metricAlert.Tags.Keys);

                Assert.NotStrictEqual(webtestCriteria, metricAlert.Criteria);
                return true;
            };

            this._insightsMetricAlertsOperationsMock.Verify(o => o.CreateOrUpdateWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<MetricAlertResource>(r => verify(r)), It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewMetricAlertRuleV2WithTwoWebtestConditionsShouldThrow()
        {
            var webtestCriteria = new WebtestLocationAvailabilityCriteria("webTestId", "componentId", 4);
            _cmdlet.TargetResourceId = "webTestId";
            _cmdlet.Condition.Add(new PSWebtestLocationAvailabilityCriteria(webtestCriteria));

            Assert.Throws<PSInvalidOperationException>(() => _cmdlet.ExecuteCmdlet());
        }

        private void PopulateCmdletDefaultParameters()
        {
            // Setting required parameter
            _cmdlet.Name = "AlertRule";
            _cmdlet.ResourceGroupName = "Name";
            _cmdlet.WindowSize = new TimeSpan(0, 5, 0);
            _cmdlet.Frequency = new TimeSpan(0, 5, 0);
            _cmdlet.Severity = 4;
            _cmdlet.Condition = new List<IPSMultiMetricCriteria>()
            {
                new PSMetricCriteria(new MetricCriteria("name", "metricName", "Average", "GreaterThan", 12))
            };
        }
    }
}
