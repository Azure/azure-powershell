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
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
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
    public class AddAzureRmLogAlertRuleTests
    {
        private readonly AddAzureRmLogAlertRuleCommand cmdlet;
        private readonly Mock<InsightsManagementClient> insightsManagementClientMock;
        private readonly Mock<IAlertOperations> insightsAlertRuleOperationsMock;
        private Mock<ICommandRuntime> commandRuntimeMock;
        private AzureOperationResponse response;
        private string resourceGroup;
        private RuleCreateOrUpdateParameters createOrUpdatePrms;

        public AddAzureRmLogAlertRuleTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            insightsAlertRuleOperationsMock = new Mock<IAlertOperations>();
            insightsManagementClientMock = new Mock<InsightsManagementClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new AddAzureRmLogAlertRuleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                InsightsManagementClient = insightsManagementClientMock.Object
            };

            response = new AzureOperationResponse()
            {
                RequestId = Guid.NewGuid().ToString(),
                StatusCode = HttpStatusCode.OK,
            };

            insightsAlertRuleOperationsMock.Setup(f => f.CreateOrUpdateRuleAsync(It.IsAny<string>(), It.IsAny<RuleCreateOrUpdateParameters>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult<AzureOperationResponse>(response))
                .Callback((string resourceGrp, RuleCreateOrUpdateParameters createOrUpdateParams, CancellationToken t) =>
                {
                    resourceGroup = resourceGrp;
                    createOrUpdatePrms = createOrUpdateParams;
                });

            insightsManagementClientMock.SetupGet(f => f.AlertOperations).Returns(this.insightsAlertRuleOperationsMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAlertRuleCommandParametersProcessing()
        {
            // Null actions
            cmdlet.Name = Utilities.Name;
            cmdlet.Location = "East US";
            cmdlet.ResourceGroup = Utilities.ResourceGroup;
            cmdlet.TargetResourceId = "/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo";
            cmdlet.Actions = null;

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: true,
                actionsCount: 0);

            // Null actions and disabled
            cmdlet.DisableRule = true;

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: false,
                actionsNull: true,
                actionsCount: 0);

            // Empty actions
            cmdlet.DisableRule = false;
            cmdlet.Actions = new List<RuleAction>();

            cmdlet.ExecuteCmdlet();

            this.AssertResult(
                location: "East US",
                tagsKey: "hidden-link:/subscriptions/a93fb07c-6c93-40be-bf3b-4f0deba10f4b/resourceGroups/Default-Web-EastUS/providers/microsoft.web/sites/misitiooeltuyo",
                isEnabled: true,
                actionsNull: false,
                actionsCount: 0);

            // Non-empty actions (one action)
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
                actionsCount: 1);

            // Non-empty actions (two actions)
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
                actionsCount: 2);
        }

        private void AssertResult(
            string location,
            string tagsKey,
            bool isEnabled,
            bool actionsNull,
            int actionsCount
            )
        {
            Assert.Equal(Utilities.ResourceGroup, this.resourceGroup);
            Assert.Equal(location, this.createOrUpdatePrms.Location);
            Assert.True(this.createOrUpdatePrms.Tags.ContainsKey(tagsKey));

            Assert.NotNull(this.createOrUpdatePrms);

            if (actionsNull)
            {
                Assert.Null(this.createOrUpdatePrms.Properties.Actions);
            }
            else
            {
                Assert.NotNull(this.createOrUpdatePrms.Properties.Actions);
                Assert.Equal(actionsCount, this.createOrUpdatePrms.Properties.Actions.Count);
            }

            Assert.Equal(Utilities.Name, this.createOrUpdatePrms.Properties.Name);
            Assert.Equal(isEnabled, this.createOrUpdatePrms.Properties.IsEnabled);
        }
    }
}
