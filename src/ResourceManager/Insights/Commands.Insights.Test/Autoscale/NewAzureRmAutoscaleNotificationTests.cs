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
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Autoscale
{
    public class NewAzureRmAutoscaleNotificationTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmAutoscaleNotificationCommand Cmdlet { get; set; }

        public NewAzureRmAutoscaleNotificationTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAutoscaleNotificationCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmAutoscaleNotificationCommandParametersProcessing()
        {
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.SendEmailToSubscriptionAdministrator = true;
            Cmdlet.ExecuteCmdlet();

            Cmdlet.SendEmailToSubscriptionAdministrator = false;
            Cmdlet.SendEmailToSubscriptionCoAdministrators = true;
            Cmdlet.ExecuteCmdlet();

            Cmdlet.SendEmailToSubscriptionCoAdministrators = false;
            Cmdlet.CustomEmails = new string[0];
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.CustomEmails = new string[] { "gu@ms.com" };
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = new string[] { "gu@ms.com", "ga@sm.net" };
            Cmdlet.ExecuteCmdlet();

            Cmdlet.CustomEmails = null;
            Cmdlet.Webhooks = new WebhookNotification[0];
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());

            var notification = new WebhookNotification
            {
                ServiceUri = "http://hello.com",
                Properties = null
            };

            Cmdlet.Webhooks = new WebhookNotification[] { notification };
            Cmdlet.ExecuteCmdlet();

            Cmdlet.SendEmailToSubscriptionAdministrator = true;
            Cmdlet.ExecuteCmdlet();

            Cmdlet.SendEmailToSubscriptionCoAdministrators = true;
            Cmdlet.ExecuteCmdlet();
        }
    }
}
