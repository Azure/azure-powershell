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

using Microsoft.Azure.Commands.Insights.Autoscale;
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

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class GetAzureRmAutoscaleSettingTests
    {
        private readonly GetAzureRmAutoscaleSettingCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAutoscaleOperations> insightsAutoscaleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AutoscaleSettingGetResponse response;
        private AutoscaleSettingListResponse responseList;
        private string resourceGroup;
        private string settingName;
        private string targetResourceUri = Utilities.ResourceUri;

        public GetAzureRmAutoscaleSettingTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsAutoscaleOperationsMock = new Mock<IAutoscaleOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmAutoscaleSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            response = new AutoscaleSettingGetResponse()
            {
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK,
                Id = "",
                Location = "",
                Name = "",
                Properties = null,
                Tags = null,
            };

            responseList = new AutoscaleSettingListResponse()
            {
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK,
                AutoscaleSettingResourceCollection = new AutoscaleSettingResourceCollection()
                {
                    Value = new List<AutoscaleSettingResource>()
                    {
                        new AutoscaleSettingResource(){
                                Id = "",
                                Location = "",
                                Name = "",
                                Properties = null,
                                Tags = null,
                            },
                    }
                }
            };

            insightsAutoscaleOperationsMock.Setup(f => f.GetSettingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AutoscaleSettingGetResponse>(response))
                .Callback((string resourceGrp, string settingNm, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    settingName = settingNm;
                });

            insightsAutoscaleOperationsMock.Setup(f => f.ListSettingsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AutoscaleSettingListResponse>(responseList))
                .Callback((string resourceGrp, string targetResourceId, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    targetResourceUri = targetResourceId;
                });

            insightsManagementClientMock.SetupGet(f => f.AutoscaleOperations).Returns(this.insightsAutoscaleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAutoscaleSettingCommandParametersProcessing()
        {
            // Calling ListSettingsAsync
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Null(this.settingName);
            Assert.Null(this.targetResourceUri);

            // Calling GetSettingAsync
            this.resourceGroup = null;
            this.targetResourceUri = Utilities.ResourceUri;
            cmdlet.Name = Utilities.Name;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.settingName);
            Assert.Equal(Utilities.ResourceUri, this.targetResourceUri);

            // Test deatiled output flag calling GetSettingAsync
            this.resourceGroup = null;
            this.settingName = null;
            cmdlet.DetailedOutput = true;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.settingName);
            Assert.Equal(Utilities.ResourceUri, this.targetResourceUri);
        }
    }
}
