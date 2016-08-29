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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class RemoveAzureRmAutoscaleSettingTests
    {
        private readonly RemoveAzureRmAutoscaleSettingCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAutoscaleOperations> insightsAutoscaleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse response;
        private string resourceGroup;
        private string settingName;

        public RemoveAzureRmAutoscaleSettingTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsAutoscaleOperationsMock = new Mock<IAutoscaleOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureRmAutoscaleSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            response = new AzureOperationResponse()
            {
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK,
            };

            insightsAutoscaleOperationsMock.Setup(f => f.DeleteSettingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse>(response))
                .Callback((string resourceGrp, string settingNm, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    settingName = settingNm;
                });

            insightsManagementClientMock.SetupGet(f => f.AutoscaleOperations).Returns(this.insightsAutoscaleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveAutoscaleSettingCommandParametersProcessing()
        {
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.Name = Utilities.Name;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.settingName);
        }
    }
}
