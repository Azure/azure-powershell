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
        private Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResource> response;
        private Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResourceCollection> multipleResponse;
        DiagnosticSettingsResource calledSettings = null;

        private string resourceIdIn;
        private string settingName;

        public RemoveDiagnosticSettingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            this.insightsDiagnosticsOperationsMock = new Mock<IDiagnosticSettingsOperations>();
            this.insightsManagementClientMock = new Mock<MonitorManagementClient>() { CallBase = true };
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new RemoveAzureRmDiagnosticSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                MonitorManagementClient = insightsManagementClientMock.Object
            };

            var resource = new DiagnosticSettingsResource(name: "service")
            {
                
                EventHubName = "",
                EventHubAuthorizationRuleId = "",
                StorageAccountId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.storage/accounts/myaccount",
                WorkspaceId = "",
                Logs = new List<LogSettings>
                    {
                        new LogSettings
                        {
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 10,
                                Enabled = true
                            },
                            Category = "TestCategory1",
                            Enabled = true
                        },
                        new LogSettings
                        {
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 5,
                                Enabled = false
                            },
                            Category = "TestCategory2",
                            Enabled = false
                        }
                    },
                Metrics = new List<MetricSettings>
                    {
                        new MetricSettings
                        {
                            Category = "MetricCat1",
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 7,
                                Enabled = false
                            },
                            TimeGrain = TimeSpan.FromMinutes(1),
                            Enabled = false
                        },
                        new MetricSettings
                        {
                            Category = "MetricCat2",
                            RetentionPolicy = new RetentionPolicy()
                            {
                                Days = 3,
                                Enabled = true
                            },
                            TimeGrain = TimeSpan.FromHours(1)
                        }
                    }
            };

            response = new Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResource>()
            {
                RequestId = Guid.NewGuid().ToString(),
                Response = new System.Net.Http.HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                },
                Body = resource
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
                            WorkspaceId = x.WorkspaceId
                        };
                        return Task.FromResult(new Rest.Azure.AzureOperationResponse<DiagnosticSettingsResource>
                        {
                            RequestId = Guid.NewGuid().ToString(),
                            Body = x,
                            Response = new System.Net.Http.HttpResponseMessage
                            {
                                StatusCode = System.Net.HttpStatusCode.OK
                            }
                        });
                    });

            insightsDiagnosticsOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResource>>(response))
                .Callback((string resourceId, string name, Dictionary<string, List<string>> headers, CancellationToken cancellationToken) =>
                {
                    resourceIdIn = resourceId;
                    this.settingName = name;
                });

            multipleResponse = new Microsoft.Rest.Azure.AzureOperationResponse<DiagnosticSettingsResourceCollection>()
            {
                Body = new DiagnosticSettingsResourceCollection(
                    value: new List<DiagnosticSettingsResource>() { resource })
            };

            insightsDiagnosticsOperationsMock.Setup(f => f.ListWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(multipleResponse))
                .Callback((string resourceId, Dictionary<string, List<string>> headers, CancellationToken cancellationToken) =>
                {
                    resourceIdIn = resourceId;
                    this.settingName = "service";
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
            cmdlet.ResourceId = ResourceId;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(ResourceId, resourceIdIn);
            Assert.Equal("service", settingName);

            cmdlet.ResourceId = ResourceId;
            cmdlet.Name = "MySetting";
            cmdlet.ExecuteCmdlet();

            Assert.Equal(ResourceId, resourceIdIn);
            Assert.Equal("MySetting", settingName);
        }
    }
}
