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
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
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

        DiagnosticSettingsResource ExistingSetting;
        DiagnosticSettingsResource calledSettings = null;

        public SetDiagnosticSettingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            this.insightsDiagnosticsOperationsMock = new Mock<IDiagnosticSettingsOperations>();
            this.insightsManagementClientMock = new Mock<MonitorManagementClient>();
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new SetAzureRmDiagnosticSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };
            
            this.ExistingSetting = GetDefaultSetting();

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
                    .Returns((string a, DiagnosticSettingsResource x, string na, Dictionary<string, List<string>> b, CancellationToken c) =>
                    {
                        calledSettings = x;
                        return Task.FromResult(new AzureOperationResponse<DiagnosticSettingsResource>
                        {
                            Body = x
                        });
                    });

            insightsManagementClientMock.SetupGet(f => f.DiagnosticSettings).Returns(this.insightsDiagnosticsOperationsMock.Object);

            cmdlet.ResourceId = resourceId;
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

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSomeCategories()
        {
            cmdlet.Categories = new List<string> { "TestCategory1"};
            cmdlet.Enabled = false;
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.EnabledParamName] = false;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.Logs[0].Enabled = false;

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetSomeTimeGrains()
        {
            cmdlet.Timegrains = new List<string> { "PT1H" };
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
            cmdlet.MyInvocation.BoundParameters[SetAzureRmDiagnosticSettingCommand.ServiceBusRuleIdParamName] = null;
            cmdlet.ExecuteCmdlet();

            DiagnosticSettingsResource expectedSettings = GetDefaultSetting();
            expectedSettings.ServiceBusRuleId = null;

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

            VerifyCalledOnce();
            VerifySettings(expectedSettings, this.calledSettings);
        }

        private void VerifyCalledOnce()
        {
            insightsDiagnosticsOperationsMock.Verify(x => x.CreateOrUpdateWithHttpMessagesAsync(
                resourceId,
                It.IsAny<DiagnosticSettingsResource>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, List<string>>>(),
                It.IsAny<CancellationToken>()),
                    Times.Once);
        }

        private void VerifySettings(
            DiagnosticSettingsResource expectedSettings,
            DiagnosticSettingsResource actualSettings)
        {
            Assert.Equal(expectedSettings.StorageAccountId, actualSettings.StorageAccountId);
            Assert.Equal(expectedSettings.ServiceBusRuleId, actualSettings.ServiceBusRuleId);
            Assert.Equal(expectedSettings.WorkspaceId, actualSettings.WorkspaceId);
            if (expectedSettings.Logs == null)
            {
                Assert.Null(actualSettings.Logs);
            }
            else
            {
                Assert.Equal(expectedSettings.Logs.Count, actualSettings.Logs.Count);
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
                Assert.Equal(expectedSettings.Metrics.Count, actualSettings.Metrics.Count);
                for (int i = 0; i < expectedSettings.Metrics.Count; i++)
                {
                    var expected = expectedSettings.Metrics[i];
                    var actual = actualSettings.Metrics[i];
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

        private DiagnosticSettingsResource GetDefaultSetting()
        {
            return new DiagnosticSettingsResource
            {
                StorageAccountId = storageAccountId,
                ServiceBusRuleId = serviceBusRuleId,
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
                        TimeGrain = TimeSpan.FromMinutes(1),
                        Enabled = false
                    },
                    new MetricSettings
                    {
                        TimeGrain = TimeSpan.FromHours(1),
                        Enabled = true
                    }
                },
                EventHubAuthorizationRuleId = eventHubAuthRuleId
            };
        }
    }
}
