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

using Hyak.Common;
using Microsoft.Azure.Commands.Insights.Autoscale;
using Microsoft.Azure.Commands.Insights.OutputClasses;
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
    public class AddAzureRmAutoscaleSettingTests
    {
        private readonly AddAzureRmAutoscaleSettingCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAutoscaleOperations> insightsAutoscaleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse response;
        private string resourceGroup;
        private string settingName;
        private AutoscaleSettingCreateOrUpdateParameters createOrUpdatePrms;

        public AddAzureRmAutoscaleSettingTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            insightsAutoscaleOperationsMock = new Mock<IAutoscaleOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new AddAzureRmAutoscaleSettingCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            response = new AzureOperationResponse()
            {
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK,
            };

            insightsAutoscaleOperationsMock.Setup(f => f.CreateOrUpdateSettingAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<AutoscaleSettingCreateOrUpdateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse>(response))
                .Callback((string resourceGrp, string settingNm, AutoscaleSettingCreateOrUpdateParameters createOrUpdateParams, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    settingName = settingNm;
                    createOrUpdatePrms = createOrUpdateParams;
                });

            insightsManagementClientMock.SetupGet(f => f.AutoscaleOperations).Returns(this.insightsAutoscaleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAutoscaleSettingCommandParametersProcessing()
        {
            var spec = this.CreateCompleteSpec(location: "East US", name: "SettingName", profiles: null);
            var autoscaleRules = new List<ScaleRule> { this.CreateAutoscaleRule("IncommingReq") };
            var autoscaleProfile = new List<AutoscaleProfile> { this.CreateAutoscaleProfile(autoscaleRules: autoscaleRules, fixedDate: true) };

            // Testing with a complete spec as parameter (Update semantics)
            // Add-AutoscaleSetting -SettingSpec <AutoscaleSettingResource> -ResourceGroup <String> [-DisableSetting [<SwitchParameter>]] [-AutoscaleProfiles <List[AutoscaleProfile]>] [-Profile <AzureSMProfile>] [<CommonParameters>]
            // Add-AutoscaleSetting -SettingSpec $spec -ResourceGroup $Utilities.ResourceGroup
            // A NOP
            cmdlet.SettingSpec = spec;
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("SettingName", this.settingName);
            Assert.NotNull(this.createOrUpdatePrms);

            // Add-AutoscaleSetting -SettingSpec <AutoscaleSettingResource> -ResourceGroup <String> [-DisableSetting [<SwitchParameter>]] [-AutoscaleProfiles <List[AutoscaleProfile]>] [-Profile <AzureSMProfile>] [<CommonParameters>]
            // Add-AutoscaleSetting -SettingSpec $spec -ResourceGroup $Utilities.ResourceGroup -DisableSetting
            // Disable the setting
            cmdlet.DisableSetting = true;
            cmdlet.ExecuteCmdlet();

            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal("SettingName", this.settingName);
            Assert.NotNull(this.createOrUpdatePrms);

            // Add-AutoscaleSetting -SettingSpec <AutoscaleSettingResource> -ResourceGroup <String> [-DisableSetting [<SwitchParameter>]] [-AutoscaleProfiles <List[AutoscaleProfile]>] [-Profile <AzureSMProfile>] [<CommonParameters>]
            // Adding a profile
            cmdlet.AutoscaleProfiles = autoscaleProfile;
            cmdlet.ExecuteCmdlet();

            // Add-AutoscaleSetting -Location <String> -Name <String> -ResourceGroup <String> [-DisableSetting [<SwitchParameter>]] [-AutoscaleProfiles <List[AutoscaleProfile]>] -TargetResourceId <String> [-Profile <AzureSMProfile>] [<CommonParameters>]
            cmdlet.SettingSpec = null;
            cmdlet.Name = "SettingName";
            cmdlet.Location = "East US";
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.TargetResourceId = Utilities.ResourceUri;
            cmdlet.ExecuteCmdlet();

            var eMailNotification = new EmailNotification
            {
                CustomEmails = null,
            };

            var notification = new AutoscaleNotification
            {
                Email = eMailNotification,
                Operation = "Scale",
                Webhooks = null
            };

            cmdlet.Notifications = new List<AutoscaleNotification> { notification };
            cmdlet.ExecuteCmdlet();
        }

        private ScaleRule CreateAutoscaleRule(string metricName = null)
        {
            var autocaseRuleCmd = new NewAzureRmAutoscaleRuleCommand
            {
                MetricName = metricName ?? "Requests",
                MetricResourceId = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                Operator = ComparisonOperationType.GreaterThan,
                MetricStatistic = MetricStatisticType.Average,
                Threshold = 10,
                TimeGrain = TimeSpan.FromMinutes(1),
                ScaleActionCooldown = TimeSpan.FromMinutes(5),
                ScaleActionDirection = ScaleDirection.Increase,
                ScaleActionScaleType = ScaleType.ChangeCount,
                ScaleActionValue = "1"
            };

            return autocaseRuleCmd.CreateSettingRule();
        }

        private AutoscaleProfile CreateAutoscaleProfile(List<ScaleRule> autoscaleRules = null, bool fixedDate = true)
        {
            var autoscaleProfileCmd = new NewAzureRmAutoscaleProfileTests();

            autoscaleProfileCmd.InitializeAutoscaleProfile(autoscaleRules);
            if (fixedDate)
            {
                autoscaleProfileCmd.InitializeForFixedDate();
            }
            else
            {
                autoscaleProfileCmd.InitializeForRecurrentSchedule();
            }

            return autoscaleProfileCmd.Cmdlet.CreateSettingProfile();
        }

        private PSAutoscaleSetting CreateCompleteSpec(string location, string name, List<AutoscaleProfile> profiles = null)
        {
            if (profiles == null)
            {
                profiles = new List<AutoscaleProfile>() { this.CreateAutoscaleProfile() };
            }

            var settingProperty = new AutoscaleSetting
            {
                Name = name,
                Enabled = true,
                Profiles = profiles,
                TargetResourceUri = Utilities.ResourceUri
            };

            var setting = new AutoscaleSettingResource
            {
                Location = location,
                Name = name,
                Properties = new PSAutoscaleSettingProperty(settingProperty),
                Tags = new LazyDictionary<string, string>()
            };

            return new PSAutoscaleSetting(setting);
        }
    }
}
