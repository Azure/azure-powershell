﻿// ----------------------------------------------------------------------------------
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
using Microsoft.Rest.Azure;
using Microsoft.Rest.Azure.OData;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class GetAzureRmAutoscaleSettingTests
    {
        private readonly GetAzureRmAutoscaleSettingCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAutoscaleSettingsOperations> insightsAutoscaleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private Microsoft.Rest.Azure.AzureOperationResponse<AutoscaleSettingResource> responseSimple;
        private Microsoft.Rest.Azure.AzureOperationResponse<IPage<AutoscaleSettingResource>> responsePage;
        private string resourceGroup;
        private string settingName;
        private ODataQuery<AutoscaleSettingResource> query = new ODataQuery<AutoscaleSettingResource>("");

        public GetAzureRmAutoscaleSettingTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            //ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsAutoscaleOperationsMock = new Mock<IAutoscaleSettingsOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetAzureRmAutoscaleSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            var responseObject = new AutoscaleSettingResource(id: "", location: "", profiles: null, autoscaleSettingResourceName: "")
                {
                    Name = "",
                    Tags = null,
                };

            responseSimple = new Microsoft.Rest.Azure.AzureOperationResponse<AutoscaleSettingResource>()
            {
                Body = responseObject
            };

            responsePage = new AzureOperationResponse<IPage<AutoscaleSettingResource>>()
            {
                Body = JsonConvert.DeserializeObject<Microsoft.Azure.Management.Insights.Models.Page<AutoscaleSettingResource>>(JsonConvert.SerializeObject(responseObject))
            };

            insightsAutoscaleOperationsMock.Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<AutoscaleSettingResource>>(responseSimple))
                .Callback((string resourceGrp, string settingNm, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    settingName = settingNm;
                });

            insightsAutoscaleOperationsMock.Setup(f => f.ListByResourceGroupWithHttpMessagesAsync(It.IsAny<string>(), It.IsAny<ODataQuery<AutoscaleSettingResource>>(), It.IsAny<Dictionary<string, List<string>>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<Microsoft.Rest.Azure.AzureOperationResponse<IPage<AutoscaleSettingResource>>>(responsePage))
                .Callback((string resourceGrp, ODataQuery<AutoscaleSettingResource> qry, Dictionary<string, List<string>> headers, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    query = qry;
                });

            insightsManagementClientMock.SetupGet(f => f.AutoscaleSettings).Returns(this.insightsAutoscaleOperationsMock.Object);
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
            Assert.True(this.query == null || string.IsNullOrWhiteSpace(this.query.Filter));

            // Calling GetSettingAsync
            this.resourceGroup = null;
            this.query = "";
            cmdlet.Name = Utilities.Name;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.settingName);
            // Assert.Equal(Utilities.ResourceUri, this.targetResourceUri);

            // Test deatiled output flag calling GetSettingAsync
            this.resourceGroup = null;
            this.settingName = null;
            cmdlet.DetailedOutput = true;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(Utilities.Name, this.settingName);
            //Assert.Equal(Utilities.ResourceUri, this.targetResourceUri);
        }
    }
}
