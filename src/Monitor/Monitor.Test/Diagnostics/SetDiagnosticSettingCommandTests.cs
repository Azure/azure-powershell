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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Insights.Diagnostics;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Diagnostics
{
    public class SetDiagnosticSettingCommandTests
    {
        private readonly SetAzureRmDiagnosticSettingCommand cmdlet;
        private readonly Mock<MonitorManagementClient> insightsManagementClientMock;
        private readonly Mock<IDiagnosticSettingsOperations> insightsDiagnosticsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private const string resourceId = "/subscriptions/123/resourcegroups/rg/providers/rp/resource/myresource";
        private const string storageAccountId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.storage/accounts/myaccount";
        private const string serviceBusRuleId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.eventhub/namespaces/ns/authorizationrules/ar";
        private const string workspaceId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.operationalinsights/workspaces/wp";
        private const string eventHubAuthRuleId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.eventhub/namespaces/ns/authorizationrules";
        private const string TempServiceName = "service";
        DiagnosticSettingsResource ExistingSetting;
        DiagnosticSettingsResource calledSettings = null;

        private Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResourceCollection> multipleResponse;

        public SetDiagnosticSettingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            this.insightsDiagnosticsOperationsMock = new Mock<IDiagnosticSettingsOperations>();
            this.insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new SetAzureRmDiagnosticSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };
            
            this.ExistingSetting = GetDefaultSetting(name: "service");

            insightsDiagnosticsOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()))
                   .Returns(Task.FromResult<AzureOperationResponse<DiagnosticSettingsResource>>(new AzureOperationResponse<DiagnosticSettingsResource>
                   {
                       Body = this.ExistingSetting
                   }));

            insightsDiagnosticsOperationsMock.Setup(f => f.CreateOrUpdateWithHttpMessagesAsync(
                It.IsAny<string>(),
                It.IsAny<DiagnosticSettingsResource>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()))
                    .Returns((string a, DiagnosticSettingsResource x, string name, Dictionary<string, List<string>> b, CancellationToken c) =>
                    {
                        calledSettings = new DiagnosticSettingsResource(name: name)
                        {
                            EventHubAuthorizationRuleId = x.EventHubAuthorizationRuleId,
                            EventHubName = x.EventHubName,
                            Logs = x.Logs,
                            Metrics = x.Metrics,
                            StorageAccountId = x.StorageAccountId,
                            WorkspaceId = x.WorkspaceId,
                            ServiceBusRuleId = x.ServiceBusRuleId,
                            LogAnalyticsDestinationType = x.LogAnalyticsDestinationType
                        };
                        return Task.FromResult(new AzureOperationResponse<DiagnosticSettingsResource>
                        {
                            Body = x
                        });
                    });

            multipleResponse = new Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResourceCollection>()
            {
                Body = new DiagnosticSettingsResourceCollection(
                    value: new List<DiagnosticSettingsResource>() { this.ExistingSetting })
            };

            insightsDiagnosticsOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns((string rsId, Dictionary<string, List<string>> head, CancellationToken token) =>
                {
                    // this.calledResourceId = resourceId;
                    // this.diagnosticSettingName = "service";
                    this.calledSettings = multipleResponse.Body.Value[0];
                    return Task.FromResult(multipleResponse);
                });

            insightsManagementClientMock.SetupGet(f => f.DiagnosticSettings).Returns(this.insightsDiagnosticsOperationsMock.Object);

            cmdlet.ResourceId = resourceId;

            // Setup Confirmation
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            commandRuntimeMock.Setup(f => f.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableStorage()
        {
            cmdlet.MyInvocation.BoundParameters["StorageAccountId"] = null;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.StorageAccountId = null;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetStorage()
        {
            string newStorageId = "otherstorage";
            cmdlet.StorageAccountId = newStorageId;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.StorageAccountIdParamName] = newStorageId;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.StorageAccountId = newStorageId;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetServiceBus()
        {
            string newServiceBusId = "otherservicebus";
            cmdlet.ServiceBusRuleId = newServiceBusId;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.ServiceBusRuleIdParamName] = newServiceBusId;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.ServiceBusRuleId = newServiceBusId;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);

            // Test with EventHubName
            cmdlet.ServiceBusRuleId = null;
            cmdlet.EventHubName = newServiceBusId;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EventHubNameParamName] = newServiceBusId;
            cmdlet.ExecuteCmdlet();
            expectedSettings.EventHubName = newServiceBusId;
            expectedSettings.ServiceBusRuleId = null;

            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetWorkspace()
        {
            string newWorkspaceId = "otherworkspace";
            cmdlet.WorkspaceId = newWorkspaceId;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.WorkspacetIdParamName] = newWorkspaceId;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.WorkspaceId = newWorkspaceId;
            expectedSettings.LogAnalyticsDestinationType = null;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetWorkspaceAndResourceSpecific()
        {
            string newWorkspaceId = "otherworkspace";
            cmdlet.WorkspaceId = newWorkspaceId;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.WorkspacetIdParamName] = newWorkspaceId;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.WorkspaceId = newWorkspaceId;
            expectedSettings.LogAnalyticsDestinationType = null;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);

            cmdlet.ExportToResourceSpecific = true;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.WorkspacetIdParamName] = newWorkspaceId;
            cmdlet.ExecuteCmdlet();

            expectedSettings.LogAnalyticsDestinationType = "Dedicated";

            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSomeCategories()
        {
            cmdlet.Category = new List<string> { "TestCategory1" };
            cmdlet.Enabled = false;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EnabledParamName] = false;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.Logs[0].Enabled = false;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings, suffix: "#1");

            // Testing the new categories must be known before the cmdlet can add them
            expectedSettings.Logs.Add(
                new LogSettings()
                {
                    Category = "TestCategory3",
                    RetentionPolicy = new RetentionPolicy
                    {
                        Days = 0,
                        Enabled = false
                    }
                });
            cmdlet.Category = new List<string> { "TestCategory3" };
            cmdlet.Enabled = false;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EnabledParamName] = false;
            cmdlet.ExecuteCmdlet();

            // Testing the new metric categories must be known before the cmdlet can add them
            expectedSettings.Metrics[0].Enabled = false;
            cmdlet.Category = null;
            cmdlet.MetricCategory = new List<string> { "MetricCat1" };
            cmdlet.Enabled = false;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EnabledParamName] = false;
            cmdlet.ExecuteCmdlet();

            VerifySettings(expectedSettings, this.calledSettings, suffix: "#2");

            // Testing the new categories must be known before the cmdlet can add them
            cmdlet.MetricCategory = new List<string> { "MetricCat3" };
            cmdlet.Enabled = false;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EnabledParamName] = false;
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSomeTimeGrains()
        {
            cmdlet.Timegrain = new List<string> { "PT1H" };
            cmdlet.Enabled = false;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EnabledParamName] = false;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.Metrics[1].Enabled = false;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableEventHub()
        {
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EventHubRuleIdParamName] = null;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableWorkspace()
        {
            cmdlet.MyInvocation.BoundParameters["WorkspaceId"] = null;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.WorkspaceId = null;
            expectedSettings.LogAnalyticsDestinationType = null;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InputObjectTest()
        {
            DiagnosticSettingsResource expectedSettings = GetDefaultSetting(id: "nothing/diagnosticSettings/");

            cmdlet.InputObject =new OutputClasses.PSServiceDiagnosticSettings(expectedSettings);
            cmdlet.ResourceId = resourceId;
            cmdlet.ExecuteCmdlet();

            // VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);

            expectedSettings = GetDefaultSetting(name: "myName", id: "nothing/diagnosticSettings/");
            cmdlet.InputObject = new OutputClasses.PSServiceDiagnosticSettings(expectedSettings);
            cmdlet.ResourceId = resourceId;
            cmdlet.Name = "myName";
            cmdlet.ExecuteCmdlet();

            // VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
            Assert.Equal(expectedSettings.Name, this.calledSettings.Name);
        }

        private void VerifyCalledOnce()
        {
            insightsDiagnosticsOperationsMock.Verify(x => x.CreateOrUpdateWithHttpMessagesAsync(
                resourceId,
                It.IsAny<DiagnosticSettingsResource>(),
                TempServiceName,
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        private void VerifySettings(
            DiagnosticSettingsResource expectedSettings,
            DiagnosticSettingsResource actualSettings,
            string suffix = "")
        {
            Assert.Equal(expectedSettings.StorageAccountId, actualSettings.StorageAccountId);
            Assert.Equal(expectedSettings.EventHubName, actualSettings.EventHubName);
            Assert.Equal(expectedSettings.WorkspaceId, actualSettings.WorkspaceId);
            Assert.Equal(expectedSettings.LogAnalyticsDestinationType, actualSettings.LogAnalyticsDestinationType);
            if (expectedSettings.Logs == null)
            {
                Assert.Null(actualSettings.Logs);
            }
            else
            {
                Assert.True(expectedSettings.Logs.Count == actualSettings.Logs.Count, string.Format("Expected: {0}, Actual: {1}, no the same number of Log settings {2}", expectedSettings.Logs.Count, actualSettings.Logs.Count, suffix));
                for (int i = 0; i < expectedSettings.Logs.Count; i++)
                {
                    var expected = expectedSettings.Logs[i];
                    var actual = actualSettings.Logs[i];
                    Assert.Equal(expected.Category, actual.Category);
                    Assert.Equal(expected.Enabled, actual.Enabled);
                    VerifyRetentionPolicy(expected.RetentionPolicy, actual.RetentionPolicy);
                }
            }

            if (expectedSettings.Metrics == null)
            {
                Assert.Null(actualSettings.Metrics);
            }
            else
            {
                Assert.True(expectedSettings.Metrics.Count == actualSettings.Metrics.Count, string.Format("Expected: {0}, Actual: {1}, no the same number of Metric settings {2}", expectedSettings.Metrics.Count, actualSettings.Metrics.Count, suffix));
                for (int i = 0; i < expectedSettings.Metrics.Count; i++)
                {
                    var expected = expectedSettings.Metrics[i];
                    var actual = actualSettings.Metrics[i];
                    Assert.Equal(expected.Category, actual.Category);
                    Assert.Equal(expected.TimeGrain, actual.TimeGrain);
                    Assert.Equal(expected.Enabled, actual.Enabled);
                    VerifyRetentionPolicy(expected.RetentionPolicy, actual.RetentionPolicy);
                }
            }
        }

        private static void VerifyRetentionPolicy(RetentionPolicy expected, RetentionPolicy actual)
        {
            if (expected == null)
            {
                Assert.Null(actual);
            }
            else
            {
                Assert.Equal(expected.Days, actual.Days);
                Assert.Equal(expected.Enabled, actual.Enabled);
            }
        }

        private DiagnosticSettingsResource GetDefaultSetting(string name = "NoName", string id = "/diagnosticSettings/")
        {
            return new DiagnosticSettingsResource(name: name ?? "NoName", id: (id ?? "/diagnosticSettings/") + name ?? "NoName")
            {
                StorageAccountId = storageAccountId,
                EventHubName = serviceBusRuleId,
                WorkspaceId = workspaceId,
                Logs = new List<LogSettings>
                {
                    new LogSettings
                    {
                        Category = "TestCategory1",
                        Enabled = true
                    },
                    new LogSettings
                    {
                        Category = "TestCategory2",
                        Enabled = false
                    }
                },
                Metrics = new List<MetricSettings>
                {
                    new MetricSettings
                    {
                        Category = "MetricCat1",
                        TimeGrain = TimeSpan.FromMinutes(1),
                        Enabled = false
                    },
                    new MetricSettings
                    {
                        Category = "MetricCat2",
                        TimeGrain = TimeSpan.FromHours(1),
                        Enabled = true
                    }
                },
                EventHubAuthorizationRuleId = eventHubAuthRuleId
            };
        }
    }
}
