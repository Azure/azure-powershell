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
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.Alerts;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Alerts
{
    public class NewAzureRmAlerRuleWebhookTests
    {
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewAzureRmAlertRuleWebhookCommand Cmdlet { get; set; }

        public NewAzureRmAlerRuleWebhookTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            Cmdlet = new NewAzureRmAlertRuleWebhookCommand()
            {
                CommandRuntime = commandRuntimeMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAzureRmAlertRuleWebhookCommandParametersProcessing()
        {
            Assert.Throws<ArgumentException>(() => Cmdlet.ExecuteCmdlet());

            Cmdlet.ServiceUri = "http://hook.com/webhook";
            Cmdlet.ExecuteCmdlet();

            Cmdlet.Properties = new Hashtable();
            Cmdlet.ExecuteCmdlet();

            Cmdlet.Properties.Add("prop1", "value1");
            Cmdlet.ExecuteCmdlet();
        }
    }
}

