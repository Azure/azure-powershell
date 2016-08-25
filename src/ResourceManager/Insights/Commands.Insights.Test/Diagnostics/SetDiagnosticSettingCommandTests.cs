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

using Microsoft.Azure.Commands.Insights.Diagnostics;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Insights.Test.Diagnostics
{
    public class SetDiagnosticSettingCommandTests
    {
        private readonly SetAzureRmDiagnosticSettingCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IServiceDiagnosticSettingsOperations> insightsDiagnosticsOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private ServiceDiagnosticSettingsGetResponse response;
        private const string resourceId = "/subscriptions/123/resourcegroups/rg/providers/rp/resource/myresource";
        private const string storageAccountId = "/subscriptions/123/resourcegroups/rg/providers/microsoft.storage/accounts/myaccount";
        private string calledResourceId;
        ServiceDiagnosticSettingsPutParameters calledPutParameters;

        public SetDiagnosticSettingCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsDiagnosticsOperationsMock = new Mock<IServiceDiagnosticSettingsOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetAzureRmDiagnosticSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            response = new ServiceDiagnosticSettingsGetResponse
            {
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK,
                Properties = new ServiceDiagnosticSettings
                {
                    StorageAccountId = storageAccountId,
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
                    }
                }
            };

            insightsDiagnosticsOperationsMock.Setup(f => f.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<ServiceDiagnosticSettingsGetResponse>(response))
                .Callback((string resourceId) =>
                {
                    this.calledResourceId = resourceId;
                });

            insightsDiagnosticsOperationsMock.Setup(f => f.PutAsync(It.IsAny<string>(), It.IsAny<ServiceDiagnosticSettingsPutParameters>()))
                .Returns(Task.FromResult<EmptyResponse>(new EmptyResponse()))
                .Callback((string resourceId, ServiceDiagnosticSettingsPutParameters putParameters) =>
                {
                    this.calledResourceId = resourceId;
                    this.calledPutParameters = putParameters;
                });

            insightsManagementClientMock.SetupGet(f => f.ServiceDiagnosticSettingsOperations).Returns(this.insightsDiagnosticsOperationsMock.Object);
        }
    }
}
